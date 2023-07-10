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
    public partial class Data_Karyawan : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string id_kry, id_cabang, nama, telp, adr, jabatan;
        BindingSource customerBindingSource = new BindingSource();
        public Data_Karyawan()
        {
            InitializeComponent();

        }

        private void Karyawan_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_kry, m.nm_kry, "
                + "m.adr_kry, m.jabatan, m.telp_kry, p.id_cabang From dbo.karyawan m " +
                "join dbo.cabang p on m.id_cabang = p.id_cabang", koneksi));
            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);

            this.customerBindingSource.DataSource = ds.Tables[0];
            this.idkarya.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "id_kry", true));
            this.txtkaryawan.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "nm_kry", true));
            this.adrkrywn.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "adr_kry", true));
            this.txtjabatan.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "jabatan", true));
            this.telpkrywn.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "telp_kry", true));
            this.cbxcabang.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "nm_cabang", true));
            koneksi.Close();
        }

        private void clearBinding()
        {
            this.txtjabatan.DataBindings.Clear();
            this.txtkaryawan.DataBindings.Clear();
            this.adrkrywn.DataBindings.Clear();
            this.telpkrywn.DataBindings.Clear();
            this.cbxcabang.DataBindings.Clear();
            this.idkarya.DataBindings.Clear();
        }

        private void refreshform()
        {
            txtkaryawan.Enabled = false;
            idkarya.Enabled = false;
            telpkrywn.Enabled = false;
            adrkrywn.Enabled = false;
            txtjabatan.Enabled = false;
            cbxcabang.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            clearBinding();
            Karyawan_Load();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
