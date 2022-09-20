namespace OrderControlMgmt
{
    partial class frmSalesRecordDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesRecordDetails));
            this.salesInvoiceDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tl2 = new System.Windows.Forms.TableLayoutPanel();
            this.tl1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSINoDetail = new System.Windows.Forms.Label();
            this.dgOrderList = new System.Windows.Forms.DataGridView();
            this.sINoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dRnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDSNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODetailNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inHouseNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUnitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliverydateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custNickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.salesInvoiceDetailsBindingSource)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tl2.SuspendLayout();
            this.tl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // salesInvoiceDetailsBindingSource
            // 
            this.salesInvoiceDetailsBindingSource.DataSource = typeof(OrderControlMgmt.Class.SalesInvoiceDetails);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1136, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "DETAILS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlMain.Size = new System.Drawing.Size(1136, 45);
            this.pnlMain.TabIndex = 1;
            // 
            // tl2
            // 
            this.tl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tl2.ColumnCount = 1;
            this.tl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.Controls.Add(this.pnlMain, 0, 0);
            this.tl2.Controls.Add(this.dgOrderList, 0, 1);
            this.tl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl2.Location = new System.Drawing.Point(0, 0);
            this.tl2.Margin = new System.Windows.Forms.Padding(0);
            this.tl2.Name = "tl2";
            this.tl2.RowCount = 2;
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl2.Size = new System.Drawing.Size(1136, 471);
            this.tl2.TabIndex = 1;
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
            this.tl1.Size = new System.Drawing.Size(1136, 471);
            this.tl1.TabIndex = 2;
            // 
            // lblSINoDetail
            // 
            this.lblSINoDetail.Location = new System.Drawing.Point(290, 0);
            this.lblSINoDetail.Name = "lblSINoDetail";
            this.lblSINoDetail.Size = new System.Drawing.Size(188, 30);
            this.lblSINoDetail.TabIndex = 15;
            this.lblSINoDetail.Text = "lblSINoDetail";
            this.lblSINoDetail.Visible = false;
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
            this.sINoDataGridViewTextBoxColumn,
            this.dRnoDataGridViewTextBoxColumn,
            this.sDSNoDataGridViewTextBoxColumn,
            this.pPONoDataGridViewTextBoxColumn,
            this.paperPONoDataGridViewTextBoxColumn,
            this.pODetailNoDataGridViewTextBoxColumn,
            this.inHouseNoDataGridViewTextBoxColumn,
            this.partNoDataGridViewTextBoxColumn,
            this.partNameDataGridViewTextBoxColumn,
            this.delQtyDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.itemUnitPriceDataGridViewTextBoxColumn,
            this.totalAmountDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn,
            this.deliverydateDataGridViewTextBoxColumn,
            this.custNickNameDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn});
            this.dgOrderList.DataSource = this.salesInvoiceDetailsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrderList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOrderList.Location = new System.Drawing.Point(3, 48);
            this.dgOrderList.Name = "dgOrderList";
            this.dgOrderList.ReadOnly = true;
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
            this.dgOrderList.Size = new System.Drawing.Size(1130, 420);
            this.dgOrderList.TabIndex = 14;
            // 
            // sINoDataGridViewTextBoxColumn
            // 
            this.sINoDataGridViewTextBoxColumn.DataPropertyName = "SINo";
            this.sINoDataGridViewTextBoxColumn.HeaderText = "SINo";
            this.sINoDataGridViewTextBoxColumn.Name = "sINoDataGridViewTextBoxColumn";
            this.sINoDataGridViewTextBoxColumn.ReadOnly = true;
            this.sINoDataGridViewTextBoxColumn.Width = 67;
            // 
            // dRnoDataGridViewTextBoxColumn
            // 
            this.dRnoDataGridViewTextBoxColumn.DataPropertyName = "DR_no";
            this.dRnoDataGridViewTextBoxColumn.HeaderText = "DR_no";
            this.dRnoDataGridViewTextBoxColumn.Name = "dRnoDataGridViewTextBoxColumn";
            this.dRnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dRnoDataGridViewTextBoxColumn.Width = 81;
            // 
            // sDSNoDataGridViewTextBoxColumn
            // 
            this.sDSNoDataGridViewTextBoxColumn.DataPropertyName = "SDSNo";
            this.sDSNoDataGridViewTextBoxColumn.HeaderText = "SDSNo";
            this.sDSNoDataGridViewTextBoxColumn.Name = "sDSNoDataGridViewTextBoxColumn";
            this.sDSNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.sDSNoDataGridViewTextBoxColumn.Width = 80;
            // 
            // pPONoDataGridViewTextBoxColumn
            // 
            this.pPONoDataGridViewTextBoxColumn.DataPropertyName = "PPONo";
            this.pPONoDataGridViewTextBoxColumn.HeaderText = "PPONo";
            this.pPONoDataGridViewTextBoxColumn.Name = "pPONoDataGridViewTextBoxColumn";
            this.pPONoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pPONoDataGridViewTextBoxColumn.Width = 86;
            // 
            // paperPONoDataGridViewTextBoxColumn
            // 
            this.paperPONoDataGridViewTextBoxColumn.DataPropertyName = "PaperPONo";
            this.paperPONoDataGridViewTextBoxColumn.HeaderText = "PaperPONo";
            this.paperPONoDataGridViewTextBoxColumn.Name = "paperPONoDataGridViewTextBoxColumn";
            this.paperPONoDataGridViewTextBoxColumn.ReadOnly = true;
            this.paperPONoDataGridViewTextBoxColumn.Width = 121;
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
            // delQtyDataGridViewTextBoxColumn
            // 
            this.delQtyDataGridViewTextBoxColumn.DataPropertyName = "DelQty";
            this.delQtyDataGridViewTextBoxColumn.HeaderText = "DelQty";
            this.delQtyDataGridViewTextBoxColumn.Name = "delQtyDataGridViewTextBoxColumn";
            this.delQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.delQtyDataGridViewTextBoxColumn.Width = 84;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "UOM";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.ReadOnly = true;
            this.uOMDataGridViewTextBoxColumn.Width = 73;
            // 
            // itemUnitPriceDataGridViewTextBoxColumn
            // 
            this.itemUnitPriceDataGridViewTextBoxColumn.DataPropertyName = "ItemUnitPrice";
            this.itemUnitPriceDataGridViewTextBoxColumn.HeaderText = "ItemUnitPrice";
            this.itemUnitPriceDataGridViewTextBoxColumn.Name = "itemUnitPriceDataGridViewTextBoxColumn";
            this.itemUnitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemUnitPriceDataGridViewTextBoxColumn.Width = 132;
            // 
            // totalAmountDataGridViewTextBoxColumn
            // 
            this.totalAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.HeaderText = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.Name = "totalAmountDataGridViewTextBoxColumn";
            this.totalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalAmountDataGridViewTextBoxColumn.Width = 124;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            this.currencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.currencyDataGridViewTextBoxColumn.Width = 102;
            // 
            // deliverydateDataGridViewTextBoxColumn
            // 
            this.deliverydateDataGridViewTextBoxColumn.DataPropertyName = "Delivery_date";
            this.deliverydateDataGridViewTextBoxColumn.HeaderText = "Delivery_date";
            this.deliverydateDataGridViewTextBoxColumn.Name = "deliverydateDataGridViewTextBoxColumn";
            this.deliverydateDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliverydateDataGridViewTextBoxColumn.Width = 137;
            // 
            // custNickNameDataGridViewTextBoxColumn
            // 
            this.custNickNameDataGridViewTextBoxColumn.DataPropertyName = "CustNickName";
            this.custNickNameDataGridViewTextBoxColumn.HeaderText = "CustNickName";
            this.custNickNameDataGridViewTextBoxColumn.Name = "custNickNameDataGridViewTextBoxColumn";
            this.custNickNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.custNickNameDataGridViewTextBoxColumn.Width = 142;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 132;
            // 
            // frmSalesRecordDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1136, 471);
            this.Controls.Add(this.tl1);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesRecordDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.Load += new System.EventHandler(this.frmSalesRecordDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesInvoiceDetailsBindingSource)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tl2.ResumeLayout(false);
            this.tl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource salesInvoiceDetailsBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tl2;
        private System.Windows.Forms.TableLayoutPanel tl1;
        public System.Windows.Forms.Label lblSINoDetail;
        public System.Windows.Forms.DataGridView dgOrderList;
        private System.Windows.Forms.DataGridViewTextBoxColumn sINoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dRnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDSNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pODetailNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inHouseNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUnitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliverydateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custNickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
    }
}