using CommandLine;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MWR_Config_Editor
{
    static class Program
    {
        public static Options Arguments = new Options();
        public class Options {
            [Option('c', "console", Required = false, HelpText = "Enable console")]
            public bool ConsoleEnabled { get; set; }
            [Option('f', "file", Required = false, HelpText = "Auto open specific config file by path")]
            public string ConfigFilePath { get; set; }
            [Option("save-as-names", Required = false, HelpText = "Wether to save the config with name values instead of hashes by default")]
            public bool SaveAsNames { get; set; } = false;
            [Option("indent", Required = false, HelpText = "Wether to indent the config for better readability")]
            public bool Indent { get; set; } = false;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var assembly = System.Reflection.Assembly.GetEntryAssembly().GetName();
            Logger.Debug("{0} v{1} ({2}) with args: {3}", assembly.Name, assembly.Version, assembly.ProcessorArchitecture, string.Join(" ", args));
            Logger.Debug("Current Date and Time: {0} (UTC: {1})", DateTime.Now, DateTime.UtcNow);
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => Arguments = o).WithNotParsed(o => Logger.Error("Unable to parse arguments: {0}", o.First().Tag));
            if (Arguments.ConsoleEnabled) ExternalConsole.InitConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            Logger.Debug("Ended");
        }
    }
}
