using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;


namespace UI
{
    public partial class OrderForm : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        public int CustomerId { get; set; } // מאפיין לתעודת זהות
        private bool IsClub { get; set; } // לקוח מזדמן - חבר מועדון

        Order Order;
        public OrderForm()
        {
            InitializeComponent();
            Order = new Order();
            this.Load += OrderForm_Load;
            this.WindowState = FormWindowState.Maximized;
        }


        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                //אם מזדמן אז אין לו מועדון ואם הוא קיים יש לו מועדון
                HelloCustomer();
                //הצגת הרשימת קודי המוצרים ב COMBOBOX
                ComboBoxAddProductsDetails();

                sumOrder.Enabled = false;
                InitGrid();

            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת הלקוח",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void addProductToOrder_Click(object sender, EventArgs e)
        {
            try
            {

                if (listProductsInputAdd.SelectedItem == null)
                {
                    MessageBox.Show("נא לבחור מוצר מהרשימה.");
                    return;
                }

                // חילוץ ה-ID מתוך הטקסט של הבחירה
                string selectedText = listProductsInputAdd.SelectedItem.ToString();
                int start = selectedText.LastIndexOf('(') + 1;
                int end = selectedText.LastIndexOf(')');
                string idStr = selectedText.Substring(start, end - start);
                int productId = int.Parse(idStr);

                int amount = (int)amountToOrderProduct.Value;

                _bl.IOrder.AddProductToOrder(Order, productId, amount, IsClub);
                RefreshProductsInOrderList();
                // MessageBox.Show("המוצר נוסף בהצלחה!", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listProductsInputAdd.SelectedIndex = -1;
                amountToOrderProduct.Value = 0;

                //טעינת המוצרים שבעגלה
                ComboBoxDeleteProductsDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteFromOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listProductsInputDelete.SelectedItem == null)
                {
                    MessageBox.Show("נא לבחור מוצר מהרשימה.");
                    return;
                }

                // חילוץ ה-ID מתוך טקסט הבחירה
                string selectedText = listProductsInputDelete.SelectedItem.ToString();
                int start = selectedText.LastIndexOf('(') + 1;
                int end = selectedText.LastIndexOf(')');
                string idStr = selectedText.Substring(start, end - start);
                int productId = int.Parse(idStr);

                var productToRemove = Order.ListProductInOrder
                    .FirstOrDefault(p => p.IdProductInOrder == productId);

                if (productToRemove != null)
                {
                    Order.ListProductInOrder.Remove(productToRemove);
                    _bl.IOrder.CalcTotalPrice(Order);
                    sumOrder.Text = Order.TotalPrice.ToString();
                    RefreshProductsInOrderList();
                    MessageBox.Show("המוצר הוסר מההזמנה.");
                }
                else
                {
                    MessageBox.Show("המוצר לא נמצא בהזמנה.");
                }

                listProductsInputDelete.SelectedIndex = -1;
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת מחיקת המוצר",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void endOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Order.ListProductInOrder == null)
                {
                    MessageBox.Show("עגלת הקניות שלך ריקה",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _bl.IOrder.DoOrder(Order);
                RefreshProductList();
                MessageBox.Show("ההזמנה הושלמה בהצלחה");
                this.Close();
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת סיום הזמנה",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void RefreshProductsInOrderList()
        //{
        //    try
        //    {
        //        List<ProductInOrder?> productsInOrderList = Order.ListProductInOrder;
        //        myOrder.Items.Clear();

        //        foreach (var product in productsInOrderList)
        //        {
        //            if (product != null)
        //            {
        //                //נופל בשורה הזו!
        //                var productDetails = product.ToString() + "\n----------------------------";
        //                // פיצול למיתרים ואז הוספה לכל פריט ברשימה
        //                var productLines = productDetails.Split("\n");
        //                foreach (var line in productLines)
        //                {
        //                    myOrder.Items.Add(line);
        //                }
        //            }
        //            sumOrder.Text = Order.TotalPrice.ToString() + " ₪";
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים",
        //                        "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void RefreshProductList()
        {
            try
            {
                List<Product?> products = _bl.IProduct.ReadAll();
                listProduct.Items.Clear();

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        var productDetails = product.ToString() + "\n----------------------------";
                        // פיצול למיתרים ואז הוספה לכל פריט ברשימה
                        var productLines = productDetails.Split("\n");
                        foreach (var line in productLines)
                        {
                            listProduct.Items.Add(line);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshProductsInOrderList()
        {
            try
            {
                var products = Order.ListProductInOrder ?? new List<ProductInOrder>();
                cardGrid.DataSource = null;
                cardGrid.DataSource = products;

                sumOrder.Text = (Order?.TotalPrice ?? 0).ToString() + " ₪";
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה בעת שליפת המוצרים:\n" + ex.Message,
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //public void HelloCustomer()
        //{
        //    try
        //    {
        //        IsClub = _bl.ICustomer.IsExist(CustomerId);

        //        RefreshProductList();

        //        helloName.Enabled = false;

        //        Customer? customer = _bl.ICustomer.Read(CustomerId);

        //        helloName.Text = customer.NameCustomer;


        //    }
        //    catch (Exception ex)
        //    {
        //        helloName.Text = "לקוח מזדמן😃";
        //    }

        //}
        public void HelloCustomer()
        {
            try
            {
                IsClub = _bl.ICustomer.IsExist(CustomerId);

                RefreshProductList();

                hi.Visible = true;

                Customer? customer = _bl.ICustomer.Read(CustomerId);

                hi.Text = $"הי, {customer.NameCustomer}";
            }
            catch (Exception ex)
            {
                hi.Text = "הי לקוח מזדמן 😃"; // הודעת ברירת מחדל במקרה של שגיאה
            }
        }
        public void ComboBoxAddProductsDetails()
        {
            try
            {
                List<Product?> products = _bl.IProduct.ReadAll();
                listProductsInputAdd.Items.Clear();
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        listProductsInputAdd.Items.Add($"{product.NameProduct} ({product.Id})");
                    }
                }
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת טעינת שמות המוצרים להוספה",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ComboBoxDeleteProductsDetails()
        {
            try
            {
                listProductsInputDelete.Items.Clear();

                if (Order.ListProductInOrder != null)
                {
                    foreach (var product in Order.ListProductInOrder)
                    {
                        string displayText = $"{product.NameProductInOrder} ({product.IdProductInOrder})";
                        listProductsInputDelete.Items.Add(displayText);
                    }
                }
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בעת טעינת שמות המוצרים למחיקה",
                                "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void InitGrid()
        {
            cardGrid.AutoGenerateColumns = false;
            cardGrid.RowTemplate.Height = 40;
            cardGrid.ReadOnly = true;

            cardGrid.Columns.Clear(); // איפוס קודם

            cardGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NameProductInOrder",
                HeaderText = "שם מוצר",
                Name = "NameProductInOrder"
            });

            cardGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BasePrice",
                HeaderText = "מחיר יחידה",
                Name = "BasePrice"
            });

            cardGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "כמות",
                Name = "Amount"
            });

            cardGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FinalPrice",
                HeaderText = "סה\"כ למוצר",
                Name = "FinalPrice"
            });

            cardGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdProductInOrder",
                Name = "IdProductInOrder",
                Visible = false
            });

            // קביעת מקור הנתונים לרשימה ריקה מהסוג המתאים
            cardGrid.DataSource = new List<ProductInOrder>();
        }


    }
}
