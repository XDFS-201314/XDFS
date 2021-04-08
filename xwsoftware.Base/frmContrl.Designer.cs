namespace xwsoftware.Base
{
    partial class frmContrl
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FieldID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RankType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FieldShowName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DataFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorPickEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(2);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1274, 145);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 145);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(188, 480);
            this.panelControl1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(188, 145);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemColorEdit1,
            this.repositoryItemColorPickEdit1,
            this.repositoryItemColorPickEdit2,
            this.repositoryItemColorEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1086, 480);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FieldID,
            this.FieldName,
            this.RankType,
            this.FieldShowName,
            this.DataFormat,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // FieldID
            // 
            this.FieldID.Caption = "序号";
            this.FieldID.FieldName = "FieldID";
            this.FieldID.Name = "FieldID";
            this.FieldID.Visible = true;
            this.FieldID.VisibleIndex = 0;
            // 
            // FieldName
            // 
            this.FieldName.Caption = "栏位列名";
            this.FieldName.FieldName = "FieldName";
            this.FieldName.Name = "FieldName";
            this.FieldName.Visible = true;
            this.FieldName.VisibleIndex = 1;
            // 
            // RankType
            // 
            this.RankType.Caption = "类型";
            this.RankType.FieldName = "FieldType";
            this.RankType.Name = "RankType";
            this.RankType.Visible = true;
            this.RankType.VisibleIndex = 2;
            // 
            // FieldShowName
            // 
            this.FieldShowName.Caption = "栏位显示名";
            this.FieldShowName.FieldName = "FieldShowName";
            this.FieldShowName.Name = "FieldShowName";
            this.FieldShowName.Visible = true;
            this.FieldShowName.VisibleIndex = 3;
            // 
            // DataFormat
            // 
            this.DataFormat.Caption = "数据格式";
            this.DataFormat.FieldName = "DataFormat";
            this.DataFormat.Name = "DataFormat";
            this.DataFormat.Visible = true;
            this.DataFormat.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "是否隐藏";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit3;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "是否启用";
            this.gridColumn2.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "是否固定";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "是否可编辑";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEdit4;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "背景颜色1";
            this.gridColumn5.ColumnEdit = this.repositoryItemColorEdit1;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "前景颜色";
            this.gridColumn6.ColumnEdit = this.repositoryItemColorPickEdit2;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 10;
            // 
            // repositoryItemColorPickEdit2
            // 
            this.repositoryItemColorPickEdit2.AutoHeight = false;
            this.repositoryItemColorPickEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit2.Name = "repositoryItemColorPickEdit2";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "背景颜色2";
            this.gridColumn7.ColumnEdit = this.repositoryItemColorEdit2;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 11;
            // 
            // repositoryItemColorEdit2
            // 
            this.repositoryItemColorEdit2.AutoHeight = false;
            this.repositoryItemColorEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit2.Name = "repositoryItemColorEdit2";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // frmContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 625);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmContrl";
            this.Text = "frmContrl";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn FieldID;
        private DevExpress.XtraGrid.Columns.GridColumn FieldName;
        private DevExpress.XtraGrid.Columns.GridColumn RankType;
        private DevExpress.XtraGrid.Columns.GridColumn FieldShowName;
        private DevExpress.XtraGrid.Columns.GridColumn DataFormat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
    }
}