using System.Collections.Generic;
using System.IO;
using MWR_Config_Editor;

namespace CFGParser.Classes
{
    public class CFGFile
    {
        public FileInfo File { get; set; }
        public CFGData Data { get; set; }
        public CFGFile() { }
        public CFGFile(FileInfo file) {
            File = file;Data = new CFGData(file.ReadAllText());
        }
        public string ToFileString(bool asNames = false)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var comment in Data.Comments) {
                sb.AppendLine("//" + comment);
            }
            foreach (var line in Data.Lines) {
                var line_split = new List<string>();
                if (line.Command != null) line_split.Add(line.Command);
                if (line.DVAR != null) line_split.Add(asNames ? line.DVAR.Name : line.DVAR.Hash);
                // $"\t{line.DVAR}\t\"{line.Value}\"{(line.Comment is null ? "" : " // " + line.Comment)}"
                sb.AppendLine(string.Join("\t", line_split));
            }
            return sb.ToString();
        }
        public CFGFile Reload() => new CFGFile(File);

        public void Save(bool asNames = false) {
            var text = ToFileString(asNames);
            Logger.Trace(text);
            var bakTo = File.Directory.CombineFile(File.FileNameWithoutExtension() + ".bak" + File.Extension);
            Logger.Info("Saving current config to {0} (Backing up as {1}", File.FullName.Quote(), bakTo.Name);
            File.CopyTo(bakTo.FullName);
            File.WriteAllText(text);
        }
    }
}
