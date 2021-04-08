namespace xwsoftware.Base {
    partial class Notebook {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Appearance.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxControl1.Appearance.Options.UseFont = true;
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.listBoxControl1.MultiColumn = true;
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(31, 420);
            this.listBoxControl1.TabIndex = 0;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(31, 0);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Size = new System.Drawing.Size(932, 420);
            this.memoEdit1.TabIndex = 1;
            this.memoEdit1.EditValueChanged += new System.EventHandler(this.memoEdit1_EditValueChanged);
            // 
            // Notebook
            // 
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.listBoxControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Notebook";
            this.Size = new System.Drawing.Size(963, 420);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}
