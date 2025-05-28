using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ManagerMenu : Form
    {

        public ManagerMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            StyleButtons();
            this.Resize += (s, e) => StyleButtons();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            CustomersMenu formCustomers = new CustomersMenu();
            formCustomers.Show();
        }

        private void products_Click(object sender, EventArgs e)
        {
            ProductsMenu formProducts = new ProductsMenu();
            formProducts.Show();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            SalesMenu formSales = new SalesMenu();
            formSales.Show();
        }

        private void StyleButtons()
        {
            // גודל אחיד לכל הכפתורים
            Size buttonSize = new Size(300, 80);

            // חישוב מיקום הכפתורים
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // חישוב רוחב כולל של כל הכפתורים + רווחים ביניהם
            int totalButtonsWidth = (buttonSize.Width * 3) + (20 * 2); // 3 כפתורים + רווחים של 20 פיקסלים ביניהם

            // חישוב המיקום האופקי של הכפתורים כך שהם יהיו ממורכזים
            int startX = (formWidth - totalButtonsWidth) / 2;
            int centerY = (formHeight - buttonSize.Height) / 2;

            // עיצוב כפתור לקוחות (צד ימין)
            customers.Font = new Font("Arial", 18, FontStyle.Bold);
            customers.BackColor = Color.Transparent;
            customers.ForeColor = Color.Black;
            customers.FlatStyle = FlatStyle.Flat;
            customers.FlatAppearance.BorderSize = 2;
            customers.FlatAppearance.BorderColor = Color.Black;
            customers.Size = buttonSize;
            customers.Location = new Point(startX + (buttonSize.Width + 20) * 2, centerY); // זז 320 פיקסלים פעמיים ימינה

            // עיצוב כפתור מוצרים (אמצע)
            products.Font = new Font("Arial", 18, FontStyle.Bold);
            products.BackColor = Color.Transparent;
            products.ForeColor = Color.Black;
            products.FlatStyle = FlatStyle.Flat;
            products.FlatAppearance.BorderSize = 3;
            products.FlatAppearance.BorderColor = Color.Black;
            products.Size = buttonSize;
            products.Location = new Point(startX + buttonSize.Width + 20, centerY); // זז 320 פיקסלים ימינה

            // עיצוב כפתור מבצעים (צד שמאל)
            sales.Font = new Font("Arial", 18, FontStyle.Bold);
            sales.BackColor = Color.Transparent;
            sales.ForeColor = Color.Black;
            sales.FlatStyle = FlatStyle.Flat;
            sales.FlatAppearance.BorderSize = 3;
            sales.FlatAppearance.BorderColor = Color.Black;
            sales.Size = buttonSize;
            sales.Location = new Point(startX, centerY); // זז 320 פיקסלים רק פעם אחת

        }

        private void deleteLogFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
