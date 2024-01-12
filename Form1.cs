using System;
using System.Windows.Forms;

namespace raktarinfo
{
   public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadForm(new home());
        }

        void loadForm(object Form)
        {
            if(this.contentPanel.Controls.Count > 0)
            {
                this.contentPanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(f);
            this.contentPanel.Tag = f;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new productsForm());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            loadForm(new customers());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            loadForm(new orders());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new home());
        }
    }
}
