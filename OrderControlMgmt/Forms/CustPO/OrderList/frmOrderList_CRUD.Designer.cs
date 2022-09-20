namespace OrderControlMgmt
{
    partial class frmOrderList_CRUD
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderList_CRUD));
            this.tl1 = new System.Windows.Forms.TableLayoutPanel();
            this.tl2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tl3 = new System.Windows.Forms.TableLayoutPanel();
            this.tl5 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCustName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbInHouseNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpReceivedDate = new MetroFramework.Controls.MetroDateTime();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPOStatus = new System.Windows.Forms.ComboBox();
            this.chkBCanPo = new System.Windows.Forms.CheckBox();
            this.btnBCancelPO = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelPO = new System.Windows.Forms.Button();
            this.dgOrderList = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODetailNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inHouseNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUnitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOTotalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDSNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pODetailsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tl1.SuspendLayout();
            this.tl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tl3.SuspendLayout();
            this.tl5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tl1
            // 
            this.tl1.ColumnCount = 1;
            this.tl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl1.Controls.Add(this.tl2, 0, 0);
            this.tl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl1.Location = new System.Drawing.Point(0, 0);
            this.tl1.Name = "tl1";
            this.tl1.RowCount = 1;
            this.tl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl1.Size = new System.Drawing.Size(1629, 820);
            this.tl1.TabIndex = 1;
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tl2.ColumnCount = 1;
            this.tl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.Controls.Add(this.pnlMain, 0, 0);
            this.tl2.Controls.Add(this.tl3, 0, 1);
            this.tl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl2.Location = new System.Drawing.Point(3, 3);
            this.tl2.Name = "tl2";
            this.tl2.RowCount = 2;
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl2.Size = new System.Drawing.Size(1623, 814);
            this.tl2.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1623, 45);
            this.pnlMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1623, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "P.O LIST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tl3
            // 
            this.tl3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl3.ColumnCount = 1;
            this.tl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl3.Controls.Add(this.tl5, 0, 0);
            this.tl3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl3.Location = new System.Drawing.Point(0, 45);
            this.tl3.Margin = new System.Windows.Forms.Padding(0);
            this.tl3.Name = "tl3";
            this.tl3.RowCount = 2;
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl3.Size = new System.Drawing.Size(1623, 769);
            this.tl3.TabIndex = 2;
            // 
            // tl5
            // 
            this.tl5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl5.ColumnCount = 6;
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tl5.Controls.Add(this.label6, 0, 2);
            this.tl5.Controls.Add(this.cmbCustName, 1, 2);
            this.tl5.Controls.Add(this.label5, 0, 1);
            this.tl5.Controls.Add(this.cmbInHouseNo, 1, 1);
            this.tl5.Controls.Add(this.label2, 2, 2);
            this.tl5.Controls.Add(this.dtpReceivedDate, 3, 2);
            this.tl5.Controls.Add(this.label7, 2, 1);
            this.tl5.Controls.Add(this.cmbPOStatus, 3, 1);
            this.tl5.Controls.Add(this.chkBCanPo, 0, 3);
            this.tl5.Controls.Add(this.btnBCancelPO, 4, 3);
            this.tl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl5.Location = new System.Drawing.Point(4, 5);
            this.tl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tl5.Name = "tl5";
            this.tl5.RowCount = 4;
            this.tl5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.93023F));
            this.tl5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.06977F));
            this.tl5.Size = new System.Drawing.Size(1615, 120);
            this.tl5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 31);
            this.label6.TabIndex = 54;
            this.label6.Text = "Customer Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCustName
            // 
            this.cmbCustName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCustName.FormattingEnabled = true;
            this.cmbCustName.Location = new System.Drawing.Point(183, 52);
            this.cmbCustName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cmbCustName.Name = "cmbCustName";
            this.cmbCustName.Size = new System.Drawing.Size(351, 28);
            this.cmbCustName.TabIndex = 64;
            this.cmbCustName.SelectedIndexChanged += new System.EventHandler(this.cmbCustName_SelectedIndexChanged);
            this.cmbCustName.TextChanged += new System.EventHandler(this.cmbCustName_TextChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 31);
            this.label5.TabIndex = 53;
            this.label5.Text = "In-House No";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbInHouseNo
            // 
            this.cmbInHouseNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbInHouseNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInHouseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInHouseNo.FormattingEnabled = true;
            this.cmbInHouseNo.Location = new System.Drawing.Point(183, 14);
            this.cmbInHouseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cmbInHouseNo.Name = "cmbInHouseNo";
            this.cmbInHouseNo.Size = new System.Drawing.Size(351, 28);
            this.cmbInHouseNo.TabIndex = 62;
            this.cmbInHouseNo.SelectedIndexChanged += new System.EventHandler(this.cmbInHouseNo_SelectedIndexChanged);
            this.cmbInHouseNo.TextChanged += new System.EventHandler(this.cmbInHouseNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 31);
            this.label2.TabIndex = 66;
            this.label2.Text = "Order Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dtpReceivedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate.Location = new System.Drawing.Point(720, 52);
            this.dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.dtpReceivedDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpReceivedDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(351, 29);
            this.dtpReceivedDate.Style = MetroFramework.MetroColorStyle.Black;
            this.dtpReceivedDate.TabIndex = 67;
            this.dtpReceivedDate.UseCustomBackColor = true;
            this.dtpReceivedDate.UseCustomForeColor = true;
            this.dtpReceivedDate.UseStyleColors = true;
            this.dtpReceivedDate.ValueChanged += new System.EventHandler(this.dtpReceivedDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(541, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 31);
            this.label7.TabIndex = 55;
            this.label7.Text = "P.O Status";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPOStatus
            // 
            this.cmbPOStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPOStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPOStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPOStatus.FormattingEnabled = true;
            this.cmbPOStatus.Items.AddRange(new object[] {
            "-",
            "ONGOING",
            "FINISHED",
            "DELAYED",
            "1WEEK BEFORE DELIVERY",
            "CANCELLED"});
            this.cmbPOStatus.Location = new System.Drawing.Point(720, 14);
            this.cmbPOStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cmbPOStatus.Name = "cmbPOStatus";
            this.cmbPOStatus.Size = new System.Drawing.Size(351, 28);
            this.cmbPOStatus.TabIndex = 65;
            this.cmbPOStatus.SelectedIndexChanged += new System.EventHandler(this.cmbPOStatus_SelectedIndexChanged);
            this.cmbPOStatus.TextChanged += new System.EventHandler(this.cmbPOStatus_TextChanged);
            // 
            // chkBCanPo
            // 
            this.chkBCanPo.AutoSize = true;
            this.chkBCanPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBCanPo.Location = new System.Drawing.Point(4, 89);
            this.chkBCanPo.Name = "chkBCanPo";
            this.chkBCanPo.Size = new System.Drawing.Size(172, 27);
            this.chkBCanPo.TabIndex = 68;
            this.chkBCanPo.Text = "Select All";
            this.chkBCanPo.UseVisualStyleBackColor = true;
            this.chkBCanPo.CheckedChanged += new System.EventHandler(this.chkBCanPo_CheckedChanged);
            // 
            // btnBCancelPO
            // 
            this.btnBCancelPO.BackColor = System.Drawing.Color.Firebrick;
            this.btnBCancelPO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBCancelPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBCancelPO.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBCancelPO.Location = new System.Drawing.Point(1076, 87);
            this.btnBCancelPO.Margin = new System.Windows.Forms.Padding(1);
            this.btnBCancelPO.Name = "btnBCancelPO";
            this.btnBCancelPO.Size = new System.Drawing.Size(176, 31);
            this.btnBCancelPO.TabIndex = 69;
            this.btnBCancelPO.Text = "Cancel P.O";
            this.btnBCancelPO.UseVisualStyleBackColor = false;
            this.btnBCancelPO.Visible = false;
            this.btnBCancelPO.Click += new System.EventHandler(this.btnBCancelPO_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancelPO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgOrderList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 132);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1615, 633);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnCancelPO
            // 
            this.btnCancelPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnCancelPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPO.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPO.ForeColor = System.Drawing.Color.White;
            this.btnCancelPO.Location = new System.Drawing.Point(4, 590);
            this.btnCancelPO.Name = "btnCancelPO";
            this.btnCancelPO.Size = new System.Drawing.Size(1607, 39);
            this.btnCancelPO.TabIndex = 10;
            this.btnCancelPO.Text = "List of P.O Items subject to Re-Inspection";
            this.btnCancelPO.UseVisualStyleBackColor = false;
            this.btnCancelPO.Visible = false;
            this.btnCancelPO.Click += new System.EventHandler(this.btnCancelPO_Click);
            // 
            // dgOrderList
            // 
            this.dgOrderList.AllowUserToAddRows = false;
            this.dgOrderList.AllowUserToDeleteRows = false;
            this.dgOrderList.AllowUserToResizeColumns = false;
            this.dgOrderList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgOrderList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOrderList.AutoGenerateColumns = false;
            this.dgOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgOrderList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgOrderList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.noDataGridViewTextBoxColumn,
            this.pPONoDataGridViewTextBoxColumn,
            this.paperPONoDataGridViewTextBoxColumn,
            this.pODetailNoDataGridViewTextBoxColumn,
            this.inHouseNoDataGridViewTextBoxColumn,
            this.partNoDataGridViewTextBoxColumn,
            this.partNameDataGridViewTextBoxColumn,
            this.revDataGridViewTextBoxColumn,
            this.pODateDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.reqDateDataGridViewTextBoxColumn,
            this.pOQtyDataGridViewTextBoxColumn,
            this.itemUnitPriceDataGridViewTextBoxColumn,
            this.pOTotalAmountDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.pDSNoDataGridViewTextBoxColumn,
            this.lotNoDataGridViewTextBoxColumn,
            this.pOStatusDataGridViewTextBoxColumn});
            this.dgOrderList.DataSource = this.pODetailsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrderList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOrderList.Location = new System.Drawing.Point(11, 4);
            this.dgOrderList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.dgOrderList.Name = "dgOrderList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrderList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgOrderList.RowHeadersVisible = false;
            this.dgOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrderList.Size = new System.Drawing.Size(1593, 579);
            this.dgOrderList.TabIndex = 9;
            this.dgOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrderList_CellContentClick);
            this.dgOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrderList_CellDoubleClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "Select";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 60;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 60;
            // 
            // pPONoDataGridViewTextBoxColumn
            // 
            this.pPONoDataGridViewTextBoxColumn.DataPropertyName = "PPONo";
            this.pPONoDataGridViewTextBoxColumn.HeaderText = "SystemPONo";
            this.pPONoDataGridViewTextBoxColumn.Name = "pPONoDataGridViewTextBoxColumn";
            this.pPONoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pPONoDataGridViewTextBoxColumn.Width = 126;
            // 
            // paperPONoDataGridViewTextBoxColumn
            // 
            this.paperPONoDataGridViewTextBoxColumn.DataPropertyName = "PaperPONo";
            this.paperPONoDataGridViewTextBoxColumn.HeaderText = "PONo";
            this.paperPONoDataGridViewTextBoxColumn.Name = "paperPONoDataGridViewTextBoxColumn";
            this.paperPONoDataGridViewTextBoxColumn.ReadOnly = true;
            this.paperPONoDataGridViewTextBoxColumn.Width = 77;
            // 
            // pODetailNoDataGridViewTextBoxColumn
            // 
            this.pODetailNoDataGridViewTextBoxColumn.DataPropertyName = "PODetailNo";
            this.pODetailNoDataGridViewTextBoxColumn.HeaderText = "PODetailNo";
            this.pODetailNoDataGridViewTextBoxColumn.Name = "pODetailNoDataGridViewTextBoxColumn";
            this.pODetailNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pODetailNoDataGridViewTextBoxColumn.Width = 119;
            // 
            // inHouseNoDataGridViewTextBoxColumn
            // 
            this.inHouseNoDataGridViewTextBoxColumn.DataPropertyName = "InHouseNo";
            this.inHouseNoDataGridViewTextBoxColumn.HeaderText = "InHouseNo";
            this.inHouseNoDataGridViewTextBoxColumn.Name = "inHouseNoDataGridViewTextBoxColumn";
            this.inHouseNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.inHouseNoDataGridViewTextBoxColumn.Width = 114;
            // 
            // partNoDataGridViewTextBoxColumn
            // 
            this.partNoDataGridViewTextBoxColumn.DataPropertyName = "PartNo";
            this.partNoDataGridViewTextBoxColumn.HeaderText = "PartNo";
            this.partNoDataGridViewTextBoxColumn.Name = "partNoDataGridViewTextBoxColumn";
            this.partNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.partNoDataGridViewTextBoxColumn.Width = 84;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            this.partNameDataGridViewTextBoxColumn.HeaderText = "PartName";
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            this.partNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.partNameDataGridViewTextBoxColumn.Width = 107;
            // 
            // revDataGridViewTextBoxColumn
            // 
            this.revDataGridViewTextBoxColumn.DataPropertyName = "Rev";
            this.revDataGridViewTextBoxColumn.HeaderText = "Rev";
            this.revDataGridViewTextBoxColumn.Name = "revDataGridViewTextBoxColumn";
            this.revDataGridViewTextBoxColumn.ReadOnly = true;
            this.revDataGridViewTextBoxColumn.Width = 63;
            // 
            // pODateDataGridViewTextBoxColumn
            // 
            this.pODateDataGridViewTextBoxColumn.DataPropertyName = "PODate";
            this.pODateDataGridViewTextBoxColumn.HeaderText = "DateImport";
            this.pODateDataGridViewTextBoxColumn.Name = "pODateDataGridViewTextBoxColumn";
            this.pODateDataGridViewTextBoxColumn.ReadOnly = true;
            this.pODateDataGridViewTextBoxColumn.Width = 118;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderDateDataGridViewTextBoxColumn.Width = 113;
            // 
            // reqDateDataGridViewTextBoxColumn
            // 
            this.reqDateDataGridViewTextBoxColumn.DataPropertyName = "ReqDate";
            this.reqDateDataGridViewTextBoxColumn.HeaderText = "ReqDate";
            this.reqDateDataGridViewTextBoxColumn.Name = "reqDateDataGridViewTextBoxColumn";
            this.reqDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.reqDateDataGridViewTextBoxColumn.Width = 99;
            // 
            // pOQtyDataGridViewTextBoxColumn
            // 
            this.pOQtyDataGridViewTextBoxColumn.DataPropertyName = "POQty";
            this.pOQtyDataGridViewTextBoxColumn.HeaderText = "POQty";
            this.pOQtyDataGridViewTextBoxColumn.Name = "pOQtyDataGridViewTextBoxColumn";
            this.pOQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.pOQtyDataGridViewTextBoxColumn.Width = 82;
            // 
            // itemUnitPriceDataGridViewTextBoxColumn
            // 
            this.itemUnitPriceDataGridViewTextBoxColumn.DataPropertyName = "ItemUnitPrice";
            this.itemUnitPriceDataGridViewTextBoxColumn.HeaderText = "ItemUnitPrice";
            this.itemUnitPriceDataGridViewTextBoxColumn.Name = "itemUnitPriceDataGridViewTextBoxColumn";
            this.itemUnitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemUnitPriceDataGridViewTextBoxColumn.Width = 132;
            // 
            // pOTotalAmountDataGridViewTextBoxColumn
            // 
            this.pOTotalAmountDataGridViewTextBoxColumn.DataPropertyName = "POTotalAmount";
            this.pOTotalAmountDataGridViewTextBoxColumn.HeaderText = "POTotalAmount";
            this.pOTotalAmountDataGridViewTextBoxColumn.Name = "pOTotalAmountDataGridViewTextBoxColumn";
            this.pOTotalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.pOTotalAmountDataGridViewTextBoxColumn.Width = 146;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            this.currencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.currencyDataGridViewTextBoxColumn.Width = 102;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarksDataGridViewTextBoxColumn.Width = 95;
            // 
            // pDSNoDataGridViewTextBoxColumn
            // 
            this.pDSNoDataGridViewTextBoxColumn.DataPropertyName = "PDSNo";
            this.pDSNoDataGridViewTextBoxColumn.HeaderText = "PDSNo";
            this.pDSNoDataGridViewTextBoxColumn.Name = "pDSNoDataGridViewTextBoxColumn";
            this.pDSNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pDSNoDataGridViewTextBoxColumn.Visible = false;
            this.pDSNoDataGridViewTextBoxColumn.Width = 82;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNoDataGridViewTextBoxColumn.Visible = false;
            this.lotNoDataGridViewTextBoxColumn.Width = 77;
            // 
            // pOStatusDataGridViewTextBoxColumn
            // 
            this.pOStatusDataGridViewTextBoxColumn.DataPropertyName = "POStatus";
            this.pOStatusDataGridViewTextBoxColumn.HeaderText = "POStatus";
            this.pOStatusDataGridViewTextBoxColumn.Name = "pOStatusDataGridViewTextBoxColumn";
            this.pOStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.pOStatusDataGridViewTextBoxColumn.Visible = false;
            this.pOStatusDataGridViewTextBoxColumn.Width = 98;
            // 
            // pODetailsBindingSource
            // 
            this.pODetailsBindingSource.DataSource = typeof(OrderControlMgmt.Class.PODetails);
            // 
            // pODetailsBindingSource1
            // 
            this.pODetailsBindingSource1.DataSource = typeof(OrderControlMgmt.Class.PODetails);
            // 
            // frmOrderList_CRUD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1629, 820);
            this.Controls.Add(this.tl1);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderList_CRUD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.Load += new System.EventHandler(this.frmOrderList_CRUD_Load);
            this.tl1.ResumeLayout(false);
            this.tl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tl3.ResumeLayout(false);
            this.tl5.ResumeLayout(false);
            this.tl5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tl1;
        private System.Windows.Forms.TableLayoutPanel tl2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tl3;
        public System.Windows.Forms.DataGridView dgOrderList;
        private System.Windows.Forms.TableLayoutPanel tl5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource pODetailsBindingSource;
        private System.Windows.Forms.ComboBox cmbInHouseNo;
        private System.Windows.Forms.ComboBox cmbCustName;
        private System.Windows.Forms.ComboBox cmbPOStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource pODetailsBindingSource1;
        private System.Windows.Forms.Button btnCancelPO;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroDateTime dtpReceivedDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pODetailNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inHouseNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pODateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUnitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOTotalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDSNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkBCanPo;
        private System.Windows.Forms.Button btnBCancelPO;
    }
}

