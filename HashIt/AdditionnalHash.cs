using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HashIt
{
    class Checksum
    {
        public static int BSDchecksum(FileStream fp) /* The file handle for input data */
        {
            int checksum = 0;             /* The checksum mod 2^16. */

            for (int i = 0; i < fp.Length; i++)
            {
                int ch = fp.ReadByte();

                checksum = (checksum >> 1) + ((checksum & 1) << 15);
                checksum += ch;
                checksum &= 0xffff;       /* Keep it within bounds. */
            }

            return checksum;
        }
    }

    public static class CRC8
    {
        static byte[] table = new byte[256];
        // x8 + x7 + x6 + x4 + x2 + 1
        const byte poly = 0xd5;

        public static byte ComputeChecksum(params byte[] bytes)
        {
            byte crc = 0;
            if (bytes != null && bytes.Length > 0)
            {
                foreach (byte b in bytes)
                {
                    crc = table[crc ^ b];
                }
            }
            return crc;
        }

        static CRC8()
        {
            for (int i = 0; i < 256; ++i)
            {
                int temp = i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((temp & 0x80) != 0) temp = (temp << 1) ^ poly;
                    else temp <<= 1;
                }
                table[i] = (byte)temp;
            }
        }
    }


    public static class CRC16
    {
        const ushort polynomial = 0xA001;
        static readonly ushort[] table = new ushort[256];

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        static CRC16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0) value = (ushort)((value >> 1) ^ polynomial);
                    else value >>= 1;
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }


    public enum Crc16Mode : ushort { Standard = 0xA001, CcittKermit = 0x8408 }


    public class CRC16_2
    {
        readonly ushort[] table = new ushort[256];

        public ushort ComputeChecksum(params byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(params byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public CRC16_2(Crc16Mode mode)
        {
            ushort polynomial = (ushort)mode;
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0) value = (ushort)((value >> 1) ^ polynomial);
                    else value >>= 1;
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }


    public class CRC24
    {
        const int CRC24_INIT = 0xb704ce;
        const int CRC24_POLY = 0x1864cfb;
        const int CRC24_OUTMASK = 0xffffff;

        public static int hash(String input)
        {
            int crc = CRC24_INIT;

            for (int i = 0; i < input.Length; i++)
            {
                crc ^= ((int)(input[i]) & 255) << 16;

                for (int j = 0; j < 8; j++)
                {
                    crc <<= 1;

                    if ((crc & 0x1000000) > 0)
                    {
                        crc ^= CRC24_POLY;
                    }
                }
            }

            return crc & CRC24_OUTMASK;
        }
    }


    class FCS16
    {
        static ushort[] fcstab = new ushort[256]
        {
            0x0000, 0x1189, 0x2312, 0x329b, 0x4624, 0x57ad, 0x6536, 0x74bf,
            0x8c48, 0x9dc1, 0xaf5a, 0xbed3, 0xca6c, 0xdbe5, 0xe97e, 0xf8f7,
            0x1081, 0x0108, 0x3393, 0x221a, 0x56a5, 0x472c, 0x75b7, 0x643e,
            0x9cc9, 0x8d40, 0xbfdb, 0xae52, 0xdaed, 0xcb64, 0xf9ff, 0xe876,
            0x2102, 0x308b, 0x0210, 0x1399, 0x6726, 0x76af, 0x4434, 0x55bd,
            0xad4a, 0xbcc3, 0x8e58, 0x9fd1, 0xeb6e, 0xfae7, 0xc87c, 0xd9f5,
            0x3183, 0x200a, 0x1291, 0x0318, 0x77a7, 0x662e, 0x54b5, 0x453c,
            0xbdcb, 0xac42, 0x9ed9, 0x8f50, 0xfbef, 0xea66, 0xd8fd, 0xc974,
            0x4204, 0x538d, 0x6116, 0x709f, 0x0420, 0x15a9, 0x2732, 0x36bb,
            0xce4c, 0xdfc5, 0xed5e, 0xfcd7, 0x8868, 0x99e1, 0xab7a, 0xbaf3,
            0x5285, 0x430c, 0x7197, 0x601e, 0x14a1, 0x0528, 0x37b3, 0x263a,
            0xdecd, 0xcf44, 0xfddf, 0xec56, 0x98e9, 0x8960, 0xbbfb, 0xaa72,
            0x6306, 0x728f, 0x4014, 0x519d, 0x2522, 0x34ab, 0x0630, 0x17b9,
            0xef4e, 0xfec7, 0xcc5c, 0xddd5, 0xa96a, 0xb8e3, 0x8a78, 0x9bf1,
            0x7387, 0x620e, 0x5095, 0x411c, 0x35a3, 0x242a, 0x16b1, 0x0738,
            0xffcf, 0xee46, 0xdcdd, 0xcd54, 0xb9eb, 0xa862, 0x9af9, 0x8b70,
            0x8408, 0x9581, 0xa71a, 0xb693, 0xc22c, 0xd3a5, 0xe13e, 0xf0b7,
            0x0840, 0x19c9, 0x2b52, 0x3adb, 0x4e64, 0x5fed, 0x6d76, 0x7cff,
            0x9489, 0x8500, 0xb79b, 0xa612, 0xd2ad, 0xc324, 0xf1bf, 0xe036,
            0x18c1, 0x0948, 0x3bd3, 0x2a5a, 0x5ee5, 0x4f6c, 0x7df7, 0x6c7e,
            0xa50a, 0xb483, 0x8618, 0x9791, 0xe32e, 0xf2a7, 0xc03c, 0xd1b5,
            0x2942, 0x38cb, 0x0a50, 0x1bd9, 0x6f66, 0x7eef, 0x4c74, 0x5dfd,
            0xb58b, 0xa402, 0x9699, 0x8710, 0xf3af, 0xe226, 0xd0bd, 0xc134,
            0x39c3, 0x284a, 0x1ad1, 0x0b58, 0x7fe7, 0x6e6e, 0x5cf5, 0x4d7c,
            0xc60c, 0xd785, 0xe51e, 0xf497, 0x8028, 0x91a1, 0xa33a, 0xb2b3,
            0x4a44, 0x5bcd, 0x6956, 0x78df, 0x0c60, 0x1de9, 0x2f72, 0x3efb,
            0xd68d, 0xc704, 0xf59f, 0xe416, 0x90a9, 0x8120, 0xb3bb, 0xa232,
            0x5ac5, 0x4b4c, 0x79d7, 0x685e, 0x1ce1, 0x0d68, 0x3ff3, 0x2e7a,
            0xe70e, 0xf687, 0xc41c, 0xd595, 0xa12a, 0xb0a3, 0x8238, 0x93b1,
            0x6b46, 0x7acf, 0x4854, 0x59dd, 0x2d62, 0x3ceb, 0x0e70, 0x1ff9,
            0xf78f, 0xe606, 0xd49d, 0xc514, 0xb1ab, 0xa022, 0x92b9, 0x8330,
            0x7bc7, 0x6a4e, 0x58d5, 0x495c, 0x3de3, 0x2c6a, 0x1ef1, 0x0f78
        };

        const ushort PPPINITFCS16 = 0xffff; /* Initial FCS value */
        const ushort PPPGOODFCS16 = 0xf0b8; /* Good final FCS value */
        /*
        * Calculate a new fcs given the current fcs and the new data.
        */
        public static byte[] GetFCS16(String encodedDLMSFrame, int len)
        {
            ushort tempFCS16 = CountFCS16(encodedDLMSFrame.ToCharArray(), 0, len);
            return new byte[] { (byte)(tempFCS16 >> 8), (byte)(tempFCS16 & 0xFF) };
        }

        static readonly ushort[] m_FCS16Table = {
            0x0000, 0x1189, 0x2312, 0x329B, 0x4624, 0x57AD, 0x6536, 0x74BF,
            0x8C48, 0x9DC1, 0xAF5A, 0xBED3, 0xCA6C, 0xDBE5, 0xE97E, 0xF8F7,
            0x1081, 0x0108, 0x3393, 0x221A, 0x56A5, 0x472C, 0x75B7, 0x643E,
            0x9CC9, 0x8D40, 0xBFDB, 0xAE52, 0xDAED, 0xCB64, 0xF9FF, 0xE876,
            0x2102, 0x308B, 0x0210, 0x1399, 0x6726, 0x76AF, 0x4434, 0x55BD,
            0xAD4A, 0xBCC3, 0x8E58, 0x9FD1, 0xEB6E, 0xFAE7, 0xC87C, 0xD9F5,
            0x3183, 0x200A, 0x1291, 0x0318, 0x77A7, 0x662E, 0x54B5, 0x453C,
            0xBDCB, 0xAC42, 0x9ED9, 0x8F50, 0xFBEF, 0xEA66, 0xD8FD, 0xC974,
            0x4204, 0x538D, 0x6116, 0x709F, 0x0420, 0x15A9, 0x2732, 0x36BB,
            0xCE4C, 0xDFC5, 0xED5E, 0xFCD7, 68, 0x99E1, 0xAB7A, 0xBAF3,
            0x5285, 0x430C, 0x7197, 0x601E, 0x14A1, 0x0528, 0x37B3, 0x263A,
            0xDECD, 0xCF44, 0xFDDF, 0xEC56, 0x98E9, 0x8960, 0xBBFB, 0xAA72,
            0x6306, 0x728F, 0x4014, 0x519D, 0x2522, 0x34AB, 0x0630, 0x17B9,
            0xEF4E, 0xFEC7, 0xCC5C, 0xDDD5, 0xA96A, 0xB8E3, 0x8A78, 0x9BF1,
            0x7387, 0x620E, 0x5095, 0x411C, 0x35A3, 0x242A, 0x16B1, 0x0738,
            0xFFCF, 0xEE46, 0xDCDD, 0xCD54, 0xB9EB, 0xA862, 0x9AF9, 0x8B70,
            0x8408, 0x9581, 0xA71A, 0xB693, 0xC22C, 0xD3A5, 0xE13E, 0xF0B7,
            0x0840, 0x19C9, 0x2B52, 0x3ADB, 0x4E64, 0x5FED, 0x6D76, 0x7CFF,
            0x9489, 0x8500, 0xB79B, 0xA612, 0xD2AD, 0xC324, 0xF1BF, 0xE036,
            0x18C1, 0x0948, 0x3BD3, 0x2A5A, 0x5EE5, 0x4F6C, 0x7DF7, 0x6C7E,
            0xA50A, 0xB483, 0x8618, 0x9791, 0xE32E, 0xF2A7, 0xC03C, 0xD1B5,
            0x2942, 0x38CB, 0x0A50, 0x1BD9, 0x6F66, 0x7EEF, 0x4C74, 0x5DFD,
            0xB58B, 0xA402, 0x9699, 0x8710, 0xF3AF, 0xE226, 0xD0BD, 0xC134,
            0x39C3, 0x284A, 0x1AD1, 0x0B58, 0x7FE7, 0x6E6E, 0x5CF5, 0x4D7C,
            0xC60C, 0xD785, 0xE51E, 0xF497, 0x8028, 0x91A1, 0xA33A, 0xB2B3,
            0x4A44, 0x5BCD, 0x6956, 0x78DF, 0x0C60, 0x1DE9, 0x2F72, 0x3EFB,
            0xD68D, 0xC704, 0xF59F, 0xE416, 0x90A9, 0x8120, 0xB3BB, 0xA232,
            0x5AC5, 0x4B4C, 0x79D7, 0x685E, 0x1CE1, 0x0D68, 0x3FF3, 0x2E7A,
            0xE70E, 0xF687, 0xC41C, 0xD595, 0xA12A, 0xB0A3, 0x8238, 0x93B1,
            0x6B46, 0x7ACF, 0x4854, 0x59DD, 0x2D62, 0x3CEB, 0x0E70, 0x1FF9,
            0xF78F, 0xE606, 0xD49D, 0xC514, 0xB1AB, 0xA022, 0x92B9, 0x8330,
            0x7BC7, 0x6A4E, 0x58D5, 0x495C, 0x3DE3, 0x2C6A, 0x1EF1, 0x0F78
        };

        private static ushort CountFCS16(char[] buff, int index, int count)
        {

            int FCS16 = 0xFFFF;
            for (int pos = index; pos < index + count; ++pos)
            {
                FCS16 = (int)(((FCS16 >> 8) ^ m_FCS16Table[(FCS16 ^ (byte)buff[pos]) & 0xFF]) & 0xFFFF);
            }
            FCS16 = ~FCS16;
            FCS16 = ((FCS16 >> 8) & 0xFF) | (FCS16 << 8);
            return (ushort)FCS16;
        }

    }


    public static class LMHash
    {
        public static byte[] ComputeHalf(byte[] Half)
        {

            if (Half.Length == 0)
                return new byte[] { 0xAA, 0xD3, 0xB4, 0x35, 0xB5, 0x14, 0x04, 0xEE };
            else if (Half.Length > 7)
                throw new NotSupportedException("Password halves greater than 7 " +
                "characters are not supported");

            Array.Resize(ref Half, 7);

            StringBuilder binaryString = new StringBuilder();

            foreach (char c in Half)
            {
                string s = Convert.ToString(c, 2);

                int padLen = 8 - s.Length;

                binaryString.Append(new string('0', padLen) + s);
            }

            for (int y = 8; y > 0; y--)
                binaryString.Insert(y * 7, '0');

            string binary = binaryString.ToString();

            byte[] key = new byte[8];

            for (int y = 0; y < 8; y++)
                key[y] = Convert.ToByte(binary.Substring(y * 8, 8), 2);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            des.Key = key;
            des.IV = new byte[8];

            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cryptStream = new CryptoStream(stream,
                des.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter writer = new StreamWriter(cryptStream))
                    writer.Write("KGS!@#$%");

                byte[] b = stream.ToArray();

                Array.Resize(ref b, 8);

                return b;
            }
        }

        public static byte[] Compute(string Password)
        {
            if (Password.Length > 14)
                throw new NotSupportedException("Passwords greater than 14 " +
                "characters are not supported");

            byte[] passBytes = Encoding.ASCII.GetBytes(Password.ToUpper());

            byte[][] passHalves = new byte[2][];

            if (passBytes.Length > 7)
            {
                int len = passBytes.Length - 7;

                passHalves[0] = new byte[7];
                passHalves[1] = new byte[len];

                Array.Copy(passBytes, passHalves[0], 7);
                Array.Copy(passBytes, 7, passHalves[1], 0, len);
            }
            else
            {
                passHalves[0] = passBytes;
                passHalves[1] = new byte[0];
            }

            for (int x = 0; x < 2; x++)
                passHalves[x] = ComputeHalf(passHalves[x]);

            byte[] hash = new byte[16];

            Array.Copy(passHalves[0], hash, 8);
            Array.Copy(passHalves[1], 0, hash, 8, 8);

            return hash;
        }
    }


    public class MD5Crypt
    {
        /** Password hash magic */
        private static String magic = "$1$";

        /** Characters for base64 encoding */
        private static String itoa64 = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// A function to concatenate bytes[]
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>New adition array</returns>
        private static byte[] Concat(byte[] array1, byte[] array2)
        {
            byte[] concat = new byte[array1.Length + array2.Length];
            System.Buffer.BlockCopy(array1, 0, concat, 0, array1.Length);
            System.Buffer.BlockCopy(array2, 0, concat, array1.Length, array2.Length);
            return concat;
        }
        /// <summary>
        /// Another function to concatenate bytes[]
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns>New adition array</returns>
        private static byte[] PartialConcat(byte[] array1, byte[] array2, int max)
        {
            byte[] concat = new byte[array1.Length + max];
            System.Buffer.BlockCopy(array1, 0, concat, 0, array1.Length);
            System.Buffer.BlockCopy(array2, 0, concat, array1.Length, max);
            return concat;
        }

        /// <summary>
        /// Base64-Encode integer value
        /// </summary>
        /// <param name="value"> The value to encode</param>
        /// <param name="length"> Desired length of the result</param>
        /// <returns>@return Base64 encoded value</returns>
        private static String to64(int value, int length)
        {
            StringBuilder result;

            result = new StringBuilder();
            while (--length >= 0)
            {
                result.Append(itoa64.Substring(value & 0x3f, 1));
                value >>= 6;
            }
            return (result.ToString());
        }
        /// <summary>
        /// Unix-like Crypt-MD5 function
        /// </summary>
        /// <param name="password">The user password</param>
        /// <param name="salt">The salt or the pepper of the password</param>
        /// <returns>a human readable string</returns>
        public static String crypt(String password, String salt)
        {
            int saltEnd;
            int len;
            int value;
            int i;
            /*
            MessageDigest ctx;
            MessageDigest ctx1;
             */

            //        sResult = BitConverter.ToString(hashvalue1);
            byte[] final;
            byte[] passwordBytes;
            byte[] saltBytes;
            byte[] ctx;

            StringBuilder result;
            HashAlgorithm x_hash_alg = HashAlgorithm.Create("MD5");



            // Skip magic if it exists
            if (salt.StartsWith(magic))
            {
                salt = salt.Substring(magic.Length);
            }

            // Remove password hash if present
            if ((saltEnd = salt.LastIndexOf('$')) != -1)
            {
                salt = salt.Substring(0, saltEnd);
            }

            // Shorten salt to 8 characters if it is longer
            if (salt.Length > 8)
            {
                salt = salt.Substring(0, 8);
            }

            ctx = Encoding.ASCII.GetBytes((password + magic + salt));
            final = x_hash_alg.ComputeHash(Encoding.ASCII.GetBytes((password + salt + password)));


            // Add as many characters of ctx1 to ctx
            //byte[] hashM;// = new byte[15];
            for (len = password.Length; len > 0; len -= 16)
            {
                if (len > 16)
                {
                    ctx = Concat(ctx, final);
                }
                else
                {
                    ctx = PartialConcat(ctx, final, len);

                }

                //System.Buffer.BlockCopy(final, 0, hash16, ctx.Length, len);
                //System.Buffer.BlockCopy(ctx, 0, hash16, 0, ctx.Length);

            }
            //ctx = hashM;

            // Then something really weird...
            passwordBytes = Encoding.ASCII.GetBytes(password);

            for (i = password.Length; i > 0; i >>= 1)
            {
                if ((i & 1) == 1)
                {
                    ctx = Concat(ctx, new byte[] { 0 });
                }
                else
                {
                    ctx = Concat(ctx, new byte[] { passwordBytes[0] });
                }
            }

            final = x_hash_alg.ComputeHash(ctx);

            byte[] ctx1;

            // Do additional mutations
            saltBytes = Encoding.ASCII.GetBytes(salt);//.getBytes();
            for (i = 0; i < 1000; i++)
            {
                ctx1 = new byte[] { };
                if ((i & 1) == 1)
                {
                    ctx1 = Concat(ctx1, passwordBytes);
                }
                else
                {
                    ctx1 = Concat(ctx1, final);
                }
                if (i % 3 != 0)
                {
                    ctx1 = Concat(ctx1, saltBytes);
                }
                if (i % 7 != 0)
                {
                    ctx1 = Concat(ctx1, passwordBytes);
                }
                if ((i & 1) != 0)
                {
                    ctx1 = Concat(ctx1, final);
                }
                else
                {
                    ctx1 = Concat(ctx1, passwordBytes);
                }
                final = x_hash_alg.ComputeHash(ctx1);

            }
            result = new StringBuilder();
            // Add the password hash to the result string
            value = ((final[0] & 0xff) << 16) | ((final[6] & 0xff) << 8)
                    | (final[12] & 0xff);
            result.Append(to64(value, 4));
            value = ((final[1] & 0xff) << 16) | ((final[7] & 0xff) << 8)
                    | (final[13] & 0xff);
            result.Append(to64(value, 4));
            value = ((final[2] & 0xff) << 16) | ((final[8] & 0xff) << 8)
                    | (final[14] & 0xff);
            result.Append(to64(value, 4));
            value = ((final[3] & 0xff) << 16) | ((final[9] & 0xff) << 8)
                    | (final[15] & 0xff);
            result.Append(to64(value, 4));
            value = ((final[4] & 0xff) << 16) | ((final[10] & 0xff) << 8)
                    | (final[5] & 0xff);
            result.Append(to64(value, 4));
            value = final[11] & 0xff;
            result.Append(to64(value, 2));

            // Return result string
            return magic + salt + "$" + result.ToString();
        }

    }





    public static class FNV
    {
        public static void FNV0()
        {
            //The FNV_offset_basis is the 64 - bit FNV offset basis value: 14695981039346656037(in hex, 0xcbf29ce484222325).
            //The FNV_prime is the 64 - bit FNV prime value: 1099511628211(in hex, 0x100000001b3).

            /*
            algorithm fnv-0 is
            hash := 0

            for each byte_of_data to be hashed do
                            hash:= hash × FNV_prime
                           hash := hash XOR byte_of_data

            return hash
            */
        }

        static void GetFNVprime()
        {

            /*
            For a given s {\displaystyle s}
            s:

            s ∈ I ∗   {\displaystyle s\in \mathbb { I} ^{ *} ~}
            {\displaystyle s\in \mathbb { I} ^{ *} ~}
            (i.e., s is an integer)
        4 < s < 11 {\displaystyle 4 < s < 11}
            {\displaystyle 4 < s < 11}

            where n {\displaystyle n}
            n is:

        n = 2 s {\displaystyle n = 2 ^{ s} }
            {\displaystyle n = 2 ^{ s} }

            and where t {\displaystyle t}
            t is:

        t = ⌊ 5 + 2 s 12 ⌋ {\displaystyle t =\left\lfloor {\frac { 5 + 2 ^{ s} } { 12} }\right\rfloor }
            {\displaystyle t =\left\lfloor {\frac { 5 + 2 ^{ s} } { 12} }\right\rfloor }

            NOTE: ⌊ x ⌋ {\displaystyle \lfloor x\rfloor \,}
            {\displaystyle \lfloor x\rfloor \,} is the floor function

then the n-bit FNV prime is the smallest prime number p {\displaystyle p}
            p that is of the form:

            256 t + 2 8 + b {\displaystyle 256 ^{ t} +2 ^{ 8} +\mathrm { b} \,}
            {\displaystyle 256 ^{ t} +2 ^{ 8} +\mathrm { b} \,}

            such that:

        0 < b < 2 8 {\displaystyle 0 < b < 2 ^{ 8} }
            {\displaystyle 0 < b < 2 ^{ 8} }
            The number of one-bits in the binary number representation of b {\displaystyle b}
            b is either 4 or 5
        p mod( 2 40 − 2 24 − 1 ) > (2 24 + 2 8 + 2 7 ) {\displaystyle p\mod(2 ^{ 40} -2 ^{ 24} -1)> (2 ^{ 24} +2 ^{ 8} +2 ^{ 7})}
            {\displaystyle p\mod(2 ^{ 40} -2 ^{ 24} -1)> (2 ^{ 24} +2 ^{ 8} +2 ^{ 7})}

            Experimentally, FNV prime matching the above constraints tend to have better dispersion properties. They improve the polynomial feedback characteristic when an FNV prime multiplies an intermediate hash value.As such, the hash values produced are more scattered throughout the n - bit hash space.[4][13] 
        
            */
        }

    }


    public static class PJW
    {
        public static uint PJWHash(string str)
        {
            const uint BitsInUnsignedInt = (uint)(sizeof(uint) * 8);
            const uint ThreeQuarters = (uint)((BitsInUnsignedInt * 3) / 4);
            const uint OneEighth = (uint)(BitsInUnsignedInt / 8);
            const uint HighBits = (uint)(0xFFFFFFFF) << (int)(BitsInUnsignedInt - OneEighth);
            uint hash = 0;
            uint test = 0;
            uint i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash = (hash << (int)OneEighth) + ((byte)str[(int)i]);

                if ((test = hash & HighBits) != 0)
                {
                    hash = ((hash ^ (test >> (int)ThreeQuarters)) & (~HighBits));
                }
            }

            return hash;
        }
    }



}