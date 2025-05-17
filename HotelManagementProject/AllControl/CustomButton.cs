using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllControl
{
    public class CustomButton : Button
    {
        public CustomButton(string tenphong)
        {
            this.Size = new System.Drawing.Size(230, 300);

            //Calibri, 30.75pt, style=Bold
            Label label = new Label();
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Font = new Font("Calibri", 20, FontStyle.Bold);
            label.AutoSize = true;
            label.Text = tenphong.Trim().ToUpper();
            label.Location = new System.Drawing.Point(
               (this.Location.X + (this.Width - label.Width) / 2) - 20 ,
               this.Location.Y + (this.Width - label.Width) / 2);
            this.Controls.Add(label);
        }
    }
}
