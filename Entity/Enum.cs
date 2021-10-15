using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum MainSocketEnum
    {
        /// <summary>
        /// 文件流
        /// </summary>
        File = 0,
        /// <summary>
        /// 粘贴板
        /// </summary>
        Clipboard,
        /// <summary>
        /// 屏幕流
        /// </summary>
        Screen,
        /// <summary>
        /// 键盘
        /// </summary>
        Keyboard,
        /// <summary>
        /// 左单机鼠标
        /// </summary>
        LeftClick,
        /// <summary>
        /// 左双击鼠标
        /// </summary>
        LeftClicks,
        /// <summary>
        /// 右单机鼠标
        /// </summary>
        RightClick,
        /// <summary>
        /// 右双击鼠标
        /// </summary>
        RightClicks,
        /// <summary>
        /// 移动鼠标
        /// </summary>
        Move,
        /// <summary>
        /// 左按下
        /// </summary>
        PressLeft,
        /// <summary>
        /// 左松开
        /// </summary>
        LeftUp,
        /// <summary>
        /// 右按下
        /// </summary>
        PressRight,
        /// <summary>
        /// 右松开
        /// </summary>
        RightUp,
        /// <summary>
        /// 主动断开连接
        /// </summary>
        Break,
        /// <summary>
        /// 文件列表
        /// </summary>
        ListedFiles,
        /// <summary>
        /// 文件列表是否存在
        /// </summary>
        FilesExists,
        /// <summary>
        /// 请求文件
        /// </summary>
        DemandFile
    }
}
