using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ControlUtil
    {
        enum MouseEventFlag : uint
        {
            Move = 0x0001, //移动鼠标
            LeftDown = 0x0002,//模拟鼠标左键按下
            LeftUp = 0x0004,//模拟鼠标左键抬起
            RightDown = 0x0008,//鼠标右键按下
            RightUp = 0x0010,//鼠标右键抬起
            MiddleDown = 0x0020,//鼠标中键按下
            MiddleUp = 0x0040,//中键抬起
            Wheel = 0x0800,
            Absolute = 0x8000//标示是否采用绝对坐标
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 移动鼠标
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void MoveEvent(int dx, int dy) =>
            SetCursorPos(dx, dy);

        /// <summary>
        /// 左点击
        /// </summary>
        /// <param name="dx">X</param>
        /// <param name="dy">Y</param>
        /// <param name="data"></param>
        public static void MouseLefClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
        /// <summary>
        /// 左按下
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void PressLeft(int dx, int dy)
        {
            mouse_event(MouseEventFlag.LeftDown, dx, dy, 0, UIntPtr.Zero);
        }
        /// <summary>
        /// 左松开
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void LeftUp(int dx, int dy)
        {
            mouse_event(MouseEventFlag.LeftUp, dx, dy, 0, UIntPtr.Zero);
        }
        /// <summary>
        /// 右按下
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void PressRight(int dx, int dy)
        {
            mouse_event(MouseEventFlag.RightDown, dx, dy, 0, UIntPtr.Zero);
        }
        /// <summary>
        /// 右松开
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void RightUp(int dx, int dy)
        {
            mouse_event(MouseEventFlag.RightUp, dx, dy, 0, UIntPtr.Zero);
        }
        /// <summary>
        /// 左双击
        /// </summary>
        /// <param name="dx">X</param>
        /// <param name="dy">Y</param>
        /// <param name="data"></param>
        public static void MouseLefClickEvents(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
        /// <summary>
        /// 右点击
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="data"></param>
        public static void RightDownClickEvent(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
        }
        /// <summary>
        /// 右双击
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="data"></param>
        public static void RightDownClickEvents(int dx, int dy, uint data)
        {
            SetCursorPos(dx, dy);
            mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
            mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
        }
    }
}
