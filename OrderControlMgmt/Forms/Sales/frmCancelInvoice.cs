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
using CustomMessageBox;
using OrderControlMgmt.Forms.Sales;

namespace OrderControlMgmt.Forms.Sales
{
    public partial class frmCancelInvoice : Form
    {
        Variables v = new Variables();
        SqlConnection con;

        public frmCancelInvoice()
        {
            InitializeComponent();
            con = new SqlConnection(v.ConnStringpcs);
        }

        private void btnCanSIN_Click(object sender, EventArgs e)
        {
            con.Open();
            DialogResult result = Warning_Confirmation.Show("Are you sure you want to cancel All this Sales Invoice?", "Cancel Confirmation");
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dgSelectedList.Rows.Count; i++)
                {
                    SqlCommand cmddelSINo = new SqlCommand("update [pcs_db].[dbo].[ADQ_SalesInvoice] set [SIPrint] = 'CANCELLED' where [SINo] = '" + dgSelectedList.Rows[i].Cells[1].Value.ToString() + "' ", con);
                    cmddelSINo.ExecuteNonQuery();
                }
                Save_Confirmation.Show("ALL LISTED SALES INVOICE HAVE BEEN SUCCESSFULLY CANCELLED","SUCCESSFULL");

                frmSalesInvoice frm = (frmSalesInvoice)Application.OpenForms["frmSalesInvoice"];
                frm.LoadData();

                frm.btnBCancelSIN.Visible = false;

                this.Close();
            }
            con.Close();
        }
    }
}
