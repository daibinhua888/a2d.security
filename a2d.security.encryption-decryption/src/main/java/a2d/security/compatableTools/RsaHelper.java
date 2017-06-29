package a2d.security.compatableTools;

/**
 * Created by z on 2017/5/9.
 */

import sun.misc.BASE64Decoder;
import java.io.IOException;
import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PublicKey;
import java.security.interfaces.RSAPublicKey;
import java.security.spec.*;


public class RsaHelper {

    public static PublicKey generateRSAKeyPair(String publicKey) {
        KeyFactory keyFactory = null;
        try {
            keyFactory = KeyFactory.getInstance("RSA");
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
            return null;
        }
        BASE64Decoder decoder = new BASE64Decoder();


        PublicKey pk_publicKey = null;
        try {
            pk_publicKey = keyFactory.generatePublic(new X509EncodedKeySpec(decoder.decodeBuffer(publicKey)));
        } catch (InvalidKeySpecException e) {
            e.printStackTrace();
            return null;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }

        return pk_publicKey;
    }

    public static String getPublicKey_Modulus(PublicKey key) {
        if (!RSAPublicKey.class.isInstance(key)) {
            return null;
        }
        RSAPublicKey pubKey = (RSAPublicKey) key;

        return Base64Helper.encode(pubKey.getModulus().toByteArray());
    }

    public static String getPublicKey_Exponent(PublicKey key) {
        if (!RSAPublicKey.class.isInstance(key)) {
            return null;
        }
        RSAPublicKey pubKey = (RSAPublicKey) key;

        return Base64Helper.encode(pubKey.getPublicExponent().toByteArray());
    }
}