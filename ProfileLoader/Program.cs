using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLoader
{
    internal class Program
    {
        static void Main()
        {
            ProfileData data = Loader.LoadProfile("\\\\Mac\\Home\\Downloads\\Elwynn_1-5.xml", "Elwynn_1-5.xml", ProfileExtension.XML, ProfileType.Grinding);
        }
    }
}
