using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using HashLib;

namespace HashIt
{
    public class Hash
    {
        public Hash()
        {

        }


        public String GetMD2(String str)
        {
            IHash hash = HashFactory.Crypto.CreateMD2();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetMD2(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateMD2();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetMD4(String str)
        {
            IHash hash = HashFactory.Crypto.CreateMD4();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetMD4(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateMD4();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetMD5(String str)
        {
            MD5 ha = MD5.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetMD5(FileStream fs)
        {
            MD5 ha = MD5.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetMD5Unix(String str, String sel = "")
        {
            return Unix_MD5Crypt.MD5Crypt.crypt(str, sel);
        }


        public String GetSHA1(String str)
        {
            SHA1 ha = SHA1.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetSHA1(FileStream fs)
        {
            SHA1 ha = SHA1.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetSHA256(String str)
        {
            SHA256 ha = SHA256.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetSHA256(FileStream fs)
        {
            SHA256 ha = SHA256.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetSHA384(String str)
        {
            SHA384 ha = SHA384.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetSHA384(FileStream fs)
        {
            SHA384 ha = SHA384.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetSHA512(String str)
        {
            SHA512 ha = SHA512.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetSHA512(FileStream fs)
        {
            SHA512 ha = SHA512.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetRIPEMD160(String str)
        {
            RIPEMD160 ha = RIPEMD160.Create();
            return BitConverter.ToString(ha.ComputeHash(UTF8Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public String GetRIPEMD160(FileStream fs)
        {
            RIPEMD160 ha = RIPEMD160.Create();
            return BitConverter.ToString(ha.ComputeHash(fs)).Replace("-", "");
        }


        public String GetRIPEMD256(String str)
        {
            IHash hash = HashFactory.Crypto.CreateRIPEMD256();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetRIPEMD256(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateRIPEMD256();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetRIPEMD320(String str)
        {
            IHash hash = HashFactory.Crypto.CreateRIPEMD320();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetRIPEMD320(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateRIPEMD320();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetWhirlpool(String str)
        {
            IHash hash = HashFactory.Crypto.CreateWhirlpool();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetWhirlpool(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateWhirlpool();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetHaval256(String str)
        {
            IHash hash = HashFactory.Crypto.CreateHaval_5_256();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetHaval256(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateHaval_5_256();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetTiger2(String str)
        {
            IHash hash = HashFactory.Crypto.CreateTiger2();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetTiger2(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateTiger2();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetPanama(String str)
        {
            IHash hash = HashFactory.Crypto.CreatePanama();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetPanama(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreatePanama();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetGost(String str)
        {
            IHash hash = HashFactory.Crypto.CreateGost();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetGost(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateGost();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetGrindahl512(String str)
        {
            IHash hash = HashFactory.Crypto.CreateGrindahl512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetGrindahl512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateGrindahl512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetHAS160(String str)
        {
            IHash hash = HashFactory.Crypto.CreateHAS160();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetHAS160(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateHAS160();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetRadioGatun64(String str)
        {
            IHash hash = HashFactory.Crypto.CreateRadioGatun64();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetRadioGatun64(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateRadioGatun64();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetSnefru8_256(String str)
        {
            IHash hash = HashFactory.Crypto.CreateSnefru_8_256();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetSnefru8_256(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.CreateSnefru_8_256();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetBlake512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateBlake512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetBlake512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateBlake512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetBlueMidnightWish512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateBlueMidnightWish512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetBlueMidnightWish512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateBlueMidnightWish512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetCubeHash512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateCubeHash512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetCubeHash512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateCubeHash512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetEcho512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateEcho512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetEcho512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateEcho512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetFugue512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateFugue512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetFugue512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateFugue512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetGroestl512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateGroestl512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetGroestl512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateGroestl512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetHamsi512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateHamsi512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetHamsi512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateHamsi512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetJH512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateJH512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetJH512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateJH512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetKeccak512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetKeccak512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetLuffa512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateLuffa512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetLuffa512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateLuffa512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetShabal512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateShabal512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetShabal512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateShabal512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetSHAvite3_512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSHAvite3_512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetSHAvite3_512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSHAvite3_512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetSIMD512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSIMD512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetSIMD512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSIMD512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetSkein512(String str)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSkein512();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetSkein512(FileStream fs)
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateSkein512();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetCRC32(String str)
        {
            IHash hash = HashFactory.Checksum.CreateCRC32_IEEE();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetCRC32(FileStream fs)
        {
            IHash hash = HashFactory.Checksum.CreateCRC32(HashLib.Checksum.CRC32Polynomials.IEEE_802_3);
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetCRC64(String str)
        {
            IHash hash = HashFactory.Checksum.CreateCRC64_ECMA();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetCRC64(FileStream fs)
        {
            IHash hash = HashFactory.Checksum.CreateCRC64(HashLib.Checksum.CRC64Polynomials.ECMA_182, UInt64.MaxValue, UInt64.MaxValue);
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetMurmur2(String str)
        {
            IHash hash = HashFactory.Hash64.CreateMurmur2();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetMurmur2(FileStream fs)
        {
            IHash hash = HashFactory.Hash64.CreateMurmur2();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetMurmur3(String str)
        {
            IHash hash = HashFactory.Hash128.CreateMurmur3_128();
            HashResult r = hash.ComputeString(str);
            return r.ToString();
        }

        public String GetMurmur3(FileStream fs)
        {
            IHash hash = HashFactory.Hash128.CreateMurmur3_128();
            HashResult r = hash.ComputeStream(fs);
            return r.ToString();
        }


        public String GetPBKDF2(String password, String salt, int iterations = 10000)
        {
            Byte[] bsalt = Encoding.UTF8.GetBytes(salt);
            if (bsalt.Length < 8) return "";

            int outputBytes = 32;
            var pbkdf2 = new Rfc2898DeriveBytes(password, bsalt, iterations);
            Byte[] bytes = pbkdf2.GetBytes(outputBytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }

    }

}
