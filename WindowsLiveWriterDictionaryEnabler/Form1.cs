using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsLiveWriterDictionaryEnabler
{
    public partial class Form1 : Form
    {

        class Dictionary
        {
            public CultureInfo CultureInfo { get; set; }
            public override string ToString()
            {
                return CultureInfo.DisplayName;
            }
        }

        public Form1()
        {
            InitializeComponent();
            btEnableLanguages.Enabled = DictionariesAvailable().Count > 0;
            lbAvailableLanguages.DataSource = DictionariesAvailable();
        }

        private void CopyLanguage(Dictionary language)
        {
            var fileName = "mssp7" + language.CultureInfo.TwoLetterISOLanguageName;
            var extensions = new string[] { ".dub", ".lex" };
            var liveWriterPath = GetLiveWriterPath();
            if (!string.IsNullOrWhiteSpace(liveWriterPath))
            {
                Util.CopyOrRemplaceFile(Directory.GetFiles(liveWriterPath, "*.dll").First(), Path.Combine(liveWriterPath, fileName + ".dll"));
                foreach (var extension in extensions)
                {
                    var origin = Path.Combine(GetOfficePath(), fileName + extension);
                    var destination = Path.Combine(liveWriterPath, fileName + extension);                    
                    if (File.Exists(origin))
                        Util.CopyOrRemplaceFile(origin, destination);
                }
            }
        }

        private List<Dictionary> DictionariesAvailable()
        {
            var officePath = GetOfficePath();
            if (!string.IsNullOrWhiteSpace(officePath))
            {
                var files = Directory.GetFiles(officePath, "mssp*.lex").Select(x => Path.GetFileNameWithoutExtension(x).Split(new char[] { '7' }).Last());
                var languages = new List<CultureInfo>();
                foreach (var file in files)
                {
                    try
                    {
                        languages.Add(new CultureInfo(file));
                    }
                    catch { }
                }
                return languages.Select(x => new Dictionary() { CultureInfo = x }).ToList();
            } 
            return null;
        }

        private string GetProgramPath(string fileName, string keyName, string directory)
        {
            var path = string.Empty;
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\" + fileName, false) ?? Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\"+fileName, false);
            if (key != null) path = Path.Combine(keyName == null ? Path.GetDirectoryName(key.GetValue(keyName).ToString()) : key.GetValue(keyName).ToString(), directory);
            return path;
        }

        private string GetOfficePath()
        {
            return GetProgramPath("Winword.exe", "Path", "PROOF");
        }

        private string GetLiveWriterPath()
        {
            return GetProgramPath("WindowsLiveWriter.exe", null, "Dictionaries");
        }

        private void btEnableLanguages_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var language in lbAvailableLanguages.SelectedItems)
                    CopyLanguage((Dictionary)language);
                MessageBox.Show("Languages have been enabled :)", "All done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException) { MessageBox.Show("Access denied! You might need to start this App as Admin.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
