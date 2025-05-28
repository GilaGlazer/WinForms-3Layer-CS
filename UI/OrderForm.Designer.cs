namespace UI
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            add = new TabControl();
            addProduct = new TabPage();
            listProductsInputAdd = new ComboBox();
            addProductToOrder = new Button();
            amountToOrderProduct = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            deleteProduct = new TabPage();
            listProductsInputDelete = new ComboBox();
            deleteFromOrder = new Button();
            nameProductLable = new Label();
            endOrder = new Button();
            label3 = new Label();
            listProduct = new ListBox();
            hi = new Label();
            label5 = new Label();
            label6 = new Label();
            cardGrid = new DataGridView();
            sumOrder = new Label();
            add.SuspendLayout();
            addProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountToOrderProduct).BeginInit();
            deleteProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cardGrid).BeginInit();
            SuspendLayout();
            // 
            // add
            // 
            add.Controls.Add(addProduct);
            add.Controls.Add(deleteProduct);
            add.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            add.Location = new Point(803, 170);
            add.Name = "add";
            add.RightToLeft = RightToLeft.Yes;
            add.RightToLeftLayout = true;
            add.SelectedIndex = 0;
            add.Size = new Size(490, 658);
            add.TabIndex = 10;
            // 
            // addProduct
            // 
            addProduct.Controls.Add(listProductsInputAdd);
            addProduct.Controls.Add(addProductToOrder);
            addProduct.Controls.Add(amountToOrderProduct);
            addProduct.Controls.Add(label1);
            addProduct.Controls.Add(label2);
            addProduct.Location = new Point(4, 46);
            addProduct.Name = "addProduct";
            addProduct.Padding = new Padding(3);
            addProduct.Size = new Size(482, 608);
            addProduct.TabIndex = 2;
            addProduct.Text = "הוספת מוצר";
            addProduct.UseVisualStyleBackColor = true;
            // 
            // listProductsInputAdd
            // 
            listProductsInputAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            listProductsInputAdd.FormattingEnabled = true;
            listProductsInputAdd.Location = new Point(57, 78);
            listProductsInputAdd.Name = "listProductsInputAdd";
            listProductsInputAdd.Size = new Size(238, 45);
            listProductsInputAdd.TabIndex = 24;
            // 
            // addProductToOrder
            // 
            addProductToOrder.Location = new Point(102, 316);
            addProductToOrder.Name = "addProductToOrder";
            addProductToOrder.Size = new Size(324, 77);
            addProductToOrder.TabIndex = 19;
            addProductToOrder.Text = "הוסף להזמנה";
            addProductToOrder.UseVisualStyleBackColor = true;
            addProductToOrder.Click += addProductToOrder_Click;
            // 
            // amountToOrderProduct
            // 
            amountToOrderProduct.Location = new Point(57, 194);
            amountToOrderProduct.Name = "amountToOrderProduct";
            amountToOrderProduct.Size = new Size(150, 43);
            amountToOrderProduct.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 196);
            label1.Name = "label1";
            label1.Size = new Size(178, 38);
            label1.TabIndex = 17;
            label1.Text = "כמות להזמנה";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 78);
            label2.Name = "label2";
            label2.Size = new Size(125, 38);
            label2.TabIndex = 15;
            label2.Text = "שם מוצר";
            // 
            // deleteProduct
            // 
            deleteProduct.Controls.Add(listProductsInputDelete);
            deleteProduct.Controls.Add(deleteFromOrder);
            deleteProduct.Controls.Add(nameProductLable);
            deleteProduct.Location = new Point(4, 46);
            deleteProduct.Margin = new Padding(3, 4, 3, 4);
            deleteProduct.Name = "deleteProduct";
            deleteProduct.Size = new Size(482, 608);
            deleteProduct.TabIndex = 3;
            deleteProduct.Text = "מחיקת מוצר";
            deleteProduct.UseVisualStyleBackColor = true;
            // 
            // listProductsInputDelete
            // 
            listProductsInputDelete.DropDownStyle = ComboBoxStyle.DropDownList;
            listProductsInputDelete.FormattingEnabled = true;
            listProductsInputDelete.Location = new Point(101, 163);
            listProductsInputDelete.Name = "listProductsInputDelete";
            listProductsInputDelete.Size = new Size(187, 45);
            listProductsInputDelete.TabIndex = 25;
            // 
            // deleteFromOrder
            // 
            deleteFromOrder.Location = new Point(101, 292);
            deleteFromOrder.Name = "deleteFromOrder";
            deleteFromOrder.Size = new Size(317, 78);
            deleteFromOrder.TabIndex = 14;
            deleteFromOrder.Text = "מחק מההזמנה";
            deleteFromOrder.UseVisualStyleBackColor = true;
            deleteFromOrder.Click += deleteFromOrder_Click_1;
            // 
            // nameProductLable
            // 
            nameProductLable.AutoSize = true;
            nameProductLable.Location = new Point(294, 163);
            nameProductLable.Name = "nameProductLable";
            nameProductLable.Size = new Size(125, 38);
            nameProductLable.TabIndex = 10;
            nameProductLable.Text = "שם מוצר";
            // 
            // endOrder
            // 
            endOrder.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            endOrder.Location = new Point(236, 901);
            endOrder.Name = "endOrder";
            endOrder.Size = new Size(538, 73);
            endOrder.TabIndex = 15;
            endOrder.Text = "סיום הזמנה";
            endOrder.UseVisualStyleBackColor = true;
            endOrder.Click += endOrder_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(516, 844);
            label3.Name = "label3";
            label3.Size = new Size(184, 38);
            label3.TabIndex = 17;
            label3.Text = "סכום לתשלום";
            // 
            // listProduct
            // 
            listProduct.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            listProduct.FormattingEnabled = true;
            listProduct.ItemHeight = 37;
            listProduct.Location = new Point(1318, 219);
            listProduct.Name = "listProduct";
            listProduct.RightToLeft = RightToLeft.No;
            listProduct.Size = new Size(496, 596);
            listProduct.TabIndex = 19;
            // 
            // hi
            // 
            hi.AutoSize = true;
            hi.BackColor = Color.Transparent;
            hi.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            hi.Location = new Point(1145, 41);
            hi.Name = "hi";
            hi.Size = new Size(52, 46);
            hi.TabIndex = 20;
            hi.Text = "הי";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(550, 170);
            label5.Name = "label5";
            label5.Size = new Size(123, 38);
            label5.TabIndex = 22;
            label5.Text = "הסל שלי";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(1492, 164);
            label6.Name = "label6";
            label6.Size = new Size(196, 38);
            label6.TabIndex = 23;
            label6.Text = "רשימת מוצרים";
            // 
            // cardGrid
            // 
            cardGrid.BackgroundColor = Color.White;
            cardGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cardGrid.Location = new Point(92, 219);
            cardGrid.Name = "cardGrid";
            cardGrid.RowHeadersWidth = 51;
            cardGrid.RowTemplate.Height = 29;
            cardGrid.Size = new Size(694, 602);
            cardGrid.TabIndex = 24;
            cardGrid.CellContentClick += cardGrid_CellContentClick;
            // 
            // sumOrder
            // 
            sumOrder.AutoSize = true;
            sumOrder.BackColor = Color.Transparent;
            sumOrder.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            sumOrder.Location = new Point(426, 849);
            sumOrder.Name = "sumOrder";
            sumOrder.Size = new Size(46, 33);
            sumOrder.TabIndex = 25;
            sumOrder.Text = "₪ 0";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1826, 1055);
            Controls.Add(sumOrder);
            Controls.Add(cardGrid);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(hi);
            Controls.Add(listProduct);
            Controls.Add(label3);
            Controls.Add(endOrder);
            Controls.Add(add);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OrderForm";
            RightToLeft = RightToLeft.Yes;
            Text = "MyOrder";
            Load += OrderForm_Load;
            add.ResumeLayout(false);
            addProduct.ResumeLayout(false);
            addProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountToOrderProduct).EndInit();
            deleteProduct.ResumeLayout(false);
            deleteProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cardGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl add;
        private TabPage addProduct;
        private TabPage deleteProduct;
        private Button addProductToOrder;
        private NumericUpDown amountToOrderProduct;
        private Label label1;
        private Label label2;
        private Button deleteFromOrder;
        private Label nameProductLable;
        private Button endOrder;
        private Label label3;
        private ListBox listProduct;
        private Label hi;
        private Label label5;
        private Label label6;
        private ComboBox listProductsInputAdd;
        private ComboBox listProductsInputDelete;
        private DataGridView cardGrid;
        private Label sumOrder;
    }
}