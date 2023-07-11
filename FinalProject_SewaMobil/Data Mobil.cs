﻿using System;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            idcar = IDmobil.Text;
            nama = txtnama.Text;
            merk = txtmerk.Text;
            tipe = txttipe.Text;
            warna = txtwarna.Text;
            kapas = txtkapas.Text;
            biaya = txtbiaya.Text;
            tahun = txttahun.Text;
            cabang = cbxcabang.SelectedValue.ToString();
            koneksi.Open();
            string strs = "select id_cabang from dbo.cabang where nm_cabang = @dd";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@dd", cabang));
            SqlDataReader dr = cm.ExecuteReader();
            dr.Close();
            string str = "insert into dbo.mobil (id_mobil, nm_mobil, merk, tipe, warna, thn_buat, kapasitas, biaya_sewa_hari, id_cabang)" +
                "values(@id, @nm, @merk, @tipe, @wrn, @thn, @kapas, @biaya, @idc)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", idcar));
            cmd.Parameters.Add(new SqlParameter("@nm", nama));
            cmd.Parameters.Add(new SqlParameter("@merk", merk));
            cmd.Parameters.Add(new SqlParameter("@tipe", tipe));
            cmd.Parameters.Add(new SqlParameter("@wrn", warna));
            cmd.Parameters.Add(new SqlParameter("@thn", tahun));
            cmd.Parameters.Add(new SqlParameter("@kapas", kapas));
            cmd.Parameters.Add(new SqlParameter("@biaya", biaya));
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

        BindingSource customerBindingSource = new BindingSource();
        public Data_Mobil()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            this.bindingNavigator1.BindingSource = this.customerBindingSource;
            refreshform();
        }

        private void Mobil_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_mobil, m.nm_mobil, "
                + "m.merk, m.tipe, m.warna, m.thn_buat, m.kapasitas, biaya_sewa_hari, p.id_cabang From dbo.karyawan m " +
                "join dbo.cabang p on m.id_cabang = p.id_cabang", koneksi));
            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);

            this.customerBindingSource.DataSource = ds.Tables[0];
            this.IDmobil.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "id_mobil", true));
            this.txtnama.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "nm_mobil", true));
            this.txtmerk.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "merk", true));
            this.txttipe.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "tipe", true));
            this.txtwarna.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "warna", true));
            this.txttahun.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "thn_buat", true));
            this.txtkapas.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "kapasitas", true));
            this.txtbiaya.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "biaya_sewa_hari", true));
            this.cbxcabang.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "nm_cabang", true));
            koneksi.Close();
        }

        private void clearBinding()
        {
            this.txtbiaya.DataBindings.Clear();
            this.txtkapas.DataBindings.Clear();
            this.txtmerk.DataBindings.Clear();
            this.txtnama.DataBindings.Clear();
            this.cbxcabang.DataBindings.Clear();
            this.txttahun.DataBindings.Clear();
            this.txttipe.DataBindings.Clear();
            this.IDmobil.DataBindings.Clear();
            this.txtwarna.DataBindings.Clear();
        }

        private void refreshform()
        {
            txtnama.Enabled = false;
            txtmerk.Enabled = false;
            txtkapas.Enabled = false;
            txtbiaya.Enabled = false;
            txttahun.Enabled = false;
            txttipe.Enabled = false;
            txtwarna.Enabled = false;
            IDmobil.Enabled = false;
            cbxcabang.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            clearBinding();
            Mobil_Load();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtbiaya.Text = "";
            txtkapas.Text = "";
            txtmerk.Text = "";
            txtnama.Text = "";
            txttahun.Text = "";
            IDmobil.Text = "";
            txttipe.Text = "";
            txtwarna.Text = "";
            txttipe.Enabled = true;
            txtwarna.Enabled = true;
            cbxcabang.Enabled = true;
            txtbiaya.Enabled = true;
            txtkapas.Enabled = true;
            txtmerk.Enabled = true;
            txtnama.Enabled = true;
            txttahun.Enabled = true;
            IDmobil.Enabled = true;
            Cabangcbx();
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}
