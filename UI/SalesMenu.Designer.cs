﻿namespace UI
{
    partial class SalesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesMenu));
            delete = new TabPage();
            deleteBtn = new Button();
            codeSaleInputToDelete = new TextBox();
            codeProductToDelete = new Label();
            update = new TabPage();
            isOnlyClubInputUpdate = new CheckBox();
            searchSaleBtn = new Button();
            idSalePInput = new TextBox();
            lastSaleDateInputUpdate = new DateTimePicker();
            startSaleDateInputUpdate = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            fainalPriceInputUpdate = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            saveUpdatedBtn = new Button();
            minAmountSaleInputUpdate = new NumericUpDown();
            idSaleInput = new TextBox();
            label9 = new Label();
            label10 = new Label();
            addCustomer = new TabPage();
            isOnlyClubInput = new CheckBox();
            idSaleProductInput = new TextBox();
            lastSaleDateInput = new DateTimePicker();
            startSaleDateInput = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            fainalPriceInput = new NumericUpDown();
            amountLable = new Label();
            category = new Label();
            addSaleBtn = new Button();
            minAmountSaleInput = new NumericUpDown();
            priceLable = new Label();
            add = new TabControl();
            saleDetails = new TabPage();
            codeSaleInputSearch = new TextBox();
            detailsSale = new ListBox();
            showDetailsSale = new Button();
            label1 = new Label();
            salesListBox = new ListBox();
            filterByCodeSale = new TextBox();
            label11 = new Label();
            delete.SuspendLayout();
            update.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fainalPriceInputUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minAmountSaleInputUpdate).BeginInit();
            addCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fainalPriceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minAmountSaleInput).BeginInit();
            add.SuspendLayout();
            saleDetails.SuspendLayout();
            SuspendLayout();
            // 
            // delete
            // 
            delete.Controls.Add(deleteBtn);
            delete.Controls.Add(codeSaleInputToDelete);
            delete.Controls.Add(codeProductToDelete);
            delete.Location = new Point(4, 40);
            delete.Name = "delete";
            delete.Padding = new Padding(3);
            delete.Size = new Size(573, 632);
            delete.TabIndex = 2;
            delete.Text = "מחיקה";
            delete.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(178, 258);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(186, 45);
            deleteBtn.TabIndex = 5;
            deleteBtn.Text = "מחיקה";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // codeSaleInputToDelete
            // 
            codeSaleInputToDelete.Location = new Point(178, 178);
            codeSaleInputToDelete.Name = "codeSaleInputToDelete";
            codeSaleInputToDelete.Size = new Size(186, 38);
            codeSaleInputToDelete.TabIndex = 4;
            codeSaleInputToDelete.KeyPress += codeSaleInputToDelete_KeyPress;
            // 
            // codeProductToDelete
            // 
            codeProductToDelete.AutoSize = true;
            codeProductToDelete.Location = new Point(152, 103);
            codeProductToDelete.Name = "codeProductToDelete";
            codeProductToDelete.Size = new Size(251, 33);
            codeProductToDelete.TabIndex = 3;
            codeProductToDelete.Text = "הקש קוד מבצע למחיקה";
            // 
            // update
            // 
            update.Controls.Add(isOnlyClubInputUpdate);
            update.Controls.Add(searchSaleBtn);
            update.Controls.Add(idSalePInput);
            update.Controls.Add(lastSaleDateInputUpdate);
            update.Controls.Add(startSaleDateInputUpdate);
            update.Controls.Add(label4);
            update.Controls.Add(label5);
            update.Controls.Add(fainalPriceInputUpdate);
            update.Controls.Add(label7);
            update.Controls.Add(label8);
            update.Controls.Add(saveUpdatedBtn);
            update.Controls.Add(minAmountSaleInputUpdate);
            update.Controls.Add(idSaleInput);
            update.Controls.Add(label9);
            update.Controls.Add(label10);
            update.Location = new Point(4, 40);
            update.Name = "update";
            update.Padding = new Padding(3);
            update.Size = new Size(573, 632);
            update.TabIndex = 1;
            update.Text = "עדכון";
            update.UseVisualStyleBackColor = true;
            // 
            // isOnlyClubInputUpdate
            // 
            isOnlyClubInputUpdate.AutoSize = true;
            isOnlyClubInputUpdate.Location = new Point(242, 466);
            isOnlyClubInputUpdate.Margin = new Padding(3, 4, 3, 4);
            isOnlyClubInputUpdate.Name = "isOnlyClubInputUpdate";
            isOnlyClubInputUpdate.Size = new Size(279, 37);
            isOnlyClubInputUpdate.TabIndex = 41;
            isOnlyClubInputUpdate.Text = "מבצע לחברי מועדון בלבד";
            isOnlyClubInputUpdate.UseVisualStyleBackColor = true;
            // 
            // searchSaleBtn
            // 
            searchSaleBtn.Location = new Point(29, 46);
            searchSaleBtn.Name = "searchSaleBtn";
            searchSaleBtn.Size = new Size(84, 45);
            searchSaleBtn.TabIndex = 40;
            searchSaleBtn.Text = "חפש מבצע";
            searchSaleBtn.UseVisualStyleBackColor = true;
            searchSaleBtn.Click += searchSaleBtn_Click;
            // 
            // idSalePInput
            // 
            idSalePInput.Location = new Point(143, 141);
            idSalePInput.Name = "idSalePInput";
            idSalePInput.Size = new Size(150, 38);
            idSalePInput.TabIndex = 39;
            idSalePInput.KeyPress += idSalePInput_KeyPress;
            // 
            // lastSaleDateInputUpdate
            // 
            lastSaleDateInputUpdate.Location = new Point(29, 385);
            lastSaleDateInputUpdate.Margin = new Padding(2, 1, 2, 1);
            lastSaleDateInputUpdate.Name = "lastSaleDateInputUpdate";
            lastSaleDateInputUpdate.Size = new Size(247, 38);
            lastSaleDateInputUpdate.TabIndex = 38;
            // 
            // startSaleDateInputUpdate
            // 
            startSaleDateInputUpdate.Location = new Point(29, 323);
            startSaleDateInputUpdate.Margin = new Padding(2, 1, 2, 1);
            startSaleDateInputUpdate.Name = "startSaleDateInputUpdate";
            startSaleDateInputUpdate.Size = new Size(247, 38);
            startSaleDateInputUpdate.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(290, 329);
            label4.Name = "label4";
            label4.Size = new Size(231, 33);
            label4.TabIndex = 36;
            label4.Text = "תאריך תחילת המבצע";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(314, 385);
            label5.Name = "label5";
            label5.Size = new Size(207, 33);
            label5.TabIndex = 35;
            label5.Text = "תאריך סיום המבצע";
            // 
            // fainalPriceInputUpdate
            // 
            fainalPriceInputUpdate.Location = new Point(143, 270);
            fainalPriceInputUpdate.Name = "fainalPriceInputUpdate";
            fainalPriceInputUpdate.Size = new Size(150, 38);
            fainalPriceInputUpdate.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(406, 272);
            label7.Name = "label7";
            label7.Size = new Size(115, 33);
            label7.TabIndex = 31;
            label7.Text = "מחיר סופי";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(327, 144);
            label8.Name = "label8";
            label8.Size = new Size(194, 33);
            label8.TabIndex = 30;
            label8.Text = "קוד מוצר שבמבצע";
            // 
            // saveUpdatedBtn
            // 
            saveUpdatedBtn.Location = new Point(29, 535);
            saveUpdatedBtn.Name = "saveUpdatedBtn";
            saveUpdatedBtn.Size = new Size(492, 57);
            saveUpdatedBtn.TabIndex = 29;
            saveUpdatedBtn.Text = "עדכן";
            saveUpdatedBtn.UseVisualStyleBackColor = true;
            saveUpdatedBtn.Click += saveUpdatedBtn_Click;
            // 
            // minAmountSaleInputUpdate
            // 
            minAmountSaleInputUpdate.Location = new Point(143, 208);
            minAmountSaleInputUpdate.Name = "minAmountSaleInputUpdate";
            minAmountSaleInputUpdate.Size = new Size(150, 38);
            minAmountSaleInputUpdate.TabIndex = 28;
            // 
            // idSaleInput
            // 
            idSaleInput.Location = new Point(133, 53);
            idSaleInput.Name = "idSaleInput";
            idSaleInput.Size = new Size(172, 38);
            idSaleInput.TabIndex = 27;
            idSaleInput.KeyPress += idSaleInput_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(299, 208);
            label9.Name = "label9";
            label9.Size = new Size(222, 33);
            label9.TabIndex = 26;
            label9.Text = "כמות מינימום למבצע";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(327, 53);
            label10.Name = "label10";
            label10.Size = new Size(238, 33);
            label10.TabIndex = 25;
            label10.Text = "הכנס קוד מבצע לעדכון";
            // 
            // addCustomer
            // 
            addCustomer.Controls.Add(isOnlyClubInput);
            addCustomer.Controls.Add(idSaleProductInput);
            addCustomer.Controls.Add(lastSaleDateInput);
            addCustomer.Controls.Add(startSaleDateInput);
            addCustomer.Controls.Add(label3);
            addCustomer.Controls.Add(label2);
            addCustomer.Controls.Add(fainalPriceInput);
            addCustomer.Controls.Add(amountLable);
            addCustomer.Controls.Add(category);
            addCustomer.Controls.Add(addSaleBtn);
            addCustomer.Controls.Add(minAmountSaleInput);
            addCustomer.Controls.Add(priceLable);
            addCustomer.Location = new Point(4, 40);
            addCustomer.Name = "addCustomer";
            addCustomer.Padding = new Padding(3);
            addCustomer.Size = new Size(573, 632);
            addCustomer.TabIndex = 0;
            addCustomer.Text = "הוספה";
            addCustomer.UseVisualStyleBackColor = true;
            // 
            // isOnlyClubInput
            // 
            isOnlyClubInput.AutoSize = true;
            isOnlyClubInput.Location = new Point(236, 446);
            isOnlyClubInput.Margin = new Padding(3, 4, 3, 4);
            isOnlyClubInput.Name = "isOnlyClubInput";
            isOnlyClubInput.Size = new Size(279, 37);
            isOnlyClubInput.TabIndex = 25;
            isOnlyClubInput.Text = "מבצע לחברי מועדון בלבד";
            isOnlyClubInput.UseVisualStyleBackColor = true;
            // 
            // idSaleProductInput
            // 
            idSaleProductInput.Location = new Point(119, 68);
            idSaleProductInput.Name = "idSaleProductInput";
            idSaleProductInput.Size = new Size(150, 38);
            idSaleProductInput.TabIndex = 24;
            idSaleProductInput.KeyPress += idSaleProductInput_KeyPress;
            // 
            // lastSaleDateInput
            // 
            lastSaleDateInput.Location = new Point(41, 368);
            lastSaleDateInput.Margin = new Padding(2, 1, 2, 1);
            lastSaleDateInput.Name = "lastSaleDateInput";
            lastSaleDateInput.Size = new Size(247, 38);
            lastSaleDateInput.TabIndex = 23;
            // 
            // startSaleDateInput
            // 
            startSaleDateInput.Location = new Point(41, 302);
            startSaleDateInput.Margin = new Padding(2, 1, 2, 1);
            startSaleDateInput.Name = "startSaleDateInput";
            startSaleDateInput.Size = new Size(247, 38);
            startSaleDateInput.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 302);
            label3.Name = "label3";
            label3.Size = new Size(231, 33);
            label3.TabIndex = 21;
            label3.Text = "תאריך תחילת המבצע";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 373);
            label2.Name = "label2";
            label2.Size = new Size(207, 33);
            label2.TabIndex = 20;
            label2.Text = "תאריך סיום המבצע";
            // 
            // fainalPriceInput
            // 
            fainalPriceInput.Location = new Point(119, 226);
            fainalPriceInput.Name = "fainalPriceInput";
            fainalPriceInput.Size = new Size(150, 38);
            fainalPriceInput.TabIndex = 17;
            // 
            // amountLable
            // 
            amountLable.AutoSize = true;
            amountLable.Location = new Point(398, 226);
            amountLable.Name = "amountLable";
            amountLable.Size = new Size(115, 33);
            amountLable.TabIndex = 16;
            amountLable.Text = "מחיר סופי";
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(321, 71);
            category.Name = "category";
            category.Size = new Size(194, 33);
            category.TabIndex = 14;
            category.Text = "קוד מוצר שבמבצע";
            // 
            // addSaleBtn
            // 
            addSaleBtn.Location = new Point(41, 512);
            addSaleBtn.Name = "addSaleBtn";
            addSaleBtn.Size = new Size(472, 59);
            addSaleBtn.TabIndex = 13;
            addSaleBtn.Text = "הוספה";
            addSaleBtn.UseVisualStyleBackColor = true;
            addSaleBtn.Click += addSaleBtn_Click;
            // 
            // minAmountSaleInput
            // 
            minAmountSaleInput.Location = new Point(119, 147);
            minAmountSaleInput.Name = "minAmountSaleInput";
            minAmountSaleInput.Size = new Size(150, 38);
            minAmountSaleInput.TabIndex = 12;
            // 
            // priceLable
            // 
            priceLable.AutoSize = true;
            priceLable.Location = new Point(291, 152);
            priceLable.Name = "priceLable";
            priceLable.Size = new Size(222, 33);
            priceLable.TabIndex = 10;
            priceLable.Text = "כמות מינימום למבצע";
            // 
            // add
            // 
            add.Controls.Add(addCustomer);
            add.Controls.Add(update);
            add.Controls.Add(delete);
            add.Controls.Add(saleDetails);
            add.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            add.Location = new Point(633, 210);
            add.Name = "add";
            add.RightToLeft = RightToLeft.Yes;
            add.RightToLeftLayout = true;
            add.SelectedIndex = 0;
            add.Size = new Size(581, 676);
            add.TabIndex = 1;
            // 
            // saleDetails
            // 
            saleDetails.Controls.Add(codeSaleInputSearch);
            saleDetails.Controls.Add(detailsSale);
            saleDetails.Controls.Add(showDetailsSale);
            saleDetails.Controls.Add(label1);
            saleDetails.Location = new Point(4, 40);
            saleDetails.Margin = new Padding(3, 4, 3, 4);
            saleDetails.Name = "saleDetails";
            saleDetails.Size = new Size(573, 632);
            saleDetails.TabIndex = 3;
            saleDetails.Text = "פרטי מבצע";
            saleDetails.UseVisualStyleBackColor = true;
            // 
            // codeSaleInputSearch
            // 
            codeSaleInputSearch.Location = new Point(116, 56);
            codeSaleInputSearch.Margin = new Padding(3, 4, 3, 4);
            codeSaleInputSearch.Name = "codeSaleInputSearch";
            codeSaleInputSearch.Size = new Size(161, 38);
            codeSaleInputSearch.TabIndex = 14;
            codeSaleInputSearch.KeyPress += codeSaleInputSearch_KeyPress;
            // 
            // detailsSale
            // 
            detailsSale.FormattingEnabled = true;
            detailsSale.ItemHeight = 31;
            detailsSale.Location = new Point(116, 224);
            detailsSale.Margin = new Padding(3, 4, 3, 4);
            detailsSale.Name = "detailsSale";
            detailsSale.RightToLeft = RightToLeft.No;
            detailsSale.Size = new Size(384, 345);
            detailsSale.TabIndex = 13;
            // 
            // showDetailsSale
            // 
            showDetailsSale.Location = new Point(116, 141);
            showDetailsSale.Name = "showDetailsSale";
            showDetailsSale.Size = new Size(384, 58);
            showDetailsSale.TabIndex = 12;
            showDetailsSale.Text = "הצג פרטי מבצע";
            showDetailsSale.UseVisualStyleBackColor = true;
            showDetailsSale.Click += showDetailsSale_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 59);
            label1.Name = "label1";
            label1.Size = new Size(169, 33);
            label1.TabIndex = 10;
            label1.Text = "הכנס קוד מבצע";
            // 
            // salesListBox
            // 
            salesListBox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            salesListBox.FormattingEnabled = true;
            salesListBox.ItemHeight = 31;
            salesListBox.Location = new Point(1276, 227);
            salesListBox.Margin = new Padding(2, 1, 2, 1);
            salesListBox.Name = "salesListBox";
            salesListBox.Size = new Size(488, 655);
            salesListBox.TabIndex = 2;
            // 
            // filterByCodeSale
            // 
            filterByCodeSale.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            filterByCodeSale.Location = new Point(1306, 101);
            filterByCodeSale.Name = "filterByCodeSale";
            filterByCodeSale.Size = new Size(261, 38);
            filterByCodeSale.TabIndex = 7;
            filterByCodeSale.TextChanged += filterByDealCode_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(1575, 105);
            label11.Name = "label11";
            label11.Size = new Size(124, 33);
            label11.TabIndex = 6;
            label11.Text = "סנן לפי קוד";
            // 
            // SalesMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1824, 989);
            Controls.Add(filterByCodeSale);
            Controls.Add(label11);
            Controls.Add(salesListBox);
            Controls.Add(add);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "SalesMenu";
            Text = "SalesMenu";
            delete.ResumeLayout(false);
            delete.PerformLayout();
            update.ResumeLayout(false);
            update.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fainalPriceInputUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)minAmountSaleInputUpdate).EndInit();
            addCustomer.ResumeLayout(false);
            addCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fainalPriceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)minAmountSaleInput).EndInit();
            add.ResumeLayout(false);
            saleDetails.ResumeLayout(false);
            saleDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabPage delete;
        private Button deleteBtn;
        private TextBox codeSaleInputToDelete;
        private Label codeProductToDelete;
        private TabPage update;
        private Button searchSaleBtn;
        private TextBox idSalePInput;
        private DateTimePicker lastSaleDateInputUpdate;
        private DateTimePicker startSaleDateInputUpdate;
        private Label label4;
        private Label label5;
        private NumericUpDown fainalPriceInputUpdate;
        private Label label7;
        private Label label8;
        private Button saveUpdatedBtn;
        private NumericUpDown minAmountSaleInputUpdate;
        private TextBox idSaleInput;
        private Label label9;
        private Label label10;
        private TabPage addCustomer;
        private TextBox idSaleProductInput;
        private DateTimePicker lastSaleDateInput;
        private DateTimePicker startSaleDateInput;
        private Label label3;
        private Label label2;
        private NumericUpDown fainalPriceInput;
        private Label amountLable;
        private Label category;
        private Button addSaleBtn;
        private NumericUpDown minAmountSaleInput;
        private Label priceLable;
        private TabControl add;
        private ListBox salesListBox;
        private TextBox filterByCodeSale;
        private Label label11;
        private CheckBox isOnlyClubInput;
        private CheckBox isOnlyClubInputUpdate;
        private TabPage saleDetails;
        private ListBox detailsSale;
        private Label label1;
        private Button showDetailsSale;
        private TextBox codeSaleInputSearch;
    }
}