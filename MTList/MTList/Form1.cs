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
        private System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mTLISTDataSet.MTTable' table. You can move, or remove it, as needed.
            
            mTTableTableAdapter.Fill(this.mTLISTDataSet.MTTable);
            dataGridView1.DataSource = mTLISTDataSet.MTTable;
          
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
                mTTableTableAdapter.GetData();
                mTTableTableAdapter.FillBy(mTLISTDataSet.MTTable);
                dataGridView1.DataSource = mTLISTDataSet.MTTable;

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
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand();
               // cmd.CommandText = 'insert';
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(table);
                
                bindingSource1.DataSource = table;
                mTTableTableAdapter.GetData();
                dataAdapter.Update(table);
                

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
    }
}