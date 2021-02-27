using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HashIt
{
    public static class Work
    {
        public static Dictionary<String, String> HashFile(String file, List<Algo> listAlgos)
        {
            HashClass h = new HashClass();
            Param p = new Param();
            Dictionary<String, String> dicAlgos = new Dictionary<String, String>();

            using (FileStream stream = File.OpenRead(file))
            {
                foreach (Algo a in listAlgos)
                {
                    if (!HasMethod(h, "Get" + a.Name)) continue;
                    p.Fs = stream;

                    object ob = h.GetType().InvokeMember("Get" + a.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });
                    String hash = ob.ToString();
                    hash = ((Settings.OutputUppercase) ? hash.ToUpper() : hash.ToLower());
                    hash = hash.Replace("-", "");
                    dicAlgos[a.Name] = hash;

                    stream.Position = 0;
                }
            }

            return dicAlgos;
        }



        public static Dictionary<String, String> HashText(Param p, List<Algo> listAlgos)
        {
            HashClass h = new HashClass();
            Dictionary<String, String> dicAlgos = new Dictionary<String, String>();

            foreach (Algo a in listAlgos)
            {
                if (!HasMethod(h, "Get" + a.Name)) continue;
                p.ValueToHash = p.OriginalValueToHash;
                

                for (int j = 0; j < p.Iterations; j++)
                {
                    object ob = h.GetType().InvokeMember("Get" + a.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });

                    String hash = ob.ToString();
                    hash = hash.Replace("-", "");
                    hash = Settings.OutputUppercase ? hash.ToUpper() : hash.ToLower();

                    p.ResultHash = hash;
                    p.ValueToHash = hash;
                }

                dicAlgos[a.Name] = p.ResultHash;
            }

            return dicAlgos;
        }


        public static List<Algo> GetListAlgoToWork(String str)
        {
            if (str == "all") return Config.listAlgos;

            List<Algo> listAlgos = new List<Algo>();
            String[] tabAlgosNames = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0, n = Config.listAlgos.Count; i < n; i++)
            {
                for (int j = 0, m = tabAlgosNames.Length; j < m; j++)
                {
                    if (tabAlgosNames[j].ToLower() == Config.listAlgos[i].Name.ToLower())
                        listAlgos.Add(Config.listAlgos[i]);
                }
            }

            return listAlgos;
        }

        public static Algo GetAlgoFromName(String name)
        {
            Algo a = null;
            bool found = false;
            
            for (int i = 0, n = Config.listAlgos.Count; i < n && !found; i++)
            {
                if (Config.listAlgos[i].Name.ToLower() == name.ToLower())
                {
                    a = Config.listAlgos[i];
                    found = true;
                }
            }

            return a;
        }


        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }
    }
}
