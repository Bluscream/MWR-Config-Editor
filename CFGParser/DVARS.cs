using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using MWR_Config_Editor;
using System.Linq;

namespace CFGParser.Classes
{
    public static class DVARS
    {
        public const string DefaultFileName = "dvars.json";
        public static List<DVAR> Load(FileInfo File = null)
        {
            if (File is null) File = new FileInfo(DefaultFileName);
            using (StreamReader file = File.OpenText())
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<DVAR>)serializer.Deserialize(file, typeof(List<DVAR>));
            }
        }
        public static string Serialize(List<DVAR> list, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(list, 
                            formatting, 
                            new JsonSerializerSettings { 
                                NullValueHandling = NullValueHandling.Ignore
            });
        }
        public static string MergeJson(List<DVAR> from, List<DVAR> to)
        {
            // var from_json = JObject.FromObject(from);
            var from_json = JArray.Parse(Serialize(from));
            // var to_json = JObject.FromObject(to);
            var to_json = JArray.Parse(Serialize(to));
            from_json.Merge(to_json, new JsonMergeSettings {
                MergeArrayHandling = MergeArrayHandling.Union,
                MergeNullValueHandling = MergeNullValueHandling.Ignore
            });
            return from_json.ToString();
        }
        public static string Merge(List<DVAR> existing, List<DVAR> _new)
        {
            var merged = existing.Union(_new).ToList();
            return Serialize(merged);
        }
        public static void Update(CFGData config, FileInfo existing_file = null)
        {
            if (existing_file is null) existing_file = new FileInfo(DefaultFileName);
            if (!existing_file.Exists) {
                existing_file.WriteAllText(Serialize(Parse(config))); return;
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
                if (item.Value is null) continue;
                if (item.Value.Contains(".") && float.TryParse(item.Value, out _)) item.DVAR.Type = "float";
                else if (int.TryParse(item.Value, out _)) item.DVAR.Type = "int";
                else if (bool.TryParse(item.Value, out _)) item.DVAR.Type = "bool";
                else item.DVAR.Type = "string";
                dvars.Add(item.DVAR);
            }
            return dvars;
        }
    }
}
