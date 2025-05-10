using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class OrderToCustomer : Form
    {
        private static IBl _bl = BlApi.Factory.Get();

        public OrderToCustomer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            StyleButton(orderBtn);
            this.Resize += (s, e) => StyleButton(orderBtn);
        }

        private void inputId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // מניעת הקלדה של תו שאינו מספר
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 זה הקוד עבור Backspace
            {
                e.Handled = true; // מונע את הקלדת התו
            }

            // מגביל את מספר הספרות ל-9
            if (inputId.Text.Length >= 9 && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; // מונע הקלדה אחרי 9 ספרות
            }
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OrderForm orderForm = new OrderForm();
                orderForm.CustomerId = int.Parse(inputId.Text);
                orderForm.Show();
                inputId.Text = "";
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת ניסיון לתחילת הזמנה",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleButton(Button btn)
        {
            // הגדרת גודל הכפתור
            Size buttonSize = new Size(300, 80); // יותר גדולים

            // חישוב מיקום מרכזי על המסך
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int centerX = (formWidth - buttonSize.Width) / 2;
            int centerY = (formHeight - buttonSize.Height) / 2;

            // עיצוב הכפתור
            btn.Font = new Font("Arial", 18, FontStyle.Bold);
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.Size = buttonSize;
            btn.Location = new Point(centerX, centerY);
        }
    }
}
