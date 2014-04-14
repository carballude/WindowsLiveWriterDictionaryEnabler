using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsLiveWriterDictionaryEnabler
{
    public partial class MainWindow : Form
    {

        class Dictionary
        {
            public CultureInfo CultureInfo { get; set; }
            public override string ToString()
            {
                return CultureInfo.DisplayName;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            btEnableLanguages.Enabled = DictionariesAvailable().Count() > 0;
            lbAvailableLanguages.DataSource = DictionariesAvailable().ToList();
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

        /// <summary>
        /// Returns a list of the languages of the dictionaries that are currently installed in the local machine
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Dictionary> DictionariesAvailable()
        {
            var officePath = GetOfficePath();
            if (string.IsNullOrWhiteSpace(officePath)) return null;
            var files = from x in Directory.GetFiles(officePath, "mssp*.lex")
                    select Path.GetFileNameWithoutExtension(x).Split(new char[] { '7' }).Last();
            return from x in CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                   where files.Any(y => y.ToLowerInvariant() == x.TwoLetterISOLanguageName.ToLowerInvariant())
                   select new Dictionary() { CultureInfo = x };
        }

        private Func<string> GetOfficePath = () => Util.GetProgramPath("Winword.exe", "Path", "PROOF");

        private Func<string> GetLiveWriterPath = () => Util.GetProgramPath("WindowsLiveWriter.exe", null, "Dictionaries");

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
