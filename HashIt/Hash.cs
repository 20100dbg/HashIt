using System;
using System.Security.Cryptography;
using System.Text;
using HashLib;
using Core.Security.Cryptography;


namespace HashIt
{
    public class HashClass
    {
        public HashClass()
        {

        }

        public String GetAdler32(Param p)
        {
            if (p.Fs != null) return HashFactory.Checksum.CreateAdler32().ComputeStream(p.Fs).ToString();
            else return HashFactory.Checksum.CreateAdler32().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetCRC32_IEEE(Param p)
        {
            if (p.Fs != null) return HashFactory.Checksum.CreateCRC32_IEEE().ComputeStream(p.Fs).ToString();
            else return HashFactory.Checksum.CreateCRC32_IEEE().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetCRC64_ECMA(Param p)
        {
            if (p.Fs != null) return HashFactory.Checksum.CreateCRC64_ECMA().ComputeStream(p.Fs).ToString();
            else return HashFactory.Checksum.CreateCRC64_ECMA().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetGost(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateGost().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateGost().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetGrindahl256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateGrindahl256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateGrindahl256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetGrindahl512(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateGrindahl512().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateGrindahl512().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHAS160(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHAS160().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHAS160().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_3_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_3_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_3_128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_3_160(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_3_160().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_3_160().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_3_192(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_3_192().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_3_192().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_3_224(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_3_224().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_3_224().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_3_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_3_256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_3_256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_4_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_4_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_4_128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_4_160(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_4_160().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_4_160().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_4_192(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_4_192().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_4_192().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_4_224(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_4_224().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_4_224().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_4_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_4_256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_4_256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_5_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_5_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_5_128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_5_160(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_5_160().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_5_160().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_5_192(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_5_192().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_5_192().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_5_224(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_5_224().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_5_224().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetHaval_5_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateHaval_5_256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateHaval_5_256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetKeccak_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.SHA3.CreateKeccak256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.SHA3.CreateKeccak256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetKeccak_512(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.SHA3.CreateKeccak512().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.SHA3.CreateKeccak512().ComputeString(p.StringValueToHash).ToString();
        }
        /*
        public String GetLDAP(Param p)
        {
            if (p.Fs != null) return "";
            else return Crypter.Ldap.Crypt(p.StringValueToHash);
        }
        */

        public String GetLM(Param p)
        {
            if (p.Fs != null) return "";
            else
            {
                String s = p.StringValueToHash;
                if (s.Length > 14) s = s.Substring(0, 14);
                return BitConverter.ToString(WinHash.LMHash.Compute(s));
            }
        }

        public String GetMD2(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateMD2().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateMD2().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMD4(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateMD4().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateMD4().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMD5(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateMD5().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateMD5().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMD5Unix(Param p)
        {
            if (p.Fs != null) return "";
            else return Unix_MD5Crypt.MD5Crypt.crypt(p.StringValueToHash, p.Salt);
        }

        public String GetMurmur2_32(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateMurmur2().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateMurmur2().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMurmur2_64(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash64.CreateMurmur2().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash64.CreateMurmur2().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMurmur3_32(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateMurmur3().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateMurmur3().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetMurmur3_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash128.CreateMurmur3_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash128.CreateMurmur3_128().ComputeString(p.StringValueToHash).ToString();
        }

        public string GetMySQL4(Param p)
        {
            if (p.Fs != null) return "";
            else
            {
                UInt32 nr = 1345345333;
                UInt32 add = 7;
                UInt32 nr2 = 0x12345671;

                for (int i = 0; i < p.StringValueToHash.Length; i++)
                {
                    char c = p.StringValueToHash.Substring(i, 1)[0];
                    if (c == ' ' || c == '\t') continue;

                    UInt32 tmp = (UInt32)c;
                    nr ^= (((nr & 63) + add) * tmp) + ((nr << 8) & 0xFFFFFFFF);
                    nr2 += ((nr2 << 8) & 0xFFFFFFFF) ^ nr;
                    add += tmp;
                }

                int x = 31;
                UInt32 y = 1;

                UInt32 out_a = nr & ((y << x) - 1);
                UInt32 out_b = nr2 & ((y << x) - 1);

                return String.Format("{0:x8}{1:x8}", out_a, out_b);
            }
        }

        public string GetMySQL5(Param p)
        {
            if (p.Fs != null) return "";
            else
            {
                SHA1 s = SHA1.Create();
                byte[] passBytes = Settings.GetEncoding().GetBytes(p.StringValueToHash);
                byte[] hash = s.ComputeHash(passBytes);
                hash = s.ComputeHash(hash);

                var sb = new StringBuilder("*");
                for (int i = 0; i < hash.Length; i++) sb.AppendFormat("{0:X2}", hash[i]);
                return sb.ToString();
            }
        }

        public String GetNTLM(Param p)
        {
            if (p.Fs != null) return "";
            else return GetMD4(p);
        }

        public String GetPanama(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreatePanama().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreatePanama().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetPBKDF2(Param p) //String password, String salt, int iterations = 10000)
        {
            if (p.Fs != null) return "";
            else
            {
                int nbIterations = p.Iterations;
                if (nbIterations == 1) nbIterations = 10000;
                Byte[] bsalt = Settings.GetEncoding().GetBytes(p.Salt);
                if (bsalt.Length < 8) return "Sel trop court";

                int outputBytes = 32;
                var pbkdf2 = new Rfc2898DeriveBytes(p.StringValueToHash, bsalt, nbIterations);
                Byte[] bytes = pbkdf2.GetBytes(outputBytes);
                return BitConverter.ToString(bytes);
            }
        }
        /*
        public String GetPhpass(Param p)
        {
            if (p.Fs != null) return "";
            else return Crypter.Phpass.Crypt(p.StringValueToHash);
        }
        */
        public String GetRadioGatun32(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRadioGatun32().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRadioGatun32().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRadioGatun64(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRadioGatun64().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRadioGatun64().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRIPEMD(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRIPEMD().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRIPEMD().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRIPEMD128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRIPEMD128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRIPEMD128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRIPEMD160(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRIPEMD160().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRIPEMD160().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRIPEMD256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRIPEMD256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRIPEMD256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetRIPEMD320(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateRIPEMD320().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateRIPEMD320().ComputeString(p.StringValueToHash).ToString();
        }

        /*
        public string GetScrypt(Param p)
        {
            if (p.Fs != null) return "";
            else
            {
                int cost = 16384, blockSize = 8, parallel = 1, maxThread = 1, derivedKeyLength = 64;
                //cost : The cost parameter, typically a fairly large number such as 262144. Memory usage and CPU time scale approximately linearly with this parameter. 
                //blockSize :  The mixing block size, typically 8. Memory usage and CPU time scale approximately linearly with this parameter. 
                //parallel :  The level of parallelism, typically 1. CPU time scales approximately linearly with this parameter. 
                //maxThread :  The maximum number of threads to spawn to derive the key. This is limited by the parallel value. null will use as many threads as possible. 
                //derivedKeyLength : The desired length of the derived key.

                byte[] b = Settings.GetEncoding().GetBytes(p.StringValueToHash);
                byte[] s = Settings.GetEncoding().GetBytes(p.Salt);
                byte[] r = CryptSharp.Utility.SCrypt.ComputeDerivedKey(b, s, cost, blockSize, parallel, maxThread, derivedKeyLength);
                return BitConverter.ToString(r);
            }
        }
        */

        public String GetSHA0(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA0().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA0().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA1(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA1().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA1().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA224(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA224().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA224().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA384(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA384().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA384().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA512(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSHA512().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSHA512().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSHA3_Keccak224(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateKeccak224().ComputeHash(p.Fs);
            else h = SHA3.CreateKeccak224().ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSHA3_Keccak256(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateKeccak256().ComputeHash(p.Fs);
            else h = SHA3.CreateKeccak256().ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSHA3_Keccak384(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateKeccak384().ComputeHash(p.Fs);
            else h = SHA3.CreateKeccak384().ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSHA3_Keccak512(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateKeccak512().ComputeHash(p.Fs);
            else h = SHA3.CreateKeccak512().ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSHA3_Shake128(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateShake128(128).ComputeHash(p.Fs);
            else h = SHA3.CreateShake128(128).ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSHA3_Shake256(Param p)
        {
            byte[] h;
            if (p.Fs != null) h = SHA3.CreateShake256(256).ComputeHash(p.Fs);
            else h = SHA3.CreateShake256(256).ComputeHash(Settings.GetEncoding().GetBytes(p.StringValueToHash));
            return BitConverter.ToString(h);
        }

        public String GetSnefru_4_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSnefru_4_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSnefru_4_128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSnefru_4_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSnefru_4_256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSnefru_4_256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSnefru_8_128(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSnefru_8_128().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSnefru_8_128().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSnefru_8_256(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateSnefru_8_256().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateSnefru_8_256().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetTiger2(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateTiger2().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateTiger2().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetTiger_3_192(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateTiger_3_192().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateTiger_3_192().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetTiger_4_192(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateTiger_4_192().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateTiger_4_192().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetWhirlpool(Param p)
        {
            if (p.Fs != null) return HashFactory.Crypto.CreateWhirlpool().ComputeStream(p.Fs).ToString();
            else return HashFactory.Crypto.CreateWhirlpool().ComputeString(p.StringValueToHash).ToString();
        }


        // en test // en test // en test 

        public String GetAP(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateAP().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateAP().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetDotNet(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateDotNet().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateDotNet().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetELF(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateELF().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateELF().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetJenkins3(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash32.CreateJenkins3().ComputeStream(p.Fs).ToString();
            else return HashFactory.Hash32.CreateJenkins3().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetSip(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash64.CreateSipHash().ComputeStream(p.Fs).ToString();
            return HashFactory.Hash64.CreateSipHash().ComputeString(p.StringValueToHash).ToString();
        }

        public String GetFnv(Param p)
        {
            if (p.Fs != null) return HashFactory.Hash64.CreateFNV().ComputeStream(p.Fs).ToString();
            return HashFactory.Hash64.CreateFNV().ComputeString(p.StringValueToHash).ToString();
        }

    }
}