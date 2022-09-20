namespace OrderControlMgmt
{
    partial class frmItemsForReInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemsForReInspection));
            this.tl1 = new System.Windows.Forms.TableLayoutPanel();
            this.tl2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tl3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgPOReInspect = new System.Windows.Forms.DataGridView();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paperPONoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODetailNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inHouseNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custNickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reqDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUnitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOTotalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDSNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pODetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tl1.SuspendLayout();
            this.tl2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPOReInspect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource)).BeginInit();
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
            this.tl1.Size = new System.Drawing.Size(1334, 661);
            this.tl1.TabIndex = 2;
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
            this.tl2.Size = new System.Drawing.Size(1328, 655);
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
            this.pnlMain.Size = new System.Drawing.Size(1328, 45);
            this.pnlMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1328, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "P.O LIST SUBJECT TO RE-INSPECTION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tl3
            // 
            this.tl3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tl3.ColumnCount = 1;
            this.tl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl3.Controls.Add(this.dgPOReInspect, 0, 1);
            this.tl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl3.Location = new System.Drawing.Point(0, 45);
            this.tl3.Margin = new System.Windows.Forms.Padding(0);
            this.tl3.Name = "tl3";
            this.tl3.RowCount = 2;
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl3.Size = new System.Drawing.Size(1328, 610);
            this.tl3.TabIndex = 2;
            // 
            // dgPOReInspect
            // 
            this.dgPOReInspect.AllowUserToAddRows = false;
            this.dgPOReInspect.AllowUserToDeleteRows = false;
            this.dgPOReInspect.AllowUserToResizeColumns = false;
            this.dgPOReInspect.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgPOReInspect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPOReInspect.AutoGenerateColumns = false;
            this.dgPOReInspect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgPOReInspect.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgPOReInspect.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPOReInspect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPOReInspect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPOReInspect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.pPONoDataGridViewTextBoxColumn,
            this.paperPONoDataGridViewTextBoxColumn,
            this.pODetailNoDataGridViewTextBoxColumn,
            this.inHouseNoDataGridViewTextBoxColumn,
            this.partNoDataGridViewTextBoxColumn,
            this.partNameDataGridViewTextBoxColumn,
            this.revDataGridViewTextBoxColumn,
            this.custNickNameDataGridViewTextBoxColumn,
            this.pODateDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.reqDateDataGridViewTextBoxColumn,
            this.pOQtyDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.itemUnitPriceDataGridViewTextBoxColumn,
            this.pOTotalAmountDataGridViewTextBoxColumn,
            this.currencyDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.pDSNoDataGridViewTextBoxColumn,
            this.lotNoDataGridViewTextBoxColumn,
            this.pOStatusDataGridViewTextBoxColumn});
            this.dgPOReInspect.DataSource = this.pODetailsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPOReInspect.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPOReInspect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPOReInspect.Location = new System.Drawing.Point(4, 5);
            this.dgPOReInspect.Name = "dgPOReInspect";
            this.dgPOReInspect.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPOReInspect.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPOReInspect.RowHeadersVisible = false;
            this.dgPOReInspect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPOReInspect.Size = new System.Drawing.Size(1320, 601);
            this.dgPOReInspect.TabIndex = 13;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 55;
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
            // revDataGridViewTextBoxColumn
            // 
            this.revDataGridViewTextBoxColumn.DataPropertyName = "Rev";
            this.revDataGridViewTextBoxColumn.HeaderText = "Rev";
            this.revDataGridViewTextBoxColumn.Name = "revDataGridViewTextBoxColumn";
            this.revDataGridViewTextBoxColumn.ReadOnly = true;
            this.revDataGridViewTextBoxColumn.Width = 63;
            // 
            // custNickNameDataGridViewTextBoxColumn
            // 
            this.custNickNameDataGridViewTextBoxColumn.DataPropertyName = "CustNickName";
            this.custNickNameDataGridViewTextBoxColumn.HeaderText = "CustNickName";
            this.custNickNameDataGridViewTextBoxColumn.Name = "custNickNameDataGridViewTextBoxColumn";
            this.custNickNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.custNickNameDataGridViewTextBoxColumn.Width = 142;
            // 
            // pODateDataGridViewTextBoxColumn
            // 
            this.pODateDataGridViewTextBoxColumn.DataPropertyName = "PODate";
            this.pODateDataGridViewTextBoxColumn.HeaderText = "PODate";
            this.pODateDataGridViewTextBoxColumn.Name = "pODateDataGridViewTextBoxColumn";
            this.pODateDataGridViewTextBoxColumn.ReadOnly = true;
            this.pODateDataGridViewTextBoxColumn.Width = 92;
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
            this.pDSNoDataGridViewTextBoxColumn.Width = 82;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNoDataGridViewTextBoxColumn.Width = 77;
            // 
            // pOStatusDataGridViewTextBoxColumn
            // 
            this.pOStatusDataGridViewTextBoxColumn.DataPropertyName = "POStatus";
            this.pOStatusDataGridViewTextBoxColumn.HeaderText = "POStatus";
            this.pOStatusDataGridViewTextBoxColumn.Name = "pOStatusDataGridViewTextBoxColumn";
            this.pOStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.pOStatusDataGridViewTextBoxColumn.Width = 98;
            // 
            // pODetailsBindingSource
            // 
            this.pODetailsBindingSource.DataSource = typeof(OrderControlMgmt.Class.PODetails);
            // 
            // frmItemsForReInspection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1334, 661);
            this.Controls.Add(this.tl1);
            this.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemsForReInspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INAG SYSTEM";
            this.tl1.ResumeLayout(false);
            this.tl2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPOReInspect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pODetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource pODetailsBindingSource;
        private System.Windows.Forms.TableLayoutPanel tl1;
        private System.Windows.Forms.TableLayoutPanel tl2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tl3;
        private System.Windows.Forms.DataGridView dgPOReInspect;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paperPONoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pODetailNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inHouseNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn revDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custNickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pODateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reqDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUnitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOTotalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDSNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOStatusDataGridViewTextBoxColumn;
    }
}