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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.formPemesananToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPenyewaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataKaryawanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMobilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataHirePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCabangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(864, 29);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formPemesananToolStripMenuItem,
            this.dataPenyewaToolStripMenuItem,
            this.dataKaryawanToolStripMenuItem,
            this.dataMobilToolStripMenuItem,
            this.dataHirePointToolStripMenuItem,
            this.dataCabangToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // formPemesananToolStripMenuItem
            // 
            this.formPemesananToolStripMenuItem.Name = "formPemesananToolStripMenuItem";
            this.formPemesananToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.formPemesananToolStripMenuItem.Text = "Form Pemesanan";
            this.formPemesananToolStripMenuItem.Click += new System.EventHandler(this.formPemesananToolStripMenuItem_Click);
            // 
            // dataPenyewaToolStripMenuItem
            // 
            this.dataPenyewaToolStripMenuItem.Name = "dataPenyewaToolStripMenuItem";
            this.dataPenyewaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dataPenyewaToolStripMenuItem.Text = "Data Penyewa";
            this.dataPenyewaToolStripMenuItem.Click += new System.EventHandler(this.dataPenyewaToolStripMenuItem_Click);
            // 
            // dataKaryawanToolStripMenuItem
            // 
            this.dataKaryawanToolStripMenuItem.Name = "dataKaryawanToolStripMenuItem";
            this.dataKaryawanToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dataKaryawanToolStripMenuItem.Text = "Data Karyawan";
            this.dataKaryawanToolStripMenuItem.Click += new System.EventHandler(this.dataKaryawanToolStripMenuItem_Click);
            // 
            // dataMobilToolStripMenuItem
            // 
            this.dataMobilToolStripMenuItem.Name = "dataMobilToolStripMenuItem";
            this.dataMobilToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dataMobilToolStripMenuItem.Text = "Data Mobil";
            this.dataMobilToolStripMenuItem.Click += new System.EventHandler(this.dataMobilToolStripMenuItem_Click);
            // 
            // dataHirePointToolStripMenuItem
            // 
            this.dataHirePointToolStripMenuItem.Name = "dataHirePointToolStripMenuItem";
            this.dataHirePointToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dataHirePointToolStripMenuItem.Text = "Data Hire Point";
            this.dataHirePointToolStripMenuItem.Click += new System.EventHandler(this.dataHirePointToolStripMenuItem_Click);
            // 
            // dataCabangToolStripMenuItem
            // 
            this.dataCabangToolStripMenuItem.Name = "dataCabangToolStripMenuItem";
            this.dataCabangToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.dataCabangToolStripMenuItem.Text = "Data Cabang";
            this.dataCabangToolStripMenuItem.Click += new System.EventHandler(this.dataCabangToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(851, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "WELCOME TO RUBY RENTAL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(864, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem formPemesananToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataHirePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataKaryawanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataMobilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataCabangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPenyewaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

