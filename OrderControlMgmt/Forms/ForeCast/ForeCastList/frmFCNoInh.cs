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

namespace OrderControlMgmt.Forms.ForeCast.ForeCastList
{
    public partial class frmFCNoInh : Form
    {

        POExport exp = new POExport();

        public frmFCNoInh()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exp.ExportToExcelWithFormat(dgvNoInhList);
        }
    }
}
