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
    public partial class Form_Pemesanan : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string id, mobil, status, nm;
        private DateTime tgl;
        public Form_Pemesanan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from dbo.pemesanan";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshform()
        {
            cbxmobil.Enabled = false;
            cbxpenyewa.Enabled = false;
            cbxstatus.Enabled = false;
            datetgl.Enabled = false;
            txtID.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        private void cbxidmobil()
        {
            koneksi.Open();
            string query = "SELECT id_mobil FROM dbo.mobil";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("id_mobil");

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row["id_mobil"] = reader["id_mobil"].ToString();
                dt.Rows.Add(row);
            }

            koneksi.Close();

            cbxmobil.DisplayMember = "id_mobil";
            cbxmobil.ValueMember = "id_mobil";
            cbxmobil.DataSource = dt;
        }

        private void btnnBack_Click(object sender, EventArgs e)
        {
            Form1 hu = new Form1();
            hu.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan dihapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["id_pesan"].Value.ToString();

            string sql = "DELETE FROM pemesanan WHERE id_pesan = @id_pesan";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id_pesan", id);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform();
                        dataGridView();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            id = txtID.Text;
            nm = cbxpenyewa.SelectedValue.ToString();
            mobil = cbxmobil.SelectedValue.ToString();
            tgl = datetgl.Value;
            status = cbxstatus.Text;

            if (id == "")
            {
                MessageBox.Show("Pilih ID Pesan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nm == "")
            {
                MessageBox.Show("Pilih Nama Penyewa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mobil == "")
            {
                MessageBox.Show("Masukkan ID Mobil Bayar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (status == "")
            {
                MessageBox.Show("Masukkan Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO pemesanan (id_pesan, tgl_pesan, status_pesan, id_penyewa, id_mobil) VALUES (@id, @tgl, @stat, @idp, @idm)";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@tgl", tgl);
                command.Parameters.AddWithValue("@stat", status);
                command.Parameters.AddWithValue("@idp", nm);
                command.Parameters.AddWithValue("@idm", mobil);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform(); // Mengosongkan form setelah menyimpan
                        dataGridView(); // Refresh tampilan data setelah menyimpan
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form_Pemesanan_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris data yang akan diperbarui", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dataGridView1.SelectedRows[0].Cells["id_penyewa"].Value.ToString();
            string nm = cbxpenyewa.Text;
            string mbl = cbxmobil.Text;
            string stt = cbxstatus.Text;
            tgl = datetgl.Value;

            if (id == "")
            {
                MessageBox.Show("ID pesan tidak valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nm == "")
            {
                MessageBox.Show("Masukkan Nama penyewa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mbl == "")
            {
                MessageBox.Show("Masukkan ID Mobil", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (stt == "")
            {
                MessageBox.Show("Masukkan Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE pemesanan SET tgl_pesan = @tgl, status_pesan = @stat, id_penyewa = @idp, id_mobil = @idm WHERE id_pesan = @id";
            using (SqlCommand command = new SqlCommand(sql, koneksi))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@tgl", tgl);
                command.Parameters.AddWithValue("@stat", stt);
                command.Parameters.AddWithValue("@idp", nm);
                command.Parameters.AddWithValue("@idm", mobil);

                try
                {
                    koneksi.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data berhasil diperbarui", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        koneksi.Close();
                        refreshform(); // Mengosongkan form setelah perbarui
                        dataGridView(); // Refresh tampilan data setelah perbarui
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

        private void cbxnmpenyewa()
        {
            koneksi.Open();
            string str = "SELECT id_penyewa, nm_penyewa FROM dbo.penyewa";

            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();

            cbxpenyewa.DisplayMember = "nm_penyewa";
            cbxpenyewa.ValueMember = "id_penyewa";
            cbxpenyewa.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            cbxmobil.Enabled = true;
            cbxpenyewa.Enabled = true;
            cbxstatus.Enabled = true;
            datetgl.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
            cbxidmobil();
            cbxnmpenyewa();
        }
    }
}
