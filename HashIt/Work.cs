using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashIt
{
    public static class Work
    {
        public static Dictionary<String, String> HashFile(String file, List<String> algos)
        {
            HashClass h = new HashClass();
            Param p = new Param();
            Dictionary<String, String> dicAlgos = new Dictionary<String, String>();

            using (FileStream stream = File.OpenRead(file))
            {
                foreach (String algo in algos)
                {
                    p.Fs = stream;

                    object ob = h.GetType().InvokeMember("Get" + algo, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });
                    String hash = ob.ToString();
                    hash = ((Settings.OutputUppercase) ? hash.ToUpper() : hash.ToLower());
                    hash = hash.Replace("-", "");
                    dicAlgos[algo] = hash;

                    stream.Position = 0;
                }
            }

            return dicAlgos;
        }



        public static Dictionary<String, String> HashText(Param p, List<String> algos)
        {
            HashClass h = new HashClass();
            Dictionary<String, String> dicAlgos = new Dictionary<String, String>();

            foreach (String algo in algos)
            {
                p.ValueToHash = p.OriginalValueToHash;

                for (int j = 0; j < p.Iterations; j++)
                {
                    object ob = h.GetType().InvokeMember("Get" + algo, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, h, new object[] { p });

                    String hash = ob.ToString();
                    hash = hash.Replace("-", "");
                    hash = ((Settings.OutputUppercase) ? hash.ToUpper() : hash.ToLower());

                    p.ResultHash = hash;
                    p.ValueToHash = hash;
                }

                dicAlgos[algo] = p.ResultHash;
            }

            return dicAlgos;
        }
    }
}
