using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace OTS.Helper
{
    public class CCrypt
    {
        public static UInt32 BPHash(string str)
        {
            UInt32 hash = 0;
            foreach (char c in str)
            {
                hash = hash << 7 ^ c;
            }
            return hash;
        }

        public static UInt32 APHash(string str)
        {
            UInt32 hash = 0xAAAAAAAA;
            UInt32 i = 0;
            foreach (char c in str)
            {
                hash ^= ((i & 1) == 0) ? ((hash << 7) ^ c * (hash >> 3)) :
                                    (~((hash << 11) + (c ^ (hash >> 5))));
                i++;
            }
            return hash;
        }

        static readonly string PasswordHash = "P@@Sw0rdkhallew";//固定
        //static readonly string SaltKey = "S@LT&KEYNEW";         //变动
        static readonly string SaltKey = "A@$#%&*(AC2";         //变动
        static readonly string VIKey = "@1B2c3D4e5F6g7H@12";
        public static Byte[] GetAESKey()
        {
            string strBuf = PasswordHash + SaltKey;
            UInt32 nFixedHash = BPHash(PasswordHash);
            UInt32 nActiyHash = APHash(SaltKey);
            UInt32 nThirdHash = BPHash(strBuf);
            UInt32 nFourthHash = APHash(strBuf);

            Byte[] uHash = new Byte[16];
            Console.WriteLine("HASE:");
            Console.Write(" nFixed->{0:x}", nFixedHash);
            Console.Write(", Actiy->{0:x}", nActiyHash);
            Console.Write(", Third->{0:x}", nThirdHash);
            Console.WriteLine(", Fourth->{0:x}", nFourthHash);

            uHash[0] = (Byte)(nFixedHash << 24 >> 24);
            uHash[1] = (Byte)(nFixedHash << 16 >> 24);
            uHash[2] = (Byte)(nFixedHash << 8 >> 24);
            uHash[3] = (Byte)(nFixedHash >> 24);

            uHash[4] = (Byte)(nActiyHash << 24 >> 24);
            uHash[5] = (Byte)(nActiyHash << 16 >> 24);
            uHash[6] = (Byte)(nActiyHash << 8 >> 24);
            uHash[7] = (Byte)(nActiyHash >> 24);

            uHash[8] = (Byte)(nThirdHash << 24 >> 24);
            uHash[9] = (Byte)(nThirdHash << 16 >> 24);
            uHash[10] = (Byte)(nThirdHash << 8 >> 24);
            uHash[11] = (Byte)(nThirdHash >> 24);

            uHash[12] = (Byte)(nFourthHash << 24 >> 24);
            uHash[13] = (Byte)(nFourthHash << 16 >> 24);
            uHash[14] = (Byte)(nFourthHash << 8 >> 24);
            uHash[15] = (Byte)(nFourthHash >> 24);

            strBuf += SaltKey;
            strBuf += PasswordHash;
            Byte[] uKey = new Byte[32];
            int i = 0;
            foreach (char c in strBuf)
            {
                uKey[i] = (Byte)c;
                i++;
                if (i >= 32) break;
            }

            Console.Write("HASE Bytes:");
            for (i = 0; i < 16; i++)
            {
                if (0 == i % 8) Console.Write("\r\n");
                Console.Write(" Ox{0:X2},", uHash[i]);
                if (0 == i % 2)
                {
                    uKey[i] = (Byte)(uKey[i] & uHash[i]);
                    uKey[i + 16] = (Byte)(uKey[i + 16] | uHash[15 - i]);
                }
                else
                {
                    uKey[i] = (Byte)(uKey[i] | uHash[i]);
                    uKey[i + 16] = (Byte)(uKey[i + 16] & uHash[15 - i]);
                }
            }
            Console.Write("\r\nKEY:");

            for (i = 0; i < 32; i++)
            {
                if (0 == i % 8) Console.Write("\r\n");
                Console.Write(" Ox{0:X2},", uKey[i]);
            }
            Console.WriteLine("\n");
            return uKey;
        }
        public static void OutPutKeyRealKey(byte[] keyBytes)
        {
            string StringOut = "";
            int i = 0;
            foreach (byte InByte in keyBytes)
            {
                StringOut = StringOut + " 0x" + String.Format("{0:X2}", InByte) + ",";
                i++;
                if (0 == i % 8)
                {
                    StringOut = StringOut + "\r\n";
                }
            }
            //Console.WriteLine("Real Rsa cbc Key:\r\n" + StringOut);
        }


        public static string Encrypt(string plainText)
        {
            byte[] keyBytes = GetAESKey();
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            //byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            OutPutKeyRealKey(keyBytes);

            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = GetAESKey();
            //byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    };
}
