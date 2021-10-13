using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ListedFilesEntity
    {
        /// <summary>
        /// 大小
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否文件
        /// </summary>
        public bool IsFile { get; set; }
    }
}
