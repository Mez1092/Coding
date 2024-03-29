﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace SignWithRSA
{
    public class RSACSPSample
    {
        static void Main()
        {
            try
            {
                string privateKey = @"-----BEGIN RSA PRIVATE KEY-----
                                MIIEowIBAAKCAQEA4YWrintlrUR6Xhoscdk0pFSI9U+Y7tDOFs491sC+m9wT6Jhl
                                5SsR2QnPd/YbeCLzgmwG3dygL/Ld+1HycFz8Mab5p+OVI0QU8XHgGZwbbC69h1YZ
                                WSnfkuunLYJUHOImH+8uydcjfDzK9owfLjW+dvX30KQ5IM44aVZuDxv8GJGATguM
                                MUKcYXMMMDICyR5n/snQSDPI+YXS/sUgqlf8tqhMCr5/Vm+NuoRIP+waB0JFOCV5
                                poohlW1QfnOUplV49h4CXs6MM//ZoCPybLfJzIT4Qi4LOkG+Rye6CTt5EOaqXv4B
                                4zcRedbMjGIrCrS3GDserlNcYn1xhmZ9el6KkQIDAQABAoIBAGqNMUM4kg2PMRGM
                                5DrWGN0bY6ojdWpAFV8JCoaQgn45ON7IQjxIYSJeVDuld80HFm4khAoG11hQMzku
                                upEEHdOHxKTiDfCflhWNbAgtjXdLjhiHQWqzMgLEfDQwQ3VyE/k6lKygjQ+B2ZMr
                                GQBIPDkQdYmKTcOGK3j5cP6Khk1Ebn/KzbrWPvidW1wa8tr107WTla0d9T3ujCB/
                                UUHwcb5Y7tPI6uNnFvtaBEKOazs062CBpE+gGjZujxNxAUTE3GT8OvWqijRm/QHc
                                4Qcm04qTs9446qUfvL64gMrhyXocymQonfE8EQPA1k/I517ZVHYGWb4ZIfTNiNMQ
                                OFpk0VECgYEA8jBsuy+y40oO9SO8iZbNbv2eTsCwksW2Lq585GTFzEW1Ka3NjtFF
                                SFkyLW3C0ju8vRl1LyXC3D+ZcgfVOUEcQXBVh0QK4RA+qPQg6IlaieCQ0tw1LwfH
                                /865gZBKx7fuLwLH/Y90wQLUexUkN22tYox6jxmh27ckAXAULj7KHZcCgYEA7mHv
                                AA1Vs75LwA+MZmWJgF4jLagGJuy1/ryX2ua+TuBPQmcQGmKOjfuvsq07dFxer3ZR
                                RbKDZQdxmoUJZp/wfCEC+7vW0UdlHBhNfWdZuNEB4h3fH75guiai8HMZM4wtp8Qp
                                CSxa8yyNOyNQrTU/Qin42VuW8ki8oulvnWxZbhcCgYBlKcMRQXBYroOm9AF5+2re
                                VMP+o1BeToW15B65DDrvA6MTwMyfPlzRRqjF/xYk2N0SpAKl6gEGHO7MiecP3lme
                                H/0p3kspDa8OxcLFPzJ5azszSNZSSc7J1KD6NLp3yCWOr3u4N2cOhE8bBo61NHP7
                                OTCse4l3jH1WuGlFk+a7CwKBgQDdzppH/iBkYwiw6MbG8GuE2hL5hIJU7aRaJrlV
                                oaYqVmTpcGR3aIUkb7AIHVBY8SnZMcplg7jm5Io8MNWSe/eUSFMyUJGNoVTfU22m
                                5eeCJFgQQaM/MjFmhFTQTwiAAkro84kLVA48fpPbFv0WbZkyw0MdXC+TuUJsg7Cr
                                VgnQeQKBgFHx0Q9fH7sfw8Z3ErkNkEjYhuS3XQQIMvaatY6NVOUoYWJbRYb2u36A
                                kRUkmtFZ+QUqcYgLZqQSc4Xxnp4mMgoRP2y/dpuAss9CJ4D9XxIbvOwem3aGwCoO
                                ntnh+g/u4OpKoRUIxWZQRKfZM1kAlSo4GA+48qcn/0e2lHhs01ZY
                                -----END RSA PRIVATE KEY-----";

                string dataString = "ed610b4a03e4a360fa0e9ad0f3ba25105512acadad5cd5d4d2d8e2dc181662e33fc86a82f6349af7ee4cac5f3e43e8007ec1acf7ad13ece28dccc0c4b9157154";

                RSACSPSample P = new RSACSPSample();
                string result = P.HashAndSignBytes(dataString, privateKey);


                Console.WriteLine(result);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data was not signed or verified");
            }
        }
        public string HashAndSignBytes(string stringToSign, string pKey)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the
                // key from RSAParameters.
                ASCIIEncoding ByteConverter = new ASCIIEncoding();

                byte[] originalData = ByteConverter.GetBytes(stringToSign);
                byte[] dataToSign = ByteConverter.GetBytes(stringToSign);




                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportFromPem(pKey.ToCharArray());
                RSAParameters Key = RSAalg.ExportParameters(true);

                RSAalg.ImportParameters(Key);

                // Hash and sign the data. Pass a new instance of SHA512
                // to specify the hashing algorithm.
                return Convert.ToBase64String(RSAalg.SignData(dataToSign, SHA512.Create()));
            }
            catch (CryptographicException e)
            {

                throw new ArgumentException(e.Message);
            }
        }


    }

}