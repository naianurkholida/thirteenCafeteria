using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thirteenCafeteria
{
    public class CloneGroupbox
    {
        public GroupBox clone(GroupBox original, string menu, string harga)
        {
            GroupBox cloned = new GroupBox
            {
                Text = original.Text,
                Width = original.Width,
                Height = original.Height,
                Location = new Point(original.Location.X, original.Location.Y + original.Height + 10)
            };
            cloneControl(cloned, menu, harga);
            return cloned;
        }

        public void cloneControl(GroupBox original, string menu, string harga) 
        {
            foreach(Control control in original.Controls)
            {
                if(control is Label label)
                {
                    Label lbl = (Label)Activator.CreateInstance(control.GetType());
                    if(lbl.Name == "txt_menu")
                    {
                        lbl.Text = menu;
                        lbl.Size = label.Size;
                        lbl.Location = label.Location;
                        original.Controls.Add(lbl);
                    }
                    else if(lbl.Name == "txt_harga")
                    {
                        lbl.Text = harga;
                        lbl.Size = label.Size;
                        lbl.Location = label.Location;
                        original.Controls.Add(lbl);
                    }
                    else
                    {
                        lbl.Text = label.Text;
                        lbl.Size = label.Size;
                        lbl.Location = label.Location;
                        original.Controls.Add(lbl);
                    }
                }
                else
                {
                    Control newControl = (Control)Activator.CreateInstance(control.GetType());
                    newControl.Text = control.Text;
                    newControl.Size = control.Size;
                    newControl.Location = control.Location;
                    original.Controls.Add(newControl);
                }

                
            }
        }
    }
}
