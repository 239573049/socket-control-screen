using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Entity
{
    public class VerificationUtil
    {
        public static void NumeralsLimit(object sender)
        {
            var data = sender as System.Windows.Forms.TextBox;
            if (string.IsNullOrEmpty(data.Text)) return;
            data.Text = Regex.Replace(data.Text, @"[^0-9]+", "");
        }
    }
}
