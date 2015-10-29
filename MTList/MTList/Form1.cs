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
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private bool unsaved = false;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                





            // MTList Left Top Datagridview1
                con = new SqlConnection();
                con.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                con.Open();
                dataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT ID,DriverName,City,State,Trailer,Notes,Status,Color from dbo.MTTable", con);
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];

            // MTList1 Right Top Datagridview2
                con1 = new SqlConnection();
                con1.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                con1.Open();
                dataAdapter1 = new System.Data.SqlClient.SqlDataAdapter("SELECT ID,DriverName,City,State,Trailer,Notes,Status,Color from dbo.MTTable1", con1);
                ds1 = new DataSet();
                dataAdapter1.Fill(ds1, "MTTable1");
                dataGridView2.DataSource = ds1.Tables[0];

            // MTHome Left Bottom Datagridview3
                conHome = new SqlConnection();
                conHome.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                conHome.Open();
                dataAdapterHome = new System.Data.SqlClient.SqlDataAdapter("SELECT ID,DriverName,HomeCity,HomeState,[When],HowLong,Notes,Color from dbo.MTHome", conHome);
                dsHome = new DataSet();
                dataAdapterHome.Fill(dsHome, "MTHome");
                dataGridView3.DataSource = dsHome.Tables[0];

            // MTPart Right Bottom Datagridview4
                conPart = new SqlConnection();
                conPart.ConnectionString = @"server=192.168.1.213;Integrated Security=true;Initial Catalog=MTList";
                conPart.Open();
                dataAdapterPart = new System.Data.SqlClient.SqlDataAdapter("SELECT ID,DriverName,City,State,Trailer,AvaliableSpace,Destination,Color from dbo.MTPart", conPart);
                dsPart = new DataSet();
                dataAdapterPart.Fill(dsPart, "MTPart");
                dataGridView4.DataSource = dsPart.Tables[0];

                unsaved = false;





            // Colors the rows the defined colors in the database.
                RowsColor();


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
            // Refresh the data and re-color
            try
            {

             // MTList Left Top Datagridview1
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];

             // MTList1 Right Top Datagridview2
                ds1 = new DataSet();
                dataAdapter1.Fill(ds1, "MTTable1");
                dataGridView2.DataSource = ds1.Tables[0];

             // MTHome Left Bottom Datagridview3
                dsHome = new DataSet();
                dataAdapterHome.Fill(dsHome, "MTHome");
                dataGridView3.DataSource = dsHome.Tables[0];

             // MTPart Right Bottom Datagridview4
                dsPart = new DataSet();
                dataAdapterPart.Fill(dsPart, "MTPart");
                dataGridView4.DataSource = dsPart.Tables[0];

             // Colors the rows the defined colors in the database.
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
             // Save new Data 
                SaveIt();

             // Refresh The Form
                RefreshIt();

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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                RefreshIt();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                
                SaveIt();
                RefreshIt();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SaveIt()
        {
            // Change Focus
            this.ActiveControl = txtTEST;

            // Save new data to database -MTTable
            cmdbl = new SqlCommandBuilder(dataAdapter);
            dataAdapter.AcceptChangesDuringUpdate = true;
            dataAdapter.Update(ds, "MTTable");

            // Save new data to database -MTTable1
            cmdbl1 = new SqlCommandBuilder(dataAdapter1);
            dataAdapter1.AcceptChangesDuringUpdate = true;
            dataAdapter1.Update(ds1, "MTTable1");

            // Save new data to database -MTHome
            cmdblHome = new SqlCommandBuilder(dataAdapterHome);
            dataAdapterHome.AcceptChangesDuringUpdate = true;
            dataAdapterHome.Update(dsHome, "MTHome");

            // Save new data to database -MTPart
            cmdblPart = new SqlCommandBuilder(dataAdapterPart);
            dataAdapterPart.AcceptChangesDuringUpdate = true;
            dataAdapterPart.Update(dsPart, "MTPart");

            // Note that data has been saved
            unsaved = false;
        }
        private void RefreshIt()
        {
            try
            {

                // MTList Left Top Datagridview1
                ds = new DataSet();
                dataAdapter.Fill(ds, "MTTable");
                dataGridView1.DataSource = ds.Tables[0];

                // MTList1 Right Top Datagridview2
                ds1 = new DataSet();
                dataAdapter1.Fill(ds1, "MTTable1");
                dataGridView2.DataSource = ds1.Tables[0];

                // MTHome Left Bottom Datagridview3
                dsHome = new DataSet();
                dataAdapterHome.Fill(dsHome, "MTHome");
                dataGridView3.DataSource = dsHome.Tables[0];

                // MTPart Right Bottom Datagridview4
                dsPart = new DataSet();
                dataAdapterPart.Fill(dsPart, "MTPart");
                dataGridView4.DataSource = dsPart.Tables[0];

                // Colors the rows the defined colors in the database.
                RowsColor();



            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Close all open database connections
            con.Close();
            con1.Close();
            conHome.Close();
            conPart.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
            
            

            if (checkBox1.Checked == true)
            {
              timer1.Interval = 12000;//5 minutes300000
                timer1.Tick += new System.EventHandler(timer1_Tick);
              timer1.Start();
            }
            else
            { timer1.Stop(); }
                
        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (!unsaved)
            {
                MessageBox.Show("refresh called");
                RefreshMyForm();
            }
            else if (unsaved | MessageBox.Show("You have unsaved changes! Do you want to save them now!?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveIt();
                RefreshIt();
            }
            else
            {
                MessageBox.Show("Changes not saved and page not refreshed!");
            }
           
            
        }

        private void RefreshMyForm()
        {
            
            // Refresh the data and re-color
            RefreshIt();

        }
        public void RowsColor()
        {
            Color col = new Color();

            string tempColor;
            string strColor;
            string tempColorRea;
            string strReadyPlan;
            
            int i = 0;

         // Color for DataGridView1 -MTTable
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tempColor = dataGridView1.Rows[i].Cells[7].FormattedValue.ToString();
                tempColorRea = dataGridView1.Rows[i].Cells[6].FormattedValue.ToString();
                strColor = tempColor.ToUpper();
                strReadyPlan = tempColorRea.ToUpper();

                bool y = strColor.Contains("Y");
                bool r = strColor.Contains("R");
                bool g = strColor.Contains("G");
                bool w = strColor.Contains("W");
                bool b = strColor.Contains("B");
                bool d = strColor.Contains("D");
                bool ready = strReadyPlan.Contains("READY");
                bool planned = strReadyPlan.Contains("PLANNED");



                if (y)
                { col = Color.Yellow; }
                else if (r)
                { col = Color.Red; }
                else if (g)
                { col = Color.Green; }
                else if (b)
                { col = Color.LightBlue; }
                else if (w)
                { col = Color.White; }
                else if (d)
                {
                    col = Color.Black;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White; 
                }
                else if (ready)
                { col = Color.Green; }
                else if (planned)
                { col = Color.Yellow; }
                else
                { col = Color.White; }


                dataGridView1.Rows[i].DefaultCellStyle.BackColor = col;
            }

         // Color for DataGridView2 -MTTable1
            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                tempColor = dataGridView2.Rows[i].Cells[7].FormattedValue.ToString();
                tempColorRea = dataGridView2.Rows[i].Cells[6].FormattedValue.ToString();
                strColor = tempColor.ToUpper();
                strReadyPlan = tempColorRea.ToUpper();

                bool y = strColor.Contains("Y");
                bool r = strColor.Contains("R");
                bool g = strColor.Contains("G");
                bool w = strColor.Contains("W");
                bool b = strColor.Contains("B");
                bool d = strColor.Contains("D");
                bool ready = strReadyPlan.Contains("READY");
                bool planned = strReadyPlan.Contains("PLANNED");

                if (y)
                { col = Color.Yellow;  }
                else if (r)
                { col = Color.Red; }
                else if (g)
                { col = Color.Green; }
                else if (b)
                { col = Color.LightBlue; }
                else if (w)
                { col = Color.White; }
                else if (d)
                {
                    col = Color.Black;
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else if (ready)
                { col = Color.Green; }
                else if (planned)
                { col = Color.Yellow; }
                else
                { col = Color.White; }


                dataGridView2.Rows[i].DefaultCellStyle.BackColor = col;
            }

         // Color for DataGridView3 -MTHome
            for (i = 0; i < dataGridView3.Rows.Count; i++)
            {
                tempColor = dataGridView3.Rows[i].Cells[7].FormattedValue.ToString();

                strColor = tempColor.ToUpper();

                bool y = strColor.Contains("Y");
                bool r = strColor.Contains("R");
                bool g = strColor.Contains("G");
                bool w = strColor.Contains("W");
                bool b = strColor.Contains("B");
                bool d = strColor.Contains("D");

                if (y)
                { col = Color.Yellow; }
                else if (r)
                { col = Color.Red; }
                else if (g)
                { col = Color.Green; }
                else if (b)
                { col = Color.LightBlue; }
                else if (w)
                { col = Color.White; }
                else if (d)
                {
                    col = Color.Black;
                    dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                { col = Color.White; }


                dataGridView3.Rows[i].DefaultCellStyle.BackColor = col;
            }

         // Color for DataGridView4 -MTPart
            for (i = 0; i < dataGridView4.Rows.Count; i++)
            {
                tempColor = dataGridView4.Rows[i].Cells[7].FormattedValue.ToString();

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
                { col = Color.Red; }
                else if (g)
                { col = Color.Green; }
                else if (b)
                { col = Color.LightBlue; }
                else if (w)
                { col = Color.White; }
                else if (d)
                {
                    col = Color.Black;
                    dataGridView4.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                { col = Color.White; }

                dataGridView4.Rows[i].DefaultCellStyle.BackColor = col;

            }

        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            unsaved = true;
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            unsaved = true;
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            unsaved = true;
        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            unsaved = true;
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowsColor();
        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowsColor();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowsColor();
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowsColor();
        }
        private void copyRowNow(DataGridView datCo,DataGridView datPa, int selCo,int selPa)
        {


            for (int j = 0; j < datCo.Rows[selCo].Cells.Count; j++)

                datPa.Rows[selPa].Cells[j].Value = datCo.Rows[selCo].Cells[j].Value;
        }

        private int selC;
        private int selP;
        private DataGridView datC;
        private DataGridView datP;

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grid 1: " + this.dataGridView1.Focused.ToString() + " Grid 2: " + this.dataGridView2.Focused.ToString()
                + " Grid 3: " + this.dataGridView3.Focused.ToString()
                + " Grid 4: " + this.dataGridView4.Focused.ToString());

            if (dataGridView1.Focused)
            {
                selC = dataGridView1.SelectedRows[0].Index;
                datC = dataGridView1;
               
            }
            else if (dataGridView2.Focused)
            {
                selC = dataGridView2.SelectedRows[0].Index;
                datC = dataGridView2;
            }
            else if (dataGridView3.Focused)
            {
                selC = dataGridView3.SelectedRows[0].Index;
                datC = dataGridView3;
            }
            else if (dataGridView4.Focused)
            {
                selC = dataGridView4.SelectedRows[0].Index;
                datC = dataGridView4;
            }
            else
            {
                MessageBox.Show("No Copy Row Selected");
            }
        }

        private void pasteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
            {
                selP = dataGridView1.SelectedRows[0].Index;
                datP = dataGridView1;
                copyRowNow(datC, datP, selC, selP);
            }
            else if (dataGridView2.Focused)
            {
                selP = dataGridView2.SelectedRows[0].Index;
                datP = dataGridView2;
                copyRowNow(datC, datP, selC, selP);
            }
            else if (dataGridView3.Focused)
            {
                selP = dataGridView3.SelectedRows[0].Index;
                datP = dataGridView3;
                copyRowNow(datC, datP, selC, selP);
            }
            else if (dataGridView4.Focused)
            {
                selP = dataGridView4.SelectedRows[0].Index;
                datP = dataGridView4;
                copyRowNow(datC, datP, selC, selP);
            }
            else
            {
                MessageBox.Show("No Paste Row Selected");
            }

        }
    }
}