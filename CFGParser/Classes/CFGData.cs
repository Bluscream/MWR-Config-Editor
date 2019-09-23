using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using MWR_Config_Editor;

namespace CFGParser.Classes
{
    static partial class Utils {
        internal static Regex CommentPattern = new Regex(@"^\/\/(.*)$", RegexOptions.Compiled);
    }
    public class CFGData
    {
        // public List<string> Comments { get; set; } = new List<string>();
        public BindingList<CFGLine> Lines { get; set; } = new BindingList<CFGLine>();
        public string Raw { get; set; }
        public CFGData() { }
        public CFGData(string input) {
            Raw = input;
            List<DVAR> dvarInfo = null;
            if (File.Exists(DVARS.DefaultFileName)) dvarInfo = DVARS.Load();
            foreach (var line in input.SplitToLines()) {
                /*var lineMatch = Utils.CommentPattern.Match(line);
                if (lineMatch.Success) {
                    Comments.Add(line);
                } else {*/
                    Lines.Add(new CFGLine(line, dvarInfo: dvarInfo));
                // }
            }
        }
    }
}
