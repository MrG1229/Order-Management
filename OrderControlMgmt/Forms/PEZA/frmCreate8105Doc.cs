using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using OrderControlMgmt.Class;
using System.Text.RegularExpressions;
using CustomMessageBox;

namespace OrderControlMgmt
{
    public partial class frmCreate8105Doc : Form
    {
        Variables varr = new Variables();
        decimal VAL;
        public static string Custom,created;
        public frmCreate8105Doc()
        {
            InitializeComponent();
            fillin();
            //created = frmSalesRecordList.CreatedBy;
        }

        #region "METHOD"
        public void fillin()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from GGG_Supplier_Customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(reader.GetOrdinal("SuppCustName")).ToUpper();
                cmb05Supp.Items.Add(str);

            }
            conn.Close();
            conn.Dispose();
        }

        public void ClearFeilds()
        {
            txt05CtrlNo.Text = "";
            txt05SINo.Text = "";
            txt05DRNo.Text = "";
            txt05DesCom.Text = "";
            txt05Qty.Text = "";
            cmb05Measure.SelectedIndex = -1;
            cmb05Currency.SelectedIndex = -1;
            cmb05Supp.SelectedIndex = -1;
            cmb05DelClass.SelectedIndex = -1;
            txt05RefNo06.Text = "";

        }
        #endregion

        #region "ComboBox"
        private void cmb05Measure_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt05FQty.Text = txt05Qty.Text + " " + cmb05Measure.Text;
        }
        private void cmb05DelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb05DelClass.Text == "LTPI-IZ")
            {
                Custom = "";
            }
            else
            {
                Custom = "BOC";
            }
        }

        private void cmb05Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"[0-9]");
            if (txt05Val.Text != "" && regex.IsMatch(txt05Val.Text))
            {
                VAL = (Convert.ToDecimal(txt05Val.Text));
                txt05Val.Text = VAL.ToString("N");
               
            }
        }

        #endregion

        #region "Button"
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_PEZA8105 where ControlNo = '"+txt05CtrlNo.Text+"'",conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (txt05CtrlNo.Text == "" || txt05SINo.Text == "" || txt05DRNo.Text == "" || cmb05Measure.Text == "" || txt05FQty.Text == "" || 
                    cmb05Currency.Text == "" || cmb05Supp.Text == "" || txt05Carrier.Text == "" || txt05RefNo06.Text == "" || cmb05DelClass.Text == "")
                { Warning.Show("Complete All Feilds!", "WARNING"); }
                else if (dt.Rows.Count >= 1)
                { Warning.Show("The Control Number That you Input is Already Exist!", "WARNING"); }
               else 
                {
                    Warning_Confirmation.Show("Are You Sure That All Data is Correct!?","CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {
                        SqlTransaction trns;
                        trns = conn.BeginTransaction();
                        SqlCommand cmd = new SqlCommand("insert into GGG_PEZA8105 (ControlNo, DateCreated, SINo, DRNo, DescriptionOfCom, " +
                              "Quantity, Measurement, FinalQty, Currency, Value, Supplier, DeliveryDate, Carrier, CreatedBy, " +
                              "No8106Ref, Custom, DelClass)" +
                                "Values (@Ctrno,@DCre,@SiNo,@DrNo,@Des,@Qty,@Mes,@FQty,@Curr,@Val,@Supp,@DelD,@Carr,@CBy,@Ref06,@Custom,@DelC)", conn);

                        cmd.Parameters.AddWithValue("@Ctrno", txt05CtrlNo.Text);
                        cmd.Parameters.AddWithValue("@DCre", dtp05Created.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SiNo", txt05SINo.Text);
                        cmd.Parameters.AddWithValue("@DrNo", txt05DRNo.Text);
                        cmd.Parameters.AddWithValue("@Des", txt05DesCom.Text);
                        cmd.Parameters.AddWithValue("@Qty", txt05Qty.Text);
                        cmd.Parameters.AddWithValue("@Mes", cmb05Measure.Text);
                        cmd.Parameters.AddWithValue("@FQty", txt05FQty.Text);
                        cmd.Parameters.AddWithValue("@Curr", cmb05Currency.Text);
                        cmd.Parameters.AddWithValue("@Val", VAL);
                        cmd.Parameters.AddWithValue("@Supp", cmb05Supp.Text);
                        cmd.Parameters.AddWithValue("@DelD", dtp05DelDate.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Carr", txt05Carrier.Text);
                        cmd.Parameters.AddWithValue("@CBy", created);
                        cmd.Parameters.AddWithValue("@Ref06", txt05RefNo06.Text);
                        cmd.Parameters.AddWithValue("@Custom", Custom);
                        cmd.Parameters.AddWithValue("@DelC", cmb05DelClass.Text);
                        cmd.Transaction = trns;

                        cmd.ExecuteNonQuery();
                        Save_Confirmation.Show("Created Successfully!", "SUCCESS");
                        trns.Commit();
                        conn.Close();
                        conn.Dispose();
                        ClearFeilds();
                        this.Close();
                        frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                        mainForm.OrgBC();
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

        private void txt05Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt05Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt05Qty_OnValueChanged(object sender, EventArgs e)
        {
            txt05FQty.Text = txt05Qty.Text + " " + cmb05Measure.Text; 
        }

        private void txt05CtrlNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt05RefNo06_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmCreate8105Doc_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesRecordList.i = 0;
            if (frmSalesRecordList.i == 0)
            {
                frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                mainForm.OrgBC();
            }
        }
    

        private void frmCreate8105Doc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSalesRecordList.i = 0;
            if (frmSalesRecordList.i == 0)
            {
                frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                mainForm.OrgBC();
            }

        }

        private void txt05Val_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var regex = new Regex(@"[0-9]");
                if (e.KeyCode == Keys.Enter && regex.IsMatch(txt05Val.Text))
                {
                    VAL = (Convert.ToDecimal(txt05Val.Text));
                    txt05Val.Text = VAL.ToString("N");

                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion



    }
}
