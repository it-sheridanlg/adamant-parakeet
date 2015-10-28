using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MTList
{
    public partial class Form1 : Form
    {
        private System.Data.SqlClient.SqlDataAdapter dataAdapter;
        private System.Data.SqlClient.SqlDataAdapter dataAdapter1;
        private System.Data.SqlClient.SqlDataAdapter dataAdapterHome;
        private System.Data.SqlClient.SqlDataAdapter dataAdapterPart;
        private DataSet ds;
        private DataSet ds1;
        private DataSet dsHome;
        private DataSet dsPart;
        private SqlCommandBuilder cmdbl;
        private SqlCommandBuilder cmdbl1;
        private SqlCommandBuilder cmdblHome;
        private SqlCommandBuilder cmdblPart;
        private SqlConnection con;
        private SqlConnection con1;
        private SqlConnection conHome;
        private SqlConnection conPart;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mTLISTDataSet.MTTable1' table. You can move, or remove it, as needed.
            this.mTTable1TableAdapter.Fill(this.mTLISTDataSet.MTTable1);
            try
            {
                
            // MTList Left Top Datagridview1
                con = new SqlConnection();
                con.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                con.Open();
                dataAdapter = new System.Data.SqlClient.SqlDataAdapter("select ID,DriverName,City,State,Trailer,Notes,Status,Color from dbo.MTTable", con);
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];

            // MTList1 Right Top Datagridview2
                con1 = new SqlConnection();
                con1.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                con1.Open();
                dataAdapter1 = new System.Data.SqlClient.SqlDataAdapter("select ID,DriverName,City,State,Trailer,Notes,Status,Color from dbo.MTTable1", con1);
                ds1 = new DataSet();
                dataAdapter1.Fill(ds1, "MTTable1");
                dataGridView2.DataSource = ds1.Tables[0];
                RowsColor();


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            con.Close();
            con1.Close();
            MessageBox.Show("works");
            


            }


    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // public event ReportPrintEventHandler Print
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
         
        }
     
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

      

        private void tslAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width + this.dataGridView2.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            dataGridView2.DrawToBitmap(bm, new Rectangle(this.dataGridView1.Width, 0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bm, 0, 10);
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];
                RowsColor();


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtTEST;
                cmdbl = new SqlCommandBuilder(dataAdapter);
                dataAdapter.AcceptChangesDuringUpdate = true;
                dataAdapter.Update(ds, "MTTable");

                cmdbl1 = new SqlCommandBuilder(dataAdapter1);
                dataAdapter1.AcceptChangesDuringUpdate = true;
                dataAdapter1.Update(ds1, "MTTable1");

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void aboutMTListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MTList Version 0.2", "About", MessageBoxButtons.OK);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Close();
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DateTime datenow = new DateTime();
            
            if (checkBox1.Checked == true)
            {
                //do
                //{
                //    datenow = DateTime.Now;
                //    do
                //    {

                //    } while ();
                    
                //} while (checkBox1.Checked == true);

            }
                
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //do whatever you want 
            RefreshMyForm();
        }

        private void RefreshMyForm()
        {

            //update form with latest Data
            ds = new DataSet();
            dataAdapter.Fill(ds, "MTTable");
            dataGridView1.DataSource = ds.Tables[0];

        }
        public void RowsColor()
        {
            Color col = new Color();
            string tempColor;
            string strColor;
            
            int i = 0;
            
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
                tempColor = dataGridView1.Rows[i].Cells[7].FormattedValue.ToString();
                strColor = tempColor.ToUpper();
                bool y = strColor.Contains("Y");
                bool r = strColor.Contains("R");
                bool g = strColor.Contains("G");
                bool w = strColor.Contains("W");
                bool b = strColor.Contains("B");
                bool d = strColor.Contains("D");



                if (y)
                {
                    col = Color.Yellow;
                    
                }
                else if (r)
                {
                    col = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }
                else if (g)
                {
                    col = Color.Green;
                }
                else if (b)
                {
                    col = Color.LightBlue;
                }
                else if (w)
                {
                    col = Color.White;
                }
                else if (d)
                {
                    col = Color.Black;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    col = Color.White;
                }


                dataGridView1.Rows[i].DefaultCellStyle.BackColor = col;
            }


            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                tempColor = dataGridView2.Rows[i].Cells[7].FormattedValue.ToString();
                strColor = tempColor.ToUpper();
                bool y = strColor.Contains("Y");
                bool r = strColor.Contains("R");
                bool g = strColor.Contains("G");
                bool w = strColor.Contains("W");
                bool b = strColor.Contains("B");

                if (y)
                {
                    col = Color.Yellow;
                }
                else if (r)
                {
                    col = Color.Red;
                }
                else if (g)
                {
                    col = Color.Green;
                }
                else if (b)
                {
                    col = Color.LightBlue;
                }
                else if (w)
                {
                    col = Color.White;
                }
                else
                {
                    col = Color.White;
                }


                dataGridView2.Rows[i].DefaultCellStyle.BackColor = col;
            }


        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}