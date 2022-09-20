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
using OrderControlMgmt.Class;
using CustomMessageBox;

namespace OrderControlMgmt.Forms.PEZA
{
    public partial class frmCreateBoatNote : Form
    {
        Variables varr = new Variables();
        public static string created;
        public frmCreateBoatNote()
        {
            InitializeComponent();
            fillin();
            fillinInCPerson();
        }
        #region"METHOD"
        public void fillin()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from GGG_Supplier_Customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(reader.GetOrdinal("SuppCustName")).ToUpper();
                cmbBNCust.Items.Add(str);

            }
            conn.Close();
            conn.Dispose();
        }

        public void fillinInCPerson()
        {
            varr.conn = new SqlConnection(varr.connString);
            varr.conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FullName FROM [hris_db].[dbo].[EmployeeList] WHERE IsResigned = 'ACTIVE' AND Section = 'PRODUCTION CONTROL'", varr.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(reader.GetOrdinal("FullName")).ToUpper();
                cmbBNInCPer.Items.Add(str);

            }
            varr.conn.Close();
            varr.conn.Dispose();
        }

        #endregion

        #region"BUTTON"
        private void btnBNCreate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_BoatNote where ControlNo = '"+txtBNCtrlNo.Text+"'",conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (txtBNCtrlNo.Text == "" || cmbBNCust.Text == "" || txtBNNumOfPack.Text == "" || txtBNKindPack.Text == "" ||
                    txtBNContent.Text == "" || txtBNnoItem.Text == "" || cmbBNMeasure.Text == "" || txtBNRem.Text == "" || txtBN06RefNo.Text == "" || cmbBNInCPer.Text == "")
                { Warning.Show("Complete All Fields!", "WARNING"); }
                else if (dt.Rows.Count >= 1)
                { Warning.Show("The Control No. You Input Is Already Exist!", "WARNING"); }
                else
                {
                    Warning_Confirmation.Show("Are You Sure That All Data is Correct!?", "CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {
                        SqlTransaction trns;
                        trns = conn.BeginTransaction();
                        SqlCommand cmd = new SqlCommand("insert into GGG_BoatNote (ControlNo, Customer, NoPackages, KindPackages, " +
                                  "ContentPackages, NoItems, Measurement, Remarks, No8106Ref, InChargePerson, DateCreated, CreatedBy)" +
                                "Values (@Ctrno,@Cust,@NoPack,@KPack,@CPack,@NoItems,@Mes,@Rem,@Ref06,@InCPer,@DCre,@CBy)", conn);

                        cmd.Parameters.AddWithValue("@Ctrno", txtBNCtrlNo.Text);
                        cmd.Parameters.AddWithValue("@Cust", cmbBNCust.Text);
                        cmd.Parameters.AddWithValue("@NoPack", txtBNNumOfPack.Text);
                        cmd.Parameters.AddWithValue("@KPack", txtBNKindPack.Text);
                        cmd.Parameters.AddWithValue("@CPack", txtBNContent.Text);
                        cmd.Parameters.AddWithValue("@NoItems", txtBNnoItem.Text);
                        cmd.Parameters.AddWithValue("@Mes", cmbBNMeasure.Text);
                        cmd.Parameters.AddWithValue("@Rem", txtBNRem.Text);
                        cmd.Parameters.AddWithValue("@Ref06", txtBN06RefNo.Text);
                        cmd.Parameters.AddWithValue("@DCre", dtpBNDCre.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@InCPer", cmbBNInCPer.Text);
                        cmd.Parameters.AddWithValue("@CBy", created);
                        cmd.Transaction = trns;

                        cmd.ExecuteNonQuery();
                        Save_Confirmation.Show("Created Successfully!", "SUCCESS");
                        trns.Commit();
                        conn.Close();
                        conn.Dispose();
                        // ClearFeilds();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region "TEXTBOX" 
        private void txtBNNumOfPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBNnoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBN06RefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBNCtrlNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #endregion

        private void frmCreateBoatNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesRecordList.i = 0;
            if (frmSalesRecordList.i == 0)
            {
                frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                mainForm.OrgBC();
            }
        }
    }
}
