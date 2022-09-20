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
using OrderControlMgmt.Forms.PEZA;

namespace OrderControlMgmt
{
    public partial class frmSalesRecordList : Form
    {

        Variables v = new Variables();
        public static string DrNo;
        public static string CreatedBy;
        public static int i;
        int counter = 0;
        DataTable dtDrNoList = new DataTable();
        DataTable dtDrNoCocat = new DataTable();

        public frmSalesRecordList()
        {
            InitializeComponent();

            //LoadTable();
            LoadSINo();
            this.WindowState = FormWindowState.Maximized;
            CreatedBy = lblID.Text;
            LoadTable();

            dtDrNoList.Columns.Add("DrNo",typeof(string));
            dtDrNoCocat.Columns.Add("ConCatDr", typeof(string));
        }


        private void LoadTable()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    //string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_SalesInvoice] WHERE SINo = '" + cmbSINo.Text + "' ORDER BY DateCreated ASC";
                    string query = "SELECT * FROM [pcs_db].[dbo].[ADQ_SalesInvoice] ORDER BY DateCreated ASC";
                    salesInvoiceDetailsBindingSource.DataSource = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text);
                }

                //foreach (DataGridViewRow row in dataGridView.Rows)
                //{
                //    TotalAmount = (Convert.ToDecimal(row.Cells[9].Value) * Convert.ToDecimal(row.Cells[11].Value));
                //    row.Cells[12].Value = TotalAmount;
                //}

                //int i = 0;
                //foreach (DataGridViewRow row in dataGridView.Rows)
                //{
                //    row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                //    i++;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadSINo()
        {
            v.query = "SELECT SINo FROM [pcs_db].[dbo].[ADQ_SalesInvoice] WHERE SIPrint = 'DONE' GROUP BY SINo "; //
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    cmbSINo.Items.Add(v.reader.GetString(v.reader.GetOrdinal("SINo")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.Columns[e.ColumnIndex].Name == "CHK")
            {
                try
                {
                    if (Convert.ToBoolean(dataGridView.SelectedRows[0].Cells["CHK"].Value) == true)
                    {
                        dataGridView.SelectedRows[0].Cells["CHK"].Value = false;
                    }
                    else
                    {
                        dataGridView.SelectedRows[0].Cells["CHK"].Value = true;
                    }
                }
                catch
                {
                    dataGridView.SelectedRows[0].Cells["CHK"].Value = true;
                }
            }
            btn_8105.Enabled = true;
            btn_8106.Enabled = true;
            btn_8112.Enabled = true;
            btn_BoatNote.Enabled = true;
            if (e.ColumnIndex == 6)
            {
                frmSalesRecordDetails salesRecordDetails = new frmSalesRecordDetails();
                salesRecordDetails.lblSINoDetail.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(salesRecordDetails.SINODetail);
                salesRecordDetails.ShowDialog();
            }

        }

        #region "BUTTTONS"
        private void btn_8105_Click(object sender, EventArgs e)
        {
            frmCreate8105Doc.created = lblID.Text;
            i = 1;
            btn_8105.BackColor = Color.FromArgb(233, 233, 233);
            btn_8105.ForeColor = Color.Black;
            OrgBC();

            frmCreate8105Doc f8105Doc = new frmCreate8105Doc();

            f8105Doc.txt05SINo.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            f8105Doc.txt05DRNo.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            f8105Doc.ShowDialog();
        }

        private void btn_8106_Click(object sender, EventArgs e)
        {
            frmCreate8106Doc.created = lblID.Text;
            i = 2;
            btn_8106.BackColor = Color.FromArgb(233, 233, 233);
            btn_8106.ForeColor = Color.Black;
            OrgBC();
            frmCreate8106Doc frm06 = new frmCreate8106Doc();
            GetDrNo();
            frm06.ShowDialog();
        }

        private void btn_8112_Click(object sender, EventArgs e)
        {
            frmCreate8112Doc.createdb = lblID.Text;
            i = 3;
            btn_8112.BackColor = Color.FromArgb(233, 233, 233);
            btn_8112.ForeColor = Color.Black;
            OrgBC();
            frmCreate8112Doc frm12 = new frmCreate8112Doc();
            GetDrNo();
            frm12.ShowDialog();
        }

        private void btn_BoatNote_Click(object sender, EventArgs e)
        {
            frmCreateBoatNote.created = lblID.Text;
            i = 4;
            btn_BoatNote.BackColor = Color.FromArgb(233, 233, 233);
            btn_BoatNote.ForeColor = Color.Black;
            OrgBC();
            frmCreateBoatNote frmBN = new frmCreateBoatNote();

            frmBN.ShowDialog();
        }
        #endregion

        #region "METHOD"

        public void OrgBC()
        {
            if (i == 1)
            {
                btn_8106.BackColor = Color.FromArgb(82, 82, 82);
                btn_8106.ForeColor = Color.Gainsboro;
                btn_8112.BackColor = Color.FromArgb(82, 82, 82);
                btn_8112.ForeColor = Color.Gainsboro;
                btn_BoatNote.BackColor = Color.FromArgb(82, 82, 82);
                btn_BoatNote.ForeColor = Color.Gainsboro;
            }
            else if (i == 2)
            {
                btn_8105.BackColor = Color.FromArgb(82, 82, 82);
                btn_8105.ForeColor = Color.Gainsboro;
                btn_8112.BackColor = Color.FromArgb(82, 82, 82);
                btn_8112.ForeColor = Color.Gainsboro;
                btn_BoatNote.BackColor = Color.FromArgb(82, 82, 82);
                btn_BoatNote.ForeColor = Color.Gainsboro;
            }
            else if (i == 3)
            {
                btn_8105.BackColor = Color.FromArgb(82, 82, 82);
                btn_8105.ForeColor = Color.Gainsboro;
                btn_8106.BackColor = Color.FromArgb(82, 82, 82);
                btn_8106.ForeColor = Color.Gainsboro;
                btn_BoatNote.BackColor = Color.FromArgb(82, 82, 82);
                btn_BoatNote.ForeColor = Color.Gainsboro;
            }
            else if (i == 4)
            {
                btn_8105.BackColor = Color.FromArgb(82, 82, 82);
                btn_8105.ForeColor = Color.Gainsboro;
                btn_8106.BackColor = Color.FromArgb(82, 82, 82);
                btn_8106.ForeColor = Color.Gainsboro;
                btn_8112.BackColor = Color.FromArgb(82, 82, 82);
                btn_8112.ForeColor = Color.Gainsboro;
            }
            else if (i == 0)
            {
                btn_8105.BackColor = Color.FromArgb(82, 82, 82);
                btn_8105.ForeColor = Color.Gainsboro;
                btn_8106.BackColor = Color.FromArgb(82, 82, 82);
                btn_8106.ForeColor = Color.Gainsboro;
                btn_8112.BackColor = Color.FromArgb(82, 82, 82);
                btn_8112.ForeColor = Color.Gainsboro;
                btn_BoatNote.BackColor = Color.FromArgb(82, 82, 82);
                btn_BoatNote.ForeColor = Color.Gainsboro;
            }
        }

        public void GetDrNo()
        {
            dtDrNoList.Rows.Clear();
            dtDrNoCocat.Rows.Clear();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["CHK"].Value.ToString()) == true)
                {
                    dtDrNoList.Rows.Add(dataGridView.Rows[i].Cells["dataGridViewTextBoxColumn1"].Value.ToString());
                }
            }

            for (int i = 1; i < dtDrNoList.Rows.Count; i++)
            {
                string var1, var2;

                if (i == 1)
                {
                    var1 = dtDrNoList.Rows[0][0].ToString();
                    var2 = var1 + "/" + dtDrNoList.Rows[i][0].ToString();
                    DrNo = var2;
                    dtDrNoCocat.Rows.Add(var2);
                }
                else
                {
                    DrNo = dtDrNoCocat.Rows[0][0].ToString()+"/"+ dtDrNoList.Rows[i][0].ToString();
                    dtDrNoCocat.Rows[0][0] = DrNo;
                }
            }

            if(dtDrNoList.Rows.Count == 1)
            {
                DrNo = dtDrNoList.Rows[0][0].ToString();
            }
        } 

        #endregion

        private void cmbSINo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}

