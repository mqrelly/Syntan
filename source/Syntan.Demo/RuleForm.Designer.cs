namespace Syntan.Demo
{
    partial class RuleForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RuleString_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lhs_ComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Rhs_TablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.Rhs_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Rhs_ToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.RhsAddItem_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.RhsRemoveItem_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.Rhs_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.RuleString_Label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Lhs_ComboBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Rhs_TablePanel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Rhs_ToolStrip, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(257, 295);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RuleString_Label
            // 
            this.RuleString_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RuleString_Label.AutoSize = true;
            this.RuleString_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RuleString_Label.Location = new System.Drawing.Point(8, 8);
            this.RuleString_Label.Margin = new System.Windows.Forms.Padding(0);
            this.RuleString_Label.Name = "RuleString_Label";
            this.RuleString_Label.Padding = new System.Windows.Forms.Padding(1);
            this.RuleString_Label.Size = new System.Drawing.Size(241, 18);
            this.RuleString_Label.TabIndex = 0;
            this.RuleString_Label.Text = "->";
            this.RuleString_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szabály bal oldala";
            // 
            // Lhs_ComboBox
            // 
            this.Lhs_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lhs_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Lhs_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Lhs_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Lhs_ComboBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Lhs_ComboBox.FormattingEnabled = true;
            this.Lhs_ComboBox.Location = new System.Drawing.Point(16, 47);
            this.Lhs_ComboBox.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Lhs_ComboBox.Name = "Lhs_ComboBox";
            this.Lhs_ComboBox.Size = new System.Drawing.Size(233, 27);
            this.Lhs_ComboBox.TabIndex = 2;
            this.Lhs_ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Symbol_ComboBox_DrawItem);
            this.Lhs_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Lhs_ComboBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.OK_Button);
            this.flowLayoutPanel2.Controls.Add(this.Cancel_Button);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(146, 260);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(103, 27);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // OK_Button
            // 
            this.OK_Button.AutoSize = true;
            this.OK_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OK_Button.Location = new System.Drawing.Point(6, 0);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OK_Button.Size = new System.Drawing.Size(37, 27);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "&OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.AutoSize = true;
            this.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(49, 0);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancel_Button.Size = new System.Drawing.Size(54, 27);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "&Mégse";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Rhs_TablePanel
            // 
            this.Rhs_TablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Rhs_TablePanel.AutoScroll = true;
            this.Rhs_TablePanel.BackColor = System.Drawing.SystemColors.Window;
            this.Rhs_TablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Rhs_TablePanel.ColumnCount = 1;
            this.Rhs_TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Rhs_TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Rhs_TablePanel.Location = new System.Drawing.Point(16, 99);
            this.Rhs_TablePanel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Rhs_TablePanel.Name = "Rhs_TablePanel";
            this.Rhs_TablePanel.RowCount = 1;
            this.Rhs_TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Rhs_TablePanel.Size = new System.Drawing.Size(233, 153);
            this.Rhs_TablePanel.TabIndex = 6;
            // 
            // Rhs_ToolStrip
            // 
            this.Rhs_ToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Rhs_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Rhs_ToolStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rhs_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Rhs_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rhs_ToolLabel,
            this.RhsAddItem_ToolButton,
            this.RhsRemoveItem_ToolButton});
            this.Rhs_ToolStrip.Location = new System.Drawing.Point(8, 74);
            this.Rhs_ToolStrip.Name = "Rhs_ToolStrip";
            this.Rhs_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Rhs_ToolStrip.Size = new System.Drawing.Size(241, 25);
            this.Rhs_ToolStrip.TabIndex = 7;
            // 
            // Rhs_ToolLabel
            // 
            this.Rhs_ToolLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rhs_ToolLabel.Name = "Rhs_ToolLabel";
            this.Rhs_ToolLabel.Size = new System.Drawing.Size(116, 22);
            this.Rhs_ToolLabel.Text = "Szabály jobb oldala";
            // 
            // RhsAddItem_ToolButton
            // 
            this.RhsAddItem_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RhsAddItem_ToolButton.Image = global::Syntan.Demo.Properties.Resources.add;
            this.RhsAddItem_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RhsAddItem_ToolButton.Name = "RhsAddItem_ToolButton";
            this.RhsAddItem_ToolButton.Size = new System.Drawing.Size(23, 22);
            this.RhsAddItem_ToolButton.Text = "Szimbólum hozzáadása a jobboldal végéhez";
            this.RhsAddItem_ToolButton.Click += new System.EventHandler(this.RhsAddItem_Button_Click);
            // 
            // RhsRemoveItem_ToolButton
            // 
            this.RhsRemoveItem_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RhsRemoveItem_ToolButton.Image = global::Syntan.Demo.Properties.Resources.delete;
            this.RhsRemoveItem_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RhsRemoveItem_ToolButton.Name = "RhsRemoveItem_ToolButton";
            this.RhsRemoveItem_ToolButton.Size = new System.Drawing.Size(23, 22);
            this.RhsRemoveItem_ToolButton.Text = "Kijelölt szimbólum törlése";
            this.RhsRemoveItem_ToolButton.Click += new System.EventHandler(this.RhsRemoveItem_ToolButton_Click);
            // 
            // RuleForm
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(257, 295);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Szabály";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.Rhs_ToolStrip.ResumeLayout(false);
            this.Rhs_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label RuleString_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Lhs_ComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TableLayoutPanel Rhs_TablePanel;
        private System.Windows.Forms.ToolStrip Rhs_ToolStrip;
        private System.Windows.Forms.ToolStripLabel Rhs_ToolLabel;
        private System.Windows.Forms.ToolStripButton RhsAddItem_ToolButton;
        private System.Windows.Forms.ToolStripButton RhsRemoveItem_ToolButton;
    }
}