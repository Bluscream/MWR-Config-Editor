using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace CFGParser.Classes
{
    static partial class Utils {
        internal static Regex CFGLinePattern = new Regex(@"^(\w+)\s+(\w+)\s+\""(.*)\""(?:\s*\/\/\s*(.*))?$", RegexOptions.Compiled);
    }
    public class CFGLine
    {
        public string Command { get; set; }
        public object dvar {
            get { return DVAR; } set {
                var val = (string)value;
                if (val.IsHash()) DVAR.Hash = val;
                else DVAR.Name = val;
            } }
        [Browsable(false)]
        public DVAR DVAR { get; set; } = new DVAR();
        public string Value { get; set; }
        public string Comment { get; set; }
        [Browsable(false)]
        public bool isComment { get { return Command is null && Value is null && Comment != null; } }
        public CFGLine(string command, string dvar, string value) {
            Command = command; DVAR.Hash = dvar; Value = value;
        }
        public CFGLine() { }
        public CFGLine(string line, List<DVAR> dvarInfo) {
            var regex = Utils.CFGLinePattern.Match(line);
            if (regex.Success)
            {
                Command = regex.Groups[1].Value;
                if (regex.Groups.Count > 4 && !string.IsNullOrWhiteSpace(regex.Groups[4].Value)) {
                    Comment = regex.Groups[4].Value;
                }
                switch (Command.ToLower())
                {
                    case "seta":
                    case "set":
                        Value = regex.Groups[3].Value;
                        if (regex.Groups[2].Value.StartsWith("0x") && dvarInfo != null) {
                            var dVAR = dvarInfo.Where(dvar => dvar.Hash == regex.Groups[2].Value).FirstOrDefault();
                            if (dVAR != null) DVAR = dVAR;
                            else DVAR.Hash = regex.Groups[2].Value;
                        } else {
                            DVAR.Name = regex.Groups[2].Value;
                        }
                        break;
                    default:
                        Value = line;
                        break;
                }
            } else {
                Comment = line;
            }
        }
    }
}
