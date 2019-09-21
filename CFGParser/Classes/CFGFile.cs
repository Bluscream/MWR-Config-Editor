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
        public CFGFile Reload() => new CFGFile(File);
        public void Save() {
            using (StreamWriter file = new StreamWriter(File.FullName)) {
                foreach (var comment in Data.Comments) {
                    file.WriteLine("//" + comment);
                }
                foreach (var line in Data.Lines) {
                    file.WriteLine($"{line.Command}\t{line.DVAR}\t\"{line.Value}\"");
                }
            }
        }
    }
}
