using System;
using System.Text;

namespace HashIt
{
    static class Util
    {
        public static byte[] HexToBytes(string input)
        {
            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
            return result;
        }

        public static string BytesToHex(byte[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
                result += Convert.ToString(input[i], 16);
            return result;
        }

        public static String GetBase64(String str)
        {
            return GetBase64(Encoding.UTF8.GetBytes(str));
        }

        public static String GetBase64(Byte[] b)
        {
            return Convert.ToBase64String(b);
        }
    }



}
