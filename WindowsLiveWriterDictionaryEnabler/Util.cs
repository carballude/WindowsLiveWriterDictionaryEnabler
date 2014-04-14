using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLiveWriterDictionaryEnabler
{
    class Util
    {
        /// <summary>
        /// Copy the source file to the destination overwriting the destination file if exists
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void CopyOrRemplaceFile(string source, string destination)
        {
            if (File.Exists(destination))
                File.Delete(destination);
            File.Copy(source, destination);
        }

        /// <summary>
        /// Get the path to the program by looking the registry
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="keyName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetProgramPath(string fileName, string keyName, string directory)
        {
            var path = string.Empty;
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\" + fileName, false) ?? Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\App Paths\" + fileName, false);
            if (key != null) path = Path.Combine(keyName == null ? Path.GetDirectoryName(key.GetValue(keyName).ToString()) : key.GetValue(keyName).ToString(), directory);
            return path;
        }
    }
}
