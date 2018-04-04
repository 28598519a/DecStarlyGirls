using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SecretCode
{
    public static long Convert(byte[] data)
    {
        byte b = 0;
        byte b2 = 57;
        ulong num = 14695981039346656037UL;
        for (int i = 0; i < data.Length; i++)
        {
            byte b3 = data[i];
            byte b4 = (byte)((b3 ^ b2) + b);
            data[i] = b4;
            num = (num + (num << 1) + (num << 4) + (num << 5) + (num << 7) + (num << 8) + (num << 40) ^ (ulong)b3);
            b2 = b4;
            b += 178;
        }
        return (long)num;
    }

    // Token: 0x06001C68 RID: 7272 RVA: 0x000943E8 File Offset: 0x000925E8
    public static long Revert(byte[] srcbin, byte[] dstbin)
    {
        byte b = 0;
        byte b2 = 57;
        ulong num = 14695981039346656037UL;
        for (int i = 0; i < srcbin.Length; i++)
        {
            byte b3 = srcbin[i];
            byte b4 = (byte)(b2 ^ b3 - b);
            dstbin[i] = b4;
            num = (num + (num << 1) + (num << 4) + (num << 5) + (num << 7) + (num << 8) + (num << 40) ^ (ulong)b4);
            b2 = b3;
            b += 178;
        }
        return (long)num;
    }

    // Token: 0x06001C69 RID: 7273 RVA: 0x00094458 File Offset: 0x00092658
    public static long GetHash(byte[] data)
    {
        byte b = 0;
        byte b2 = 57;
        ulong num = 14695981039346656037UL;
        foreach (byte b3 in data)
        {
            byte b4 = (byte)(b2 ^ b3 - b);
            num = (num + (num << 1) + (num << 4) + (num << 5) + (num << 7) + (num << 8) + (num << 40) ^ (ulong)b4);
            b2 = b3;
            b += 178;
        }
        return (long)num;
    }
}

