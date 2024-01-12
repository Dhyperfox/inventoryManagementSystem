
namespace raktarinfo
{
    partial class orders
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
            this.orderContorlPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.CustomerBox = new System.Windows.Forms.ComboBox();
            this.productBox = new System.Windows.Forms.ComboBox();
            this.productIDBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printBtn = new System.Windows.Forms.Button();
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.dtgrid = new System.Windows.Forms.DataGridView();
            this.orderContorlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderContorlPanel
            // 
            this.orderContorlPanel.Controls.Add(this.label5);
            this.orderContorlPanel.Controls.Add(this.label4);
            this.orderContorlPanel.Controls.Add(this.label3);
            this.orderContorlPanel.Controls.Add(this.label2);
            this.orderContorlPanel.Controls.Add(this.label1);
            this.orderContorlPanel.Controls.Add(this.TypeBox);
            this.orderContorlPanel.Controls.Add(this.AmountBox);
            this.orderContorlPanel.Controls.Add(this.CustomerBox);
            this.orderContorlPanel.Controls.Add(this.productBox);
            this.orderContorlPanel.Controls.Add(this.productIDBox);
            this.orderContorlPanel.Controls.Add(this.menuStrip1);
            this.orderContorlPanel.Controls.Add(this.panel1);
            this.orderContorlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.orderContorlPanel.Location = new System.Drawing.Point(0, 0);
            this.orderContorlPanel.Name = "orderContorlPanel";
            this.orderContorlPanel.Size = new System.Drawing.Size(800, 150);
            this.orderContorlPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Product Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Customer";
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "Uveges",
            "Dobozos"});
            this.TypeBox.Location = new System.Drawing.Point(556, 72);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(121, 21);
            this.TypeBox.TabIndex = 7;
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(450, 73);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(100, 20);
            this.AmountBox.TabIndex = 6;
            // 
            // CustomerBox
            // 
            this.CustomerBox.FormattingEnabled = true;
            this.CustomerBox.Location = new System.Drawing.Point(204, 73);
            this.CustomerBox.Name = "CustomerBox";
            this.CustomerBox.Size = new System.Drawing.Size(121, 21);
            this.CustomerBox.TabIndex = 5;
            // 
            // productBox
            // 
            this.productBox.FormattingEnabled = true;
            this.productBox.Location = new System.Drawing.Point(23, 72);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(175, 21);
            this.productBox.TabIndex = 4;
            this.productBox.SelectedIndexChanged += new System.EventHandler(this.productBox_SelectedIndexChanged);
            // 
            // productIDBox
            // 
            this.productIDBox.Location = new System.Drawing.Point(335, 73);
            this.productIDBox.Name = "productIDBox";
            this.productIDBox.ReadOnly = true;
            this.productIDBox.Size = new System.Drawing.Size(100, 20);
            this.productIDBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.printBtn);
            this.panel1.Controls.Add(this.addOrderBtn);
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Location = new System.Drawing.Point(23, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 42);
            this.panel1.TabIndex = 14;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(312, 14);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 14;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Location = new System.Drawing.Point(3, 14);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(108, 23);
            this.addOrderBtn.TabIndex = 0;
            this.addOrderBtn.Text = "New Purchase";
            this.addOrderBtn.UseVisualStyleBackColor = true;
            this.addOrderBtn.Click += new System.EventHandler(this.addOrderBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(181, 14);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 13;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.dtgrid);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 150);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(800, 300);
            this.gridPanel.TabIndex = 1;
            // 
            // dtgrid
            // 
            this.dtgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid.Location = new System.Drawing.Point(0, 0);
            this.dtgrid.Name = "dtgrid";
            this.dtgrid.Size = new System.Drawing.Size(800, 300);
            this.dtgrid.TabIndex = 0;
            // 
            // orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.orderContorlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "orders";
            this.Text = "orders";
            this.Load += new System.EventHandler(this.orders_Load);
            this.orderContorlPanel.ResumeLayout(false);
            this.orderContorlPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel orderContorlPanel;
        private System.Windows.Forms.Button addOrderBtn;
        private System.Windows.Forms.TextBox productIDBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.ComboBox CustomerBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView dtgrid;
    }
}