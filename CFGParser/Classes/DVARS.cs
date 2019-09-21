using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using MWR_Config_Editor;

namespace CFGParser.Classes
{
    public static class DVARS
    {
        public const string DefaultFileName = "dvars.json";

        public static List<DVAR> Get() {
            return new List<DVAR>() {
                new DVAR { Hex = "0x2A70777D", Type = "int" },
                new DVAR { Hex = "0xFC60C821", Type = "int" },
            };
        }
        public static List<DVAR> Load(FileInfo File = null)
        {
            if (File is null) File = new FileInfo(DefaultFileName);
            using (StreamReader file = File.OpenText())
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<DVAR>)serializer.Deserialize(file, typeof(List<DVAR>));
            }
        }
        public static string Merge(List<DVAR> from, List<DVAR> to)
        {
            // var from_json = JObject.FromObject(from);
            var from_json = JArray.Parse(JsonConvert.SerializeObject(from));
            // var to_json = JObject.FromObject(to);
            var to_json = JArray.Parse(JsonConvert.SerializeObject(to));
            from_json.Merge(to_json, new JsonMergeSettings {
                MergeArrayHandling = MergeArrayHandling.Union,
                MergeNullValueHandling = MergeNullValueHandling.Merge
            });
            return from_json.ToString();
        }
        public static void Update(CFGData config, FileInfo existing_file = null)
        {
            if (existing_file is null) existing_file = new FileInfo(DefaultFileName);
            if (!existing_file.Exists) {
                existing_file.WriteAllText(JsonConvert.SerializeObject(Parse(config)));
            }
            var existing = Load(existing_file);
            var _new  = Parse(config);
            var merged = Merge(existing, _new);
            existing_file.WriteAllText(merged);
        }
        public static List<DVAR> Parse(CFGData config)
        {
            var dvars = new List<DVAR>();
            foreach (var item in config.Lines)
            {
                var dvar = new DVAR();
                dvar.Hex = item.DVAR.Hex;
                if (item.Value.Contains(".") && float.TryParse(item.Value, out _)) dvar.Type = "float";
                else if (int.TryParse(item.Value, out _)) dvar.Type = "int";
                else if (bool.TryParse(item.Value, out _)) dvar.Type = "bool";
                else dvar.Type = "string";
                dvars.Add(dvar);
            }
            return dvars;
        }
    }
}
