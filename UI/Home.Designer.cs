namespace UI
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            manager = new Button();
            seller = new Button();
            SuspendLayout();
            // 
            // manager
            // 
            manager.Location = new Point(542, 149);
            manager.Margin = new Padding(3, 4, 3, 4);
            manager.Name = "manager";
            manager.Size = new Size(237, 61);
            manager.TabIndex = 0;
            manager.Text = "מנהל";
            manager.UseVisualStyleBackColor = true;
            manager.Click += manager_Click;
            // 
            // seller
            // 
            seller.Location = new Point(149, 149);
            seller.Margin = new Padding(3, 4, 3, 4);
            seller.Name = "seller";
            seller.Size = new Size(232, 61);
            seller.TabIndex = 0;
            seller.Text = "קופאי";
            seller.UseVisualStyleBackColor = true;
            seller.Click += seller_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.home;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 503);
            Controls.Add(manager);
            Controls.Add(seller);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button manager;
        private Button seller;
    }
}
