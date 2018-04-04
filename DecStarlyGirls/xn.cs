using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DecStarlyGirls
{
    class Program
    {
        public static string JSON_ENCRYPT_KEY = "lkirwf897+22#bbtrm8814z5qq=498j5";
        public static string JSON_ENCRYPT_IV = "741952hheeyy66#cs!9hjv887mxx7@8y";
        //public static string Root = Environment.CurrentDirectory;

        static void Main(string[] args)
        {
            /* 打開當前目錄下的data.unity3d */
            //byte[] file = File.ReadAllBytes($@"{Root}\data.unity3d");

            /* 開啟檔案 */
            Console.Write("輸入檔案路徑(建議拖曳檔案) : ");
            string Infile = Console.ReadLine();
            /* 取得檔名(不包含附檔名) */
            string InfileName = Path.GetFileNameWithoutExtension(Infile);
            /* 取得目錄 */
            string InfilePath = Path.GetDirectoryName(Infile) + '\\';
            /* 取得副檔名 */
            string InfileExtn = Path.GetExtension(Infile);
            byte[] file = File.ReadAllBytes(Infile);

            /* 解密檔案 */
            //byte[] file = AESDecrypt(JSON_ENCRYPT_KEY, JSON_ENCRYPT_IV, file);
            SecretCode.Revert(file, file);

            /* 輸出檔案 */
            InfileName += "_decrypted";
            Console.WriteLine("輸出檔案 : " + InfileName + InfileExtn);
            File.WriteAllBytes(InfilePath + InfileName + InfileExtn, file);
            //File.WriteAllBytes($@"{Root}\data_decrypted.unity3d", file);
            Console.WriteLine("解密完成");
            Console.ReadKey(true);
        }

        private static byte[] AESDecrypt(string prm_key, string prm_iv, byte[] buffer)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.BlockSize = 256;
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Key = Encoding.UTF8.GetBytes(prm_key);
            rijndaelManaged.IV = Encoding.UTF8.GetBytes(prm_iv);
            rijndaelManaged.Padding = PaddingMode.None;
            ICryptoTransform cTransform = rijndaelManaged.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(buffer, 0, buffer.Length / 16 * 16);
            resultArray.CopyTo(buffer, 0);
            return resultArray;
        }
    }
}