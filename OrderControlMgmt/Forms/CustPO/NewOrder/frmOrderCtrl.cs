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
    public partial class frmOrderCtrl : Form
    {
        Variables v = new Variables();
        ImportPO_FDTP pO_FDTP = new ImportPO_FDTP();
        ImportPO_GLORY pO_GLORY = new ImportPO_GLORY();
        ImportPO_KOUSHIN pO_KOUSHIN = new ImportPO_KOUSHIN();
        PublicDataTransporter pdt = new PublicDataTransporter();
        string sheetName;

        public frmOrderCtrl()
        {
            InitializeComponent();                 
        }

       
        #region METHODS 

        //
        private void Import_FDTP()
        {
            
            cmbSheetName.Items.Clear();
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {                    
                    TextBoxPath.Text = of.FileName;
                    //pO_FDTP.dgOrderList.Rows.Clear();
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);                    
                    Con.Open();

                    System.Data.DataTable dtExcelSchema = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                        if(sheetName.Contains("FilterDatabase"))
                        {
                            sheetName = "";
                        }

                        if (sheetName != "")
                        {
                            cmbSheetName.Items.Add(sheetName);
                        }
                    }
                   
                }
            }
          
        }

        private void DisplayPOItems_FDTP()
        {
            //cmbSheetName.Items.Clear();
            //pO_FDTP.dgOrderList.Rows.Clear();
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            Con.Open();
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "A2:R1000]", Con);
            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            pO_FDTP.dgOrderList.DataSource = data;

            pO_FDTP.dgOrderList.ReadOnly = true;
            //pO_FDTP.dgOrderList.Columns[0].Width = 320;
            pO_FDTP.dgOrderList.ClearSelection();

            ////////////
            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_FDTP.lblID.Text = lblID.Text;
            pO_FDTP.TopLevel = false;
            //rf.TopMost = true;
            pO_FDTP.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_FDTP);
            pO_FDTP.Dock = DockStyle.Fill;
            pO_FDTP.Show();
            pO_FDTP.BringToFront();
            pO_FDTP.lblCustName.Text = cmbCustName2.Text;
            pO_FDTP.dtpDate.Value = dtpReceivedDate2.Value;
        }

        //
        private void Import_GLORY()
        {
            
            cmbSheetName.Items.Clear();
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    TextBoxPath.Text = of.FileName;
                    //pO_GLORY.dgOrderList.Rows.Clear();

                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);                    
                    Con.Open();

                    System.Data.DataTable dtExcelSchema = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                        if (sheetName.Contains("FilterDatabase"))
                        {
                            sheetName = "";
                        }

                        if (sheetName != "")
                        {
                            cmbSheetName.Items.Add(sheetName);
                        }
                    }
                    
                }
            }
            
        }

        private void DisplayPOItems_GLORY()
        {
            //pO_GLORY.dgOrderList.Rows.Clear();
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "A1:L1000]", Con);
            Con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            pO_GLORY.dgOrderList.DataSource = data;

            pO_GLORY.dgOrderList.ReadOnly = true;
            //pO_GLORY.dgOrderList.Columns[0].Width = 320;
            pO_GLORY.dgOrderList.ClearSelection();

            ///////////////////////////////////

            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_GLORY.lblID.Text = lblID.Text;
            pO_GLORY.TopLevel = false;
            //rf.TopMost = true;
            pO_GLORY.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_GLORY);
            pO_GLORY.Dock = DockStyle.Fill;
            pO_GLORY.Show();
            pO_GLORY.BringToFront();
            pO_GLORY.lblCustName.Text = cmbCustName2.Text;
            pO_GLORY.dtpDate.Value = dtpReceivedDate2.Value;
        }

        //
        private void Import_KOUSHIN()
        {
            
            cmbSheetName.Items.Clear();
            using (OpenFileDialog of = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm", ValidateNames = true })
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    TextBoxPath.Text = of.FileName;
                    //pO_KOUSHIN.dgOrderList.Rows.Clear();

                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);                    
                    Con.Open();

                    System.Data.DataTable dtExcelSchema = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                    {
                        sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                        if (sheetName.Contains("FilterDatabase"))
                        {
                            sheetName = "";
                        }

                        if (sheetName != "")
                        {
                            cmbSheetName.Items.Add(sheetName);
                        }
                    }
                    
                }
            }            
        }

        private void DisplayPOItems_KOUSHIN()
        {
            //pO_KOUSHIN.dgOrderList.Rows.Clear();
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBoxPath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection Con = new OleDbConnection(constr);
            OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [" + cmbSheetName.Text + "A8:S1000]", Con);
            Con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            pO_KOUSHIN.dgOrderList.DataSource = data;


            pO_KOUSHIN.dgOrderList.ReadOnly = true;
            //pO_KOUSHIN.dgOrderList.Columns[0].Width = 320;
            pO_KOUSHIN.dgOrderList.ClearSelection();

            ///////////////////////////////////////

            pnlContent1.Controls.Clear();
            //rf.lblUName.Text = lblUName.Text;
            pO_KOUSHIN.lblID.Text = lblID.Text;
            pO_KOUSHIN.TopLevel = false;
            //rf.TopMost = true;
            pO_KOUSHIN.FormBorderStyle = FormBorderStyle.None;
            //rf.WindowState = FormWindowState.Maximized;
            pnlContent1.Controls.Add(pO_KOUSHIN);
            pO_KOUSHIN.Dock = DockStyle.Fill;
            pO_KOUSHIN.Show();
            pO_KOUSHIN.BringToFront();
            pO_KOUSHIN.lblCustName.Text = cmbCustName2.Text;
            pO_KOUSHIN.dtpDate.Value = dtpReceivedDate2.Value;
        }

        #endregion

        #region COMBOBOX             

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
                DisplayPOItems_FDTP();
            }
            else if (cmbCustName2.Text == "GPI")
            {
                DisplayPOItems_GLORY();
            }
            else if (cmbCustName2.Text == "KMP")
            {
                DisplayPOItems_KOUSHIN();
            }
            else { }
        }

        #endregion

        #region BUTTON

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (cmbCustName2.Text == "FDTP")
            {
                Import_FDTP();
            }
            else if (cmbCustName2.Text == "GPI")
            {
                Import_GLORY();
            }
            else if (cmbCustName2.Text == "KMP")
            {
                Import_KOUSHIN();
            }
            else { }
        }               

        #endregion            

        private void btnManualPO_Click(object sender, EventArgs e)
        {
            frmManualPO manPO = new frmManualPO();
            manPO.ShowDialog();
            manPO.lblID.Text = lblID.Text;
        }

        private void frmOrderCtrl_Load(object sender, EventArgs e)
        {

        }
    }
}
