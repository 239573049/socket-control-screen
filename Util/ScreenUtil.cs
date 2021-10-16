using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ScreenUtil
    {
        static MemoryStream ms = new MemoryStream();
        public static Size size = new Size(1920,1080);
        static Bitmap bitmap = new Bitmap(size.Width, size.Height);
        static Graphics g = Graphics.FromImage(bitmap);
        /// <summary>
        /// 获取截图返回byte[]
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GetScreenByte()
        {
            g.CopyFromScreen(Point.Empty, Point.Empty, size);
            bitmap.Save(ms, ImageFormat.Jpeg);
            return ms.GetBuffer();
        }
    }
}
