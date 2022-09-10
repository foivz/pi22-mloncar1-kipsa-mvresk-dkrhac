using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserHelp
{
    public class UserHelpp
    {
        public void OtvoriUserHelp(Form form, string topic)
        {
            string putanja = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

            Help.ShowHelp(form, putanja + "\\UserHelp\\UserHelp.chm", HelpNavigator.Topic, topic);
        }
    }
}
