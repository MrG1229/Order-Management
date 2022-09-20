using CustomMessageBox;
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

namespace OrderControlMgmt.Forms.CustPO.OrderList
{
    public partial class frmDeleteBatchPO : Form
    {
        Variables v = new Variables();

        public frmDeleteBatchPO()
        {
            InitializeComponent();
            v.conn = new SqlConnection(v.connString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v.conn.Open();
            if (txtCanReason.Text.Length < 30)
            { Warning.Show("ADD A CANCELLATION REASON ATLEAST 30 CHARACTERS!!", "WARNING"); }
            else
            {
                DialogResult result = Warning_Confirmation.Show("Are you sure you want to cancel All this P.O?", "Cancel Confirmation");
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgOrderList.Rows.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("Begin transaction INSERT INTO[pcs_db].[dbo].[ADQ_CancelledPO](PPONo, isPOCancelled, POCancelReason) VALUES('" + dgOrderList.Rows[i].Cells["SytemPONo"].Value.ToString() + "', 1, @res) UPDATE [pcs_db].[dbo].[ADQ_Orders] SET POStatus = 'CANCELLED' WHERE PPONo = '" + dgOrderList.Rows[i].Cells["SytemPONo"].Value.ToString() + "' COMMIT ", v.conn);
                        cmd.Parameters.AddWithValue("@res", txtCanReason.Text);
                        cmd.ExecuteNonQuery();
                    }
                    Save_Confirmation.Show(dgOrderList.Rows.Count +"P.O is cancelled!", "P.O Cancellation");
                    this.Close();
                }
            }
            v.conn.Close();
        }
    }
}
