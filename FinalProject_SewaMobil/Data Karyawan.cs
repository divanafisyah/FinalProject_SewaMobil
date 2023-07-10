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
        private string id_kry, cabang, nama, telp, adr, jabatan;
        BindingSource customerBindingSource = new BindingSource();
        public Data_Karyawan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            this.bindingNavigator1.BindingSource = this.customerBindingSource;
            refreshform();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            id_kry = idkarya.Text;
            nama = txtkaryawan.Text;
            jabatan = txtjabatan.Text;
            adr = adrkrywn.Text;
            telp = telpkrywn.Text;
            cabang = cbxcabang.SelectedValue.ToString();
            koneksi.Open();
            string strs = "select id_cabang from dbo.cabang where nm_cabang = @dd";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@dd", cabang));
            SqlDataReader dr = cm.ExecuteReader();
            dr.Close();
            string str = "insert into dbo.Mahasiswa (id_kry, nm_kry, jabatan, telp_kry, adr_kry, id_cabang)" +
                "values(@id, @nm, @jabatan, @telp, @adr, @idc)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", id_kry));
            cmd.Parameters.Add(new SqlParameter("@nm", nama));
            cmd.Parameters.Add(new SqlParameter("@jabatan", jabatan));
            cmd.Parameters.Add(new SqlParameter("@telp", telp));
            cmd.Parameters.Add(new SqlParameter("@adr", adr));
            cmd.Parameters.Add(new SqlParameter("@idc", cabang));
            cmd.ExecuteNonQuery();

            koneksi.Close();

            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            refreshform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
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

        private void Cabangcbx()
        {
            koneksi.Open();
            string str = "select id_cabang, nm_cabang from dbo.cabang";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxcabang.DisplayMember = "nm_cabang";
            cbxcabang.ValueMember = "id_cabang";
            cbxcabang.DataSource = ds.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtkaryawan.Text = "";
            idkarya.Text = "";
            telpkrywn.Text = "";
            adrkrywn.Text = "";
            txtjabatan.Text = "";
            txtkaryawan.Enabled = true;
            txtjabatan.Enabled = true;
            cbxcabang.Enabled = true;
            idkarya.Enabled = true;
            telpkrywn.Enabled = true;
            adrkrywn.Enabled = true;
            Cabangcbx();
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}
