using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PublicProperty
    {
        private static string PrivateKeyRed = @"-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCAPUQwxZ+8499ZneFC94szqOQGmNmz5TsEVRsOOwRggg4QShkO
jBrq/zxc/5AwxYlsjUeH4p1aM+J9ef4q81C/em8MK5Ab/Rdxrwoj/tulxJR24cKv
NyFzlU8ss8eSHeP+AtRGqXbHH+B2xIWBAN0JAdgSLQC+MSzTE6HdYOerOQIDAQAB
AoGAFbxMpoeYf4eP/7yGxbb3XRYvL/8QRzF/Q0i5gTv3jfP9Nj2Y6aJNna8NKCYY
5mtU05VOnnWGfhd1OBdJQTZkZQ75oxTSjT1mXz3deWbX3K5063pm1N4xWF/g9KTA
xXDdJnzjXPOePOKpRIfUDFlGIiutp10m+tOwwtlAm5nJcEECQQCBDMoF9gBUACbl
gWPeaUhalXo1qpEvBGKsgz7wZFYmOzikbtXRmTlYE/bjBP12mIJxcHvG2y37TTSd
gELRlVUlAkEA/mRUzc2vQEjfkdZjSc8dYjcs/kVOIQt92EPCHrYPCQXNKFUsdv8w
pu5ZsNCG66afx/8pvUztWUhIlw3bOBcDhQJAEVmR06lWM/TtRc/WiHFpK9yK2Ko8
6LBTP9RJYvJqbqtpmxnXn11VS1UrzSu/k/E/IFc6HOsczHt9xmsXEKxeDQJBAJnE
j7Yuw+X5ppoCmtV8iehaLaosvkMfLRxSKL5jkccEaLQed9gd/IyKulA0W7mJaD99
rv8rxrQXCzmzOHU5A/kCQH//p7myHyFmmLjJm8wUu4ltHkqn6XR5OBoYOplOUb/z
5DZkX+baqBCFc8wlHYq9d7JdpLyNm0rbkwPrVokACjw=
-----END RSA PRIVATE KEY-----";
        public static string PrivateKey = PrivateKeyRed.Replace("-----BEGIN RSA PRIVATE KEY-----", "")
                .Replace("-----END RSA PRIVATE KEY-----", "");

        private static string PublicKeyRed = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCAPUQwxZ+8499ZneFC94szqOQG
mNmz5TsEVRsOOwRggg4QShkOjBrq/zxc/5AwxYlsjUeH4p1aM+J9ef4q81C/em8M
K5Ab/Rdxrwoj/tulxJR24cKvNyFzlU8ss8eSHeP+AtRGqXbHH+B2xIWBAN0JAdgS
LQC+MSzTE6HdYOerOQIDAQAB
-----END PUBLIC KEY-----";
        public static string PublicKey = PublicKeyRed.Replace("-----BEGIN PUBLIC KEY-----", "")
            .Replace("-----END PUBLIC KEY-----", "");
    }
}
