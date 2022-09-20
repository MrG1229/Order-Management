namespace OrderControlMgmt.Forms.PEZA
{
    partial class frmCreateBoatNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateBoatNote));
            this.tl2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBNnoItem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBNKindPack = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBNNumOfPack = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBNCtrlNo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBNRem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBN06RefNo = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBNContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBNMeasure = new System.Windows.Forms.ComboBox();
            this.dtpBNDCre = new MetroFramework.Controls.MetroDateTime();
            this.cmbBNCust = new System.Windows.Forms.ComboBox();
            this.cmbBNInCPer = new System.Windows.Forms.ComboBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblSINoDetail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBNCreate = new System.Windows.Forms.Button();
            this.tl2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tl2.ColumnCount = 1;
            this.tl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tl2.Controls.Add(this.pnlMain, 0, 0);
            this.tl2.Controls.Add(this.btnBNCreate, 0, 2);
            this.tl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl2.Location = new System.Drawing.Point(0, 0);
            this.tl2.Margin = new System.Windows.Forms.Padding(0);
            this.tl2.Name = "tl2";
            this.tl2.RowCount = 3;
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.90672F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.093279F));
            this.tl2.Size = new System.Drawing.Size(839, 744);
            this.tl2.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.91827F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.08173F));
            this.tableLayoutPanel5.Controls.Add(this.txtBNnoItem, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.txtBNKindPack, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.txtBNNumOfPack, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtBNCtrlNo, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 9);
            this.tableLayoutPanel5.Controls.Add(this.label12, 0, 10);
            this.tableLayoutPanel5.Controls.Add(this.label13, 0, 11);
            this.tableLayoutPanel5.Controls.Add(this.txtBNRem, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.txtBN06RefNo, 1, 9);
            this.tableLayoutPanel5.Controls.Add(this.txtBNContent, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cmbBNMeasure, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.dtpBNDCre, 1, 11);
            this.tableLayoutPanel5.Controls.Add(this.cmbBNCust, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.cmbBNInCPer, 1, 10);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 15;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(833, 636);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // txtBNnoItem
            // 
            this.txtBNnoItem.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBNnoItem.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBNnoItem.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBNnoItem.BorderThickness = 1;
            this.txtBNnoItem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBNnoItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNnoItem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBNnoItem.ForeColor = System.Drawing.Color.Black;
            this.txtBNnoItem.isPassword = false;
            this.txtBNnoItem.Location = new System.Drawing.Point(204, 400);
            this.txtBNnoItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNnoItem.Name = "txtBNnoItem";
            this.txtBNnoItem.Size = new System.Drawing.Size(624, 30);
            this.txtBNnoItem.TabIndex = 64;
            this.txtBNnoItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBNnoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNnoItem_KeyPress);
            // 
            // txtBNKindPack
            // 
            this.txtBNKindPack.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBNKindPack.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBNKindPack.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBNKindPack.BorderThickness = 1;
            this.txtBNKindPack.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBNKindPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNKindPack.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBNKindPack.ForeColor = System.Drawing.Color.Black;
            this.txtBNKindPack.isPassword = false;
            this.txtBNKindPack.Location = new System.Drawing.Point(204, 115);
            this.txtBNKindPack.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNKindPack.Name = "txtBNKindPack";
            this.txtBNKindPack.Size = new System.Drawing.Size(624, 30);
            this.txtBNKindPack.TabIndex = 62;
            this.txtBNKindPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtBNNumOfPack
            // 
            this.txtBNNumOfPack.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBNNumOfPack.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBNNumOfPack.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBNNumOfPack.BorderThickness = 1;
            this.txtBNNumOfPack.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBNNumOfPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNNumOfPack.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBNNumOfPack.ForeColor = System.Drawing.Color.Black;
            this.txtBNNumOfPack.isPassword = false;
            this.txtBNNumOfPack.Location = new System.Drawing.Point(204, 76);
            this.txtBNNumOfPack.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNNumOfPack.Name = "txtBNNumOfPack";
            this.txtBNNumOfPack.Size = new System.Drawing.Size(624, 30);
            this.txtBNNumOfPack.TabIndex = 61;
            this.txtBNNumOfPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBNNumOfPack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNNumOfPack_KeyPress);
            // 
            // txtBNCtrlNo
            // 
            this.txtBNCtrlNo.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBNCtrlNo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBNCtrlNo.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBNCtrlNo.BorderThickness = 1;
            this.txtBNCtrlNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBNCtrlNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNCtrlNo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBNCtrlNo.ForeColor = System.Drawing.Color.Black;
            this.txtBNCtrlNo.isPassword = false;
            this.txtBNCtrlNo.Location = new System.Drawing.Point(204, 5);
            this.txtBNCtrlNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNCtrlNo.Name = "txtBNCtrlNo";
            this.txtBNCtrlNo.Size = new System.Drawing.Size(624, 30);
            this.txtBNCtrlNo.TabIndex = 58;
            this.txtBNCtrlNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBNCtrlNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBNCtrlNo_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "CONTROL NO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "NUMBER OF PACKAGES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "KIND OF PACKAGES";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 239);
            this.label6.TabIndex = 4;
            this.label6.Text = "CONTENTS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 399);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "NO. ITEMS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 438);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 32);
            this.label8.TabIndex = 6;
            this.label8.Text = "MEASUREMENT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 477);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 32);
            this.label9.TabIndex = 7;
            this.label9.Text = "REMARKS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 517);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 32);
            this.label11.TabIndex = 9;
            this.label11.Text = "8106 NO REFERENCE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 556);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 34);
            this.label12.TabIndex = 10;
            this.label12.Text = "IN-CHARGE PERSONNEL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 597);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 32);
            this.label13.TabIndex = 11;
            this.label13.Text = "DATE CREATED";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBNRem
            // 
            this.txtBNRem.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBNRem.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBNRem.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBNRem.BorderThickness = 1;
            this.txtBNRem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBNRem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNRem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBNRem.ForeColor = System.Drawing.Color.Black;
            this.txtBNRem.isPassword = false;
            this.txtBNRem.Location = new System.Drawing.Point(204, 478);
            this.txtBNRem.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNRem.Name = "txtBNRem";
            this.txtBNRem.Size = new System.Drawing.Size(624, 30);
            this.txtBNRem.TabIndex = 65;
            this.txtBNRem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtBN06RefNo
            // 
            this.txtBN06RefNo.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBN06RefNo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBN06RefNo.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBN06RefNo.BorderThickness = 1;
            this.txtBN06RefNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBN06RefNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBN06RefNo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtBN06RefNo.ForeColor = System.Drawing.Color.Black;
            this.txtBN06RefNo.isPassword = false;
            this.txtBN06RefNo.Location = new System.Drawing.Point(204, 518);
            this.txtBN06RefNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBN06RefNo.Name = "txtBN06RefNo";
            this.txtBN06RefNo.Size = new System.Drawing.Size(624, 30);
            this.txtBN06RefNo.TabIndex = 69;
            this.txtBN06RefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBN06RefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBN06RefNo_KeyPress);
            // 
            // txtBNContent
            // 
            this.txtBNContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.txtBNContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBNContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNContent.Font = new System.Drawing.Font("Century Gothic", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBNContent.Location = new System.Drawing.Point(204, 154);
            this.txtBNContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtBNContent.Multiline = true;
            this.txtBNContent.Name = "txtBNContent";
            this.txtBNContent.Size = new System.Drawing.Size(624, 237);
            this.txtBNContent.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 31);
            this.label3.TabIndex = 74;
            this.label3.Text = "CUSTOMER";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBNMeasure
            // 
            this.cmbBNMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBNMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBNMeasure.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBNMeasure.FormattingEnabled = true;
            this.cmbBNMeasure.Items.AddRange(new object[] {
            "-",
            "SET/S",
            "DRUM/S",
            "KG/S",
            "PC/S"});
            this.cmbBNMeasure.Location = new System.Drawing.Point(203, 438);
            this.cmbBNMeasure.Name = "cmbBNMeasure";
            this.cmbBNMeasure.Size = new System.Drawing.Size(626, 25);
            this.cmbBNMeasure.TabIndex = 66;
            // 
            // dtpBNDCre
            // 
            this.dtpBNDCre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpBNDCre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBNDCre.Location = new System.Drawing.Point(203, 597);
            this.dtpBNDCre.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpBNDCre.Name = "dtpBNDCre";
            this.dtpBNDCre.Size = new System.Drawing.Size(626, 29);
            this.dtpBNDCre.TabIndex = 70;
            // 
            // cmbBNCust
            // 
            this.cmbBNCust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBNCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBNCust.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBNCust.FormattingEnabled = true;
            this.cmbBNCust.Location = new System.Drawing.Point(203, 43);
            this.cmbBNCust.Name = "cmbBNCust";
            this.cmbBNCust.Size = new System.Drawing.Size(626, 25);
            this.cmbBNCust.TabIndex = 78;
            // 
            // cmbBNInCPer
            // 
            this.cmbBNInCPer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBNInCPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBNInCPer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBNInCPer.FormattingEnabled = true;
            this.cmbBNInCPer.Location = new System.Drawing.Point(203, 556);
            this.cmbBNInCPer.Name = "cmbBNInCPer";
            this.cmbBNInCPer.Size = new System.Drawing.Size(626, 25);
            this.cmbBNInCPer.TabIndex = 79;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.pnlMain.Controls.Add(this.lblSINoDetail);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(839, 45);
            this.pnlMain.TabIndex = 1;
            // 
            // lblSINoDetail
            // 
            this.lblSINoDetail.Location = new System.Drawing.Point(-3, 15);
            this.lblSINoDetail.Name = "lblSINoDetail";
            this.lblSINoDetail.Size = new System.Drawing.Size(188, 30);
            this.lblSINoDetail.TabIndex = 15;
            this.lblSINoDetail.Text = "lblSINoDetail";
            this.lblSINoDetail.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(839, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "BOAT NOTE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBNCreate
            // 
            this.btnBNCreate.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBNCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBNCreate.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnBNCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBNCreate.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBNCreate.ForeColor = System.Drawing.Color.White;
            this.btnBNCreate.Location = new System.Drawing.Point(3, 690);
            this.btnBNCreate.Name = "btnBNCreate";
            this.btnBNCreate.Size = new System.Drawing.Size(833, 51);
            this.btnBNCreate.TabIndex = 3;
            this.btnBNCreate.Text = "CREATE";
            this.btnBNCreate.UseVisualStyleBackColor = false;
            this.btnBNCreate.Click += new System.EventHandler(this.btnBNCreate_Click);
            // 
            // frmCreateBoatNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 744);
            this.Controls.Add(this.tl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreateBoatNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateBoatNote_FormClosing);
            this.tl2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MetroFramework.Controls.MetroDateTime dtpBNDCre;
        private System.Windows.Forms.ComboBox cmbBNMeasure;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBNnoItem;
        public Bunifu.Framework.UI.BunifuMetroTextbox txtBNKindPack;
        public Bunifu.Framework.UI.BunifuMetroTextbox txtBNNumOfPack;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBNCtrlNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBNRem;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBN06RefNo;
        private System.Windows.Forms.TextBox txtBNContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.Label lblSINoDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBNCreate;
        private System.Windows.Forms.ComboBox cmbBNCust;
        private System.Windows.Forms.ComboBox cmbBNInCPer;
    }
}