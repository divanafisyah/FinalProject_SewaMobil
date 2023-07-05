namespace FinalProject_SewaMobil
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.formPemesananToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formPengembalianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataHirePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataKaryawanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMobilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCabangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPenyewaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formPemesananToolStripMenuItem,
            this.formPengembalianToolStripMenuItem,
            this.dataPenyewaToolStripMenuItem,
            this.dataHirePointToolStripMenuItem,
            this.dataKaryawanToolStripMenuItem,
            this.dataMobilToolStripMenuItem,
            this.dataCabangToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // formPemesananToolStripMenuItem
            // 
            this.formPemesananToolStripMenuItem.Name = "formPemesananToolStripMenuItem";
            this.formPemesananToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.formPemesananToolStripMenuItem.Text = "Form Pemesanan";
            // 
            // formPengembalianToolStripMenuItem
            // 
            this.formPengembalianToolStripMenuItem.Name = "formPengembalianToolStripMenuItem";
            this.formPengembalianToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.formPengembalianToolStripMenuItem.Text = "Form Pengembalian";
            // 
            // dataHirePointToolStripMenuItem
            // 
            this.dataHirePointToolStripMenuItem.Name = "dataHirePointToolStripMenuItem";
            this.dataHirePointToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataHirePointToolStripMenuItem.Text = "Data Hire Point";
            // 
            // dataKaryawanToolStripMenuItem
            // 
            this.dataKaryawanToolStripMenuItem.Name = "dataKaryawanToolStripMenuItem";
            this.dataKaryawanToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataKaryawanToolStripMenuItem.Text = "Data Karyawan";
            // 
            // dataMobilToolStripMenuItem
            // 
            this.dataMobilToolStripMenuItem.Name = "dataMobilToolStripMenuItem";
            this.dataMobilToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataMobilToolStripMenuItem.Text = "Data Mobil";
            // 
            // dataCabangToolStripMenuItem
            // 
            this.dataCabangToolStripMenuItem.Name = "dataCabangToolStripMenuItem";
            this.dataCabangToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataCabangToolStripMenuItem.Text = "Data Cabang";
            // 
            // dataPenyewaToolStripMenuItem
            // 
            this.dataPenyewaToolStripMenuItem.Name = "dataPenyewaToolStripMenuItem";
            this.dataPenyewaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataPenyewaToolStripMenuItem.Text = "Data Penyewa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem formPemesananToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formPengembalianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataHirePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataKaryawanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataMobilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataCabangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPenyewaToolStripMenuItem;
    }
}

