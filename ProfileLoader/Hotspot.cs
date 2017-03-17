using System.Runtime.Serialization;
using ZzukBot.Objects;

namespace Aequasi.ProfileLoader
{
    public class Hotspot
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public string Type { get; set; }
        public Location Location { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Location = new Location(X, Y, Z);
        }
    }
}
