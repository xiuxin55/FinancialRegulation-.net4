namespace BaseManage
{
    partial class AssemblyInfoForm
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
            this.pnlAll = new System.Windows.Forms.Panel();
            this.treeAssembly = new System.Windows.Forms.TreeView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAll
            // 
            this.pnlAll.Controls.Add(this.treeAssembly);
            this.pnlAll.Controls.Add(this.pnlBottom);
            this.pnlAll.Controls.Add(this.pnlTop);
            this.pnlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAll.Location = new System.Drawing.Point(0, 0);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(415, 499);
            this.pnlAll.TabIndex = 0;
            // 
            // treeAssembly
            // 
            this.treeAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAssembly.Location = new System.Drawing.Point(0, 36);
            this.treeAssembly.Name = "treeAssembly";
            this.treeAssembly.Size = new System.Drawing.Size(415, 420);
            this.treeAssembly.TabIndex = 2;
            this.treeAssembly.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeAssembly_NodeMouseDoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 456);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(415, 43);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(415, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // AssemblyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 499);
            this.Controls.Add(this.pnlAll);
            this.Name = "AssemblyInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序集";
            this.Load += new System.EventHandler(this.AssemblyInfoForm_Load);
            this.pnlAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAll;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TreeView treeAssembly;
        private System.Windows.Forms.Panel pnlBottom;
    }
}