using System.Collections.Generic;

namespace Aequasi.ProfileLoader
{
    public class Profile
    {
        public List<Hotspot> Hotspots { get; set; } = new List<Hotspot>();
        public List<Hotspot> VendorHotspots { get; set; } = new List<Hotspot>();
        public List<Hotspot> GhostHotspots { get; set; } = new List<Hotspot>();
        public List<Hotspot> Blackspots { get; set; } = new List<Hotspot>();
        public List<Hotspot> Repair { get; set; } = new List<Hotspot>();
    }
}
