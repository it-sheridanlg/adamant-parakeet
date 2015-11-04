namespace MTList
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Printgrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Printgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Printgrid
            // 
            this.Printgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Printgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Printgrid.Location = new System.Drawing.Point(0, 0);
            this.Printgrid.Name = "Printgrid";
            this.Printgrid.Size = new System.Drawing.Size(548, 760);
            this.Printgrid.TabIndex = 0;
            this.Printgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Printgrid_CellContentClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 760);
            this.Controls.Add(this.Printgrid);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Printgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Printgrid;
    }
}