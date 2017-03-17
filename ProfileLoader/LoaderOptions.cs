using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aequasi.ProfileLoader
{
    public class LoaderOptions
    {
        public string FileName { get; set; }
        public string ProfileName { get; set; }
        public ProfileExtension ProfileExtension { get; set; } = ProfileExtension.JSON;
        public ProfileType ProfileType { get; set; } = ProfileType.Grinding;
    }
}
