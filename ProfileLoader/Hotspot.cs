using System;
using System.Runtime.Serialization;
using ZzukBot.Objects;

namespace ProfileLoader
{
    public class Hotspot
    {
        private static Lazy<Hotspot> _instance = new Lazy<Hotspot>(() => new Hotspot());
        public static Hotspot Instance => _instance.Value;
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
