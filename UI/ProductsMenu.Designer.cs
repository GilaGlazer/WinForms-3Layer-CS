
namespace UI
{
    partial class ProductsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsMenu));
            productsList = new ListBox();
            delete = new TabPage();
            deleteBtn = new Button();
            codeInputToDelete = new TextBox();
            codeProductToDelete = new Label();
            update = new TabPage();
            searchBtn = new Button();
            codeProductInput = new TextBox();
            label5 = new Label();
            amount = new NumericUpDown();
            label1 = new Label();
            categoryUpdate = new ComboBox();
            label2 = new Label();
            updateBtn = new Button();
            price = new NumericUpDown();
            nameProduct = new TextBox();
            label3 = new Label();
            label4 = new Label();
            addCustomer = new TabPage();
            amountInput = new NumericUpDown();
            amountLable = new Label();
            categoryInput = new ComboBox();
            category = new Label();
            addProduct = new Button();
            priceInput = new NumericUpDown();
            nameProductInput = new TextBox();
            priceLable = new Label();
            nameProductLable = new Label();
            add = new TabControl();
            detailProduct = new TabPage();
            detailProductOne = new ListBox();
            showDetailsProduct = new Button();
            idProductSearch = new TextBox();
            label10 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            label11 = new Label();
            filterCategory = new ComboBox();
            cleanFilter = new Button();
            delete.SuspendLayout();
            update.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)price).BeginInit();
            addCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            add.SuspendLayout();
            detailProduct.SuspendLayout();
            SuspendLayout();
            // 
            // productsList
            // 
            productsList.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            productsList.FormattingEnabled = true;
            productsList.ItemHeight = 31;
            productsList.Location = new Point(1220, 271);
            productsList.Margin = new Padding(2, 3, 2, 3);
            productsList.Name = "productsList";
            productsList.Size = new Size(456, 469);
            productsList.TabIndex = 1;
            // 
            // delete
            // 
            delete.Controls.Add(deleteBtn);
            delete.Controls.Add(codeInputToDelete);
            delete.Controls.Add(codeProductToDelete);
            delete.Location = new Point(4, 40);
            delete.Name = "delete";
            delete.Padding = new Padding(3);
            delete.Size = new Size(593, 538);
            delete.TabIndex = 2;
            delete.Text = "מחיקה";
            delete.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(210, 253);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(195, 45);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "מחיקה";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // codeInputToDelete
            // 
            codeInputToDelete.Location = new Point(211, 184);
            codeInputToDelete.Name = "codeInputToDelete";
            codeInputToDelete.Size = new Size(194, 38);
            codeInputToDelete.TabIndex = 1;
            codeInputToDelete.KeyPress += codeInputToDelete_KeyPress;
            // 
            // codeProductToDelete
            // 
            codeProductToDelete.AutoSize = true;
            codeProductToDelete.Location = new Point(194, 120);
            codeProductToDelete.Name = "codeProductToDelete";
            codeProductToDelete.Size = new Size(243, 33);
            codeProductToDelete.TabIndex = 0;
            codeProductToDelete.Text = "הקש קוד מוצר למחיקה";
            // 
            // update
            // 
            update.Controls.Add(searchBtn);
            update.Controls.Add(codeProductInput);
            update.Controls.Add(label5);
            update.Controls.Add(amount);
            update.Controls.Add(label1);
            update.Controls.Add(categoryUpdate);
            update.Controls.Add(label2);
            update.Controls.Add(updateBtn);
            update.Controls.Add(price);
            update.Controls.Add(nameProduct);
            update.Controls.Add(label3);
            update.Controls.Add(label4);
            update.Location = new Point(4, 40);
            update.Name = "update";
            update.Padding = new Padding(3);
            update.Size = new Size(593, 538);
            update.TabIndex = 1;
            update.Text = "עדכון";
            update.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(26, 22);
            searchBtn.Margin = new Padding(2, 3, 2, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(91, 44);
            searchBtn.TabIndex = 20;
            searchBtn.Text = "חפש";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // codeProductInput
            // 
            codeProductInput.Location = new Point(140, 26);
            codeProductInput.Name = "codeProductInput";
            codeProductInput.Size = new Size(171, 38);
            codeProductInput.TabIndex = 19;
            codeProductInput.KeyPress += codeProductInput_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(326, 27);
            label5.Name = "label5";
            label5.Size = new Size(236, 33);
            label5.TabIndex = 18;
            label5.Text = "הכנס קוד מוצר לעידכון";
            // 
            // amount
            // 
            amount.Location = new Point(100, 287);
            amount.Name = "amount";
            amount.Size = new Size(228, 38);
            amount.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(432, 287);
            label1.Name = "label1";
            label1.Size = new Size(67, 33);
            label1.TabIndex = 16;
            label1.Text = "כמות";
            // 
            // categoryUpdate
            // 
            categoryUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryUpdate.FormattingEnabled = true;
            categoryUpdate.Items.AddRange(new object[] { "Necklaces ", "Bracelets", "Rings    ", "Earrings  ", "Watches      " });
            categoryUpdate.Location = new Point(100, 169);
            categoryUpdate.Name = "categoryUpdate";
            categoryUpdate.Size = new Size(224, 39);
            categoryUpdate.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 172);
            label2.Name = "label2";
            label2.Size = new Size(97, 33);
            label2.TabIndex = 14;
            label2.Text = "קטגוריה";
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(100, 357);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(398, 60);
            updateBtn.TabIndex = 13;
            updateBtn.Text = "עדכן";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // price
            // 
            price.Location = new Point(100, 227);
            price.Name = "price";
            price.Size = new Size(227, 38);
            price.TabIndex = 12;
            // 
            // nameProduct
            // 
            nameProduct.Location = new Point(100, 107);
            nameProduct.Name = "nameProduct";
            nameProduct.Size = new Size(211, 38);
            nameProduct.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(432, 232);
            label3.Name = "label3";
            label3.Size = new Size(66, 33);
            label3.TabIndex = 10;
            label3.Text = "מחיר";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(395, 107);
            label4.Name = "label4";
            label4.Size = new Size(103, 33);
            label4.TabIndex = 9;
            label4.Text = "שם מוצר";
            // 
            // addCustomer
            // 
            addCustomer.Controls.Add(amountInput);
            addCustomer.Controls.Add(amountLable);
            addCustomer.Controls.Add(categoryInput);
            addCustomer.Controls.Add(category);
            addCustomer.Controls.Add(addProduct);
            addCustomer.Controls.Add(priceInput);
            addCustomer.Controls.Add(nameProductInput);
            addCustomer.Controls.Add(priceLable);
            addCustomer.Controls.Add(nameProductLable);
            addCustomer.Location = new Point(4, 40);
            addCustomer.Name = "addCustomer";
            addCustomer.Padding = new Padding(3);
            addCustomer.Size = new Size(593, 538);
            addCustomer.TabIndex = 0;
            addCustomer.Text = "הוספה";
            addCustomer.UseVisualStyleBackColor = true;
            // 
            // amountInput
            // 
            amountInput.Location = new Point(156, 255);
            amountInput.Name = "amountInput";
            amountInput.Size = new Size(150, 38);
            amountInput.TabIndex = 8;
            // 
            // amountLable
            // 
            amountLable.AutoSize = true;
            amountLable.Location = new Point(386, 255);
            amountLable.Name = "amountLable";
            amountLable.Size = new Size(67, 33);
            amountLable.TabIndex = 7;
            amountLable.Text = "כמות";
            // 
            // categoryInput
            // 
            categoryInput.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryInput.FormattingEnabled = true;
            categoryInput.Items.AddRange(new object[] { "Necklaces ", "Bracelets", "Rings    ", "Earrings  ", "Watches      " });
            categoryInput.Location = new Point(155, 109);
            categoryInput.Name = "categoryInput";
            categoryInput.Size = new Size(189, 39);
            categoryInput.TabIndex = 6;
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(356, 115);
            category.Name = "category";
            category.Size = new Size(97, 33);
            category.TabIndex = 5;
            category.Text = "קטגוריה";
            // 
            // addProduct
            // 
            addProduct.Location = new Point(147, 324);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(306, 61);
            addProduct.TabIndex = 4;
            addProduct.Text = "שמור";
            addProduct.UseVisualStyleBackColor = true;
            addProduct.Click += addProduct_Click;
            // 
            // priceInput
            // 
            priceInput.Location = new Point(156, 179);
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(150, 38);
            priceInput.TabIndex = 3;
            // 
            // nameProductInput
            // 
            nameProductInput.Location = new Point(156, 46);
            nameProductInput.Name = "nameProductInput";
            nameProductInput.Size = new Size(188, 38);
            nameProductInput.TabIndex = 2;
            // 
            // priceLable
            // 
            priceLable.AutoSize = true;
            priceLable.Location = new Point(387, 184);
            priceLable.Name = "priceLable";
            priceLable.Size = new Size(66, 33);
            priceLable.TabIndex = 1;
            priceLable.Text = "מחיר";
            // 
            // nameProductLable
            // 
            nameProductLable.AutoSize = true;
            nameProductLable.Location = new Point(350, 49);
            nameProductLable.Name = "nameProductLable";
            nameProductLable.Size = new Size(103, 33);
            nameProductLable.TabIndex = 0;
            nameProductLable.Text = "שם מוצר";
            // 
            // add
            // 
            add.Controls.Add(addCustomer);
            add.Controls.Add(update);
            add.Controls.Add(delete);
            add.Controls.Add(detailProduct);
            add.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            add.Location = new Point(552, 228);
            add.Name = "add";
            add.RightToLeft = RightToLeft.Yes;
            add.RightToLeftLayout = true;
            add.SelectedIndex = 0;
            add.Size = new Size(601, 582);
            add.TabIndex = 1;
            // 
            // detailProduct
            // 
            detailProduct.Controls.Add(detailProductOne);
            detailProduct.Controls.Add(showDetailsProduct);
            detailProduct.Controls.Add(idProductSearch);
            detailProduct.Controls.Add(label10);
            detailProduct.Location = new Point(4, 40);
            detailProduct.Margin = new Padding(3, 4, 3, 4);
            detailProduct.Name = "detailProduct";
            detailProduct.Size = new Size(593, 538);
            detailProduct.TabIndex = 3;
            detailProduct.Text = "פרטי מוצר";
            detailProduct.UseVisualStyleBackColor = true;
            // 
            // detailProductOne
            // 
            detailProductOne.FormattingEnabled = true;
            detailProductOne.ItemHeight = 31;
            detailProductOne.Location = new Point(77, 189);
            detailProductOne.Margin = new Padding(3, 4, 3, 4);
            detailProductOne.Name = "detailProductOne";
            detailProductOne.RightToLeft = RightToLeft.No;
            detailProductOne.Size = new Size(445, 283);
            detailProductOne.TabIndex = 9;
            // 
            // showDetailsProduct
            // 
            showDetailsProduct.Location = new Point(77, 119);
            showDetailsProduct.Name = "showDetailsProduct";
            showDetailsProduct.Size = new Size(445, 45);
            showDetailsProduct.TabIndex = 8;
            showDetailsProduct.Text = "הצג פרטי מוצר";
            showDetailsProduct.UseVisualStyleBackColor = true;
            showDetailsProduct.Click += showDetailsProduct_Click;
            // 
            // idProductSearch
            // 
            idProductSearch.Location = new Point(121, 60);
            idProductSearch.Name = "idProductSearch";
            idProductSearch.Size = new Size(183, 38);
            idProductSearch.TabIndex = 7;
            idProductSearch.KeyPress += idProductSearch_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(310, 63);
            label10.Name = "label10";
            label10.Size = new Size(161, 33);
            label10.TabIndex = 6;
            label10.Text = "הכנס קוד מוצר";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(1471, 193);
            label11.Name = "label11";
            label11.Size = new Size(174, 33);
            label11.TabIndex = 6;
            label11.Text = "סנן לפי קטגוריה";
            // 
            // filterCategory
            // 
            filterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            filterCategory.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            filterCategory.FormattingEnabled = true;
            filterCategory.Items.AddRange(new object[] { "Necklaces ", "Bracelets", "Rings    ", "Earrings  ", "Watches      " });
            filterCategory.Location = new Point(1278, 193);
            filterCategory.Name = "filterCategory";
            filterCategory.Size = new Size(160, 39);
            filterCategory.TabIndex = 7;
            filterCategory.SelectionChangeCommitted += filterCategory_SelectionChangeCommitted;
            // 
            // cleanFilter
            // 
            cleanFilter.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            cleanFilter.Location = new Point(1220, 765);
            cleanFilter.Name = "cleanFilter";
            cleanFilter.Size = new Size(456, 45);
            cleanFilter.TabIndex = 8;
            cleanFilter.Text = "נקה סינון";
            cleanFilter.UseVisualStyleBackColor = true;
            cleanFilter.Click += cleanFilter_Click;
            // 
            // ProductsMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1687, 1029);
            Controls.Add(cleanFilter);
            Controls.Add(filterCategory);
            Controls.Add(label11);
            Controls.Add(productsList);
            Controls.Add(add);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProductsMenu";
            Text = "ProductsMenu";
            delete.ResumeLayout(false);
            delete.PerformLayout();
            update.ResumeLayout(false);
            update.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amount).EndInit();
            ((System.ComponentModel.ISupportInitialize)price).EndInit();
            addCustomer.ResumeLayout(false);
            addCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            add.ResumeLayout(false);
            detailProduct.ResumeLayout(false);
            detailProduct.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private ListBox listBox1;
        private ListBox productsList;
        private TabPage delete;
        private Button deleteBtn;
        private TextBox codeInputToDelete;
        private Label codeProductToDelete;
        private TabPage update;
        private TextBox codeProductInput;
        private Label label5;
        private NumericUpDown amount;
        private Label label1;
        private ComboBox categoryUpdate;
        private Label label2;
        private Button updateBtn;
        private NumericUpDown price;
        private TextBox nameProduct;
        private Label label3;
        private Label label4;
        private TabPage addCustomer;
        private NumericUpDown amountInput;
        private Label amountLable;
        private ComboBox categoryInput;
        private Label category;
        private Button addProduct;
        private NumericUpDown priceInput;
        private TextBox nameProductInput;
        private Label priceLable;
        private Label nameProductLable;
        private TabControl add;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private Button searchBtn;
        private TabPage detailProduct;
        private ListBox detailProductOne;
        private Button showDetailsProduct;
        private TextBox idProductSearch;
        private Label label10;
        private Label label11;
        private ComboBox filterCategory;
        private Button cleanFilter;
    }
}