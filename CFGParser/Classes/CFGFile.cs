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
        public CFGFile(FileInfo file)  {
            File = file; Reload();
        }
        public string ToFileString(bool asNames = false, bool indent = false)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var line in Data.Lines) {
                // Logger.Trace(line.ToJson());
                if (line.isComment) sb.AppendLine(line.Comment);
                else {
                    var line_split = new List<string>();
                    if (line.Command != null) line_split.Add(line.Command);
                    if (line.DVAR != null) {
                        line_split.Add(asNames && line.DVAR.Name != null ? line.DVAR.Name : line.DVAR.Hash);
                    }
                    if (line.Value != null) line_split.Add(line.Value.Quote());
                    if (line.Comment != null) line_split.Add("// " + line.Comment);
                    else {
                        line_split.Add("// " + (asNames && line.DVAR.Hash != null ? line.DVAR.Hash : line.DVAR.Name));
                    }
                    // $"\t{line.DVAR}\t\"{line.Value}\"{(line.Comment is null ? "" : " // " + line.Comment)}"
                    sb.AppendLine(string.Join(indent ? "\t\t\t\t\t\t\t" : " ", line_split));
                }
            }
            return sb.ToString().Trim();
        }
        public void Reload() => Data = new CFGData(File.ReadAllText().Trim());

        public void Save(bool asNames = false, bool indent = false) {
            var text = ToFileString(asNames, indent);
            Logger.Trace(text);
            Logger.Debug("Saving current config to {0}", File.FullName.Quote());
            Backup();
            File.WriteAllText(text);
            Logger.Info("Saved current config to {0}", File.FullName.Quote());
        }
        public void Backup() {
            var FileNameWithoutExtension = File.FileNameWithoutExtension();
            var toFile = File.Directory.CombineFile(FileNameWithoutExtension + ".org" + File.Extension);
            if (toFile.Exists) toFile = File.Directory.CombineFile(FileNameWithoutExtension + ".bak" + File.Extension);
            Logger.Debug("Backing up config {0} to {1}", File.Name.Quote(), toFile.Name.Quote());
            File.CopyTo(toFile.FullName, true);
            Logger.Info("Backed up config {0} to {1}", File.Name.Quote(), toFile.Name.Quote());
        }
    }
}
