namespace UI
{
    partial class OrderToCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderToCustomer));
            label1 = new Label();
            customerId = new Label();
            inputId = new TextBox();
            orderBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Narrow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(730, 261);
            label1.Name = "label1";
            label1.Size = new Size(487, 69);
            label1.TabIndex = 0;
            label1.Text = "הזמנת מוצרים ללקוח";
            // 
            // customerId
            // 
            customerId.AutoSize = true;
            customerId.BackColor = Color.Transparent;
            customerId.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            customerId.Location = new Point(962, 354);
            customerId.Name = "customerId";
            customerId.Size = new Size(227, 38);
            customerId.TabIndex = 1;
            customerId.Text = "תעודת זהות לקוח";
            // 
            // inputId
            // 
            inputId.BackColor = Color.White;
            inputId.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            inputId.Location = new Point(751, 349);
            inputId.Name = "inputId";
            inputId.Size = new Size(194, 43);
            inputId.TabIndex = 2;
            inputId.KeyPress += inputId_KeyPress;
            // 
            // orderBtn
            // 
            orderBtn.Location = new Point(896, 433);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(147, 59);
            orderBtn.TabIndex = 3;
            orderBtn.Text = "התחל הזמנה";
            orderBtn.UseVisualStyleBackColor = true;
            orderBtn.Click += orderBtn_Click;
            // 
            // OrderToCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1344, 577);
            Controls.Add(orderBtn);
            Controls.Add(inputId);
            Controls.Add(customerId);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OrderToCustomer";
            Text = "OrderMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label customerId;
        private TextBox inputId;
        private Button orderBtn;
    }
}