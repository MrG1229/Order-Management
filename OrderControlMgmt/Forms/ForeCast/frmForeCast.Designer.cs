namespace OrderControlMgmt
{
    partial class frmForeCast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForeCast));
            this.tl1 = new System.Windows.Forms.TableLayoutPanel();
            this.tl2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tl3 = new System.Windows.Forms.TableLayoutPanel();
            this.tl8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPO = new System.Windows.Forms.Button();
            this.btnNewPO = new System.Windows.Forms.Button();
            this.tl7 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFCNo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPartNo = new MetroFramework.Controls.MetroComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRemarks = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUOM = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFCQty = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbInHouseNo = new System.Windows.Forms.ComboBox();
            this.forecastDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tl1.SuspendLayout();
            this.tl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tl3.SuspendLayout();
            this.tl8.SuspendLayout();
            this.tl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forecastDetailsBindingSource)).BeginInit();
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
            this.tl1.Size = new System.Drawing.Size(648, 470);
            this.tl1.TabIndex = 1;
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tl2.ColumnCount = 1;
            this.tl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.Controls.Add(this.pnlMain, 0, 0);
            this.tl2.Controls.Add(this.pnlContent, 0, 1);
            this.tl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl2.Location = new System.Drawing.Point(3, 3);
            this.tl2.Name = "tl2";
            this.tl2.RowCount = 2;
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl2.Size = new System.Drawing.Size(642, 464);
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
            this.pnlMain.Size = new System.Drawing.Size(642, 45);
            this.pnlMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(642, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "NEW FORECAST";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.tl3);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 45);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(642, 419);
            this.pnlContent.TabIndex = 2;
            // 
            // tl3
            // 
            this.tl3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl3.ColumnCount = 1;
            this.tl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl3.Controls.Add(this.tl8, 0, 1);
            this.tl3.Controls.Add(this.tl7, 0, 0);
            this.tl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl3.Location = new System.Drawing.Point(0, 0);
            this.tl3.Name = "tl3";
            this.tl3.RowCount = 2;
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tl3.Size = new System.Drawing.Size(642, 419);
            this.tl3.TabIndex = 4;
            // 
            // tl8
            // 
            this.tl8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl8.ColumnCount = 2;
            this.tl8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tl8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tl8.Controls.Add(this.btnAddPO, 0, 0);
            this.tl8.Controls.Add(this.btnNewPO, 0, 0);
            this.tl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl8.Location = new System.Drawing.Point(1, 355);
            this.tl8.Margin = new System.Windows.Forms.Padding(0);
            this.tl8.Name = "tl8";
            this.tl8.RowCount = 1;
            this.tl8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl8.Size = new System.Drawing.Size(640, 63);
            this.tl8.TabIndex = 7;
            // 
            // btnAddPO
            // 
            this.btnAddPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnAddPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnAddPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPO.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPO.ForeColor = System.Drawing.Color.White;
            this.btnAddPO.Location = new System.Drawing.Point(323, 4);
            this.btnAddPO.Name = "btnAddPO";
            this.btnAddPO.Size = new System.Drawing.Size(313, 55);
            this.btnAddPO.TabIndex = 7;
            this.btnAddPO.Text = "ADD FORECAST";
            this.btnAddPO.UseVisualStyleBackColor = false;
            this.btnAddPO.Click += new System.EventHandler(this.btnAddPO_Click);
            // 
            // btnNewPO
            // 
            this.btnNewPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnNewPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewPO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.btnNewPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPO.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPO.ForeColor = System.Drawing.Color.White;
            this.btnNewPO.Location = new System.Drawing.Point(4, 4);
            this.btnNewPO.Name = "btnNewPO";
            this.btnNewPO.Size = new System.Drawing.Size(312, 55);
            this.btnNewPO.TabIndex = 5;
            this.btnNewPO.Text = "CLEAR ";
            this.btnNewPO.UseVisualStyleBackColor = false;
            this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
            // 
            // tl7
            // 
            this.tl7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl7.ColumnCount = 2;
            this.tl7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tl7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tl7.Controls.Add(this.txtFCNo, 1, 0);
            this.tl7.Controls.Add(this.label2, 0, 0);
            this.tl7.Controls.Add(this.label5, 0, 3);
            this.tl7.Controls.Add(this.label4, 0, 2);
            this.tl7.Controls.Add(this.txtPartName, 1, 3);
            this.tl7.Controls.Add(this.label3, 0, 1);
            this.tl7.Controls.Add(this.cmbPartNo, 1, 1);
            this.tl7.Controls.Add(this.lblID, 1, 8);
            this.tl7.Controls.Add(this.label18, 0, 7);
            this.tl7.Controls.Add(this.txtRemarks, 1, 7);
            this.tl7.Controls.Add(this.label11, 0, 6);
            this.tl7.Controls.Add(this.txtUOM, 1, 6);
            this.tl7.Controls.Add(this.label10, 0, 5);
            this.tl7.Controls.Add(this.txtFCQty, 1, 5);
            this.tl7.Controls.Add(this.label6, 0, 4);
            this.tl7.Controls.Add(this.dtpDate, 1, 4);
            this.tl7.Controls.Add(this.cmbInHouseNo, 1, 2);
            this.tl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl7.Location = new System.Drawing.Point(1, 1);
            this.tl7.Margin = new System.Windows.Forms.Padding(0);
            this.tl7.Name = "tl7";
            this.tl7.RowCount = 9;
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tl7.Size = new System.Drawing.Size(640, 353);
            this.tl7.TabIndex = 2;
            // 
            // txtFCNo
            // 
            this.txtFCNo.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtFCNo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFCNo.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtFCNo.BorderThickness = 1;
            this.txtFCNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFCNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFCNo.Enabled = false;
            this.txtFCNo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFCNo.ForeColor = System.Drawing.Color.Black;
            this.txtFCNo.isPassword = false;
            this.txtFCNo.Location = new System.Drawing.Point(156, 5);
            this.txtFCNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFCNo.Name = "txtFCNo";
            this.txtFCNo.Size = new System.Drawing.Size(479, 30);
            this.txtFCNo.TabIndex = 1;
            this.txtFCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Forecast No.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Part Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "In-House No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartName
            // 
            this.txtPartName.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtPartName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPartName.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtPartName.BorderThickness = 1;
            this.txtPartName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartName.Enabled = false;
            this.txtPartName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPartName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPartName.isPassword = false;
            this.txtPartName.Location = new System.Drawing.Point(156, 122);
            this.txtPartName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(479, 30);
            this.txtPartName.TabIndex = 24;
            this.txtPartName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Part No.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.ItemHeight = 23;
            this.cmbPartNo.Location = new System.Drawing.Point(155, 47);
            this.cmbPartNo.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(481, 29);
            this.cmbPartNo.TabIndex = 41;
            this.cmbPartNo.UseSelectable = true;
            this.cmbPartNo.SelectedIndexChanged += new System.EventHandler(this.cmbPartNo_SelectedIndexChanged);
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(155, 313);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(319, 32);
            this.lblID.TabIndex = 47;
            this.lblID.Text = "label6";
            this.lblID.Visible = false;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 277);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 32);
            this.label18.TabIndex = 21;
            this.label18.Text = "Remarks";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtRemarks.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemarks.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtRemarks.BorderThickness = 1;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemarks.isPassword = false;
            this.txtRemarks.Location = new System.Drawing.Point(156, 278);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(479, 30);
            this.txtRemarks.TabIndex = 37;
            this.txtRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 238);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 32);
            this.label11.TabIndex = 14;
            this.label11.Text = "UOM";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUOM
            // 
            this.txtUOM.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtUOM.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUOM.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtUOM.BorderThickness = 1;
            this.txtUOM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUOM.Enabled = false;
            this.txtUOM.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUOM.isPassword = false;
            this.txtUOM.Location = new System.Drawing.Point(156, 239);
            this.txtUOM.Margin = new System.Windows.Forms.Padding(4);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(479, 30);
            this.txtUOM.TabIndex = 46;
            this.txtUOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 199);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 32);
            this.label10.TabIndex = 13;
            this.label10.Text = "Qty";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFCQty
            // 
            this.txtFCQty.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtFCQty.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFCQty.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtFCQty.BorderThickness = 1;
            this.txtFCQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFCQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFCQty.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFCQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFCQty.isPassword = false;
            this.txtFCQty.Location = new System.Drawing.Point(156, 200);
            this.txtFCQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtFCQty.Name = "txtFCQty";
            this.txtFCQty.Size = new System.Drawing.Size(479, 30);
            this.txtFCQty.TabIndex = 29;
            this.txtFCQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFCQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFCQty_KeyPress);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 32);
            this.label6.TabIndex = 48;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(155, 160);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(481, 31);
            this.dtpDate.TabIndex = 49;
            // 
            // cmbInHouseNo
            // 
            this.cmbInHouseNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbInHouseNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInHouseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInHouseNo.FormattingEnabled = true;
            this.cmbInHouseNo.Location = new System.Drawing.Point(155, 82);
            this.cmbInHouseNo.Name = "cmbInHouseNo";
            this.cmbInHouseNo.Size = new System.Drawing.Size(481, 28);
            this.cmbInHouseNo.TabIndex = 50;
            this.cmbInHouseNo.SelectedIndexChanged += new System.EventHandler(this.cmbInHouseNo_SelectedIndexChanged);
            this.cmbInHouseNo.TextChanged += new System.EventHandler(this.cmbInHouseNo_TextChanged);
            // 
            // forecastDetailsBindingSource
            // 
            this.forecastDetailsBindingSource.DataSource = typeof(OrderControlMgmt.Class.ForecastDetails);
            // 
            // frmForeCast
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(648, 470);
            this.Controls.Add(this.tl1);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmForeCast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.Load += new System.EventHandler(this.frmForeCast_Load);
            this.tl1.ResumeLayout(false);
            this.tl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tl3.ResumeLayout(false);
            this.tl8.ResumeLayout(false);
            this.tl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.forecastDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tl1;
        private System.Windows.Forms.TableLayoutPanel tl2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tl3;
        private System.Windows.Forms.TableLayoutPanel tl7;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtRemarks;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtFCQty;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPartName;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtFCNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        public MetroFramework.Controls.MetroComboBox cmbPartNo;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtUOM;
        private System.Windows.Forms.BindingSource forecastDetailsBindingSource;
        public System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TableLayoutPanel tl8;
        private System.Windows.Forms.Button btnAddPO;
        private System.Windows.Forms.Button btnNewPO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbInHouseNo;
    }
}

