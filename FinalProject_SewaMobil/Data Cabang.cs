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
    public partial class Data_Cabang : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string cabang, nama, telp, adr, jumlah;
        BindingSource customerBindingSource = new BindingSource();
        public Data_Cabang()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            this.bindingNavigator1.BindingSource = this.customerBindingSource;
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtcabang.Text = "";
            txtalamat.Text = "";
            txttelepon.Text = "";
            txtjumlah.Text = "";
            txtID.Text = "";
            txtcabang.Enabled = true;
            txtalamat.Enabled = true;
            txttelepon.Enabled = true;
            txtjumlah.Enabled = true;
            txtID.Enabled = true;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cabang = txtID.Text;
            nama = txtcabang.Text;
            adr = txtalamat.Text;
            telp = txttelepon.Text;
            jumlah = txtjumlah.Text;
            koneksi.Open();
            string str = "insert into dbo.cabang (id_cabang, nm_cabang, adr_cabang, telp_cabang, jmlh_mobil) " +
                "VALUES (@id, @nm, @adr, @telp, @jmlh)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@id", cabang));
            cmd.Parameters.Add(new SqlParameter("@nm", nama));
            cmd.Parameters.Add(new SqlParameter("@adr", adr));
            cmd.Parameters.Add(new SqlParameter("@telp", telp));
            cmd.Parameters.Add(new SqlParameter("@jmlh", jumlah));
            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "")
            {
                MessageBox.Show("Masukkan ID Cabang yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "DELETE FROM cabang WHERE id_cabang = @id_cabang";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_cabang", id);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cabang = txtID.Text;
            string nama = txtcabang.Text;
            string adr = txtalamat.Text;
            string telp = txttelepon.Text;
            string jumlah = txtjumlah.Text;

            if (cabang == "")
            {
                MessageBox.Show("ID Cabang tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nama == "")
            {
                MessageBox.Show("Masukkan Nama Cabang", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (adr == "")
            {
                MessageBox.Show("Masukkan Alamat Cabang", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (telp == "")
            {
                MessageBox.Show("Masukkan No Telepon", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (jumlah == "")
            {
                MessageBox.Show("Masukkan Jumlah Mobil Yang Tersedia", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                string sql = "UPDATE cabang SET nm_cabang = @nm, adr_cabang = @adr, telp_cabang = @telp, jmlh_mobil = @jmlh WHERE id_cabang = @id";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id", cabang);
                command.Parameters.AddWithValue("@nm", nama);
                command.Parameters.AddWithValue("@adr", adr);
                command.Parameters.AddWithValue("@telp", telp);
                command.Parameters.AddWithValue("@jmlh", jumlah);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Cabang_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select id_cabang, nm_cabang, "
                + "adr_cabang, telp_cabang, jmlh_mobil From dbo.cabang", koneksi));
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
               new Binding("Text", this.customerBindingSource, "telp_cabang", true));
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
