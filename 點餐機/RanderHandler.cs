using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal class RanderHandler
    {
        public static event EventHandler<FlowLayoutPanel> handler;

        public static void Notify(FlowLayoutPanel fPanel)
        {  
            handler?.Invoke(null, fPanel);
        }


    }
}
