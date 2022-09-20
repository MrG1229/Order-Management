namespace OrderControlMgmt
{
    partial class frmOrderCtrl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label19;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderCtrl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContent1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSheetName = new MetroFramework.Controls.MetroComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TextBoxPath = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtpReceivedDate2 = new MetroFramework.Controls.MetroDateTime();
            this.cmbCustName2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnManualPO = new System.Windows.Forms.Button();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label21
            // 
            label21.Dock = System.Windows.Forms.DockStyle.Fill;
            label21.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label21.Location = new System.Drawing.Point(509, 4);
            label21.Margin = new System.Windows.Forms.Padding(3);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(195, 35);
            label21.TabIndex = 45;
            label21.Text = "Forecast File";
            label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Dock = System.Windows.Forms.DockStyle.Fill;
            label22.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label22.Location = new System.Drawing.Point(509, 46);
            label22.Margin = new System.Windows.Forms.Padding(3);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(195, 33);
            label22.TabIndex = 46;
            label22.Text = "Sheet Name";
            label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Dock = System.Windows.Forms.DockStyle.Fill;
            label19.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(4, 4);
            label19.Margin = new System.Windows.Forms.Padding(3);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(195, 35);
            label19.TabIndex = 6;
            label19.Text = "Customer Name";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblID);
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainPanel.Size = new System.Drawing.Size(1540, 853);
            this.mainPanel.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(1000, 11);
            this.lblID.Margin = new System.Windows.Forms.Padding(3);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(320, 30);
            this.lblID.TabIndex = 52;
            this.lblID.Text = "label15";
            this.lblID.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1534, 847);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1534, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "NEW CUSTOMER P.O";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1534, 797);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pnlContent1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.80483F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.92084F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.274331F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1534, 797);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // pnlContent1
            // 
            this.pnlContent1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent1.Location = new System.Drawing.Point(3, 89);
            this.pnlContent1.Name = "pnlContent1";
            this.pnlContent1.Size = new System.Drawing.Size(1528, 654);
            this.pnlContent1.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.29561F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.70439F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1528, 80);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.cmbSheetName, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.TextBoxPath, 3, 0);
            this.tableLayoutPanel5.Controls.Add(label19, 0, 0);
            this.tableLayoutPanel5.Controls.Add(label22, 2, 1);
            this.tableLayoutPanel5.Controls.Add(label21, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.dtpReceivedDate2, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.cmbCustName2, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1012, 80);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // cmbSheetName
            // 
            this.cmbSheetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSheetName.FormattingEnabled = true;
            this.cmbSheetName.ItemHeight = 23;
            this.cmbSheetName.Location = new System.Drawing.Point(711, 47);
            this.cmbSheetName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cmbSheetName.Name = "cmbSheetName";
            this.cmbSheetName.Size = new System.Drawing.Size(297, 29);
            this.cmbSheetName.TabIndex = 45;
            this.cmbSheetName.UseSelectable = true;
            this.cmbSheetName.SelectedIndexChanged += new System.EventHandler(this.cmbSheetName_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 46);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(195, 33);
            this.label20.TabIndex = 11;
            this.label20.Text = "Receive Date";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.BorderColorFocused = System.Drawing.Color.Blue;
            this.TextBoxPath.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TextBoxPath.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.TextBoxPath.BorderThickness = 1;
            this.TextBoxPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxPath.Enabled = false;
            this.TextBoxPath.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.TextBoxPath.ForeColor = System.Drawing.Color.Black;
            this.TextBoxPath.isPassword = false;
            this.TextBoxPath.Location = new System.Drawing.Point(712, 5);
            this.TextBoxPath.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.Size = new System.Drawing.Size(295, 33);
            this.TextBoxPath.TabIndex = 47;
            this.TextBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dtpReceivedDate2
            // 
            this.dtpReceivedDate2.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dtpReceivedDate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpReceivedDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate2.Location = new System.Drawing.Point(206, 47);
            this.dtpReceivedDate2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.dtpReceivedDate2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpReceivedDate2.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpReceivedDate2.Name = "dtpReceivedDate2";
            this.dtpReceivedDate2.Size = new System.Drawing.Size(296, 29);
            this.dtpReceivedDate2.Style = MetroFramework.MetroColorStyle.Black;
            this.dtpReceivedDate2.TabIndex = 39;
            this.dtpReceivedDate2.UseCustomBackColor = true;
            this.dtpReceivedDate2.UseCustomForeColor = true;
            this.dtpReceivedDate2.UseStyleColors = true;
            // 
            // cmbCustName2
            // 
            this.cmbCustName2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustName2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCustName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustName2.FormattingEnabled = true;
            this.cmbCustName2.Items.AddRange(new object[] {
            "FDTP",
            "GPI",
            "KMP"});
            this.cmbCustName2.Location = new System.Drawing.Point(206, 7);
            this.cmbCustName2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cmbCustName2.Name = "cmbCustName2";
            this.cmbCustName2.Size = new System.Drawing.Size(296, 28);
            this.cmbCustName2.TabIndex = 48;
            this.cmbCustName2.SelectedIndexChanged += new System.EventHandler(this.cmbCustName2_SelectedIndexChanged);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.btnChooseFile, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnManualPO, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(1012, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(516, 80);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnChooseFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChooseFile.Enabled = false;
            this.btnChooseFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnChooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseFile.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.ForeColor = System.Drawing.Color.Black;
            this.btnChooseFile.Location = new System.Drawing.Point(4, 4);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(250, 72);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "CHOOSE A FILE";
            this.btnChooseFile.UseVisualStyleBackColor = false;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnManualPO
            // 
            this.btnManualPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnManualPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualPO.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualPO.Location = new System.Drawing.Point(261, 4);
            this.btnManualPO.Name = "btnManualPO";
            this.btnManualPO.Size = new System.Drawing.Size(251, 72);
            this.btnManualPO.TabIndex = 53;
            this.btnManualPO.Text = "CREATE MANUAL P.O";
            this.btnManualPO.UseVisualStyleBackColor = true;
            this.btnManualPO.Click += new System.EventHandler(this.btnManualPO_Click);
            // 
            // frmOrderCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1540, 853);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderCtrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.Load += new System.EventHandler(this.frmOrderCtrl_Load);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MetroFramework.Controls.MetroComboBox cmbSheetName;
        private System.Windows.Forms.Label label20;
        public Bunifu.Framework.UI.BunifuMetroTextbox TextBoxPath;
        private MetroFramework.Controls.MetroDateTime dtpReceivedDate2;
        private System.Windows.Forms.ComboBox cmbCustName2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnManualPO;
        private System.Windows.Forms.Panel pnlContent1;
    }
}

