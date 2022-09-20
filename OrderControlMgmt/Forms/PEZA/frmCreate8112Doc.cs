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
using System.Text.RegularExpressions;
using CustomMessageBox;

namespace OrderControlMgmt.Forms.PEZA
{
    public partial class frmCreate8112Doc : Form
    {
        Variables varr = new Variables();
        decimal VAL;
        string SuppCustNo,LOANo, LOADExp,Custom;
        public static string createdb;
        public frmCreate8112Doc()
        {
            InitializeComponent();
            txt12DRNo.Text = frmSalesRecordList.DrNo;
            fillin();
        }

        #region "METHOD"
        public void subFill()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from GGG_LOA where UsedBySupplier != '" + "FDTP METAL" + "' And UsedBySupplier != '" + "FDTP ASSY" + "' And IsInUse = 1 ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(reader.GetOrdinal("UsedBySupplier")).ToUpper();
                cmb12Buyer.Items.Add(str);
            }
            conn.Close();
            conn.Dispose();
        }

        public void fillin()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();

            SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where UsedBySupplier = '" + "FDTP METAL" + "' And IsInUse = '" + 1 + "'", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            SqlDataAdapter adpA = new SqlDataAdapter("select * from GGG_LOA where UsedBySupplier = '" + "FDTP ASSY" + "' And IsInUse = '" + 1 + "'", conn);
            DataTable dtA = new DataTable();
            adpA.Fill(dtA);

            if (dt.Rows.Count >= 1 && dtA.Rows.Count >= 1)
            {

                cmb12Buyer.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                subFill();

            }
            else if (dt.Rows.Count == 1)
            {
                cmb12Type.Items.Clear();
                cmb12Type.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                cmb12Type.Items.Add("FDTP METAL");
            }
            else if (dtA.Rows.Count == 1)
            {
                cmb12Type.Items.Clear();
                cmb12Type.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                cmb12Type.Items.Add("FDTP ASSY");
            }
            else
            {
                subFill();
            }
            conn.Close();
            conn.Dispose();
        }

        public void ClearFeilds()
        {
            txt12CtrlNo.Text = "";
            txt12Des.Text = "";
            txt12Qty.Text = "";
            cmb12Measure.SelectedIndex = -1;
            cmb12Currency.SelectedIndex = -1;
            cmb12Buyer.SelectedIndex = -1;
            txt12LoaNo.Text = "";
            txt12DRNo.Text = "";
        }

        public void CustNo()
        {
            try
            {
                if (cmb12Buyer.Text != "")
                {
                    SqlConnection conn = new SqlConnection(varr.ConnString);
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_Supplier_Customer where SuppCustName = '" + cmb12Buyer.Text + "'", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    SuppCustNo = dt.Rows[0][0].ToString();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadDeatails()
        {
            if (SuppCustNo == "CS000001")
            {
                label21.Visible = true;
                cmb12Type.Visible = true;
                if (cmb12Type.Text != "")
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(varr.ConnString);
                        conn.Open();
                        SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where SuppCustNo = '" + SuppCustNo + "' AND UsedBySupplier = '" + cmb12Type.Text + "' AND IsInUse = 1", conn);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        DateTime resLoaDEx;
                       

                        LOANo = dt.Rows[0]["LOANo"].ToString();
                        LOADExp = dt.Rows[0]["LOADateExp"].ToString();

                        resLoaDEx = Convert.ToDateTime(LOADExp);

                        txt12LoaNo.Text = LOANo;
                        dtp12LOADExp.Value = resLoaDEx;
                        

                     
                      
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (SuppCustNo == "" || SuppCustNo == " ")
            {
                txt12LoaNo.Text = "-";
            }
            else if (SuppCustNo != "CS000001")
            {
                label21.Visible = false;
                cmb12Type.Visible = false;
                try
                {
                    SqlConnection conn = new SqlConnection(varr.ConnString);
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where SuppCustNo = '" + SuppCustNo + "' AND IsInUse = 1", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        txt12LoaNo.Text = "";
                        dtp12LOADExp.Text = DateTime.Now.ToShortDateString();
                    }
                    else
                    {
                        DateTime resLoaDEx;
                       

                        LOANo = dt.Rows[0]["LOANo"].ToString();
                        LOADExp = dt.Rows[0]["LOADateExp"].ToString();
                        

                        resLoaDEx = Convert.ToDateTime(LOADExp);
                      

                        txt12LoaNo.Text = LOANo;
                        dtp12LOADExp.Value = resLoaDEx;
                     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion

        #region "COMBOBOX"
        private void cmb12Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"[0-9]");
            if (txt12Val.Text != "" && regex.IsMatch(txt12Val.Text))
            {
                VAL = (Convert.ToDecimal(txt12Val.Text));
                txt12Val.Text = VAL.ToString("N");
            }
        }

        private void cmb12Measure_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt12FQty.Text = txt12Qty.Text + " " + cmb12Measure.Text;
        }

        private void cmb12Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeatails();
        }

        private void cmb12Buyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustNo();
            LoadDeatails();
        }

        private void cmb12DelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb12DelClass.Text == "LTPI-IZ")
            {
                Custom = "";
            }
            else
            {
                Custom = "BOC";
            }
        }
        #endregion

        #region "TEXTBOX"
        private void txt12Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt12CtrlNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmCreate8112Doc_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesRecordList.i = 0;
            if (frmSalesRecordList.i == 0)
            {
                frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                mainForm.OrgBC();
            }
        }

        private void txt12Val_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var regex = new Regex(@"[0-9]");
                if (e.KeyCode == Keys.Enter && regex.IsMatch(txt12Val.Text))
                {
                    VAL = (Convert.ToDecimal(txt12Val.Text));
                    txt12Val.Text = VAL.ToString("N");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt12Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt12Qty_OnValueChanged(object sender, EventArgs e)
        {
            txt12FQty.Text = txt12Qty.Text + " " + cmb12Measure.Text;
        }
        #endregion

        #region "BUTTON"

        private void btn12Create_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_PEZA8112 where ControlNo = '"+txt12CtrlNo.Text+"'",conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (txt12CtrlNo.Text == "" || txt12Qty.Text == "" || cmb12Measure.Text == "" || cmb12Currency.Text == "" || txt12Val.Text == "" || cmb12Buyer.Text == "" || txt12LoaNo.Text == "" || txt12DRNo.Text == "")
                { Warning.Show("Complete All Fields!", "WARNING"); }
                else if (dt.Rows.Count>=1)
                { Warning.Show("The Control No. You Input Is Already Exist!", "WARNING"); }
                else
                {
                    Warning_Confirmation.Show("Are You Sure That All Data is Correct!?", "CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {

                        SqlTransaction trns;
                        trns = conn.BeginTransaction();
                        SqlCommand cmd = new SqlCommand("insert into GGG_PEZA8112 (ControlNo, DateCreated, Description, Quantity," +
                        " Measurement, FinalQty, Value, Currency, Buyer, DeliveryDate, CreatedBy, LOANo, LOADateExp, SuppCustNo, DRNo, Custom, DelClass)" +
                        "Values (@Ctrno,@DCre,@Des,@Qty,@Mes,@FQty,@Val,@Curr,@Buyer,@DelD,@CBy,@LOANo,@LOADEx,@SupCust,@DrNo,@Custom,@DelC)", conn);

                        cmd.Parameters.AddWithValue("@Ctrno", txt12CtrlNo.Text);
                        cmd.Parameters.AddWithValue("@DCre", dtp12Created.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Des", txt12Des.Text);
                        cmd.Parameters.AddWithValue("@Qty", txt12Qty.Text);
                        cmd.Parameters.AddWithValue("@Mes", cmb12Measure.Text);
                        cmd.Parameters.AddWithValue("@FQty", txt12FQty.Text);
                        cmd.Parameters.AddWithValue("@Val", VAL);
                        cmd.Parameters.AddWithValue("@Curr", cmb12Currency.Text);
                        cmd.Parameters.AddWithValue("@Buyer", cmb12Buyer.Text);
                        cmd.Parameters.AddWithValue("@DelD", dtp12DelDate.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@CBy", createdb);
                        cmd.Parameters.AddWithValue("@LOANo", txt12LoaNo.Text);
                        cmd.Parameters.AddWithValue("@LOADEx", dtp12LOADExp.Value.ToShortDateString());
                        cmd.Parameters.AddWithValue("@SupCust", SuppCustNo);
                        cmd.Parameters.AddWithValue("@DrNo", txt12DRNo.Text);
                        cmd.Parameters.AddWithValue("@Custom", Custom);
                        cmd.Parameters.AddWithValue("@DelC", cmb12DelClass.Text);

                        cmd.Transaction = trns;

                        cmd.ExecuteNonQuery();
                        Save_Confirmation.Show("Created Successfully!", "SUCCESS");
                        trns.Commit();
                        conn.Close();
                        conn.Dispose();
                        ClearFeilds();
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
    }
}
