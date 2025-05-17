using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllControl
{
    public class TextBoxForIdentificationCard : TextBox
    {
        public TextBoxForIdentificationCard()
        {
            this.KeyPress += TextBoxForIdentificationCard_KeyPress;
            this.Leave += TextBoxForIdentificationCard_Leave;
        }

        private void TextBoxForIdentificationCard_Leave(object sender, EventArgs e)
        {
            if (this.Text.Length != 12 && !this.Text.Equals(string.Empty))
            {
                MessageBox.Show("Nhập đúng CCCD (12 số)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
            }
        }

        private void TextBoxForIdentificationCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }
    }
}
