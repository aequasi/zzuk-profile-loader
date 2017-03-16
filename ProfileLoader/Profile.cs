using System.Collections.Generic;

namespace ProfileLoader
{
    public class Profile
    {
        public List<Hotspot> Hotspots { get; set; }
        public List<Hotspot> VendorHotspots { get; set; }
        public List<Hotspot> GhostHotspots { get; set; }
        public List<Hotspot> Blackspots { get; set; }
        public List<Hotspot> Repair { get; set; }
    }
}
