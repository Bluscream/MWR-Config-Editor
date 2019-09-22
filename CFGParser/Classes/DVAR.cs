using Newtonsoft.Json;
using System;

namespace CFGParser.Classes
{
    public class DVAR {
        private string _hash { get; set; }
        public string Hash { get {
                if (_hash is null && _name != null) {
                    if ( !_name.StartsWith("0x")) _hash = _name.ToHashFnv1a32();
                    else _hash = _name;
                }
                return _hash;
            } set { _hash = value; }
        }
        private string _name { get; set; }
        public string Name { get { return _name; }
            set {
                var isHex = (value != null && value.StartsWith("0x"));
                if (!isHex) _name = value;
                if (_name != null && string.IsNullOrWhiteSpace(Hash)) {
                    if (!isHex) Hash = _name.ToHashFnv1a32();
                    else Hash = _name;
                }
            }
        }
        public string Description { get; set; }
        public string Type { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string DefaultValue { get; set; }
        [JsonIgnore]
        public string Value { get; set; }
        public override string ToString()
        {
            return Name ?? Hash;
        }
        public DVAR(string hash = null, string name = null, string description = null, string type = null, string minValue = null, string maxValue = null, string defaultValue = null)
        {
            Hash = hash; Name = name; Description = description; Type = type; MinValue = minValue; MaxValue = maxValue; DefaultValue = defaultValue;
        }

        public static bool operator ==(DVAR obj1, DVAR obj2) {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }
            return obj1.Hash.Equals(obj2.Hash);
        }

    // this is second one '!='
    public static bool operator !=(DVAR obj1, DVAR obj2)
    {
        return !(obj1 == obj2);
    }

    public bool Equals(DVAR other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return Hash.Equals(other.Hash);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((DVAR)obj);
    }

    public override int GetHashCode()
    {
        unchecked {
                return Convert.ToInt32(Hash , 16);
        }
    }
    }
}
