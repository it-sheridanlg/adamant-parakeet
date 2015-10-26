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

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            // TODO: This line of code loads data into the 'mTLISTDataSet.MTTable' table. You can move, or remove it, as needed.
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=192.168.1.213;User ID=sa;Password=*****;Initial Catalog=MTList";
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


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // public event ReportPrintEventHandler Print
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
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
     
        private void toolStripButton1_Click(object sender, EventArgs e)
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
    }
}