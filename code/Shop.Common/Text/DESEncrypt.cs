using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Shop.Common
{
    /// <summary>
    /// 数据加密 解密类
    /// 
    /// ThinkWang
    /// 2012-1-26
    /// </summary>
    public static class DESEncrypt
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        public static string Decrypt(string sText)
        {
            return Decrypt(sText, "ThinkWang");
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string sText, string sKey)
        {
            return Decrypt(sText, sKey, CipherMode.CBC);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="sKey"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string Decrypt(string sText, string sKey, CipherMode mode)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = mode;
                int num = sText.Length / 2;
                byte[] buffer = new byte[num];
                for (int i = 0; i < num; i++)
                {
                    int num3 = Convert.ToInt32(sText.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num3;
                }
                if (mode == CipherMode.ECB)
                {
                    provider.Key = Encoding.ASCII.GetBytes(sKey);
                    provider.IV = Encoding.ASCII.GetBytes(sKey);
                }
                else
                {

                    provider.Key = Encoding.ASCII.GetBytes(Md5.Encrypt(sKey, 8));
                    provider.IV = Encoding.ASCII.GetBytes(Md5.Encrypt(sKey, 8));
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.Default.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        public static string Encrypt(string sText)
        {
            return Encrypt(sText, "ThinkWang");
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string sText, string sKey)
        {
            return Encrypt(sText, sKey, CipherMode.CBC);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="sKey"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string Encrypt(string sText, string sKey, CipherMode mode)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = mode;
                byte[] bytes = Encoding.Default.GetBytes(sText);
                if (mode == CipherMode.ECB)
                {
                    provider.Key = Encoding.ASCII.GetBytes(sKey);
                    provider.IV = Encoding.ASCII.GetBytes(sKey);
                }
                else
                {
                    provider.Key = Encoding.ASCII.GetBytes(Md5.Encrypt(sKey, 8));
                    provider.IV = Encoding.ASCII.GetBytes(Md5.Encrypt(sKey, 8));
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
