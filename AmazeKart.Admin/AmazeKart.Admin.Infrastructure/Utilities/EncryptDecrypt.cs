using System.Security.Cryptography;
using System.Text;

namespace AmazeKart.Admin.Infrastructure.Utilities
{
    public static class EncryptDecrypt
    {
        /// <summary>
        /// This security key should be very complex and Random for encrypting the text. This playing vital role in encrypting the text.
        /// </summary>
        public const string _securityKey = "z3H2k10hd3";
        public static string AES_Decrypt(string input)
        {
            string resultDecrypt = "";
            try
            {
                byte[] decryptedBytes = null;
                byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(_securityKey);

                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }
                resultDecrypt = Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
                if (ex != null)
                    resultDecrypt = input;
            }
            return resultDecrypt;
        }
    }
}