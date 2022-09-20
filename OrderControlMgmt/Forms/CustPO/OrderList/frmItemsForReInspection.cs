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
    public partial class frmItemsForReInspection : Form
    {
        public frmItemsForReInspection()
        {
            InitializeComponent();

            POforReInspection();
        }

        private void POforReInspection()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "SELECT * FROM [pcs_db].[dbo].[viewPOListForReInspection] WHERE Date2 >= 1 AND POStatus != 'FINISHED' AND POStatus != 'CANCELLED' ORDER BY PPONo ASC"; //WHERE POStatus != 'CANCELLED'   WHERE POStatus IS NULL               
                pODetailsBindingSource.DataSource = db.Query<PODetails>(query, commandType: CommandType.Text);
            }

            int i = 0;
            foreach (DataGridViewRow row in dgPOReInspect.Rows)
            {
                row.Cells["noDataGridViewTextBoxColumn"].Value = i + 1;
                i++;
            }
        }
    }
}
