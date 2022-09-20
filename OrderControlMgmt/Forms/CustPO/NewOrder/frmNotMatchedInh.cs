using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderControlMgmt.Class;

namespace OrderControlMgmt.Forms.CustPO.NewOrder
{
    public partial class frmNotMatchedInh : Form
    {
        POExport exp = new POExport();
        public frmNotMatchedInh()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exp.ExportToExcelWithFormat(dgvNoInhList);
        }

        private void frmNotMatchedInh_Load(object sender, EventArgs e)
        {
            label2.Text = "*PLEASE BE INFORMED THAT ALL DATA LISTED BELOW DOESN'T HAVE A MATCHING  INHOUSE. \n EDIT OR INSERT THIS TO PART'S MANAGEMENT BEFORE CREATING A P.O AGAIN";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            //this.Dispose();
        }
    }
}
