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
    public partial class frmLoaManagement : Form
    {
        public static string ID;
        Variables varr = new Variables();
      
        public frmLoaManagement()
        {
            InitializeComponent();  
            rbInUse.Select();
            load();
            //dgvLoaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            FillInSuggest();
            FillInCmb();
            dtpLOADExp.Text = DateTime.Now.AddYears(1).ToShortDateString();
            txtLOANo.Select();
        }

        #region"METHOD"

        public void FillInCmb()
        {
            try
            {
                cmbSuppCust.Items.Clear();
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("select * from GGG_LOA where IsInUse = 1 Order By UsedBySupplier ASC", conn);
                SqlDataReader rd = cmd1.ExecuteReader();

                cmbSuppCust.Items.Add("");
                while (rd.Read())
                {
                    string str = rd.GetString(rd.GetOrdinal("UsedBySupplier")).ToUpper();
                    cmbSuppCust.Items.Add(str);

                }
              
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void FillInSuggest()
        {
            try
            {
                cmbSuppCustName.Items.Clear();
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from GGG_Supplier_Customer", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            
                while (reader.Read())
                {
                    string str = reader.GetString(reader.GetOrdinal("SuppCustName")).ToUpper();
                    cmbSuppCustName.Items.Add(str);
                }
                conn.Close();
                conn.Dispose();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void load()
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA where IsInUse = 1 ", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dgvLoaList.DataSource = dt;
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void RbCmbSearch()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            if (rbAll.Checked == true && cmbSuppCust.Text != "")
            {
                SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA where UsedBySupplier = '" + cmbSuppCust.Text + "'", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dgvLoaList.DataSource = dt;
            }
            else if (rbInUse.Checked == true && cmbSuppCust.Text != "")
            {
                try
                {    
                    SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA where IsInUse = 1 AND UsedBySupplier = '" + cmbSuppCust.Text + "'", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dgvLoaList.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (rbNotUsed.Checked == true && cmbSuppCust.Text != "")
            {
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA where IsInUse = 0 AND UsedBySupplier = '" + cmbSuppCust.Text + "'", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dgvLoaList.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dgvLoaList.DataSource = dt;
                rbAll.Checked = true;
            }
            conn.Close();
            conn.Dispose();

        }
        
        #endregion

        #region"BUTTON"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA ", conn);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);

                //INSERT QUERY
                SqlCommand cmd = new SqlCommand("insert into GGG_LOA  (SN,LOANo,LOADateExp,BondNo,BondDateExp,IsInUse,DateStartUsing,UsedBySupplier,SuppCustNo) " +
                        "VAlues (@SN,@LNo,@LDexp,@BNo,@BDexp,1,@DSUsing,@UBySupp,@CustNo)", conn);

                int sn = dt1.Rows.Count + 1;
                if (cmbSuppCustName.Text == "" || txtLOANo.Text == "" || dtpLOADExp.Value.ToString() == DateTime.Now.ToString())
                {
                    Warning.Show("Complete All Feilds!","WARNING");
                }
                else if (cmbSuppCustName.Text == "FUJITSU DIETECH CORPORATION OF THE PHILIPPINES" && cmbType.Text == "")
                { Warning.Show("Select Type First!", "WARNING"); }
                else
                {
                    Warning_Confirmation.Show("Are You Sure That All Data is Correct?","CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {
                        if (cmbSuppCustName.Text == "FUJITSU DIETECH CORPORATION OF THE PHILIPPINES" && cmbType.Text != "")
                        {
                            //UPDATE QUERY
                            SqlCommand cmdup = new SqlCommand("Update GGG_LOA set IsInUse = 0 where IsInUse = 1 And UsedBySupplier = '" + cmbType.Text + "'", conn);
                            cmdup.ExecuteNonQuery();

                            cmd.Parameters.AddWithValue("@SN", sn);
                            cmd.Parameters.AddWithValue("@LNo", txtLOANo.Text);
                            cmd.Parameters.AddWithValue("@LDexp", dtpLOADExp.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@BNo", txtBondNo.Text);
                            cmd.Parameters.AddWithValue("@BDexp", dtpBondDExp.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@DSUsing", DateTime.Now.ToShortDateString());
                            cmd.Parameters.AddWithValue("@UBySupp", cmbType.Text);
                            cmd.Parameters.AddWithValue("@CustNo", "CS000001");
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            //UPDATE QUERY 
                            SqlCommand cmdup = new SqlCommand("Update GGG_LOA set IsInUse = 0 where IsInUse = 1 And UsedBySupplier = '" + cmbSuppCustName.Text + "'", conn);
                            cmdup.ExecuteNonQuery();

                            SqlDataAdapter adapter = new SqlDataAdapter("select SuppCustNo from GGG_Supplier_Customer where SuppCustName = '" + cmbSuppCustName.Text + "'", conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            string CustNo = dt.Rows[0][0].ToString();

                            cmd.Parameters.AddWithValue("@SN", sn);
                            cmd.Parameters.AddWithValue("@LNo", txtLOANo.Text);
                            cmd.Parameters.AddWithValue("@LDexp", dtpLOADExp.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@BNo", txtBondNo.Text);
                            cmd.Parameters.AddWithValue("@BDexp", dtpBondDExp.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@DSUsing", DateTime.Now.ToShortDateString());
                            cmd.Parameters.AddWithValue("@UBySupp", cmbSuppCustName.Text);
                            cmd.Parameters.AddWithValue("@CustNo", CustNo);
                            cmd.ExecuteNonQuery();

                        }
                        Save_Confirmation.Show("The Data is Successfully Saved.", "SUCCESS");
                        txtLOANo.Clear();
                        txtBondNo.Clear();
                        cmbType.SelectedIndex = -1;
                        cmbSuppCustName.SelectedIndex = -1;
                        dtpLOADExp.Text = DateTime.Now.AddYears(1).ToShortDateString();
                        conn.Close();
                        conn.Dispose();
                        load();
                        FillInCmb();
                        FillInSuggest();
                        rbInUse.Checked = true;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAddNewSupp_Click(object sender, EventArgs e)
        {
            frmAddingNewSupplier add = new frmAddingNewSupplier();
            add.ShowDialog();
        }
        #endregion

        #region"TEXTBOX"
        private void txtLOANo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtBondNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }
        #endregion

        #region"RADIO BTN/CMB" 
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbSuppCust.Text == "")
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dgvLoaList.DataSource = dt;
            }
            else
            {
                RbCmbSearch();
            }
        }

        private void rbInUse_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbSuppCust.Text == "")
            {
                load();
            }
            else
            {
                RbCmbSearch();
            }
         
        }

        private void rbNotUsed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSuppCust.Text == "")
                {
                    SqlConnection conn = new SqlConnection(varr.ConnString);
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select SN,LOANo as 'LOA No.',LOADateExp as 'LOA Expiration',BondNo as 'Bond No.',BondDateExp as 'Bond Expiration',IsInUse as 'In Use',DateStartUsing as 'Start Using',UsedBySupplier as 'Used By',SuppCustNo as 'Customer No.' from GGG_LOA where IsInUse = 0 ", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dgvLoaList.DataSource = dt;
                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    RbCmbSearch();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbSuppCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            RbCmbSearch();
        }

        private void dtpLOADExp_ValueChanged(object sender, EventArgs e)
        {
            dtpBondDExp.Text = dtpLOADExp.Value.ToShortDateString();
        }

        private void cmbSuppCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuppCustName.Text == "FUJITSU DIETECH CORPORATION OF THE PHILIPPINES")
            {
                label8.Visible = true;
                cmbType.Visible = true;
            }
            else
            {
                label8.Visible = false;
                cmbType.Visible = false;
            }

        }

        #endregion

        
    }
}
