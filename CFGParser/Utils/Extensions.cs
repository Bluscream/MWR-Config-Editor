using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Fnv1a;

namespace CFGParser {

    public static class Extensions {
        private const UInt32 FnvPrime = 0xB3CB2E29; private const UInt32 FnvOffsetBasis = 0x319712C3;
        public static string ToHashFnv1a32(this string text, Fnv1a32 hasher = null) {
            text = text.Trim().ToLowerInvariant() + "\0";
            var bytes_encoded = Encoding.ASCII.GetBytes(text);
            if (hasher is null) hasher = new Fnv1a32(fnvPrime: FnvPrime, fnvOffsetBasis: FnvOffsetBasis);
            var byte_hash = hasher.ComputeHash(bytes_encoded);
            var uint32 = BitConverter.ToUInt32(byte_hash, 0);
            var uint32_hex = string.Format("0x{0:X}", uint32);
            // var str = "0x" + BitConverter.ToString(byte_hash).Replace("-", "");
            return uint32_hex;
        }
        public static bool IsHash(this string source) {
            return source.StartsWith("0x");
        }
    }
}
