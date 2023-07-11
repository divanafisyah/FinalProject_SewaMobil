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
    public partial class Data_Cabang : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string cabang, nama, telp, adr, jumlah;
        BindingSource customerBindingSource = new BindingSource();
        public Data_Cabang()
        {
            InitializeComponent();
        }

        private void Cabang_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_cabang, m.nm_cabang, "
                + "m.adr_cabang, m.telp_cabang, m.jmlh_mobil", koneksi));
            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);

            this.customerBindingSource.DataSource = ds.Tables[0];
            this.txtID.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "id_cabang", true));
            this.txtcabang.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "nm_cabang", true));
            this.txtalamat.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "adr_cabang", true));
            this.txttelepon.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "telp_kry", true));
            this.txtjumlah.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "jmlh_mobil", true));
            koneksi.Close();
        }

        private void clearBinding()
        {
            this.txtalamat.DataBindings.Clear();
            this.txtcabang.DataBindings.Clear();
            this.txtjumlah.DataBindings.Clear();
            this.txttelepon.DataBindings.Clear();
            this.txtID.DataBindings.Clear();
        }

        private void refreshform()
        {
            txtID.Enabled = false;
            txtcabang.Enabled = false;
            txttelepon.Enabled = false;
            txtalamat.Enabled = false;
            txtjumlah.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            clearBinding();
            Cabang_Load();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
