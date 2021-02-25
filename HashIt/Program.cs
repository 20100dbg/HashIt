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
        static int Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HashIt());
                return 0;
            }
            else
            {
                RootCommand cmd = new RootCommand
                {
                    //new Argument<string>("file", "file to hash"),

                    new Argument<string>("text", "Text to hash"),
                    new Argument<string>("salt", "Salt to use"),
                    new Argument<int>("salt-method", "Salt method to use"),
                    new Argument<int>("iterations", "Number of iterations"),

                    new Argument<string>("algo", "algo to use"),
                    new Option<bool>("output-lowercase", "Output hashes in lowercase"),

                };


                cmd.Handler = CommandHandler.Create<string, string, string, int, int, string, bool, IConsole>(HandleCLI);

                return cmd.Invoke(args);
            }

        }

        static void HandleCLI(string file, string text, string salt, int salt_method, int iterations, string algo, bool output_lowercase, IConsole console)
        {
            if (!Settings.ReadConfigFile())
            {
                Console.WriteLine("failed to read config file");
            }

            String[] tabAlgos = algo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<String, String> dicAlgos;
            List<String> algos = new List<String>();


            for (int i = 0, n = Config.listAlgos.Count; i < n; i++)
            {
                for (int j = 0, m = tabAlgos.Length; j < m; j++)
                {
                    if (tabAlgos[j] == "all") algos.Add(Config.listAlgos[i].Name);
                    else if (tabAlgos[j].EndsWith("*") && Config.listAlgos[i].Name.StartsWith(algos[j].Substring(0, tabAlgos[j].Length - 2))) algos.Add(Config.listAlgos[i].Name);
                    else if (tabAlgos[j] == Config.listAlgos[i].Name) algos.Add(Config.listAlgos[i].Name);
                }
            }

            if (File.Exists(file))
                dicAlgos = Work.HashFile(file, algos);
            else
            {
                Param p = new Param
                {
                    Iterations = iterations,
                    OriginalPassword = text,
                    Salt = salt,
                };

                p.ApplySaltUse(salt_method);

                dicAlgos = Work.HashText(p, algos);
            }

            Console.WriteLine("Result : ");
            foreach (KeyValuePair<String, String> pair in dicAlgos)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }
}