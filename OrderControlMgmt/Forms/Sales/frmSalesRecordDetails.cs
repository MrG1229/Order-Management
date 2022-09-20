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

namespace OrderControlMgmt
{
    public partial class frmSalesRecordDetails : Form
    {       

        public frmSalesRecordDetails()
        {
            InitializeComponent();
           
            
        }

        private void LoadTable()
        {            
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT * FROM [pcs_db].[dbo].[viewSalesInvoiceList] WHERE SINo = '" + lblSINoDetail.Text + "' ORDER BY DateCreated ASC";
                    salesInvoiceDetailsBindingSource.DataSource = db.Query<SalesInvoiceDetails>(query, commandType: CommandType.Text);
                }
                
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

        private void frmSalesRecordDetails_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
