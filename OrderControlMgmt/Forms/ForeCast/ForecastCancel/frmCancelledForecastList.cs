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
using OrderControlMgmt.Forms;

namespace OrderControlMgmt
{
    public partial class frmCancelledForecastList : Form
    {
        Variables v = new Variables();
        //frmOrderList_CRUDdetails poCrudDetails = new frmOrderList_CRUDdetails();

        public frmCancelledForecastList()
        {
            InitializeComponent();

            GetPartNo();
            GetInHouseNo();            
        }

        #region METHODS

        public void GetPartNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE PartStatus != 'Deleted' ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.PartNo = v.reader.GetString(v.reader.GetOrdinal("CustomerPartNo"));
                    cmbPartNo.Items.Add(v.PartNo);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetInHouseNo()
        {
            v.query = "SELECT * FROM [pcs_db].[dbo].[DLR_Parts] WHERE PartStatus != 'Deleted' ";
            try
            {
                v.conn = new SqlConnection(v.connString);
                v.conn.Open();
                v.sqlCommand = new SqlCommand(v.query, v.conn);
                v.reader = v.sqlCommand.ExecuteReader();
                while (v.reader.Read())
                {
                    v.InHouseNo = v.reader.GetString(v.reader.GetOrdinal("InHouseNo"));
                    cmbInHouseNo.Items.Add(v.InHouseNo);
                    //orderCtrl.metroComboBox1.Items.Add(v.ProductNo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       

        private void DisplayPOList()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] ORDER BY FCNo ASC"; //WHERE POStatus != 'CANCELLED'
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
            }

            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i+1;
                i++;
            }

            
        }

        #endregion

        #region FILTER  

        private void FilterPOList_ByFCNo()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] WHERE FCNo LIKE '%" + txtFCNo.Text + "%' ORDER BY FCNo ASC";
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
            }
            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        #region TEXTBOX

        private void txtFCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFCNo.Text))
            {
                DisplayPOList();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FilterPOList_ByFCNo();
                }
            }
            
        }

        private void txtFCNo_OnValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFCNo.Text))
            {
                DisplayPOList();
            }
        }

        #endregion

        #region COMBOBOX

        private void cmbPartNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] WHERE PartNo = '" + cmbPartNo.Text + "' ORDER BY FCNo ASC";
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
                db.Close();
            }

            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        private void cmbInHouseNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] WHERE InHouseNo = '" + cmbInHouseNo.Text + "' ORDER BY FCNo ASC";
                forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
                db.Close();
            }
            int i = 0;
            foreach (DataGridViewRow row in dgOrderList.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }

        private void cmbInHouseNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInHouseNo.Text))
            {
                DisplayPOList();
            }
            else
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] WHERE InHouseNo = '" + cmbInHouseNo.Text + "' ORDER BY FCNo ASC";
                    forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
                    db.Close();
                }
                int i = 0;
                foreach (DataGridViewRow row in dgOrderList.Rows)
                {
                    row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                    i++;
                }
            }

        }

        private void cmbPartNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbPartNo.Text))
            {
                DisplayPOList();
            }
            else
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewCancelledForecast] WHERE PartNo = '" + cmbPartNo.Text + "' ORDER BY FCNo ASC";
                    forecastDetailsBindingSource.DataSource = db.Query<ForecastDetails>(query, commandType: CommandType.Text);
                    db.Close();
                }

                int i = 0;
                foreach (DataGridViewRow row in dgOrderList.Rows)
                {
                    row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                    i++;
                }
            }
        }

        #endregion

        #endregion

        private void frmOrderList_CRUD_Load(object sender, EventArgs e)
        {
            DisplayPOList();
        }       

        private void dgOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow data = this.dgOrderList.Rows[e.RowIndex];

            //    v.PPONo = data.Cells["pPONoDataGridViewTextBoxColumn"].Value.ToString();
            //    poCrudDetails.txtPPONo.Text = v.PPONo;

            //    poCrudDetails.ShowDialog();
            //}
        }

       
    }
}
//if (string.IsNullOrWhiteSpace(txtPPONo.Text))
//            {
//                DisplayPOList();
//    }
//            else
//            {

//            }                                                                                              
