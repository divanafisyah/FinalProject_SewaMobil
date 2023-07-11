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
        }

        private void Penyewa_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_penyewa, m.nm_penyewa, "
                + "m.adr_penyewa, m.identitas, m.telp_penyewa, p.id_kry From dbo.penyewa m " +
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
            this.cbxidentity.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "identitas", true));
            this.txttelp.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "telp_penyewa", true));
            this.cbxkrywn.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "id_kry", true));
            koneksi.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
