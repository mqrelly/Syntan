namespace Syntan.Demo
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
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HorizontalSplitter = new System.Windows.Forms.SplitContainer();
            this.TopSplitter = new System.Windows.Forms.SplitContainer();
            this.Main_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Grammar_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ParserStart_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.ParserStep_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.ParserFastforward_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.ParserStop_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Help_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.SyntacticTreeViewAutoTarget_CheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BottomSplitter = new System.Windows.Forms.SplitContainer();
            this.DfsmViewAutoTarget_CheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ParserTimer = new System.Windows.Forms.Timer(this.components);
            this.ParserView = new Syntan.Demo.ParserView();
            this.SyntacticTreeView = new Syntan.Demo.SyntcticTreeView();
            this.ParserTable = new Syntan.Demo.ParserTableView();
            this.DfsmView = new Syntan.Demo.DfsmView();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalSplitter)).BeginInit();
            this.HorizontalSplitter.Panel1.SuspendLayout();
            this.HorizontalSplitter.Panel2.SuspendLayout();
            this.HorizontalSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitter)).BeginInit();
            this.TopSplitter.Panel1.SuspendLayout();
            this.TopSplitter.Panel2.SuspendLayout();
            this.TopSplitter.SuspendLayout();
            this.Main_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplitter)).BeginInit();
            this.BottomSplitter.Panel1.SuspendLayout();
            this.BottomSplitter.Panel2.SuspendLayout();
            this.BottomSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // HorizontalSplitter
            // 
            this.HorizontalSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HorizontalSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.HorizontalSplitter.Location = new System.Drawing.Point(0, 0);
            this.HorizontalSplitter.Name = "HorizontalSplitter";
            this.HorizontalSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HorizontalSplitter.Panel1
            // 
            this.HorizontalSplitter.Panel1.Controls.Add(this.TopSplitter);
            this.HorizontalSplitter.Panel1MinSize = 274;
            // 
            // HorizontalSplitter.Panel2
            // 
            this.HorizontalSplitter.Panel2.Controls.Add(this.BottomSplitter);
            this.HorizontalSplitter.Size = new System.Drawing.Size(734, 403);
            this.HorizontalSplitter.SplitterDistance = 274;
            this.HorizontalSplitter.SplitterWidth = 6;
            this.HorizontalSplitter.TabIndex = 1;
            // 
            // TopSplitter
            // 
            this.TopSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.TopSplitter.Location = new System.Drawing.Point(0, 0);
            this.TopSplitter.Name = "TopSplitter";
            // 
            // TopSplitter.Panel1
            // 
            this.TopSplitter.Panel1.Controls.Add(this.ParserView);
            this.TopSplitter.Panel1.Controls.Add(this.Main_ToolStrip);
            this.TopSplitter.Panel1MinSize = 450;
            // 
            // TopSplitter.Panel2
            // 
            this.TopSplitter.Panel2.BackColor = System.Drawing.Color.White;
            this.TopSplitter.Panel2.Controls.Add(this.SyntacticTreeViewAutoTarget_CheckBox);
            this.TopSplitter.Panel2.Controls.Add(this.label2);
            this.TopSplitter.Panel2.Controls.Add(this.SyntacticTreeView);
            this.TopSplitter.Size = new System.Drawing.Size(734, 274);
            this.TopSplitter.SplitterDistance = 450;
            this.TopSplitter.SplitterWidth = 6;
            this.TopSplitter.TabIndex = 0;
            // 
            // Main_ToolStrip
            // 
            this.Main_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Main_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Grammar_ToolButton,
            this.toolStripSeparator1,
            this.ParserStart_ToolButton,
            this.ParserStep_ToolButton,
            this.ParserFastforward_ToolButton,
            this.ParserStop_ToolButton,
            this.toolStripSeparator2,
            this.Help_ToolButton});
            this.Main_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Main_ToolStrip.Name = "Main_ToolStrip";
            this.Main_ToolStrip.Size = new System.Drawing.Size(450, 25);
            this.Main_ToolStrip.TabIndex = 3;
            // 
            // Grammar_ToolButton
            // 
            this.Grammar_ToolButton.Image = global::Syntan.Demo.Properties.Resources.page_edit;
            this.Grammar_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Grammar_ToolButton.Name = "Grammar_ToolButton";
            this.Grammar_ToolButton.Size = new System.Drawing.Size(149, 22);
            this.Grammar_ToolButton.Text = "Nyelvtan &szerkesztése...";
            this.Grammar_ToolButton.Click += new System.EventHandler(this.Grammar_MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ParserStart_ToolButton
            // 
            this.ParserStart_ToolButton.Enabled = false;
            this.ParserStart_ToolButton.Image = ((System.Drawing.Image)(resources.GetObject("ParserStart_ToolButton.Image")));
            this.ParserStart_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParserStart_ToolButton.Name = "ParserStart_ToolButton";
            this.ParserStart_ToolButton.Size = new System.Drawing.Size(113, 22);
            this.ParserStart_ToolButton.Text = "Elemzés indítása";
            this.ParserStart_ToolButton.Click += new System.EventHandler(this.ParserStart_ToolButton_Click);
            // 
            // ParserStep_ToolButton
            // 
            this.ParserStep_ToolButton.Enabled = false;
            this.ParserStep_ToolButton.Image = global::Syntan.Demo.Properties.Resources.control_step;
            this.ParserStep_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParserStep_ToolButton.Name = "ParserStep_ToolButton";
            this.ParserStep_ToolButton.Size = new System.Drawing.Size(57, 22);
            this.ParserStep_ToolButton.Text = "Lépés";
            this.ParserStep_ToolButton.Click += new System.EventHandler(this.ParserStep_ToolButton_Click);
            // 
            // ParserFastforward_ToolButton
            // 
            this.ParserFastforward_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ParserFastforward_ToolButton.Enabled = false;
            this.ParserFastforward_ToolButton.Image = global::Syntan.Demo.Properties.Resources.control_fastforward;
            this.ParserFastforward_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParserFastforward_ToolButton.Name = "ParserFastforward_ToolButton";
            this.ParserFastforward_ToolButton.Size = new System.Drawing.Size(23, 22);
            this.ParserFastforward_ToolButton.Text = "Elemzés végigpörgetése";
            this.ParserFastforward_ToolButton.Click += new System.EventHandler(this.ParserFastforward_ToolButton_Click);
            // 
            // ParserStop_ToolButton
            // 
            this.ParserStop_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ParserStop_ToolButton.Enabled = false;
            this.ParserStop_ToolButton.Image = global::Syntan.Demo.Properties.Resources.control_stop;
            this.ParserStop_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ParserStop_ToolButton.Name = "ParserStop_ToolButton";
            this.ParserStop_ToolButton.Size = new System.Drawing.Size(23, 22);
            this.ParserStop_ToolButton.Text = "Elemzés leállítása";
            this.ParserStop_ToolButton.Click += new System.EventHandler(this.ParserStop_ToolButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Help_ToolButton
            // 
            this.Help_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Help_ToolButton.Image = global::Syntan.Demo.Properties.Resources.help;
            this.Help_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Help_ToolButton.Name = "Help_ToolButton";
            this.Help_ToolButton.Size = new System.Drawing.Size(23, 22);
            this.Help_ToolButton.Text = "Súgó";
            this.Help_ToolButton.Click += new System.EventHandler(this.Help_ToolButton_Click);
            // 
            // SyntacticTreeViewAutoTarget_CheckBox
            // 
            this.SyntacticTreeViewAutoTarget_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SyntacticTreeViewAutoTarget_CheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.SyntacticTreeViewAutoTarget_CheckBox.Checked = true;
            this.SyntacticTreeViewAutoTarget_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SyntacticTreeViewAutoTarget_CheckBox.Image = global::Syntan.Demo.Properties.Resources.eye;
            this.SyntacticTreeViewAutoTarget_CheckBox.Location = new System.Drawing.Point(254, 26);
            this.SyntacticTreeViewAutoTarget_CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.SyntacticTreeViewAutoTarget_CheckBox.Name = "SyntacticTreeViewAutoTarget_CheckBox";
            this.SyntacticTreeViewAutoTarget_CheckBox.Size = new System.Drawing.Size(24, 24);
            this.SyntacticTreeViewAutoTarget_CheckBox.TabIndex = 9;
            this.SyntacticTreeViewAutoTarget_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Szintaxis fa";
            // 
            // BottomSplitter
            // 
            this.BottomSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomSplitter.Location = new System.Drawing.Point(0, 0);
            this.BottomSplitter.Name = "BottomSplitter";
            // 
            // BottomSplitter.Panel1
            // 
            this.BottomSplitter.Panel1.Controls.Add(this.ParserTable);
            // 
            // BottomSplitter.Panel2
            // 
            this.BottomSplitter.Panel2.BackColor = System.Drawing.Color.White;
            this.BottomSplitter.Panel2.Controls.Add(this.DfsmViewAutoTarget_CheckBox);
            this.BottomSplitter.Panel2.Controls.Add(this.label1);
            this.BottomSplitter.Panel2.Controls.Add(this.DfsmView);
            this.BottomSplitter.Size = new System.Drawing.Size(734, 123);
            this.BottomSplitter.SplitterDistance = 349;
            this.BottomSplitter.SplitterWidth = 6;
            this.BottomSplitter.TabIndex = 0;
            // 
            // DfsmViewAutoTarget_CheckBox
            // 
            this.DfsmViewAutoTarget_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DfsmViewAutoTarget_CheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.DfsmViewAutoTarget_CheckBox.Checked = true;
            this.DfsmViewAutoTarget_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DfsmViewAutoTarget_CheckBox.Image = global::Syntan.Demo.Properties.Resources.eye;
            this.DfsmViewAutoTarget_CheckBox.Location = new System.Drawing.Point(355, 26);
            this.DfsmViewAutoTarget_CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.DfsmViewAutoTarget_CheckBox.Name = "DfsmViewAutoTarget_CheckBox";
            this.DfsmViewAutoTarget_CheckBox.Size = new System.Drawing.Size(24, 24);
            this.DfsmViewAutoTarget_CheckBox.TabIndex = 5;
            this.DfsmViewAutoTarget_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "VDA";
            // 
            // ParserTimer
            // 
            this.ParserTimer.Interval = 750;
            this.ParserTimer.Tick += new System.EventHandler(this.ParserStep_ToolButton_Click);
            // 
            // ParserView
            // 
            this.ParserView.BackColor = System.Drawing.Color.White;
            this.ParserView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParserView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParserView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ParserView.InputEditEnabled = true;
            this.ParserView.InputText = "";
            this.ParserView.Location = new System.Drawing.Point(0, 25);
            this.ParserView.MinimumSize = new System.Drawing.Size(450, 248);
            this.ParserView.Name = "ParserView";
            this.ParserView.Padding = new System.Windows.Forms.Padding(8);
            this.ParserView.Size = new System.Drawing.Size(450, 249);
            this.ParserView.TabIndex = 4;
            // 
            // SyntacticTreeView
            // 
            this.SyntacticTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SyntacticTreeView.EdgeColor = System.Drawing.Color.Silver;
            this.SyntacticTreeView.EdgeWidth = 3F;
            this.SyntacticTreeView.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.SyntacticTreeView.HorizontalSpace = 10;
            this.SyntacticTreeView.InternalNodeBackColor = System.Drawing.Color.WhiteSmoke;
            this.SyntacticTreeView.InternalNodeForeColor = System.Drawing.Color.Gray;
            this.SyntacticTreeView.LeafNodeBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.SyntacticTreeView.LeafNodeForeColor = System.Drawing.Color.Black;
            this.SyntacticTreeView.Location = new System.Drawing.Point(0, 0);
            this.SyntacticTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.SyntacticTreeView.Name = "SyntacticTreeView";
            this.SyntacticTreeView.Size = new System.Drawing.Size(278, 274);
            this.SyntacticTreeView.TabIndex = 8;
            this.SyntacticTreeView.TopLevelNodeBackColor = System.Drawing.Color.White;
            this.SyntacticTreeView.TopLevelNodeForeColor = System.Drawing.Color.Black;
            this.SyntacticTreeView.VerticalSpace = 20;
            // 
            // ParserTable
            // 
            this.ParserTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParserTable.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ParserTable.Location = new System.Drawing.Point(0, 0);
            this.ParserTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ParserTable.Name = "ParserTable";
            this.ParserTable.Size = new System.Drawing.Size(349, 123);
            this.ParserTable.TabIndex = 1;
            // 
            // DfsmView
            // 
            this.DfsmView.BackColor = System.Drawing.Color.White;
            this.DfsmView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DfsmView.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DfsmView.EdgeWidth = 5F;
            this.DfsmView.Font = new System.Drawing.Font("Arial", 11.25F);
            this.DfsmView.LabelColor = System.Drawing.Color.Black;
            this.DfsmView.Location = new System.Drawing.Point(0, 0);
            this.DfsmView.Margin = new System.Windows.Forms.Padding(4);
            this.DfsmView.Name = "DfsmView";
            this.DfsmView.NodeBackColor = System.Drawing.Color.White;
            this.DfsmView.Size = new System.Drawing.Size(379, 123);
            this.DfsmView.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 403);
            this.Controls.Add(this.HorizontalSplitter);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "MainForm";
            this.Text = "Syntan DEMO";
            this.HorizontalSplitter.Panel1.ResumeLayout(false);
            this.HorizontalSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalSplitter)).EndInit();
            this.HorizontalSplitter.ResumeLayout(false);
            this.TopSplitter.Panel1.ResumeLayout(false);
            this.TopSplitter.Panel1.PerformLayout();
            this.TopSplitter.Panel2.ResumeLayout(false);
            this.TopSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitter)).EndInit();
            this.TopSplitter.ResumeLayout(false);
            this.Main_ToolStrip.ResumeLayout(false);
            this.Main_ToolStrip.PerformLayout();
            this.BottomSplitter.Panel1.ResumeLayout(false);
            this.BottomSplitter.Panel2.ResumeLayout(false);
            this.BottomSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplitter)).EndInit();
            this.BottomSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer HorizontalSplitter;
        private System.Windows.Forms.SplitContainer TopSplitter;
        private System.Windows.Forms.SplitContainer BottomSplitter;
        private ParserTableView ParserTable;
        private System.Windows.Forms.CheckBox DfsmViewAutoTarget_CheckBox;
        private System.Windows.Forms.Label label1;
        private DfsmView DfsmView;
        private System.Windows.Forms.CheckBox SyntacticTreeViewAutoTarget_CheckBox;
        private System.Windows.Forms.Label label2;
        private SyntcticTreeView SyntacticTreeView;
        private System.Windows.Forms.ToolStrip Main_ToolStrip;
        private System.Windows.Forms.ToolStripButton Grammar_ToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ParserStart_ToolButton;
        private ParserView ParserView;
        private System.Windows.Forms.ToolStripButton ParserStep_ToolButton;
        private System.Windows.Forms.ToolStripButton ParserFastforward_ToolButton;
        private System.Windows.Forms.Timer ParserTimer;
        private System.Windows.Forms.ToolStripButton ParserStop_ToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Help_ToolButton;




    }
}

