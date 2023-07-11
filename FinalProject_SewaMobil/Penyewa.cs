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
    public partial class Penyewa : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string id_sewa, krywn, nama, telp, adr, ident;
        BindingSource customerBindingSource = new BindingSource();
        public Penyewa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            this.bindingNavigator1.BindingSource = this.customerBindingSource;
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtnama.Text = "";
            txtadr.Text = "";
            txttelp.Text = "";
            idpenyewa.Text = "";
            txtnama.Enabled = true;
            txtadr.Enabled = true;
            txttelp.Enabled = true;
            idpenyewa.Enabled = true;
            cbxidentity.Enabled = true;
            cbxkrywn.Enabled = true;
            Karyawancbx();
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            id_sewa = idpenyewa.Text;
            nama = txtnama.Text;
            ident = cbxidentity.Text;
            adr = txtadr.Text;
            telp = txttelp.Text;
            krywn = cbxkrywn.SelectedValue.ToString();
            koneksi.Open();
            string strs = "select id_kry from dbo.karyawan where nm_kry = @kr";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@kr", krywn));
            SqlDataReader dr = cm.ExecuteReader();
            dr.Close();
            string str = "insert into dbo.penyewa (id_penyewa, nm_penyewa, adr_penyewa, telp_penyewa, identitas, id_kry)" +
                "values(@id, @nm, @adr, @telp, @idt, @idk)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", id_sewa));
            cmd.Parameters.Add(new SqlParameter("@nm", nama));
            cmd.Parameters.Add(new SqlParameter("@adr", adr));
            cmd.Parameters.Add(new SqlParameter("@telp", telp));
            cmd.Parameters.Add(new SqlParameter("@idt", ident));
            cmd.Parameters.Add(new SqlParameter("@idk", krywn));
            cmd.ExecuteNonQuery();

            koneksi.Close();

            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            refreshform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void Penyewa_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_penyewa, m.nm_penyewa, "
                + "m.adr_penyewa, m.telp_penyewa, m.identitas, p.id_kry From dbo.penyewa m " +
                "join dbo.karyawan p on m.id_kry = p.id_kry", koneksi));
            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);

            this.customerBindingSource.DataSource = ds.Tables[0];
            this.idpenyewa.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "id_penyewa", true));
            this.txtnama.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "nm_penyewa", true));
            this.txtadr.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "adr_penyewa", true));
            this.txttelp.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "telp_penyewa", true));
            this.cbxidentity.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "identitas", true));
            this.cbxkrywn.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "id_kry", true));
            koneksi.Close();
        }

        private void clearBinding()
        {
            this.txtnama.DataBindings.Clear();
            this.txtadr.DataBindings.Clear();
            this.txttelp.DataBindings.Clear();
            this.cbxidentity.DataBindings.Clear();
            this.cbxkrywn.DataBindings.Clear();
            this.idpenyewa.DataBindings.Clear();
        }

        private void refreshform()
        {
            txtnama.Enabled = false;
            txtadr.Enabled = false;
            txttelp.Enabled = false;
            cbxidentity.Enabled = false;
            cbxkrywn.Enabled = false;
            idpenyewa.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            clearBinding();
            Penyewa_Load();
        }

        private void Karyawancbx()
        {
            koneksi.Open();
            string str = "select id_kry, nm_kry from dbo.karyawan";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxkrywn.DisplayMember = "nm_cabang";
            cbxkrywn.ValueMember = "id_cabang";
            cbxkrywn.DataSource = ds.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
