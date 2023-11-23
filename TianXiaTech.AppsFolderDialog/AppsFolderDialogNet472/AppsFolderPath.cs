using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsFolderDialog
{
    public class AppsFolderPath
    {
        public string Path { get; set; }

        public PathType PathType { get; set; }
    }

    public enum PathType
    {
        Folder,
        Absolute,
        AUMID
    }
}
