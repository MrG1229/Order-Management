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
using System.IO;
using ExcelDataReader;
using System.Configuration;
using Dapper;
using OrderControlMgmt.Class;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using OrderControlMgmt.Forms;
using CustomMessageBox;
using UserAccessControl;
using OrderControlMgmt.Forms.Sales;

namespace OrderControlMgmt
{
    public partial class frmSalesInvoice : Form
    {
        Variables v = new Variables();
        System.Data.DataTable dtSelectedList = new System.Data.DataTable();
        int counter = 0;
        frmCancelInvoice frmCanSINo = new frmCancelInvoice();

        public frmSalesInvoice()
        {
            InitializeComponent();
            LoadData();
            LoadSINo();
            AddCol();
        }      
       
        private void LoadSINo()
        {
            v.query = "SELECT SINo FROM [pcs_db].[dbo].[ADQ_SalesInvoice] WHERE SIPrint = '-' GROUP BY SINo "; //
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

        public void AddCol()
        {
            dtSelectedList.Columns.Add("Cust Nick Name",typeof(string));
            dtSelectedList.Columns.Add("SINo",typeof(string));
            dtSelectedList.Columns.Add("DR_No",typeof(string));
            dtSelectedList.Columns.Add("Delivery Date",typeof(string));
            dtSelectedList.Columns.Add("Total Amount",typeof(string));
        }

        public void LoadData()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                //string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] WHERE SINo = '" + cmbSINo.Text + "' ";
                //string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList]  ";
                // string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] inner join [pcs_db].[dbo].[ADQ_SalesInvoice] on [pcs_db].[dbo].[viewSalesInvoiceList].SINo = [pcs_db].[dbo].[ADQ_SalesInvoice].SINo WHERE [pcs_db].[dbo].[ADQ_SalesInvoice].SIPrint = '-' ";
                string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList]";
                salesInvoiceDetailsBindingSource.DataSource = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text);
            }
        }

        public void EnaCanBtn()
        {
            counter = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                try
                {
                    if (Convert.ToBoolean(dataGridView.Rows[i].Cells["chk"].Value) == true)
                    {
                        counter++;
                    }
                }
                catch
                { }
            }

            if (counter >= 1)
            {
                btnBCancelSIN.Visible = true;
            }
            else
            {
                btnBCancelSIN.Visible = false;
            }
        }

        private void cmbDRNo_TextChanged(object sender, EventArgs e)
        {
            //if(cmbDRNo.Text == "" || cmbDRNo.Text == null)
            //{
            //    label2.Visible = false;
            //    txtSINo.Visible = false;
            //    btnSave.Visible = false;
            //}
            //else
            //{
            //    label2.Visible = true;
            //    txtSINo.Visible = true;
            //    btnSave.Visible = true;
            //}
        }        

        private void cmbSINo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    //string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] WHERE SINo = '" + cmbSINo.Text + "' ";
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] where SINo = '"+cmbSINo.Text+"'";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SalesInvoiceDetails obj = salesInvoiceDetailsBindingSource.Current as SalesInvoiceDetails;
            if (obj != null)
            {

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] WHERE SINo = '" + cmbSINo.Text + "'    ";
                    //string queryFordate = "SELECT *   FROM [pcs_db].[dbo].[ADQ_SalesInvoice] WHERE SINo = '" + cmbSINo.Text + "'    ";
                    List<SalesInvoiceDetails> list = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text).ToList();
                    //List<SalesInvoiceDetails> list = db.Query<SalesInvoiceDetails>(queryFordate, commandType: CommandType.Text).ToList();

                    using (frmPrintSalesInvoice frm = new frmPrintSalesInvoice(obj, list))
                    {
                        frm.SINo = cmbSINo.Text;
                        frm.ShowDialog();
                    }
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                #region UPDATE DATA
                v.query = "UPDATE [pcs_db].[dbo].[ADQ_SalesInvoice] SET SIPrint = 'DONE' " +
                " WHERE SINo = '" + row.Cells[2].Value + "'    ";
                try
                {
                    v.conn = new SqlConnection(v.connString);
                    v.conn.Open();
                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                    v.reader = v.sqlCommand.ExecuteReader();
                    while (v.reader.Read())
                    {

                    }
                    //MessageBox.Show("Saved!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtSelectedList.Rows.Clear();
            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                if (Convert.ToBoolean(dataGridView.Rows[j].Cells["CHK"].Value) == true)
                {
                    dtSelectedList.Rows.Add(
                        dataGridView.Rows[j].Cells["custNickNameDataGridViewTextBoxColumn"].Value.ToString(),
                        dataGridView.Rows[j].Cells["sINoDataGridViewTextBoxColumn"].Value.ToString(),
                        dataGridView.Rows[j].Cells["dRnoDataGridViewTextBoxColumn"].Value.ToString(),
                        dataGridView.Rows[j].Cells["Delivery_date"].Value.ToString(),
                        dataGridView.Rows[j].Cells["totalAmountDataGridViewTextBoxColumn"].Value.ToString());
                }
            }
            frmCanSINo.dgSelectedList.DataSource = dtSelectedList;
            frmCanSINo.ShowDialog();

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
            EnaCanBtn();
        }

        private void frmSalesInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
