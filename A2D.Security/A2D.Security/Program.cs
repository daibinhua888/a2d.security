using A2D.Security.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2D.Security.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var signature=RSASignatureFactory.Instance(@"C:\ssl\rsa_public_key.pem");

            
            var result=signature.VerifySign("表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表示表", @"jGR3l4LrAbRLNdhXDQWdBiMIgp1x8iiCHSY8hEl6HXQ3r0zV1Yi0FuR8KAO5+Q5Js4x0eGXoS8gJA02w9QKGLI7vAnSrVmMi8bzpceFiekoBFuoXjFzBuMsc6cMFWSSHpE3CRKZEy4Jy9FcHFrTpygPZEhFVL7fX+GeNyj+maP8=");

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
