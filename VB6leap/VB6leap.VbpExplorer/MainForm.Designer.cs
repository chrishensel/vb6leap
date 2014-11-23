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
            this.trvProject = new System.Windows.Forms.TreeView();
            this.lsvProperties = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpenProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveProject = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvProject
            // 
            this.trvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvProject.Location = new System.Drawing.Point(553, 3);
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
            this.trvProject.Size = new System.Drawing.Size(395, 307);
            this.trvProject.TabIndex = 1;
            this.trvProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProject_AfterSelect);
            // 
            // lsvProperties
            // 
            this.lsvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvProperties.FullRowSelect = true;
            this.lsvProperties.GridLines = true;
            this.lsvProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvProperties.Location = new System.Drawing.Point(553, 316);
            this.lsvProperties.Name = "lsvProperties";
            this.lsvProperties.Size = new System.Drawing.Size(395, 283);
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
            this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEdit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdit.Location = new System.Drawing.Point(3, 3);
            this.txtEdit.Multiline = true;
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.txtEdit, 2);
            this.txtEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEdit.Size = new System.Drawing.Size(544, 596);
            this.txtEdit.TabIndex = 3;
            this.txtEdit.WordWrap = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.93901F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.06099F));
            this.tableLayoutPanel1.Controls.Add(this.txtEdit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsvProperties, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.trvProject, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.11786F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.88214F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 602);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpenProject,
            this.toolStripSeparator1,
            this.tsbSaveProject});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(951, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpenProject
            // 
            this.tsbOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenProject.Name = "tsbOpenProject";
            this.tsbOpenProject.Size = new System.Drawing.Size(73, 22);
            this.tsbOpenProject.Text = "&Open VBP...";
            this.tsbOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(951, 602);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(951, 627);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSaveProject
            // 
            this.tsbSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveProject.Name = "tsbSaveProject";
            this.tsbSaveProject.Size = new System.Drawing.Size(68, 22);
            this.tsbSaveProject.Text = "&Save VBP...";
            this.tsbSaveProject.Click += new System.EventHandler(this.tsbSaveProject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 627);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "MainForm";
            this.Text = "VBP-Explorer (proof-of-concept)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lsvProperties;

        #endregion

        private System.Windows.Forms.TreeView trvProject;
        private System.Windows.Forms.TextBox txtEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpenProject;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSaveProject;
    }
}

