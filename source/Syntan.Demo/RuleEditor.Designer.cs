namespace Syntan.Demo
{
    partial class RuleEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RightHandSide_ComboBox = new System.Windows.Forms.ComboBox();
            this.LeftHandSide_ComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RightHandSide_ComboBox
            // 
            this.RightHandSide_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RightHandSide_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.RightHandSide_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RightHandSide_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightHandSide_ComboBox.FormattingEnabled = true;
            this.RightHandSide_ComboBox.Location = new System.Drawing.Point(84, 0);
            this.RightHandSide_ComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.RightHandSide_ComboBox.Name = "RightHandSide_ComboBox";
            this.RightHandSide_ComboBox.Size = new System.Drawing.Size(87, 21);
            this.RightHandSide_ComboBox.TabIndex = 1;
            // 
            // LeftHandSide_ComboBox
            // 
            this.LeftHandSide_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LeftHandSide_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LeftHandSide_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LeftHandSide_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftHandSide_ComboBox.FormattingEnabled = true;
            this.LeftHandSide_ComboBox.Location = new System.Drawing.Point(0, 0);
            this.LeftHandSide_ComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.LeftHandSide_ComboBox.Name = "LeftHandSide_ComboBox";
            this.LeftHandSide_ComboBox.Size = new System.Drawing.Size(62, 21);
            this.LeftHandSide_ComboBox.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.LeftHandSide_ComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.RightHandSide_ComboBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 24);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "->";
            // 
            // RuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(0, 20);
            this.Name = "RuleEditor";
            this.Size = new System.Drawing.Size(306, 24);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox RightHandSide_ComboBox;
        private System.Windows.Forms.ComboBox LeftHandSide_ComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;

    }
}
