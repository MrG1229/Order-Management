using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OrderControlMgmt;

namespace OrderControlMgmt.Forms.ForeCast.ForeCastList
{
    public partial class frmNewForecast : Form
    {

        ImportForecast_FDTP fdtp = new ImportForecast_FDTP();
        ImportForecast_GPI gpi = new ImportForecast_GPI();
        ImportForecast_KOUSHIN kmp = new ImportForecast_KOUSHIN();
       
        public frmNewForecast()
        {
            InitializeComponent();
        }


        #region Method

        public void DisplayGPIformat()
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            Con.Open();
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "B1:Q1000]", Con);
            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            gpi.dgOrderList.DataSource = data;

            gpi.dgOrderList.ReadOnly = true;
            //pO_FDTP.dgOrderList.Columns[0].Width = 320;
            gpi.dgOrderList.ClearSelection();

            ////////////
            panelContent.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            gpi.lblID.Text = lblID.Text;
            gpi.TopLevel = false;
            //rf.TopMost = true;
            gpi.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            panelContent.Controls.Add(gpi);
            gpi.Dock = DockStyle.Fill;
            gpi.Show();
            gpi.BringToFront();
            gpi.lblCustName.Text = cmbCustName2.Text;
            gpi.dtpDate.Value = dtpReceivedDate2.Value;
        }

        public void DisplayFDTPformat()
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            Con.Open();
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "A12:AY5000]", Con);
            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);

            fdtp.dgOrderList.DataSource = data;

            fdtp.RemoveRows();
            fdtp.RemoveAnusedCol();

            fdtp.dgOrderList.ReadOnly = true;
            //pO_FDTP.dgOrderList.Columns[0].Width = 320;
            fdtp.dgOrderList.ClearSelection();

            ////////////
            panelContent.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            fdtp.lblID.Text = lblID.Text;
            fdtp.TopLevel = false;
            //rf.TopMost = true;
            fdtp.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            panelContent.Controls.Add(fdtp);
            fdtp.Dock = DockStyle.Fill;
            fdtp.Show();
            fdtp.BringToFront();
            fdtp.lblCustName.Text = cmbCustName2.Text;
            fdtp.dtpDate.Value = dtpReceivedDate2.Value;
        }

        public void DisplayKMPformat()
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            Con.Open();
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "D6:U1000]", Con);
            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);

            kmp.dgOrderList.DataSource = data;

            kmp.dgOrderList.ReadOnly = true;
            //pO_FDTP.dgOrderList.Columns[0].Width = 320;
            kmp.dgOrderList.ClearSelection();

            ////////////
            panelContent.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            kmp.lblID.Text = lblID.Text;
            kmp.TopLevel = false;
            //rf.TopMost = true;
            kmp.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            panelContent.Controls.Add(kmp);
            kmp.Dock = DockStyle.Fill;
            kmp.Show();
            kmp.BringToFront();
            kmp.lblCustName.Text = cmbCustName2.Text;
            kmp.dtpDate.Value = dtpReceivedDate2.Value;
        }

        #endregion

        #region combo box
        private void cmbCustName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustName2.Text == "FDTP")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else if (cmbCustName2.Text == "GPI")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else if (cmbCustName2.Text == "KMP")
            {
                btnChooseFile.Enabled = true;
                TextBoxPath.Enabled = true;
            }
            else { }
        }

        private void cmbSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustName2.Text == "FDTP")
            {
                DisplayFDTPformat();
            }
            else if (cmbCustName2.Text == "GPI")
            {
                DisplayGPIformat();
            }
            else if (cmbCustName2.Text == "KMP")
            {
                DisplayKMPformat();
            }
        }
        #endregion

        #region BUTTON
        private void btnAddForecast_Click(object sender, EventArgs e)
        {
            frmForeCastList_CRUD fcc = new frmForeCastList_CRUD();
            frmForeCast foreCast = new frmForeCast();
            foreCast.lblID.Text = fcc.lblID;
            foreCast.ShowDialog();

            fcc.DisplayPOList();
        }

        private void btnChooseFile_Click_1(object sender, EventArgs e)
        {
            cmbSheetName.Items.Clear();
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                string sheetName = "";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    TextBoxPath.Text = of.FileName;

                    string constr = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";

                    System.Data.OleDb.OleDbConnection Con = new System.Data.OleDb.OleDbConnection(constr);
                    Con.Open();

                    System.Data.DataTable dtExcelSchema = Con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                        cmbSheetName.Items.Add(sheetName);
                    }

                    //Workbook workbook = new Workbook();

                    //Microsoft.Office.Interop.Excel.Application myapp = new Microsoft.Office.Interop.Excel.Application();
                    //myapp.Workbooks.Open(label1.Text);

                    //Workbook wb = myapp.Workbooks.Add(label1.Text);

                    //("ReadFormulaSample.xls");

                    //Worksheet sheet = wb.Worksheets["PartsRequirementPlan_Monthly"];



                    //sheet.Range["AN12"].Text = sheet.Range["AO12"].Formula;
                    //sheet.Range["AN12"].Formula = sheet.Range["AN12"].Formula;

                   // DateTime rs = sheet.Range["AO12"].Value;

                   // DateTime rs1 = rs.AddMonths(-1);

                    //MessageBox.Show(rs1.ToString());
                    Con.Close();

                    ///wb.Close(false);
                }
            }
        }

        #endregion
    }
}
