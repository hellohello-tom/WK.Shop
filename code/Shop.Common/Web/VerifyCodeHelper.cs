using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Shop.Common
{
    /// <summary>
    /// 验证码帮助类
    /// 
    /// ThinkWang 
    /// 2014-3-4
    /// </summary>
    public class VerifyCodeHelper
    {
        private static string verifyCodeSessionKey = ConfigHelper.Get("AppPrefix") + "verifycode";

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="codeW">验证码图片宽度</param>
        /// <param name="codeH">验证码图片高度</param>
        /// <param name="fontSize">验证码图片字体大小</param>
        /// <returns>返回png格式图片</returns>
        public static MemoryStream GetVerifyCodeImg(int codeW = 80, int codeH = 22, int fontSize = 16)
        {
       
           string chkCode = string.Empty;
            //颜色列表，用于验证码
            Color[] fontcolor = { Color.Black};
            //颜色列表，用于噪线、噪点 
            Color[] linecolor = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            string[] font = { "Arial", "Axure Handwriting", "Tekton Pro", "Cooper Std" };
            //验证码的字符集，去掉了一些容易混淆的字符 
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rnd = new Random();
            //生成验证码字符串 
            for (int i = 0; i < 4; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            //写入Session
            SessionHelper.Set(verifyCodeSessionKey, chkCode);
            //创建画布
            Bitmap bmp = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪线 
            for (int i = 0; i < 4; i++)
            {
                int x1 = rnd.Next(codeW);
                int y1 = rnd.Next(codeH);
                int x2 = rnd.Next(codeW);
                int y2 = rnd.Next(codeH);
                Color clr = linecolor[rnd.Next(linecolor.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串 
            for (int i = 0; i < chkCode.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, fontSize);
                Color clr = fontcolor[rnd.Next(fontcolor.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), i * 18 + 2, rnd.Next(-4,4));
            }
            //画噪点 
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color clr = linecolor[rnd.Next(linecolor.Length)];
                bmp.SetPixel(x, y, clr);
            }
            //将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
            MemoryStream ms = new MemoryStream();
            try
            {
                bmp.Save(ms, ImageFormat.Png);
            }
            finally
            {
                //显式释放资源 
                bmp.Dispose();
                g.Dispose();
            }
            
            return ms;
        }

        /// <summary>
        /// 判断验证码是否正确
        /// 
        /// 修复验证码不存在时 报错的问题
        /// </summary>
        /// <param name="code">用户输入的验证码</param>
        /// <returns></returns>
        public static bool IsPass(string code)
        {
            return (SessionHelper.Get<string>((verifyCodeSessionKey)??"")??"").ToLower() == code.ToLower();
        }
    }
}
