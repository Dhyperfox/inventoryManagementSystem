using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace raktarinfo
{
   
    public partial class productsForm : Form
    {
        MySqlDataAdapter adapter1;
        DataSet ds;
        MySqlCommandBuilder cmdb1;

        string sql;
        public productsForm()
        {
            InitializeComponent();
        }

        private void productsForm_Load(object sender, EventArgs e)
        {
            sql = "SELECT idt as `Id`, nev as `Name`, ids as `Product id` ,tip as `Type`,egys_ar as `Price`, ruc, tarifa as `Tarifa`, aktiv_termek AS `Active` FROM termek  ";
            MySqlConnection con = GetConnection();
            DisplayData(sql, con);
        }

        public void DisplayData(string sql, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            adapter1 = new MySqlDataAdapter(cmd);
            ds = new DataSet();

            adapter1.Fill(ds, "productData");
            dtgrid.DataSource = ds.Tables[0];
            con.Close();
        }
        public static MySqlConnection GetConnection()
        {
            String connectionString = "Server=localhost;Database=raktar_info;User=root;Password=;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySql connection error! \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

             
        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmdb1 = new MySqlCommandBuilder(adapter1);
            adapter1.Update(ds, "productData");
            MessageBox.Show("Product Edited succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {          
            MySqlConnection con = GetConnection();
            
            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert into termek Values(@id,@Nev ,@Azonosito, @Tipus,@Egysegar,@ruc,@Tarifa,@aktiv_termek);", con);
                dtgrid.CurrentCell = dtgrid.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First(); //get the last first cell of the last row

                int index = Convert.ToInt32(dtgrid.CurrentCell.Value) + 1; //value of the first cell (last id) + 1
                int aktiv = aktiv_termekChk.Checked ? 1 : 0;

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = index;
                cmd.Parameters.Add("@Nev", MySqlDbType.VarChar).Value = nameTxb.Text;
                cmd.Parameters.Add("@Azonosito", MySqlDbType.Int32).Value = Convert.ToInt32(prdId.Text);
                cmd.Parameters.Add("@Tipus", MySqlDbType.VarChar).Value = tipusTbx.Text;
                cmd.Parameters.Add("@Egysegar", MySqlDbType.Float).Value = Convert.ToDecimal(egys_arTbx.Text);
                cmd.Parameters.Add("@ruc", MySqlDbType.Int32).Value = Convert.ToInt32(rucTbx.Text);
                cmd.Parameters.Add("@Tarifa", MySqlDbType.VarChar).Value = tarifaTbx.Text;
                cmd.Parameters.Add("@aktiv_termek", MySqlDbType.VarChar).Value = aktiv.ToString();
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Product Added succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData(sql, con);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Producs Can Not be Added!" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = dtgrid.CurrentCell.RowIndex; //to remove from datagrid

            DataGridViewCellCollection currentRow = dtgrid.CurrentCell.OwningRow.Cells; // get selected row cells

            DataGridViewCell firstCell = currentRow[0]; // get first cell of row

            int id =  Convert.ToInt32(firstCell.Value); //value of first cell

          //  Console.WriteLine(id.ToString());

            rowDeleted(id);
            ds.Tables[0].Rows.RemoveAt(rowindex);
            
            MessageBox.Show("Product Deleted succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      public  void rowDeleted(int rowIndex)
        {
            string query = "Delete From termek Where idt = @id;";
            try
            {
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = rowIndex;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Product Can't Deleted!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {           
            MySqlConnection con = GetConnection();
            sql = "Select * from termek where nev like '" + searchBox.Text.ToLower() + "%' or ids like '" + searchBox.Text.ToLower() + "%' or tip like '" + searchBox.Text.ToLower() + "%' or tarifa like '" + searchBox.Text.ToLower() + "%'; ";            
            DisplayData(sql, con);
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
        }
    }

}
