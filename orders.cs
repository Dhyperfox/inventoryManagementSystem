using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;

namespace raktarinfo
{
    class RoundedBorder : IPdfPCellEvent
    {
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle rect, PdfContentByte[] canvas)
        {
            PdfContentByte cb = canvas[PdfPTable.BACKGROUNDCANVAS];
            cb.RoundRectangle(
              rect.Left + 1.5f,
              rect.Bottom + 1.5f,
              rect.Width - 3,
              rect.Height - 3, 4
            );
            cb.Stroke();
        }
    }
    public partial class orders : Form
    {

        MySqlDataAdapter adapter1;
        DataSet ds;
       

        string sql;
        public orders()
        {
            InitializeComponent();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            sql = "Select id, idr, idp, nev, cim, ids, db, egys, dat_ins,type from rendel ";
            MySqlConnection con = GetConnection();
            DisplayData(sql, con);
                        
            LoadComboBox("ProductData", 1, "Select nev, ids from termek", "nev" ,productBox);
            LoadComboBox("PartnerData", 2, "Select nev , cim from partner", "nev",CustomerBox );         
            
        }

        string getCustomerData(string sql, string getdata, ComboBox comboBox)
        {
            
            MySqlConnection con = GetConnection();            
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@nev", MySqlDbType.VarChar).Value = comboBox.Text.ToString();

            MySqlDataReader reader;
            string[] data = new string[3];
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              string  id = reader.GetString(0);              
              data[0] = id;
                 
            }

            reader.Close();
            con.Close();            
            return data[0];
        }
        void LoadComboBox(string DataSetName ,int IndexOfTable , string sql,string columnName, ComboBox box)
        {
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            adapter1 = new MySqlDataAdapter(cmd);
            adapter1.Fill(ds, DataSetName);
            con.Close();
            for (int i = 0; i < ds.Tables[IndexOfTable].Rows.Count; i++)
            {
                box.Items.Add(ds.Tables[IndexOfTable].Rows[i][columnName].ToString());
            }
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
            String connectionString = "Server=localhost;Database=raktar_info_v1;User=root;Password=;";

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

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             string sql = "select ids from termek where nev = @nev";
           
             string id = getCustomerData(sql, "id", productBox);
            productIDBox.Text = id;
           
        }

        
        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            

            
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand("Insert into rendel Values(@id,@idr ,@idp,@Nev ,@Cim,@ids,@db,@egys,@dat_ins,'',@type);", con);
            try
            {

                string date = DateTime.Now.ToString("yyyy-MM-dd");


                Random rnd = new Random();

                string idr = rnd.Next(100).ToString() + "-" + date;
                Console.WriteLine(date);


                string cim = getCustomerData("select cim from partner where nev = @nev", "cim", CustomerBox);
                string idp = getCustomerData("select idp from partner where nev = @nev", "idp", CustomerBox);
                Console.WriteLine(cim + "\n" + idp);

                long index = Convert.ToInt32(dtgrid.CurrentCell.Value) + 1;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@idr", MySqlDbType.VarChar).Value = idr;
                cmd.Parameters.Add("@idp", MySqlDbType.VarChar).Value = idp;
                cmd.Parameters.Add("@Nev", MySqlDbType.VarChar).Value = productBox.Text;
                cmd.Parameters.Add("@Cim", MySqlDbType.VarChar).Value = cim;
                cmd.Parameters.Add("@ids", MySqlDbType.VarChar).Value = productIDBox.Text;
                cmd.Parameters.Add("@db", MySqlDbType.VarChar).Value = AmountBox.Text;
                cmd.Parameters.Add("@egys", MySqlDbType.VarChar).Value = TypeBox.Text.ToString();
                cmd.Parameters.Add("@dat_ins", MySqlDbType.Date).Value = date;
                cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = TypeBox.Text;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Order Added succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData(sql, con);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Order Can Not be Added!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int rowindex = dtgrid.CurrentCell.RowIndex; //to remove from datagrid

            DataGridViewCellCollection currentRow = dtgrid.CurrentCell.OwningRow.Cells; // get selected row cells

            DataGridViewCell firstCell = currentRow[0]; // get first cell of row

            int id = Convert.ToInt32(firstCell.Value); //value of first cell

            rowDeleted(id);
            ds.Tables[0].Rows.RemoveAt(rowindex);

            MessageBox.Show("Order Deleted succecfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void rowDeleted(int rowIndex)
        {
            string query = "Delete From rendel Where id = @id;";
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
                MessageBox.Show("Order Cant Deleted!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection currentRow = dtgrid.CurrentCell.OwningRow.Cells; // get selected row cells
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Random rnd = new Random();

            MySqlConnection con0 = GetConnection();
            MySqlCommand cmd0 = new MySqlCommand("Select nev, varos, cim, post_br, pib, mat_br from partner where idp = @idp", con0);
            MySqlDataReader reader0;
            string customerName = "";
            string city = "";
            string address = "";
            string post_br = "";
            string pib = "";
            string mat_br = "";
            cmd0.Parameters.Add("@idp", MySqlDbType.Int32).Value = currentRow[2].Value;
            reader0 =cmd0.ExecuteReader();
            while (reader0.Read())
            {
                 customerName = reader0.GetString(0);
                 city = reader0.GetString(1);
                 address = reader0.GetString(2);
                 post_br = reader0.GetString(3);
                 pib = reader0.GetString(4);
                 mat_br = reader0.GetString(5);
            }

            string ticketNumber = rnd.Next(100).ToString() + "-" + date;
            string path = @"C:\Users\hyper\Desktop\szamla_" + date  +".pdf";
            Document doc = new Document();

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec2 = new iTextSharp.text.Rectangle(PageSize.A4);
            
            Document document = new Document(rec2, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);   
            document.Open();

            PdfPTable table1 = new PdfPTable(1);
            table1.DefaultCell.Border = PdfPCell.NO_BORDER;
            table1.DefaultCell.CellEvent = new RoundedBorder();
            table1.HorizontalAlignment = Element.ALIGN_RIGHT;
            table1.TotalWidth = 300f;
           
            string cellText = String.Format("\n {0}\n {1} \n {2}, {3}  \n PIB: {4} \n Maticni broj: {5}\n ", customerName, address, post_br, city, pib,mat_br);
            table1.AddCell(cellText);
       
            table1.WriteSelectedRows(0, -1, doc.Left + 200, doc.Top, writer.DirectContent);
          
            document.Add(new Paragraph("Raktar Info D.O.O", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18))); 
            document.Add(new Paragraph("24400 , SENTA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("KARADJORDJEVA 43", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("Tel.: 0651694323", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("________________", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("Pib:123451111", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("Maticni broj: 432111329", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("Ziro racun: " + currentRow[1].Value.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("Maticni broj: 43561329", FontFactory.GetFont(FontFactory.HELVETICA, 11)));

            Paragraph para = new Paragraph("Otpremnica - Racun " + ticketNumber , FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para.Alignment = Element.ALIGN_CENTER;
            document.Add(para);

            Paragraph para1 = new Paragraph("mesto i datum izdavanja:", FontFactory.GetFont(FontFactory.HELVETICA, 9));
            para1.Alignment = Element.ALIGN_RIGHT;
            document.Add(para1);

            Paragraph para2 = new Paragraph("Senta, " + date, FontFactory.GetFont(FontFactory.HELVETICA, 9));
            para2.Alignment = Element.ALIGN_RIGHT;
            document.Add(para2);
            document.Add(new Chunk("\n"));
           
            string name = currentRow[3].Value.ToString();
            string sifra = currentRow[5].Value.ToString();
            string db = currentRow[6].Value.ToString();
            string type = currentRow[9].Value.ToString();
            string price = "";
            string tarifa = "";

            MySqlDataReader reader;            

            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT egys_ar, tarifa FROM `termek` WHERE ids = @ids", con);
            cmd.Parameters.Add("@ids", MySqlDbType.VarChar).Value = sifra;

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                price = reader.GetString(0);
                tarifa = reader.GetString(1);

            }
            reader.Close();
            con.Close();
            
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Rbr.");
            dataTable.Columns.Add("Sifra");
            dataTable.Columns.Add("Naziv proizvoda");
            dataTable.Columns.Add("Kolicina");
            dataTable.Columns.Add("Jed.mere");
            dataTable.Columns.Add("Cena");
            dataTable.Columns.Add("Tarifa");
            dataTable.Columns.Add("Vrednost");            

            float sum = Convert.ToInt32(price) * Convert.ToInt32(db);
            
            dataTable.Rows.Add("1", sifra, name, db, type, price, tarifa, sum);

            float[] columnWidths = { 10, 10, 50,15,15,15,15,20 };
            PdfPTable pdftable = new PdfPTable(columnWidths);
            pdftable.DefaultCell.FixedHeight = 25f;
            pdftable.WidthPercentage = 100;

            for(int i = 0; i < dataTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.AddElement(new Chunk(dataTable.Columns[i].ColumnName));
                pdftable.AddCell(cell);
            }
            for( int i= 0; i < dataTable.Rows.Count; i++)
            {
                for(int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdftable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }
            document.Add(pdftable);
            
            Paragraph para3 = new Paragraph("Vrednost: " + sum, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9));
            para3.Alignment = Element.ALIGN_RIGHT;
            document.Add(para3);
            document.Add(new Chunk("\n"));
            document.Add(new Paragraph("Rbr.   Tarifa PDV    Osnovica     %     PDV", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("___________________________________________", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph(" 1            " + tarifa+ "             "+ sum +"          20    " + Convert.ToInt32(price), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("___________________________________________", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Paragraph("Svega PDV:                                          " + Convert.ToInt32(price), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)));
            document.Add(new Chunk("\n"));
            Paragraph para4 = new Paragraph("___________________________________", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para4.Alignment = Element.ALIGN_RIGHT;
            document.Add(para4);
            Paragraph para5 = new Paragraph("Ukupno:    " + sum + "        ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para5.Alignment = Element.ALIGN_RIGHT;
            document.Add(para5);
            Paragraph para6 = new Paragraph("Svega PDV:      " + Convert.ToInt32(price) + "        ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para6.Alignment = Element.ALIGN_RIGHT;
            document.Add(para6);
            Paragraph para7 = new Paragraph("___________________________________", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para7.Alignment = Element.ALIGN_RIGHT;
            document.Add(para7);
            Paragraph para8 = new Paragraph("Ukupno za uplatu:      " +  (sum + Convert.ToDouble(price)) + " DIN    ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
            para8.Alignment = Element.ALIGN_RIGHT;
            document.Add(para8);
            document.Add(new Chunk("\n"));
            document.Add(new Paragraph("Datum prometa dobara i usluga:  " + date, FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("Rok uplate:  " + date, FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("Nacin placanja:    Virmaski ", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("\n"));
            document.Add(new Paragraph("U SLUCAJU NEBLAGOVREMENOG PLACANJA ZARACUNAVAMO ZAKONSKU ZATEZNU KAMATU ", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("MESTO I ADRESA IZDAVANJA ROBE/PROIZVODA: SENTA, SA 024 SA ", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("NAPOMENA O PORESKOM OSLOBODJENJU: NEMA ", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Paragraph("MESTO ISPORUKE: ", FontFactory.GetFont(FontFactory.HELVETICA, 11)));
            document.Add(new Chunk("\n"));
            document.Add(new Paragraph("ODGOVORNO LICE ISPORUCIOCA", FontFactory.GetFont(FontFactory.HELVETICA, 11)));

            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph p = new Paragraph("BEVIZ DANIEL");
            p.Add(new Chunk(glue));
            p.Add("ODGOVORNO LICE PRIMAOCA");
            document.Add(p);

            Chunk glue2 = new Chunk(new VerticalPositionMark());
            Paragraph p2 = new Paragraph("(ime i prezime stamp.slovima)");
            p2.Add(new Chunk(glue2));
            p2.Add("(ime i prezime stamp.slovima)");
            document.Add(p2);

            Chunk glue3 = new Chunk(new VerticalPositionMark());
            Paragraph p3 = new Paragraph("_____________________________");
            p3.Add(new Chunk(glue3));
            p3.Add("_____________________________");
            document.Add(p3);

            Chunk glue4 = new Chunk(new VerticalPositionMark());//-----
            Paragraph p4 = new Paragraph("             (potpis)"); //(ime i prezime stamp.slovima)
            p4.Add(new Chunk(glue3));
            p4.Add("(potpis)             ");
            document.Add(p4);               
            document.Close();  // Close the document                
            writer.Close();// Close the writer instance            
            fs.Close();
            document.Close();

            MessageBox.Show("PDF created successfull!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
