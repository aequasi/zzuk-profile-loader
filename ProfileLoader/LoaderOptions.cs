using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aequasi.ProfileLoader
{
    public class LoaderOptions
    {
        /// <summary>
        /// FileName is the full filename (with path) of the profile to load
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// ProfileName is the name of the profile. Will be put into converted JSON profiles
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// ProfileExtension is the extension of the Profile. Either XML or JSON
        /// </summary>
        public ProfileExtension ProfileExtension { get; set; } = ProfileExtension.Json;

        /// <summary>
        /// ProfileType is the type of profile. Will be put into converted JSON profiles
        /// </summary>
        public ProfileType ProfileType { get; set; } = ProfileType.Grinding;
    }
}
