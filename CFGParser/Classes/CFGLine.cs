using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CFGParser.Classes
{
    static partial class Utils {
        internal static Regex CFGLinePattern = new Regex(@"^(\w+)\s+(\w+)\s+\""(.*)\""$", RegexOptions.Compiled);
    }
    public class CFGLine
    {
        public string Command { get; set; }
        public DVAR DVAR { get; set; } = new DVAR();
        public string Value { get; set; }
        public CFGLine(string command, string dvar, string value) {
            Command = command; DVAR.Hex = dvar; Value = value;
        }
        public CFGLine(string line, List<DVAR> dvarInfo) {
            var regex = Utils.CFGLinePattern.Match(line);
            if (regex.Success)
            {
                Command = regex.Groups[1].Value;
                Value = regex.Groups[3].Value;
                if (regex.Groups[2].Value.StartsWith("0x")) {
                    DVAR = dvarInfo.Where(dvar => dvar.Hex == regex.Groups[2].Value).FirstOrDefault();
                } else {
                    DVAR.Name = regex.Groups[2].Value;
                }
            } else {
                Value = line;
            }
        }
    }
}
