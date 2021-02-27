using System;
using System.Windows.Forms;
using System.CommandLine;
using System.IO;
using System.CommandLine.Invocation;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HashIt
{
    static class Program
    {
        // defines for commandline output
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [STAThread]
        static void Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HashIt());
            }
            else
            {
                HandleCLI(args);
            }
        }

        static async void HandleCLI(string[] args)
        {
            /*
            Command cFile = new Command("file", "file mode");
            cFile.AddArgument(new Argument<FileInfo>("filepath", "Specify file to hash"));
            
            Command cText = new Command("text", "text mode");
            cText.AddArgument(new Argument<String>("text", "Specify text to hash"));
            cText.AddOption(new Option<string>("--test","option text"));
            */
            RootCommand cmd = new RootCommand
            {
                
                //cText,
                //cFile,
                new Option<FileInfo>(new string[] { "--file", "-f" }, getDefaultValue: () => null, "File to hash"),
                new Option<string>(new string[] { "--text", "-t" }, getDefaultValue: () => "", "Text to hash"),

                new Option<string>(new string[] { "--salt", "-s" }, getDefaultValue: () => "", "Salt to use"),
                new Option<int>(new string[] { "--salt-method", "-m" }, getDefaultValue: () => 0, "Salt method to use"),
                new Option<int>(new string[] { "--iterations", "-i" }, getDefaultValue: () => 1, "Number of iterations"),

                new Option<string>(new string[] { "--algo", "-a" },  getDefaultValue: () => "all", "algo to use"),
                //new Option<int>(new string[] {"--lower", "-l" },  getDefaultValue: () => 0, "lowercase") //weird hack

            };

            cmd.Description = "HashIt - an handy hash software";
            cmd.Handler = CommandHandler.Create<FileInfo, string, string, int, int, string, int, IConsole>(HandleArgs);

            //Action handler = () => { };
            //cmd.Handler = CommandHandler.Create(handler);
            await cmd.InvokeAsync(args);

            System.Windows.Forms.SendKeys.SendWait("{ENTER}"); //hack to pass hand back to console
        }


        static void HandleArgs(FileInfo file, string text, string salt, int salt_method, int iterations, string algo, int output_lowercase, IConsole console)
        {
            if (!Settings.ReadConfigFile())
            {
                Console.WriteLine("failed to read config file");
            }

            Settings.OutputUppercase = true;

            Dictionary<String, String> dicResultHashes;
            List<Algo> listAlgos = Work.GetListAlgoToWork(algo);

            if (file != null && File.Exists(file.FullName))
                dicResultHashes = Work.HashFile(file.FullName, listAlgos);
            else
            {
                Param p = new Param { Iterations = iterations, OriginalPassword = text, Salt = salt, };
                p.ApplySaltUse(salt_method);
                dicResultHashes = Work.HashText(p, listAlgos);
            }

            Console.WriteLine("Result : ");
            foreach (KeyValuePair<String, String> pair in dicResultHashes)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }
}