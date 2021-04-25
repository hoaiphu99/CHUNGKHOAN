namespace CHUNGKHOAN
{
    partial class frmBGTT
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
            this.components = new System.ComponentModel.Container();
            this.dsCHUNGKHOAN = new CHUNGKHOAN.dsCHUNGKHOAN();
            this.bdsBANGGIATRUCTUYEN = new System.Windows.Forms.BindingSource(this.components);
            this.bANGGIATRUCTUYENTableAdapter = new CHUNGKHOAN.dsCHUNGKHOANTableAdapters.BANGGIATRUCTUYENTableAdapter();
            this.tableAdapterManager = new CHUNGKHOAN.dsCHUNGKHOANTableAdapters.TableAdapterManager();
            this.lblKq1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dsCHUNGKHOAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBANGGIATRUCTUYEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dsCHUNGKHOAN
            // 
            this.dsCHUNGKHOAN.DataSetName = "dsCHUNGKHOAN";
            this.dsCHUNGKHOAN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsBANGGIATRUCTUYEN
            // 
            this.bdsBANGGIATRUCTUYEN.DataMember = "BANGGIATRUCTUYEN";
            this.bdsBANGGIATRUCTUYEN.DataSource = this.dsCHUNGKHOAN;
            // 
            // bANGGIATRUCTUYENTableAdapter
            // 
            this.bANGGIATRUCTUYENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGGIATRUCTUYENTableAdapter = this.bANGGIATRUCTUYENTableAdapter;
            this.tableAdapterManager.LENHDATTableAdapter = null;
            this.tableAdapterManager.LENHKHOPTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CHUNGKHOAN.dsCHUNGKHOANTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lblKq1
            // 
            this.lblKq1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKq1.AutoSize = true;
            this.lblKq1.Location = new System.Drawing.Point(12, 572);
            this.lblKq1.Name = "lblKq1";
            this.lblKq1.Size = new System.Drawing.Size(47, 17);
            this.lblKq1.TabIndex = 2;
            this.lblKq1.Text = "Status";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1262, 569);
            this.dataGridView1.TabIndex = 3;
            // 
            // frmBGTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 672);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblKq1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBGTT";
            this.Text = "Bảng giá trực tuyến";
            this.Load += new System.EventHandler(this.frmBGTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsCHUNGKHOAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBANGGIATRUCTUYEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsCHUNGKHOAN dsCHUNGKHOAN;
        private System.Windows.Forms.BindingSource bdsBANGGIATRUCTUYEN;
        private dsCHUNGKHOANTableAdapters.BANGGIATRUCTUYENTableAdapter bANGGIATRUCTUYENTableAdapter;
        private dsCHUNGKHOANTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label lblKq1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

