namespace VB6leap.VbpExplorer
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("(Properties)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("References");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Modules");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Classes");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Forms");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Objects");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("(Project)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.trvProject = new System.Windows.Forms.TreeView();
            this.lsvProperties = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Location = new System.Drawing.Point(12, 12);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(116, 28);
            this.btnOpenProject.TabIndex = 0;
            this.btnOpenProject.Text = "&Open VBP...";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // trvProject
            // 
            this.trvProject.Location = new System.Drawing.Point(453, 44);
            this.trvProject.Name = "trvProject";
            treeNode1.Name = "PROPERTIES";
            treeNode1.Text = "(Properties)";
            treeNode2.Name = "REFERENCES";
            treeNode2.Text = "References";
            treeNode3.Name = "MODULES";
            treeNode3.Text = "Modules";
            treeNode4.Name = "CLASSES";
            treeNode4.Text = "Classes";
            treeNode5.Name = "FORMS";
            treeNode5.Text = "Forms";
            treeNode6.Name = "OBJECTS";
            treeNode6.Text = "Objects";
            treeNode7.Name = "ROOT";
            treeNode7.Text = "(Project)";
            this.trvProject.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.trvProject.Size = new System.Drawing.Size(292, 225);
            this.trvProject.TabIndex = 1;
            this.trvProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProject_AfterSelect);
            // 
            // lsvProperties
            // 
            this.lsvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvProperties.Location = new System.Drawing.Point(453, 275);
            this.lsvProperties.Name = "lsvProperties";
            this.lsvProperties.Size = new System.Drawing.Size(292, 281);
            this.lsvProperties.TabIndex = 2;
            this.lsvProperties.UseCompatibleStateImageBehavior = false;
            this.lsvProperties.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 89;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 252;
            // 
            // txtEdit
            // 
            this.txtEdit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdit.Location = new System.Drawing.Point(12, 88);
            this.txtEdit.Multiline = true;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEdit.Size = new System.Drawing.Size(435, 468);
            this.txtEdit.TabIndex = 3;
            this.txtEdit.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 568);
            this.Controls.Add(this.txtEdit);
            this.Controls.Add(this.lsvProperties);
            this.Controls.Add(this.trvProject);
            this.Controls.Add(this.btnOpenProject);
            this.Name = "MainForm";
            this.Text = "VBP-Explorer (proof-of-concept)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lsvProperties;

        #endregion

        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.TreeView trvProject;
        private System.Windows.Forms.TextBox txtEdit;
    }
}

