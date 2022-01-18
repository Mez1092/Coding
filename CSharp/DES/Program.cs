using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DES
{
    class Program
    {
        static void Main(string[] args)
        {

            string encryptedString = "dlQI7LhIZ1d/bhbEhDvoNfscphYNM/jlNVGOWrfEDB3cDUOJX2Zr5yjAELqXMBgqFliZnpxd9lP0SBWOuDIm2YUSgcPCedA9LTuMmX10x6euockCvxiAHSWQ9DE4TEm8OzPrj/J2rKIy5s16YI84W/GV6t6T57szjrcMqRSkTCHdIqSZtcRawuulPx6/rDo7KYCLsDj9xKfLlyHYkXct6B4ZtI5Z+ZVXprX6pqJ3xp5GvSMy2TN9VHM4QDVwPdqe2FLmYv/FoPbla7UBxS32HWuNeMm/xoQ8HSFFHlXXiImuZ6xnne6pbc9joaLPJ/glbTD39VvgjjbNtZ1jWAsk2By+QhH4IX3M0Ykr0+/QGk/zj3O6hUekbks0q7t4S2fEmecYiunrag/AfwX7VovLz3PKnUlxLptuAb5vcptlymDYJ6rWOL9vYNtDggq4IWJBCnjpTFXwYdnVdzO1/sX36DeslTR7aKtZNpljdFNoIRmp4dsR1e6lo5FjHa/MV06YeqMwkutqSomxjVjnI5vJTpfaMnLIpyUJX87+AInEULeBkS+ghsbG7fHMWsrCeNzsa0OiSs5+g+U89hkXrIVyMp/IRG/3F7r6";
            string decryptedString;

            string password = "CWXCRD60S3GLIEAICLZE";

            decryptedString = Decrypt(encryptedString, password);
            System.Console.WriteLine("Decrypted String: " + decryptedString);
        }


        public static string Decrypt(string encryptedMessage, string password)
        {
            // Convert encrypted message and password to bytes
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);
            byte[] passwordBytesComplete = Encoding.UTF8.GetBytes(password);
            byte[] passwordBytes = new byte[8];


           
            Array.Copy(passwordBytesComplete, 0, passwordBytes, 0, 8);

        

            // Set encryption settings -- Use password for both key and init. vector
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            provider.Padding = PaddingMode.PKCS7;
            provider.Mode = CipherMode.ECB;

            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            // Set up streams and decrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read decrypted message from memory stream
            byte[] decryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);

            // Encode deencrypted binary data to base64 string
            string message = Encoding.UTF8.GetString(decryptedMessageBytes);

            return message;
        }
    }
}
