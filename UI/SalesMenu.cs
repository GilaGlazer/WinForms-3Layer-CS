using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    //לעשות עוד בדיקות על דף זה גם על אפשרות להקליד מספרים וכו.....
    public partial class SalesMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public SalesMenu()
        {
            InitializeComponent();
            this.Load += SalesMenu_Load;
            this.WindowState = FormWindowState.Maximized;
        }
        private void SalesMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSalesList();

                idSalePInput.Enabled = false;
                minAmountSaleInputUpdate.Enabled = false;
                fainalPriceInputUpdate.Enabled = false;
                startSaleDateInputUpdate.Enabled = false;
                lastSaleDateInputUpdate.Enabled = false;
                isOnlyClubInputUpdate.Enabled = false;
                saveUpdatedBtn.Enabled = false;

                startSaleDateInput.Value = DateTime.Now;
                lastSaleDateInput.Value = DateTime.Now.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המבצע" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void searchSaleBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idSaleInput.Text))
            {
                MessageBox.Show("הכנס קוד מבצע.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int saleId = int.Parse(idSaleInput.Text);

                Sale p = _bl.ISale.Read(saleId);
                if (p == null)
                {
                    MessageBox.Show("קוד מבצע שגוי.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idSalePInput.Text = Convert.ToString(p.IdSaleP);
                minAmountSaleInputUpdate.Text = Convert.ToString(p.MinAmountSale);
                isOnlyClubInputUpdate.Checked = Convert.ToBoolean(p.IsOnlyClub);
                fainalPriceInputUpdate.Text = Convert.ToString(p.FainalPrice);
                startSaleDateInputUpdate.Value = Convert.ToDateTime(p.StartSaleDate);
                lastSaleDateInputUpdate.Value = Convert.ToDateTime(p.LastSaleDate);

                idSalePInput.Enabled = true;
                minAmountSaleInputUpdate.Enabled = true;
                fainalPriceInputUpdate.Enabled = true;
                startSaleDateInputUpdate.Enabled = true;
                lastSaleDateInputUpdate.Enabled = true;
                isOnlyClubInputUpdate.Enabled = true;
                saveUpdatedBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת חיפוש מבצע" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addSaleBtn_Click(object sender, EventArgs e)
        {
            // בדיקה שכל השדות מולאו
            if (string.IsNullOrWhiteSpace(idSaleProductInput.Text) ||
                string.IsNullOrWhiteSpace(minAmountSaleInput.Text) ||
                string.IsNullOrWhiteSpace(fainalPriceInput.Text))
            {
                MessageBox.Show("אנא מלאי את כל השדות לפני הוספת המבצע.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Sale s = new Sale();
                s.IdSaleP = int.Parse(idSaleProductInput.Text);
                s.MinAmountSale = int.Parse(minAmountSaleInput.Text);
                s.IsOnlyClub = isOnlyClubInput.Checked;
                s.FainalPrice = int.Parse(fainalPriceInput.Text);
                s.StartSaleDate = startSaleDateInput.Value;
                s.LastSaleDate = lastSaleDateInput.Value;

                _bl.ISale.Create(s);

                RefreshSalesList();
                MessageBox.Show("המבצע נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // איפוס הטופס
                idSaleInput.Text = "";
                idSaleProductInput.Text = "";
                minAmountSaleInput.Text = "";
                isOnlyClubInput.Checked = false;
                fainalPriceInput.Text = "";
                startSaleDateInput.Value = DateTime.Now;
                lastSaleDateInput.Value = DateTime.Now.AddDays(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בהוספת המבצע: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RefreshSalesList()
        {
            try
            {
                List<Sale?> sales = _bl.ISale.ReadAll();
                salesListBox.Items.Clear();

                foreach (var sale in sales)
                {
                    if (sale != null)
                    {
                        var saleDetails = sale.ToString() + "\n----------------------------";

                        var saleLines = saleDetails.Split("\n");
                        foreach (var line in saleLines)
                        {
                            salesListBox.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המבצעים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveUpdatedBtn_Click(object sender, EventArgs e)
        {

            int saleId = int.Parse(idSaleInput.Text);

            if (saleId == null)
            {
                MessageBox.Show("לא נמצא מבצע עם הקוד שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Sale updatedSale = new Sale()
            {
                IdSale = saleId,
                IdSaleP = int.Parse(idSalePInput.Text),
                MinAmountSale = (int)minAmountSaleInputUpdate.Value,
                FainalPrice = (int)fainalPriceInputUpdate.Value,
                IsOnlyClub = isOnlyClubInputUpdate.Checked,
                StartSaleDate = startSaleDateInputUpdate.Value,
                LastSaleDate = lastSaleDateInputUpdate.Value,

            };


            try
            {
                _bl.ISale.Update(updatedSale);
                RefreshSalesList();
                MessageBox.Show("המבצע עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // איפוס הטופס
                idSaleInput.Text = "";
                idSalePInput.Text = "";
                minAmountSaleInputUpdate.Value = minAmountSaleInputUpdate.Minimum;
                fainalPriceInputUpdate.Value = fainalPriceInputUpdate.Minimum;
                isOnlyClubInputUpdate.Checked = false;
                startSaleDateInputUpdate.Value = DateTime.Now;
                lastSaleDateInput.Value = DateTime.Now.AddDays(1);

                idSalePInput.Enabled = false;
                minAmountSaleInputUpdate.Enabled = false;
                fainalPriceInputUpdate.Enabled = false;
                startSaleDateInputUpdate.Enabled = false;
                lastSaleDateInputUpdate.Enabled = false;
                isOnlyClubInputUpdate.Enabled = false;
                saveUpdatedBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון המבצע" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int codeSale;
                if (int.TryParse(codeSaleInputToDelete.Text, out codeSale))
                {
                    // כאן תוכל להוסיף את הקוד למחיקת המבצע מה-BL
                    _bl.ISale.Delete(codeSale);
                    RefreshSalesList();
                    // הצגת הודעה שהמבצע נמחק בהצלחה
                    MessageBox.Show("המבצע נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    codeSaleInputToDelete.Text = "";
                }
                else
                {
                    // הצגת הודעה אם הקלט לא תקין
                    MessageBox.Show("אנא הכנס קוד מבצע תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת מבצע" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void showDetailsSale_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer;
                if (!int.TryParse(codeSaleInputSearch.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד מבצע תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailsSale.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.ISale.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailsSale.Items.Add(line);
                    }
                    codeSaleInputSearch.Text = "";
                }
                else
                {
                    MessageBox.Show("לא נמצא מבצע עם הקוד הזה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המבצע" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //פעם ראשונה להצגה עובד פעם שניה לא-------------------------
        }


        private void FilterSalesByCode(string codeInput)
        {
            try
            {
                List<Sale?> filteredDeals = _bl.ISale.ReadAll(d => d != null && d.IdSale.ToString().Contains(codeInput))
                    .ToList();
                salesListBox.Items.Clear();


                foreach (var deal in filteredDeals)
                {
                    var dealDetails = deal?.ToString() + "\n----------------------------";
                    var dealLines = dealDetails.Split('\n');
                    foreach (var line in dealLines)
                    {
                        salesListBox.Items.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון המבצעים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void filterByDealCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string codeInput = filterByCodeSale.Text;

                if (string.IsNullOrEmpty(codeInput))
                {
                    RefreshSalesList(); // טוען את כל המבצעים אם אין קלט
                }
                else
                {
                    FilterSalesByCode(codeInput); // מסנן לפי הקלט
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת סינון מבצעים" + ex.Message,
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
        private void idSaleProductInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void idSaleInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }

        private void idSalePInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void codeSaleInputSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void codeSaleInputToDelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }

    }
}
