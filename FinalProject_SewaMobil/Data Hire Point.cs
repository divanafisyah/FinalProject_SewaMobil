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
    public partial class Data_Hire_Point : Form
    {
        private string stringConnection = "data source=LAPTOP-9VURLJFC\\THARIQ_AZHAR;" + "database=SewaMobil;User ID=sa;Password=hurricane95";
        private SqlConnection koneksi;
        private string id_hp, cabang, nama, telp, adr;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        BindingSource customerBindingSource = new BindingSource();
        public Data_Hire_Point()
        {
            InitializeComponent();
        }

        private void HP_Load()
        {
            koneksi.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.id_hp, m.nm_hp, "
                + "m.adr_hp, m.telp_hp, p.nm_cabang From dbo.hire_point m " +
                "join dbo.cabang p on m.id_cabang = p.id_cabang", koneksi));
            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);

            this.customerBindingSource.DataSource = ds.Tables[0];
            this.txtID.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "id_hp", true));
            this.txtnama.DataBindings.Add(
                new Binding("Text", this.customerBindingSource, "nm_hp", true));
            this.txtadr.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "adr_hp", true));
            this.txttelp.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "telp_hp", true));
            this.cbxcabang.DataBindings.Add(
               new Binding("Text", this.customerBindingSource, "nm_cabang", true));
            koneksi.Close();
        }

        private void clearBinding()
        {
            this.txtID.DataBindings.Clear();
            this.txtnama.DataBindings.Clear();
            this.txtadr.DataBindings.Clear();
            this.txttelp.DataBindings.Clear();
            this.cbxcabang.DataBindings.Clear();
        }

        private void refreshform()
        {
            txtID.Enabled = false;
            txtnama.Enabled = false;
            txtadr.Enabled = false;
            txttelp.Enabled = false;
            cbxcabang.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            clearBinding();
            HP_Load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
