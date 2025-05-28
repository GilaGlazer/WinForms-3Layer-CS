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
    //מזה LISTSALEINPROSUCT האם צריך להציג בשבילו את המבצעים??????
    public partial class ProductsMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public ProductsMenu()
        {
            InitializeComponent();
            this.Load += ProductsMenu_Load;
            this.WindowState = FormWindowState.Maximized;
        }

        private void ProductsMenu_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshProductList();
                // עדכון קטגוריות
                categoryUpdate.DataSource = Enum.GetValues(typeof(CategoryProduct));

                nameProduct.Enabled = false;
                categoryUpdate.Enabled = false;
                amount.Enabled = false;
                price.Enabled = false;
                updateBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nameProductInput.Text) ||
               string.IsNullOrWhiteSpace(categoryInput.Text) ||
               priceInput.Value == 0 ||
               amountInput.Value == 0)
                {
                    MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Product p = new Product();
                p.NameProduct = nameProductInput.Text;
                p.Category = (CategoryProduct)Enum.Parse(typeof(CategoryProduct), categoryInput.SelectedItem.ToString());
                p.Price = (int)priceInput.Value;
                p.Amount = (int)amountInput.Value;

                _bl.IProduct.Create(p);
                RefreshProductList();
                MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // איפוס הטופס
                nameProductInput.Text = "";
                categoryInput.SelectedIndex = -1;
                priceInput.Value = 0;
                amountInput.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת הוספת מוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int codeProduct;
                if (int.TryParse(codeInputToDelete.Text, out codeProduct))
                {
                    // כאן תוכל להוסיף את הקוד למחיקת המוצר מה-BL
                    _bl.IProduct.Delete(codeProduct);

                    // הצגת הודעה שהמוצר נמחק בהצלחה
                    MessageBox.Show("המוצר נמחק בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductList();
                    codeInputToDelete.Text = "";
                }
                else
                {
                    // הצגת הודעה אם הקלט לא תקין
                    MessageBox.Show("אנא הכנס קוד מוצר תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת המוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            int productId = int.Parse(codeProductInput.Text);

            if (productId == null)
            {
                MessageBox.Show("לא נמצא מוצר עם השם שהוזן", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product updatedProduct = new Product()
            {
                Id = productId,
                NameProduct = string.IsNullOrEmpty(nameProduct.Text) ? "שם מוצר ברירת מחדל" : nameProduct.Text,
                Category = categoryUpdate.SelectedItem == null ? CategoryProduct.Bracelets : (CategoryProduct)Enum.Parse(typeof(CategoryProduct), categoryUpdate.SelectedItem.ToString()),
                Price = price.Value == 0 ? 0 : (int)price.Value,
                Amount = amount.Value == 0 ? 0 : (int)amount.Value
            };


            try
            {
                _bl.IProduct.Update(updatedProduct);
                RefreshProductList();
                MessageBox.Show("המוצר עודכן בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                codeProductInput.ReadOnly = false;

                // איפוס הטופס
                codeProductInput.Text = "";
                nameProduct.Text = "";
                categoryUpdate.SelectedIndex = -1;
                price.Value = 0;
                amount.Value = 0;


                nameProduct.Enabled = false;
                categoryUpdate.Enabled = false;
                amount.Enabled = false;
                price.Enabled = false;
                updateBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת עדכון המוצר" + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void displayProducts_Click(object sender, EventArgs e)
        {
            try
            {
                // שליפת כל המוצרים מהמלאי
                List<Product?> products = _bl.IProduct.ReadAll();

                // ניקוי הרשימה לפני שמכניסים את החדשים
                productsList.Items.Clear();

                // הוספת המוצרים לתצוגה (אפשר לעצב איך שרוצים)
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        productsList.Items.Add(
                            $"שם: {product.NameProduct}, קטגוריה: {product.Category}, מחיר: {product.Price} ₪, כמות: {product.Amount}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeProductInput.Text))
            {
                MessageBox.Show("אנא מלא את כל השדות.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int productId = int.Parse(codeProductInput.Text);
            try
            {
                Product p = _bl.IProduct.Read(productId);
                if (p == null)
                {
                    MessageBox.Show("קוד מוצר שגוי.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nameProduct.Text = p.NameProduct;
                categoryUpdate.SelectedItem = p.Category;
                price.Value = (int)p.Price;
                amount.Value = (int)p.Amount;

                codeProductInput.ReadOnly = true;

                nameProduct.Enabled = true;
                categoryUpdate.Enabled = true;
                amount.Enabled = true;
                price.Enabled = true;
                updateBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת חיפוש המוצר" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProductList()
        {
            try
            {
                List<Product?> products = _bl.IProduct.ReadAll();
                productsList.Items.Clear();

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer;
                if (!int.TryParse(idProductSearch.Text, out idCustomer))
                {
                    MessageBox.Show("אנא הכנס קוד לקוח תקין.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // עצור את הפעולה אם ההמרה לא הצליחה
                }

                detailProductOne.Items.Clear(); // ניקוי פריטים קודמים

                var customer = _bl.IProduct.Read(idCustomer);

                if (customer != null)
                {
                    var customerDetails = customer.ToString();
                    var customerLines = customerDetails.Split("\n");
                    foreach (var line in customerLines)
                    {
                        detailProductOne.Items.Add(line);
                    }
                    idProductSearch.Text = "";
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

        //סינון לפי קטגוריה
        private void filterCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (filterCategory.SelectedItem == null) return;

            CategoryProduct selectedCategory = (CategoryProduct)Enum.Parse(typeof(CategoryProduct), filterCategory.SelectedItem.ToString());

            try
            {
                List<Product?> filteredProducts = _bl.IProduct.ReadAll(p => p != null && p.Category == selectedCategory).ToList();

                productsList.Items.Clear();
                foreach (var product in filteredProducts)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            productsList.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בסינון לפי קטגוריה" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cleanFilter_Click(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        private void ValidKeyPress(KeyPressEventArgs e)
        {
            // אם התו הוא לא ספרה, אז נבטל את הקלט
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)  // (char)8 זה מקש Backspace
            {
                e.Handled = true;  // מבטל את הקלדת התו
            }
        }
        private void codeProductInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void codeInputToDelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
        private void idProductSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidKeyPress(e);
        }
    }
}
