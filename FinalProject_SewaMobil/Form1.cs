using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_SewaMobil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataCabangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Cabang fm = new Data_Cabang();
            fm.Show();
            this.Hide();
        }

        private void dataPenyewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Penyewa fm = new Penyewa();
            fm.Show();
            this.Hide();
        }

        private void dataKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Karyawan fm = new Data_Karyawan();
            fm.Show();
            this.Hide();
        }

        private void dataMobilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Mobil fm = new Data_Mobil();
            fm.Show();
            this.Hide();
        }

        private void dataHirePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Hire_Point fm = new Data_Hire_Point();
            fm.Show();
            this.Hide();
        }

        private void formPemesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Pemesanan fm = new Form_Pemesanan();
            fm.Show();
            this.Hide();
        }
    }
}
