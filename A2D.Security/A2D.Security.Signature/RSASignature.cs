using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2D.Security.Signature
{
    public class RSASignature
    {
        private string publickKey_exponent;
        private string publickKey_modulus;
        public void SetPublicKey_ExponentModulus(string exponent, string modulus)
        {
            this.publickKey_exponent = exponent;
            this.publickKey_modulus = modulus;
        }

        public bool VerifySign(string plainData, string sign)
        {
            if (this.publickKey_exponent == null || this.publickKey_modulus == null)
                throw new Exception("请先设置公钥的Exponent/Modulus值");

            ISigner signer = SignerUtilities.GetSigner("SHA1withRSA");
            RsaKeyParameters key = new RsaKeyParameters(false, new BigInteger(Convert.FromBase64String(this.publickKey_modulus)), new BigInteger(Convert.FromBase64String(this.publickKey_exponent)));
            signer.Init(false, key);
            byte[] signBytes = Convert.FromBase64String(sign);
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainData);
            signer.BlockUpdate(plainBytes, 0, plainBytes.Length);
            bool ret = signer.VerifySignature(signBytes);
            return ret;
        }
    }
}
