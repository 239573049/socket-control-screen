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
        /// <summary>
        /// 获取截图返回byte[]
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public byte[] GetScreenByte(Size size)
        {
            MemoryStream ms = new MemoryStream();
            var bitmap = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty, Point.Empty, size);
            g.Dispose();
            bitmap.Save(ms, ImageFormat.Jpeg);
            return ms.GetBuffer();
        }
    }
}
