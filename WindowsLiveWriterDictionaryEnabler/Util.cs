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
        public static void CopyOrRemplaceFile(string origin, string destination)
        {
            if (File.Exists(destination))
                File.Delete(destination);
            File.Copy(origin, destination);
        }
    }
}
