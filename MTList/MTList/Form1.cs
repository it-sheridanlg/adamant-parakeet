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
        private BindingSource bindingSource1 = new BindingSource();
        private DataSet ds;
        SqlCommandBuilder cmdbl;

        public Form1()
        {
            InitializeComponent();
        }
        private SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            // TODO: This line of code loads data into the 'mTLISTDataSet.MTTable' table. You can move, or remove it, as needed.
            con = new SqlConnection();
            con.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
            con.Open();
            dataAdapter = new System.Data.SqlClient.SqlDataAdapter("select ID,DriverName,City,State,Trailer,Notes,Status from dbo.MTTable", con);
            ds = new DataSet();
            dataAdapter.Fill(ds, "MTTable");
            dataGridView1.DataSource = ds.Tables[0];
                
                
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            con.Close();
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

        private void refreshWOSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ds = new DataSet();
            dataAdapter.Fill(ds, "MTTable");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void tslAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDialog1.ShowDialog();
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 10, 10);
        }

        private void tsRefresh_Click(object sender, EventArgs e)
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

        private void tsSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtTEST;
                cmdbl = new SqlCommandBuilder(dataAdapter);
                dataAdapter.AcceptChangesDuringUpdate = true;
                dataAdapter.Update(ds, "MTTable");



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
    }
}