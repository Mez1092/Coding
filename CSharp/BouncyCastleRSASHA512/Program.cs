using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Text;


namespace API.Crypto
{
    public class RsaSha1Signing
    {

        public static void Main()
        {

            string privateKey = @"";
           

            string dataString = "";

            var enc = new RsaSha1Signing();
            var encryptedWithPrivate = enc.SignData(dataString, privateKey);

            Console.WriteLine(encryptedWithPrivate);
        }


        public string SignData(string clearText, string privateKey)
        {
         
            var dataToSign = Encoding.UTF8.GetBytes(clearText);

            var signer = SignerUtilities.GetSigner("SHA512WITHRSA");
            

            using (var txtreader = new StringReader(privateKey))
            {
                var keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();

                signer.Init(true, keyPair.Private);
                signer.BlockUpdate(dataToSign, 0, dataToSign.Length);
            }

            var signature = signer.GenerateSignature();
            return Convert.ToBase64String(signature);
        }

    }
}
