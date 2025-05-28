namespace UI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            StyleButtons();
            this.Resize += (s, e) => StyleButtons();
        }

        private void manager_Click(object sender, EventArgs e)
        {
            ManagerMenu formManager = new ManagerMenu();
            formManager.Show();
        }

        private void seller_Click(object sender, EventArgs e)
        {
            OrderToCustomer orderToCustomer = new OrderToCustomer();
            orderToCustomer.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void StyleButtons()
        {
            // הגדרת גודל הכפתורים
            Size buttonSize = new Size(300, 80); // יותר גדולים

            // חישוב מיקום מרכזי על המסך
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int centerX = (formWidth - buttonSize.Width) / 2;
            int firstButtonY = (formHeight / 2) - buttonSize.Height - 10;
            int secondButtonY = (formHeight / 2) + 10;

            // עיצוב כפתור מנהל
            manager.Font = new Font("Arial", 18, FontStyle.Bold);
            manager.BackColor = Color.Transparent;
            manager.ForeColor = Color.Black;
            manager.FlatStyle = FlatStyle.Flat;
            manager.FlatAppearance.BorderSize = 2;
            manager.FlatAppearance.BorderColor = Color.Black;
            manager.Size = buttonSize;
            manager.Location = new Point(centerX, firstButtonY);

            // עיצוב כפתור מוכר
            seller.Font = new Font("Arial", 18, FontStyle.Bold);
            seller.BackColor = Color.Transparent;
            seller.ForeColor = Color.Black;
            seller.FlatStyle = FlatStyle.Flat;
            seller.FlatAppearance.BorderSize = 3;
            seller.FlatAppearance.BorderColor = Color.Black;
            seller.Size = buttonSize;
            seller.Location = new Point(centerX, secondButtonY);
        }


    }
}
