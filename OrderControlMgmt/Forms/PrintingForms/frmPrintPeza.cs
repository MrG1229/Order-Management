using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderControlMgmt.Reports;
using System.Data.SqlClient;
using OrderControlMgmt.Class;
using OrderControlMgmt.Forms.PrintingForms;


namespace OrderControlMgmt.Forms.PrintingForms
{
    public partial class frmPrintPeza : Form
    {
        public static string ID, selection,CNo, long12 = "";
        int i;
        Variables varr = new Variables();
        public frmPrintPeza()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            txtSearchCN.Enabled = false;
         
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            btnFilter.Enabled = false;  
            dgvDataList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            frmPrintShow.name = "Printing Form-" + label1.Text;

        }

        private void frmPrintPeza_Load(object sender, EventArgs e)
        {
            btn8105.PerformClick();
        }

        #region "BUTTONS"

        private void btn8105_Click(object sender, EventArgs e)
        {
            selection = "GGG_PEZA8105";
            i = 1;
           
            OrgBC();
            FillIn();
            DisAllData();
            txtSearchCN.Clear();
            label1.Text = "PEZA FILES - 8105";
            frmPrintShow.name = "Printing Form-" + label1.Text;
            Enablefields();
        }

        private void btn8106_Click(object sender, EventArgs e)
        {
            selection = "GGG_PEZA8106";
            i = 2;
          
            OrgBC();
            FillIn();
            DisAllData();
            txtSearchCN.Clear();
            label1.Text = "PEZA FILES - 8106";
            frmPrintShow.name = "Printing Form-" + label1.Text;
            Enablefields();
        }

        private void btn8112_Click(object sender, EventArgs e)
        {
            selection = "GGG_PEZA8112";
            i = 3;
            OrgBC();
            FillIn();
            DisAllData();
            txtSearchCN.Clear();
            label1.Text = "PEZA FILES - 8112";
            frmPrintShow.name = "Printing Form-" + label1.Text;
            Enablefields();
        }

        private void btnBoatNote_Click(object sender, EventArgs e)
        {
            selection = "GGG_BoatNote";
            i = 4;
            OrgBC();
            FillIn();
            DisAllData();
            txtSearchCN.Clear();
            label1.Text = "PEZA FILES - BOAT NOTE";
            frmPrintShow.name = "Printing Form-" + label1.Text;
            Enablefields();
        }

        //Print Button
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CNo = dgvDataList.CurrentRow.Cells[1].Value.ToString();
            long12 = "";
            frmPrintShow frmPrint = new frmPrintShow();
            frmPrint.ShowDialog();
        }

        private void btn8112PrintLong_Click(object sender, EventArgs e)
        {
            CNo = dgvDataList.CurrentRow.Cells[1].Value.ToString();
            long12 = "long";
            frmPrintShow frmPrint = new frmPrintShow();
            frmPrint.ShowDialog();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from (Select Row_Number() Over(Order By DateCreated) As RowNum , * From " + selection + "  where DateCreated  between '" + dtpFrom.Value.ToString() + "' AND '" + dtpTo.Value.ToString() + "') t2", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgvDataList.DataSource = dt;
        }

        #endregion

        #region"METHOD"

        public void OrgBC()
        {
            if (i == 1)
            {
                //btn8105.BackColor = Color.FromArgb(82, 82, 82);
                btn8105.Font = new Font(btn8105.Font,FontStyle.Bold);
                pnlindi0.Visible = true;
                //btn8106.BackColor = Color.FromArgb(233,233,233);
                btn8106.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi1.Visible = false;
                //btn8112.BackColor = Color.FromArgb(233, 233, 233);
                btn8112.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi2.Visible = false;
                //btnBoatNote.BackColor = Color.FromArgb(233, 233, 233);
                btnBoatNote.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi3.Visible = false;
            }
           else if (i == 2)
            {
                //btn8106.BackColor = Color.FromArgb(82, 82, 82);
                btn8106.Font = new Font(btn8105.Font, FontStyle.Bold);
                pnlindi1.Visible = true;
                //btn8105.BackColor = Color.FromArgb(233, 233, 233);
                btn8105.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi0.Visible = false;
                //btn8112.BackColor = Color.FromArgb(233, 233, 233);
                btn8112.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi2.Visible = false;
                //btnBoatNote.BackColor = Color.FromArgb(233, 233, 233);
                btnBoatNote.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi3.Visible = false;
            }
           else if (i == 3)
            {
                //btn8112.BackColor = Color.FromArgb(82, 82, 82);
                btn8112.Font = new Font(btn8105.Font, FontStyle.Bold);
                pnlindi2.Visible = true;
                //btn8105.BackColor = Color.FromArgb(233, 233, 233);
                btn8105.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi0.Visible = false;
                //btn8106.BackColor = Color.FromArgb(233, 233, 233);
                btn8106.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi1.Visible = false;
                //btnBoatNote.BackColor = Color.FromArgb(233, 233, 233);
                btnBoatNote.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi3.Visible = false;
            }
            else if (i == 4)
            {
                //btnBoatNote.BackColor = Color.FromArgb(82, 82, 82);
                btnBoatNote.Font = new Font(btn8105.Font, FontStyle.Bold);
                pnlindi3.Visible = true;
                //btn8105.BackColor = Color.FromArgb(233, 233, 233);
                btn8105.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi0.Visible = false;
                //btn8106.BackColor = Color.FromArgb(233, 233, 233);
                btn8106.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi1.Visible = false;
                //btn8112.BackColor = Color.FromArgb(233, 233, 233);
                btn8112.Font = new Font(btn8105.Font, FontStyle.Regular);
                pnlindi2.Visible = false;
            }
        }

        public void FillIn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(varr.ConnString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select ControlNo from " + selection + " ", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    Collection.Add(dr.GetString(0));
                }
                txtSearchCN.AutoCompleteCustomSource = Collection;
                txtSearchCN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearchCN.AutoCompleteSource = AutoCompleteSource.CustomSource;
                conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
        public void Enablefields()
        {
            if (label1.Text == "PEZA FILES - 8112")
            {
                btn8112PrintLong.Visible = true;
                btnPrint.Text = "PRINT SHORT";
            }
            else
            {
                btn8112PrintLong.Visible = false;
                btnPrint.Text = "PRINT";
            }
            txtSearchCN.Enabled = true;
          
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            btnFilter.Enabled = true;
        }

        public void DisAllData()
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select Row_Number() Over(Order By DateCreated) As RowNum , * From "+selection+" ", conn); //"Select * From (Select Row_Number() Over(Order By DateCreated) As RowNum , * From " + selection + " ) t2"
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgvDataList.DataSource = dt;
        }

        #endregion

        #region "DGV"

        private void dgvDataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //CNo = dgvDataList.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                CNo = dgvDataList.CurrentRow.Cells[1].Value.ToString();
                btnPrint.Enabled = true;
                btn8112PrintLong.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvDataList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 'p') & (e.KeyChar != 'P'))
            {

            }
            else
            {
                CNo = dgvDataList.CurrentRow.Cells[1].Value.ToString();
                frmPrintShow frmPrint = new frmPrintShow();
                frmPrint.ShowDialog();
            }
        }
        #endregion

        #region "TEXTBOX"
        private void txtSearchCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearchCN_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(varr.ConnString);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from (Select Row_Number() Over(Order By DateCreated) As RowNum , * From " + selection + " where ControlNo Like '%" + txtSearchCN.Text + "%')t2", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dgvDataList.DataSource = dt;
        }
        #endregion

    }
}
