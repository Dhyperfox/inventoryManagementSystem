using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace raktarinfo
{

    public partial class customers : Form
    {
        MySqlDataAdapter adapter1;
        DataSet ds;
        MySqlCommandBuilder cmdb1;

        string sql;
        public customers()
        {
            InitializeComponent();
        }

        private void customersForm_Load(object sender, EventArgs e)
        {
            sql = "Select idp, nev, varos, cim, post_br, pib, mat_br from partner ";
           
            MySqlConnection con = GetConnection();
            DisplayData(sql, con);

        }

        public void DisplayData(string sql, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            adapter1 = new MySqlDataAdapter(cmd);
            ds = new DataSet();

            adapter1.Fill(ds, "CustomerData");
            dtgrid.DataSource = ds.Tables[0];
            con.Close();
        }
        public static MySqlConnection GetConnection()
        {
            String connectionString = "Server=localhost;Database=data;User=root;Password=;";

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
            adapter1.Update(ds, "CustomerData");
            MessageBox.Show("Customers Edited succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand("Insert into partner Values(@id,@Nev ,@Varos, @Cim,@Postal_br,@Pib,@Mat_br,'null','null','null','null','null','null','null','null');", con);
            try
            {                             
                dtgrid.CurrentCell = dtgrid.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First(); // if first wanted

                int index = Convert.ToInt32(dtgrid.CurrentCell.Value) + 1;
                
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = index ;
                cmd.Parameters.Add("@Nev", MySqlDbType.VarChar).Value = nameTxb.Text;
                cmd.Parameters.Add("@Varos", MySqlDbType.VarChar).Value = prdId.Text;
                cmd.Parameters.Add("@Cim", MySqlDbType.VarChar).Value = tipusTbx.Text;
                cmd.Parameters.Add("@Postal_br", MySqlDbType.VarChar).Value = egys_arTbx.Text;
                cmd.Parameters.Add("@Pib", MySqlDbType.Int32).Value = Convert.ToInt32(rucTbx.Text);
                cmd.Parameters.Add("@Mat_br", MySqlDbType.VarChar).Value = tarifaTbx.Text;
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Customers Added succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData(sql, con);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Customers Can Not be Added!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = dtgrid.CurrentCell.RowIndex; //to remove from datagrid

            DataGridViewCellCollection currentRow = dtgrid.CurrentCell.OwningRow.Cells; // get selected row cells

            DataGridViewCell firstCell = currentRow[0]; // get first cell of row

            int id = Convert.ToInt32(firstCell.Value); //value of first cell                      

            rowDeleted(id);
            ds.Tables[0].Rows.RemoveAt(rowindex);

            MessageBox.Show("Product(s) Deleted succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void rowDeleted(int rowIndex)
        {
            string query = "Delete From partner Where idt = @id;";
            try
            {
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = rowIndex;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Products Cant Deleted!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = GetConnection();
            sql = "Select idp, nev, varos, cim, post_br, pib, mat_br from partner where nev like '" + searchBox.Text.ToLower() + "%' or varos like '" + searchBox.Text.ToLower() + "%' or cim like '" + searchBox.Text.ToLower() + "%' or post_br like '" + searchBox.Text.ToLower() + "%'; ";
            DisplayData(sql, con);
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
        }
    }


   

 }