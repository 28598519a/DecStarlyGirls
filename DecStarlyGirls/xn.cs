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
            /* ���}��e�ؿ��U��data.unity3d */
            //byte[] file = File.ReadAllBytes($@"{Root}\data.unity3d");

            /* �}���ɮ� */
            Console.Write("��J�ɮ׸��|(��ĳ�즲�ɮ�) : ");
            string Infile = Console.ReadLine();
            /* ���o�ɦW(���]�t���ɦW) */
            string InfileName = Path.GetFileNameWithoutExtension(Infile);
            /* ���o�ؿ� */
            string InfilePath = Path.GetDirectoryName(Infile) + '\\';
            /* ���o���ɦW */
            string InfileExtn = Path.GetExtension(Infile);
            byte[] file = File.ReadAllBytes(Infile);

            /* �ѱK�ɮ� */
            //byte[] file = AESDecrypt(JSON_ENCRYPT_KEY, JSON_ENCRYPT_IV, file);
            SecretCode.Revert(file, file);

            /* ��X�ɮ� */
            InfileName += "_decrypted";
            Console.WriteLine("��X�ɮ� : " + InfileName + InfileExtn);
            File.WriteAllBytes(InfilePath + InfileName + InfileExtn, file);
            //File.WriteAllBytes($@"{Root}\data_decrypted.unity3d", file);
            Console.WriteLine("�ѱK����");
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