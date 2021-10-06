using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MainSocket
    {
        /// <summary>
        /// 判断数据类型
        /// </summary>
        public MainSocketEnum Statue { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
