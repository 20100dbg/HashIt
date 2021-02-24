using System;
using System.IO;

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
}
