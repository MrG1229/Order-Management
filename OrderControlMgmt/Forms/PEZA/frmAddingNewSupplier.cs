using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CustomMessageBox;

namespace OrderControlMgmt.Forms.PEZA
{
    public partial class frmAddingNewSupplier : Form
    {
        Variables varr = new Variables();
        public static string path;
        public frmAddingNewSupplier()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_Supplier_Customer",conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int id = dt.Rows.Count + 1;
            lblCustNo.Text = id.ToString("CS" + "000000");
            conn.Close();
            conn.Dispose();
        }

        //INSERT
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSuppcust.Text == "")
                { Warning.Show("Input Supplier/Customer First!","WARNING"); }
                else
                {
                    Warning_Confirmation.Show("Are you sure you want to save this? "+txtSuppcust.Text,"CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(varr.ConnString);
                        conn.Open();

                        SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_Supplier_Customer ", conn);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        int id = dt.Rows.Count + 1;

                        SqlCommand cmd = new SqlCommand("insert into GGG_Supplier_Customer (SuppCustNo,SuppCustName) values ('" + id.ToString("CS" + "000000") + "','" + txtSuppcust.Text.Trim() + "')", conn);

                        cmd.ExecuteNonQuery();

                        Save_Confirmation.Show("Supplier/Customer ADDED Successfully", "SUCCESS");

                        frmLoaManagement mainForm = (frmLoaManagement)Application.OpenForms["frmLoaManagement"];
                        mainForm.FillInSuggest();


                        this.Close();
                        conn.Close();
                        conn.Dispose();
                        txtSuppcust.Clear();


                    }

                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAddingNewSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
