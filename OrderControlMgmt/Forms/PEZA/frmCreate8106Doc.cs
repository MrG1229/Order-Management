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
    public partial class frmCreate8106Doc : Form
    {
        
        Variables varr = new Variables();
        string SuppCustNo, LOANo, LOADExp,BondNo,BondDExp,Custom;
        public static string created;
        decimal VAL;
        public frmCreate8106Doc()
        {
            InitializeComponent();
        }

        private void frmCreate8106Doc_Load(object sender, EventArgs e)
        {
            txt06DRNo.Text = frmSalesRecordList.DrNo;
            fillin();
        }

        #region"METHOD"

        public void subFill()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from GGG_LOA where UsedBySupplier != '" + "FDTP METAL" + "' And UsedBySupplier != '" + "FDTP ASSY" + "' And IsInUse = 1 ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(reader.GetOrdinal("UsedBySupplier")).ToUpper();
                cmb06Imp.Items.Add(str);
            }
            conn.Close();
            conn.Dispose();
        }

        public void fillin()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();

            SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where UsedBySupplier = '"+"FDTP METAL"+ "' And IsInUse = '"+1+"'", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            SqlDataAdapter adpA = new SqlDataAdapter("select * from GGG_LOA where UsedBySupplier = '" + "FDTP ASSY" + "' And IsInUse = '" + 1 + "'", conn);
            DataTable dtA = new DataTable();
            adpA.Fill(dtA);

            if (dt.Rows.Count >= 1 && dtA.Rows.Count >= 1)
            {
              
                cmb06Imp.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                subFill();
               
            }
            else if(dt.Rows.Count==1)
            {
                cmb06Type.Items.Clear();
                cmb06Imp.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                cmb06Type.Items.Add("FDTP METAL");
            }
            else if (dtA.Rows.Count == 1)
            {
                cmb06Type.Items.Clear();
                cmb06Imp.Items.Add("FUJITSU DIETECH CORPORATION OF THE PHILIPPINES");
                cmb06Type.Items.Add("FDTP ASSY");
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
            txt06CtrlNo.Text = "";
            txt06NoUnits.Text = "";
            txt06Rem.Text = "";
            txt06DesCom.Text = "";
            txt06Qty.Text = "";
            cmb06Measure.SelectedIndex = -1;
            cmb06Currency.SelectedIndex = -1;
            cmb06Imp.SelectedIndex = -1;
            cmb06Type.SelectedIndex = -1;
            cmb06DelClass.SelectedIndex = -1;
            txt06Val.Text = "";
            txt06Fval.Text = "";
            txt06FQty.Text = "";
            txt06DRNo.Text = "";
            txt06Carrier.Text = "";
            txt06LoaNo.Text = "";
            txt06Purpose.Text = "";
            txt06BondNo.Text = "";
            dtp06DelDate.Text = DateTime.Now.ToShortDateString();
            dtp06BondDExp.Text = DateTime.Now.ToShortDateString();
            dtp06Created.Text = DateTime.Now.ToShortDateString();
            dtp06LoaDExp.Text = DateTime.Now.ToShortDateString();
        }

        public void CustNo()
        {
            try
            {
                if (cmb06Imp.Text != "")
                {
                    SqlConnection conn = new SqlConnection(varr.ConnString);
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_Supplier_Customer where SuppCustName = '" + cmb06Imp.Text + "'", conn);
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
                cmb06Type.Visible = true;
                if (cmb06Type.Text != "")
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(varr.ConnString);
                        conn.Open();
                        SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where SuppCustNo = '" + SuppCustNo + "' AND UsedBySupplier = '" + cmb06Type.Text + "' AND IsInUse = 1", conn);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        DateTime resLoaDEx;
                        DateTime resBonDEx;

                        LOANo = dt.Rows[0]["LOANo"].ToString();
                        LOADExp = dt.Rows[0]["LOADateExp"].ToString();
                        BondNo = dt.Rows[0]["BondNo"].ToString();
                        BondDExp = dt.Rows[0]["BondDateExp"].ToString();

                        resLoaDEx = Convert.ToDateTime(LOADExp);
                        resBonDEx = Convert.ToDateTime(BondDExp);

                        txt06LoaNo.Text = LOANo;
                        dtp06LoaDExp.Value = resLoaDEx;
                        txt06BondNo.Text = BondNo;

                        if (DBNull.Value.Equals(resBonDEx.ToString()) || resBonDEx.ToString() == " ")
                        {
                            dtp06BondDExp.Text = "";
                            //dtp06BondDExp.CustomFormat = " ";
                            //dtp06BondDExp.Format = DateTimePickerFormat.Custom;
                        }
                        else
                        {
                            dtp06BondDExp.Value = resBonDEx;
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (SuppCustNo != "CS000001")
            {
                label21.Visible = false;
                cmb06Type.Visible = false;
                try
                {
                    SqlConnection conn = new SqlConnection(varr.ConnString);
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_LOA where SuppCustNo = '" + SuppCustNo + "' AND IsInUse = 1", conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        txt06LoaNo.Text = "";
                        txt06BondNo.Text = "";
                        dtp06BondDExp.Text = DateTime.Now.ToShortDateString();
                        dtp06LoaDExp.Text = DateTime.Now.ToShortDateString();
                    }
                    else
                    {
                        DateTime resLoaDEx;
                        DateTime resBonDEx;

                        LOANo = dt.Rows[0]["LOANo"].ToString();
                        LOADExp = dt.Rows[0]["LOADateExp"].ToString();
                        BondNo = dt.Rows[0]["BondNo"].ToString();
                        BondDExp = dt.Rows[0]["BondDateExp"].ToString();

                        resLoaDEx = Convert.ToDateTime(LOADExp);
                        resBonDEx = Convert.ToDateTime(BondDExp);

                        txt06LoaNo.Text = LOANo;
                        dtp06LoaDExp.Value = resLoaDEx;
                        txt06BondNo.Text = BondNo;

                        if (resBonDEx.ToShortDateString() != "01/01/1900")
                        {
                            dtp06BondDExp.Value = resBonDEx;
                        }
                        else
                        {
                            dtp06BondDExp.Text = "";
                            //dtp06BondDExp.CustomFormat = " ";
                            //dtp06BondDExp.Format = DateTimePickerFormat.Custom;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        #region"BUTTON"

        private void btn06Create_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select * from GGG_PEZA8106 where ControlNo = '"+txt06CtrlNo.Text+"'",conn);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                if (txt06CtrlNo.Text == "" || txt06NoUnits.Text == "" || txt06Qty.Text == "" || cmb06Measure.Text == "" || txt06Val.Text == "" || 
                    cmb06Currency.Text == "" || cmb06Imp.Text == "" || txt06DRNo.Text == "" || txt06Purpose.Text == "" || txt06Carrier.Text == "" ||
                    txt06LoaNo.Text == "" || txt06BondNo.Text == "" || cmb06DelClass.Text == "")

                { Warning.Show("Complete All Feilds!","WARNING"); }
                else if (dt.Rows.Count >= 1)
                { Warning.Show("The Control No. You Input Is Already Exist!", "WARNING");}
                else
                {
                    Warning_Confirmation.Show("Are You Sure That All Data is Correct!?", "CONFIRMATION");
                    if (Warning_Confirmation.result == DialogResult.Yes)
                    {
                        SqlTransaction trns;
                        trns = conn.BeginTransaction();
                        SqlCommand cmd = new SqlCommand("insert into GGG_PEZA8106 (ControlNo, DateCreated, NoUnits, Remarks, Description, Quantity," +
                                "Measurement, FinalQty, Currency, Value, FinalValue, Importer, DeliveryDate, Carrier, DRNo, Purpose, CreatedBy," +
                                "LOANo, LOADateExp, SuppCustNo, BondNo, BondDateExp, Custom, DelClass)" +
                                "Values (@Ctrno,@DCre,@NoUnits,@Rem,@Des,@Qty,@Mes,@FQty,@Curr,@Val,@FVal,@Imp,@DelD,@Carr,@DrNo,@Purp,@CBy,@LOANo,@LOADEx,@SupCust,@BNo,@BDEx,@Custom,@DelC)", conn);

                        cmd.Parameters.AddWithValue("@Ctrno", txt06CtrlNo.Text);
                        cmd.Parameters.AddWithValue("@DCre", dtp06Created.Value);
                        cmd.Parameters.AddWithValue("@NoUnits", txt06NoUnits.Text);
                        cmd.Parameters.AddWithValue("@Rem", txt06Rem.Text);
                        cmd.Parameters.AddWithValue("@Des", txt06DesCom.Text);
                        cmd.Parameters.AddWithValue("@Qty", txt06Qty.Text);
                        cmd.Parameters.AddWithValue("@Mes", cmb06Measure.Text);
                        cmd.Parameters.AddWithValue("@FQty", txt06FQty.Text);
                        cmd.Parameters.AddWithValue("@Curr", cmb06Currency.Text);
                        cmd.Parameters.AddWithValue("@Val", VAL);
                        cmd.Parameters.AddWithValue("@FVal", txt06Fval.Text);
                        cmd.Parameters.AddWithValue("@Imp", cmb06Imp.Text);
                        cmd.Parameters.AddWithValue("@DelD", dtp06DelDate.Value);
                        cmd.Parameters.AddWithValue("@Carr", txt06Carrier.Text);
                        cmd.Parameters.AddWithValue("@DrNo", txt06DRNo.Text);
                        cmd.Parameters.AddWithValue("@Purp", txt06Purpose.Text);
                        cmd.Parameters.AddWithValue("@CBy", created);
                        cmd.Parameters.AddWithValue("@LOANo", txt06LoaNo.Text);
                        cmd.Parameters.AddWithValue("@LOADEx", dtp06LoaDExp.Value);
                        cmd.Parameters.AddWithValue("@SupCust", SuppCustNo);
                        cmd.Parameters.AddWithValue("@BNo", txt06BondNo.Text);
                        cmd.Parameters.AddWithValue("@BDEx", dtp06BondDExp.Value);
                        cmd.Parameters.AddWithValue("@Custom", Custom);
                        cmd.Parameters.AddWithValue("@DelC", cmb06DelClass.Text);

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

        #region "COMBOBOX"
        private void cmb06Measure_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt06FQty.Text = txt06Qty.Text + " " + cmb06Measure.Text;
        }

        private void cmb06Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"[0-9]");
            if (txt06Val.Text != "" && regex.IsMatch(txt06Val.Text))
            {
                VAL = (Convert.ToDecimal(txt06Val.Text));
                txt06Val.Text = VAL.ToString("N");
                txt06Fval.Text = cmb06Currency.Text + " " + txt06Val.Text;
            }
            else
            {
                txt06Fval.Text = cmb06Currency.Text + " " + VAL;
            }
        }

        private void cmb06DelClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb06DelClass.Text == "LTPI-IZ")
            {
                Custom = "";
            }
            else
            {
                Custom = "BOC";
            }
        }

        private void cmb06Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeatails();
        }

        private void cmb06Imp_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustNo();
            LoadDeatails();
        }

        #endregion

        #region "TEXTBOX"
        private void txt06Val_OnValueChanged(object sender, EventArgs e)
        {
            txt06Fval.Text = cmb06Currency.Text + " " + txt06Val.Text;
        }

        private void frmCreate8106Doc_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesRecordList.i = 0;
            if (frmSalesRecordList.i == 0)
            {
                frmSalesRecordList mainForm = (frmSalesRecordList)Application.OpenForms["frmSalesRecordList"];
                mainForm.OrgBC();
            }
        }

        private void txt06Val_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var regex = new Regex(@"[0-9]");
                if (e.KeyCode == Keys.Enter && regex.IsMatch(txt06Val.Text))
                {
                    VAL = (Convert.ToDecimal(txt06Val.Text));
                    txt06Val.Text = VAL.ToString("N");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt06Qty_OnValueChanged(object sender, EventArgs e)
        {
            txt06FQty.Text = txt06Qty.Text + " " + cmb06Measure.Text;
        }

        private void txt06Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt06Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txt06NoUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txt06CtrlNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion


    }
}
