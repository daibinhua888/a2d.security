using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace A2D.Security.Signature
{
    public static class RSASignatureFactory
    {
        private static RSASignature _instance = null;
        public static RSASignature Instance(string publicKeyFilePath)
        {
            if (_instance != null)
                return _instance;

            if (!File.Exists(publicKeyFilePath))
                throw new FileNotFoundException(string.Format("公钥文件未找到：{0}", publicKeyFilePath));

            string publicKeyContent = RSAPublicKeyLoader.LoadFromFile(publicKeyFilePath);

            var publickKey=a2d.security.compatableTools.RsaHelper.generateRSAKeyPair(publicKeyContent);

            var exponent = a2d.security.compatableTools.RsaHelper.getPublicKey_Exponent(publickKey);
            var modulus = a2d.security.compatableTools.RsaHelper.getPublicKey_Modulus(publickKey);

            _instance = new RSASignature();
            _instance.SetPublicKey_ExponentModulus(exponent, modulus);
            return _instance;
        }
    }
}
