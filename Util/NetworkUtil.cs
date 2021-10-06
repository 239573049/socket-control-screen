using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class NetworkUtil
    {
        /// <summary>
        /// 获取本机ip列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIPs()
        {
            var ips = new List<string>();
            foreach (IPAddress ipa in Dns.GetHostAddresses(Dns.GetHostName())){
                if (ipa.AddressFamily == AddressFamily.InterNetwork) ips.Add(ipa.ToString());
            }
            return ips;
        }
    }
}
