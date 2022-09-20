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

namespace OrderControlMgmt
{
    public partial class frmSalesEntry : Form
    {
        Variables v = new Variables();
        Boolean chk = new Boolean();
        public decimal TotalAmount = 0;          
        string Currency = "";       
        decimal sum = 0;

        public frmSalesEntry()
        {
            InitializeComponent();

            LoadDRNo();
        }      
       
        private void LoadDRNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[MOM_DRReceipt] WHERE DRPrint = 'DONE' AND SIStatus != 'DONE' "; //

            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    cmbDRNo.Items.Add(v.reader.GetString(v.reader.GetOrdinal("DR_no")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LoadAllData()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCreateSIList] where [SIStatus] != 'DONE' ";
                salesInvoiceDetailsBindingSource.DataSource = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text);

            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                TotalAmount = (Convert.ToDecimal(row.Cells[10].Value) * Convert.ToDecimal(row.Cells[12].Value));
                row.Cells[13].Value = TotalAmount;
                sum += TotalAmount;
            }

            int i = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        private void cmbDRNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewCreateSIList] WHERE DR_no = '" + cmbDRNo.Text + "' ";
                    salesInvoiceDetailsBindingSource.DataSource = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text);

                }

                #region Get SDSNo
                v.query = "SELECT * FROM [pcs_db].[dbo].[viewCreateSIList] WHERE DR_no = '" + cmbDRNo.Text + "' "; //

                try
                {
                    v.conn = new SqlConnection(v.connString);
                    v.conn.Open();
                    v.sqlCommand = new SqlCommand(v.query, v.conn);
                    v.reader = v.sqlCommand.ExecuteReader();
                    while (v.reader.Read())
                    {
                        txtSDSNo.Text = v.reader.GetString(v.reader.GetOrdinal("SDSno"));
                        Currency = v.reader.GetString(v.reader.GetOrdinal("Currency"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                #endregion

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    TotalAmount = (Convert.ToDecimal(row.Cells[9].Value) * Convert.ToDecimal(row.Cells[11].Value));
                    row.Cells[12].Value = TotalAmount;
                    sum += TotalAmount;
                }

                int i = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbDRNo_TextChanged(object sender, EventArgs e)
        {
            if (cmbDRNo.Text == "" || cmbDRNo.Text == null)
            {
                label2.Visible = false;
                txtSINo.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                label2.Visible = true;
                txtSINo.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void SaveSI()
        {

            #region INSERT DATA
            if (txtSINo.Text == "")
            { Warning.Show("The Sales Invoice No. is Empty", "WARNING"); }
            else
            {
                for(int j = 0; j < dataGridView.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridView.Rows[j].Cells[0].Value) == true)
                    {
                        v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_SalesInvoice]" +
                      "(SINo, DR_no, SDSNo, TotalAmount, Currency, DateCreated, SIPrint) " +
                      "VALUES (" +
                      "'" + txtSINo.Text + "', '" + dataGridView.Rows[j].Cells[2].Value.ToString() + "', '" + dataGridView.Rows[j].Cells[3].Value.ToString() + "', '" + dataGridView.Rows[j].Cells[13].Value.ToString() + "', " +
                      "'" + dataGridView.Rows[j].Cells[14].Value.ToString() + "', '" + DateTime.Now + "', '-')";

                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.sqlCommand.ExecuteNonQuery();

                        v.query = "UPDATE [pcs_db].[dbo].[MOM_DRReceipt] SET SIStatus = 'DONE' " +
                       " WHERE DR_no = '" + dataGridView.Rows[j].Cells[2].Value.ToString() + "'";

                        v.conn = new SqlConnection(v.connString);
                        v.conn.Open();
                        v.sqlCommand = new SqlCommand(v.query, v.conn);
                        v.sqlCommand.ExecuteNonQuery();

                        if (dataGridView.Rows.Count - 1 == j)
                        {
                            Save_Confirmation.Show("Sales Invoice Entry is saved", "Successfully Added");
                        }
                    }

                }

                
                //v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_SalesInvoice]" +
                //       "(SINo, DR_no, SDSNo, TotalAmount, Currency, DateCreated, SIPrint) " +
                //       "VALUES (" +
                //       "'" + txtSINo.Text + "', '" + cmbDRNo.Text + "', '" + txtSDSNo.Text + "', '" + sum + "', " +
                //       "'" + Currency + "', '" + DateTime.Now + "', '-')";
                //try
                //{
                //    v.conn = new SqlConnection(v.connString);
                //    v.conn.Open();
                //    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //    v.reader = v.sqlCommand.ExecuteReader();
                //    while (v.reader.Read())
                //    {

                //    }
                //    Save_Confirmation.Show("Sales Invoice Entry is saved", "Successfully Added");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
                #endregion

                #region UPDATE DATA
                //v.query = "UPDATE [pcs_db].[dbo].[MOM_DRReceipt] SET SIStatus = 'DONE' " +
                //    " WHERE DR_no = '" + cmbDRNo.Text + "'    ";
                //try
                //{
                //    v.conn = new SqlConnection(v.connString);
                //    v.conn.Open();
                //    v.sqlCommand = new SqlCommand(v.query, v.conn);
                //    v.reader = v.sqlCommand.ExecuteReader();
                //    while (v.reader.Read())
                //    {

                //    }
                //    //MessageBox.Show("Saved!");
                //}

                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
            #endregion

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSI();
        }

        private void frmSalesEntry_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "check")
            {
                try
                {
                    if (Convert.ToBoolean(dataGridView.SelectedRows[0].Cells["check"].Value) == true)
                    {
                        dataGridView.SelectedRows[0].Cells["check"].Value = false;
                    }
                    else
                    {
                        dataGridView.SelectedRows[0].Cells["check"].Value = true;
                    }
                }
                catch
                {
                    dataGridView.SelectedRows[0].Cells["check"].Value = true;
                }
            }

            int counter = 0;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView.Rows[i].Cells[0].Value) == true)
                    {
                        counter++;
                    }

                }
            }

            if (counter > 0)
            {
                btnSave.Visible = true;
                txtSINo.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                txtSINo.Visible = false;
            }
        }
    }
}
//foreach (DataGridViewRow row in dataGridView.Rows)
//{                       
//    chk = Convert.ToBoolean(row.Cells[0].Value);
//    if (chk == true)
//    {
//        #region INSERT DATA
//        v.query = "INSERT INTO [pcs_db].[dbo].[ADQ_SalesInvoiceEntry]" +
//                "(SINo, DR_no, SDSNo, TotalAmount, Currency, DateCreated, SIStatus) " +
//                "VALUES (" +
//                "'" + txtSINo.Text + "', '" + row.Cells[1].Value + "', '" + row.Cells[2].Value + "', '" + row.Cells[12].Value + "', " +
//                "'" + row.Cells[13].Value + "', '" + DateTime.Now + "', '-')";
//        try
//        { 
//            v.conn = new SqlConnection(v.connString);
//            v.conn.Open();
//            v.sqlCommand = new SqlCommand(v.query, v.conn);
//            v.reader = v.sqlCommand.ExecuteReader();
//            while (v.reader.Read())
//            {

//            }
//            Save_Confirmation.Show("Sales Invoice Entry is saved", "Successfully Added");
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.ToString());
//        }
//                #endregion

//        #region UPDATE DATA
//                v.query = "UPDATE [pcs_db].[dbo].[MOM_DRReceipt] SET SIStatus = 'DONE' " +
//                    " WHERE DR_no = '" + row.Cells[1].Value + "'    ";
//                try
//                {
//                    v.conn = new SqlConnection(v.connString);
//                    v.conn.Open();
//                    v.sqlCommand = new SqlCommand(v.query, v.conn);
//                    v.reader = v.sqlCommand.ExecuteReader();
//                    while (v.reader.Read())
//                    {

//                    }
//                    //MessageBox.Show("Saved!");
//                }

//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.ToString());
//                }

//                #endregion
//    }
//}