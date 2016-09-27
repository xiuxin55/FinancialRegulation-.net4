using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialRegulation.UserCotrol2
{
    public class MouseWheelTree :TreeView
    {
        public delegate void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e);

        public event OnMouseWheel MouseWheel;

        
        protected override void WndProc(ref   System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x020A)
            {
                //fwKeys = LOWORD(m.WParam);         //   key   flags 
                //zDelta = (short)HIWORD(m.WParam);         //   wheel   rotation 
                //xPos = (short)LOWORD(m.LParam);         //   horizontal   position   of   pointer 
                //yPos = (short)HIWORD(m.lParam);         //   vertical   position   of   pointer 
                //System.Runtime.InteropServices.Marshal.Copy(m.WParam, wparm, 0, 2);
                if (MouseWheel != null)
                {
                    MouseWheel(this, new MouseEventArgs(MouseButtons.None, 0, 0, 0, (int)m.WParam));
                }
            
            }
            base.WndProc(ref m);
        }

        
    }
}
