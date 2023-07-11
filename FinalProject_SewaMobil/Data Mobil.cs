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

namespace FinalProject_SewaMobil
{
    public partial class Data_Mobil : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string idcar, cabang, nama, merk, tipe, warna, tahun, kapas, biaya;
        BindingSource customerBindingSource = new BindingSource();
        public Data_Mobil()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
