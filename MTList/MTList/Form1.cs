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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            // TODO: This line of code loads data into the 'mTLISTDataSet.MTTable' table. You can move, or remove it, as needed.
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=192.168.1.213;User ID=sa;Password=######;Initial Catalog=MTList";
            con.Open();
            dataAdapter = new System.Data.SqlClient.SqlDataAdapter("select * from dbo.MTTable", con);
            ds = new DataSet();
            dataAdapter.Fill(ds, "MTTable");
            dataGridView1.DataSource = ds.Tables[0];
                //mTTableTableAdapter.Fill(this.mTLISTDataSet.MTTable);
                //dataGridView1.DataSource = mTLISTDataSet.MTTable;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
        
            
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
        private DataRow LastDataRow = null;

        /// <SUMMARY>
        /// Checks if there is a row with changes and
        /// writes it to the database
        /// </SUMMARY>
        private void UpdateRowToDatabase()
        {
            if (LastDataRow != null)
            {
                if (LastDataRow.RowState ==
                    DataRowState.Modified)
                {
                    mTTableTableAdapter.Update(LastDataRow);
                    MessageBox.Show("it is added");
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        





            try
            {
                SqlCommandBuilder cmdbl = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(ds, "MTTable");
                
                //DataTable table = new DataTable();
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "insert into MTTable(DriverName, City, State, Trailer, Notes, Status)"+
                //    " values('John Fransis', 'Newport', 'RI', 48101, 'Needs GA', 'Ready 10/27')";

                //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                //dataAdapter.SelectCommand.CommandText = cmd.CommandText;
                
                
                //bindingSource1.DataSource = table;
                //dataAdapter.Fill(table);
                //mTTableTableAdapter.GetData();
                //dataAdapter.Update(table);
                //UpdateRowToDatabase();
                


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
                this.mTTableTableAdapter.FillBy1(this.mTLISTDataSet.MTTable);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void refreshWOSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mTTableTableAdapter.Fill(this.mTLISTDataSet.MTTable);
            dataGridView1.DataSource = mTLISTDataSet.MTTable;
        }

        private void tslAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}