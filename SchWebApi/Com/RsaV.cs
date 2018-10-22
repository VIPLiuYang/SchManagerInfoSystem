using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SchWebApi.Com
{
    public class RsaV
    {
        //指数,模数,公钥加密
        public static string DORSAEncTest(string m_strEncryptString)
        {
            string exponent = "010001";
            string modulus =
                "CBF237896A8321444AB6CD9907AA0F9117654D8981DA8D97A7BC8CDCA2072D82C090FD73972951314207E26BB54D4A9351AC8422B4A2033CD05CDA9717EDFC267E0C5332E2F7582AF356670A6FC75887C6D390AA0D0EFF9748FC5E85DC9D4E57063F6102C162BEBE4F9C43AD9E1A11C7CFA14C1E0DBDA70AAC368BBAAC146CC7";

            RSAParameters rsaParameters = new RSAParameters()
            {
                Exponent = Public.HexStringToBytes(exponent), // new byte[] {01, 00, 01}
                Modulus = Public.HexStringToBytes(modulus),   // new byte[] {A3, A6, ...}
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);

            byte[] bytes = new ASCIIEncoding().GetBytes(m_strEncryptString);
            return Public.BytesToHexString(rsa.Encrypt(bytes, false));
        }


        public static string RSAEncTest(string m_strEncryptString)
        {
            string exponent = "010001";
            string modulus =
                "CBF237896A8321444AB6CD9907AA0F9117654D8981DA8D97A7BC8CDCA2072D82C090FD73972951314207E26BB54D4A9351AC8422B4A2033CD05CDA9717EDFC267E0C5332E2F7582AF356670A6FC75887C6D390AA0D0EFF9748FC5E85DC9D4E57063F6102C162BEBE4F9C43AD9E1A11C7CFA14C1E0DBDA70AAC368BBAAC146CC7";

            RSAParameters rsaParameters = new RSAParameters()
            {
                Exponent = FromHex(exponent), // new byte[] {01, 00, 01}
                Modulus = FromHex(modulus),   // new byte[] {A3, A6, ...}
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            byte[] bytes = new ASCIIEncoding().GetBytes(m_strEncryptString);
            return Public.BytesToHexString(rsa.Encrypt(bytes, false));
        }

        public static string RSADecTest(string m_strEncryptString)
        {
            string exponent = "010001";
            string modulus =
                "CBF237896A8321444AB6CD9907AA0F9117654D8981DA8D97A7BC8CDCA2072D82C090FD73972951314207E26BB54D4A9351AC8422B4A2033CD05CDA9717EDFC267E0C5332E2F7582AF356670A6FC75887C6D390AA0D0EFF9748FC5E85DC9D4E57063F6102C162BEBE4F9C43AD9E1A11C7CFA14C1E0DBDA70AAC368BBAAC146CC7";

            RSAParameters rsaParameters = new RSAParameters()
            {
                Exponent = FromHex(exponent), // new byte[] {01, 00, 01}
                Modulus = FromHex(modulus),   // new byte[] {A3, A6, ...}
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            byte[] bytes = new ASCIIEncoding().GetBytes(m_strEncryptString);
            return Public.BytesToHexString(rsa.Decrypt(bytes, false));
        }
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="m_strDecryptString">待解密的数据</param>
        /// <returns>解密后的结果</returns>
        public static string RSADec(string xmlPrivateKey, string m_strDecryptString)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            byte[] result = rsa.Decrypt(Public.HexStringToBytes(m_strDecryptString), false);
            System.Text.ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(result);
        }
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="xmlPublicKey">公钥</param>
        /// <param name="m_strEncryptString">加密后的数据</param>
        /// <returns>RSA公钥加密后的数据</returns>
        public static string RSAEnc(string xmlPublicKey, string m_strEncryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPublicKey);
                byte[] bytes = new ASCIIEncoding().GetBytes(m_strEncryptString);
                str2 = Public.BytesToHexString(provider.Encrypt(bytes, false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }
        //公钥加密私钥解密,私钥签名公钥认证
        /// <summary>
        /// 生成公私钥
        /// </summary>
        /// <param name="PrivateKeyPath"></param>
        /// <param name="PublicKeyPath"></param>
        public void RSAKey(string PrivateKeyPath, string PublicKeyPath)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider(1024);

                this.CreatePrivateKeyXML(PrivateKeyPath, provider.ToXmlString(true));
                this.CreatePublicKeyXML(PublicKeyPath, provider.ToXmlString(false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// generate private key and public key arr[0] for private key arr[1] for public key
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateKeys()
        {
            string[] sKeys = new String[6];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //私钥
            sKeys[0] = rsa.ToXmlString(true);
            //公钥
            sKeys[1] = rsa.ToXmlString(false);
            RSAParameters parameter = rsa.ExportParameters(true);
            sKeys[2] = Public.BytesToHexString(parameter.Exponent);
            sKeys[3] = Public.BytesToHexString(parameter.Modulus);
            parameter = rsa.ExportParameters(false);
            sKeys[4] = Public.BytesToHexString(parameter.Exponent);
            sKeys[5] = Public.BytesToHexString(parameter.Modulus);
            return sKeys;
        }
        /// <summary>
        /// 对原始数据进行MD5加密
        /// </summary>
        /// <param name="m_strSource">待加密数据</param>
        /// <returns>返回机密后的数据</returns>
        public string GetHash(string m_strSource)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create("MD5");
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
            byte[] inArray = algorithm.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="xmlPublicKey">公钥</param>
        /// <param name="m_strEncryptString">MD5加密后的数据</param>
        /// <returns>RSA公钥加密后的数据</returns>
        public static string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPublicKey);
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
                str2 = Convert.ToBase64String(provider.Encrypt(bytes, false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="m_strDecryptString">待解密的数据</param>
        /// <returns>解密后的结果</returns>
        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPrivateKey);
                //
                byte[] rgb = Convert.FromBase64String(m_strDecryptString);
                byte[] buffer2 = provider.Decrypt(rgb, false);
                str2 = new UnicodeEncoding().GetString(buffer2);
                //str2 = Encoding.UTF8.GetString(buffer2);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }
        /// <summary>
        /// 对MD5加密后的密文进行签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">MD5加密后的密文</param>
        /// <returns></returns>
        public static string SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature)
        {
            byte[] rgbHash = Convert.FromBase64String(m_strHashbyteSignature);
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPrivate);
            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("MD5");
            byte[] inArray = formatter.CreateSignature(rgbHash);
            return Convert.ToBase64String(inArray);
        }
        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="p_strHashbyteDeformatter">待验证的用户名</param>
        /// <param name="p_strDeformatterData">注册码</param>
        /// <returns></returns>
        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            try
            {
                byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
                RSACryptoServiceProvider key = new RSACryptoServiceProvider();
                key.FromXmlString(p_strKeyPublic);
                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("MD5");
                byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);
                if (deformatter.VerifySignature(rgbHash, rgbSignature))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 读注册表中指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>返回键值</returns>
        private string ReadReg(string key)
        {
            string temp = "";
            try
            {
                RegistryKey myKey = Registry.LocalMachine;
                RegistryKey subKey = myKey.OpenSubKey(@"SOFTWARE/JX/Register");

                temp = subKey.GetValue(key).ToString();
                subKey.Close();
                myKey.Close();
                return temp;
            }
            catch (Exception)
            {
                throw;//可能没有此注册项;
            }

        }
        /// <summary>
        /// 创建注册表中指定的键和值
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        private void WriteReg(string key, string value)
        {
            try
            {
                RegistryKey rootKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE/JX/Register");
                rootKey.SetValue(key, value);
                rootKey.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 创建公钥文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="publickey"></param>
        public void CreatePublicKeyXML(string path, string publickey)
        {
            try
            {
                FileStream publickeyxml = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(publickeyxml);
                sw.WriteLine(publickey);
                sw.Close();
                publickeyxml.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 创建私钥文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="privatekey"></param>
        public void CreatePrivateKeyXML(string path, string privatekey)
        {
            try
            {
                FileStream privatekeyxml = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(privatekeyxml);
                sw.WriteLine(privatekey);
                sw.Close();
                privatekeyxml.Close();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 读取公钥
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadPublicKey(string path)
        {
            StreamReader reader = new StreamReader(path);
            string publickey = reader.ReadToEnd();
            reader.Close();
            return publickey;
        }
        /// <summary>
        /// 读取私钥
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadPrivateKey(string path)
        {
            StreamReader reader = new StreamReader(path);
            string privatekey = reader.ReadToEnd();
            reader.Close();
            return privatekey;
        }
        /// <summary>
        /// 初始化注册表，程序运行时调用，在调用之前更新公钥xml
        /// </summary>
        /// <param name="path">公钥路径</param>
        public void InitialReg(string path)
        {
            Registry.LocalMachine.CreateSubKey(@"SOFTWARE/JX/Register");
            Random ra = new Random();
            string publickey = this.ReadPublicKey(path);
            if (Registry.LocalMachine.OpenSubKey(@"SOFTWARE/JX/Register").ValueCount <= 0)
            {
                this.WriteReg("RegisterRandom", ra.Next(1, 100000).ToString());
                this.WriteReg("RegisterPublicKey", publickey);
            }
            else
            {
                this.WriteReg("RegisterPublicKey", publickey);
            }
        }
        static void RsaEnc(string[] args)
        {
            string exponent = "010001";
            string modulus =
                "A3A69317FB92A534912A0999A7EEE826358C05F434C5E1E" +
                "DB61C68E882CE52F7573FA44CE46E858673A8A328E17712F" +
                "DAAECF383F13ECC1FD9D1505D2F23C983AD36F951788DEE30F1A" +
                "E2A34F2DB13E46C409980A5467E05C7667AAD896464ABB073AA01AAF" +
                "E130E28FA4D3D6A57ECA8422A482E22C5E0BA67434160B95A68DF";

            RSAParameters rsaParameters = new RSAParameters()
            {
                Exponent = FromHex(exponent), // new byte[] {01, 00, 01}
                Modulus = FromHex(modulus),   // new byte[] {A3, A6, ...}
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            byte[] sample = rsa.Encrypt(Encoding.UTF8.GetBytes("hello world"), false);
        }
        static byte[] FromHex(string hex)
        {
            if (string.IsNullOrEmpty(hex) || hex.Length % 2 != 0) throw new ArgumentException("not a hexidecimal string");
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(hex.Substring(i, 2), 16));
            }
            return bytes.ToArray();
        }
    }
}