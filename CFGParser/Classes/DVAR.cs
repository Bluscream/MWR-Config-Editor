using Newtonsoft.Json;

namespace CFGParser.Classes
{
    public class DVAR {
        public string Hex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string DefaultValue { get; set; }
        // [JsonIgnore]
        // public string Value { get; set; }
        public override string ToString()
        {
            return Name ?? Hex;
            /*if (Name != null) return Name;
            else if (Hex != null) return Hex;
            return base.ToString();*/
        }
    }
}
