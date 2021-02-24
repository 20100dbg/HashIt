using System;
using System.Text;

namespace HashIt
{
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
}