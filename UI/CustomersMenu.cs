using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;


namespace UI
{
    public partial class CustomersMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();

        public CustomersMenu()
        {
            InitializeComponent();
            this.Load += CustomersMenu_Load;
            this.WindowState = FormWindowState.Maximized;
        }

        private void CustomersMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshCustomerList();



                updateBtnCustomer.Enabled = false;
                nameCustomerUpdate.Enabled = false;
                idCustomerUpdate.Enabled = false;
                addressCustomerUpdate.Enabled = false;
                phoneCustomerUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות: " + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshCustomerList()
        {
            try
            {
                List<Customer?> customers = _bl.ICustomer.ReadAll();
                customersList.Items.Clear();

                foreach (var customer in customers)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            customersList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // בדיקה שכל השדות מולאו
            if (string.IsNullOrWhiteSpace(CustomerNameInput.Text) ||
                string.IsNullOrWhiteSpace(CustomerIdInput.Text) ||
                string.IsNullOrWhiteSpace(CustomerAddressInput.Text) ||
                string.IsNullOrWhiteSpace(CustomerTelInput.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות לפני ההוספה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer c = new Customer();
                c.NameCustomer = CustomerNameInput.Text;
                c.Id = int.Parse(CustomerIdInput.Text);
                c.Address = CustomerAddressInput.Text;
                c.Phone = CustomerTelInput.Text;

                _bl.ICustomer.Create(c);

                RefreshCustomerList();
                MessageBox.Show("הלקוח נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // איפוס הטופס
                CustomerNameInput.Text = "";
                CustomerIdInput.Text = "";
                CustomerAddressInput.Text = "";
                CustomerTelInput.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בהוספת הלקוח" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void searchBtnCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeCustomerInput.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = int.Parse(codeCustomerInput.Text);
            try
            {
                Customer? c = _bl.ICustomer.Read(customerId);
                if (c == null)
                {
                    MessageBox.Show("לא נמצא לקוח בת.ז זו", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    codeCustomerInput.Text = "";
                    return;
                }
                nameCustomerUpdate.Text = c.NameCustomer;
                idCustomerUpdate.Text = Convert.ToString(c.Id);
                addressCustomerUpdate.Text = c.Address;
                phoneCustomerUpdate.Text = c.Phone;


                codeCustomerInput.ReadOnly = true;

                updateBtnCustomer.Enabled = true;
                nameCustomerUpdate.Enabled = true;
                addressCustomerUpdate.Enabled = true;
                phoneCustomerUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בעת חיפוש לקוח לעידכון" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtnCustomer_Click(object sender, EventArgs e)
        {

            int customerId = int.Parse(codeCustomerInput.Text);

            if (customerId == null)
            {
                MessageBox.Show("לא נמצא לקוח עם התעודת זהות שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer updatedCustomer = new Customer()
            {
                Id = customerId,
                NameCustomer = nameCustomerUpdate.Text,
                Address = addressCustomerUpdate.Text,
                Phone = phoneCustomerUpdate.Text
            };


            try
            {
                _bl.ICustomer.Update(updatedCustomer);
                RefreshCustomerList();
                MessageBox.Show("הלקוח עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeCustomerInput.ReadOnly = false;
                idCustomerUpdate.ReadOnly = false;

                // איפוס הטופס
                nameCustomerUpdate.Text = "";
                codeCustomerInput.Text = "";
                idCustomerUpdate.Text = "";
                addressCustomerUpdate.Text = "";
                phoneCustomerUpdate.Text = "";

                updateBtnCustomer.Enabled = false;
                nameCustomerUpdate.Enabled = false;
                idCustomerUpdate.Enabled = false;
                addressCustomerUpdate.Enabled = false;
                phoneCustomerUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון הלקוח" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codeCustomerInputToDelete.Text))
                {
                    MessageBox.Show("אנא מלא את כל השדות .", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int codeCustomer;
                if (int.TryParse(codeCustomerInputToDelete.Text, out codeCustomer))
                {

                    _bl.ICustomer.Delete(codeCustomer);

                    RefreshCustomerList();
                    MessageBox.Show("הלקוח נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codeCustomerInputToDelete.Text = "";
                }
                else
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה במחיקת לקוח." + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer;
                if (!int.TryParse(idCustomerDisplay.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailCustomer.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.ICustomer.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailCustomer.Items.Add(line);
                    }
                    idCustomerDisplay.Text = "";
                }
                else
                {
                    MessageBox.Show("לא נמצא לקוח עם הקוד הזה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוח" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //סינון לקוחות לפי שם
        private void NameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nameInput = filterByPhone.Text; // הטקסט שהוזן בחיפוש שם

                // אם לא הוזן שם, טוענים את כל הלקוחות
                if (string.IsNullOrEmpty(nameInput))
                {
                    RefreshCustomerList(); // טוען את כל הלקוחות
                }
                else
                {
                    FilterCustomersByName(nameInput); // מסנן את הלקוחות לפי שם
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCustomersByName(string nameInput)
        {
            try
            {
                List<Customer?> filteredCustomers = _bl.ICustomer.ReadAll(c => c?.NameCustomer?.Contains(nameInput, StringComparison.OrdinalIgnoreCase) == true).ToList();
                customersList.Items.Clear();
                foreach (var customer in filteredCustomers)
                {
                    if (customer != null)
                    {
                        var customerDetails = customer.ToString() + "\n----------------------------";
                        var customerLines = customerDetails.Split("\n");
                        foreach (var line in customerLines)
                        {
                            customersList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון הלקוחות" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ValidKeyPress(KeyPressEventArgs e)
        {
            // אם התו הוא לא ספרה, אז נבטל את הקלט
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 זה מקש Backspace
            {
                e.Handled = true;  // מבטל את הקלדת התו
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void CustomerTelInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void codeCustomerInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void idCustomerDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void codeCustomerInputToDelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void phoneCustomerUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
    }
}
