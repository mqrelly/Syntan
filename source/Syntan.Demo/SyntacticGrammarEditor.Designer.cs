namespace Syntan.Demo
{
    partial class SyntacticGrammarEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyntacticGrammarEditor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartSymbol_Label = new System.Windows.Forms.Label();
            this.Rules_TooLStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.AddRule_Button = new System.Windows.Forms.ToolStripButton();
            this.EditRule_Button = new System.Windows.Forms.ToolStripButton();
            this.DeleteRules_Button = new System.Windows.Forms.ToolStripButton();
            this.Rules_ListBox = new System.Windows.Forms.ListBox();
            this.Grammaticals_Label = new System.Windows.Forms.Label();
            this.Grammaticals_TextBox = new System.Windows.Forms.TextBox();
            this.Terminals_Label = new System.Windows.Forms.Label();
            this.Terminals_TextBox = new System.Windows.Forms.TextBox();
            this.StartSymbol_ComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.Rules_TooLStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.StartSymbol_Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Rules_TooLStrip, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Rules_ListBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Grammaticals_Label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Grammaticals_TextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Terminals_Label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Terminals_TextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.StartSymbol_ComboBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 213);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StartSymbol_Label
            // 
            this.StartSymbol_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartSymbol_Label.AutoSize = true;
            this.StartSymbol_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.StartSymbol_Label.Location = new System.Drawing.Point(0, 39);
            this.StartSymbol_Label.Margin = new System.Windows.Forms.Padding(0);
            this.StartSymbol_Label.Name = "StartSymbol_Label";
            this.StartSymbol_Label.Size = new System.Drawing.Size(105, 13);
            this.StartSymbol_Label.TabIndex = 2;
            this.StartSymbol_Label.Text = "Kezdő szimbólum";
            // 
            // Rules_TooLStrip
            // 
            this.Rules_TooLStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Rules_TooLStrip, 2);
            this.Rules_TooLStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Rules_TooLStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Rules_TooLStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.AddRule_Button,
            this.EditRule_Button,
            this.DeleteRules_Button});
            this.Rules_TooLStrip.Location = new System.Drawing.Point(0, 92);
            this.Rules_TooLStrip.Name = "Rules_TooLStrip";
            this.Rules_TooLStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Rules_TooLStrip.Size = new System.Drawing.Size(323, 25);
            this.Rules_TooLStrip.TabIndex = 6;
            this.Rules_TooLStrip.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel1.Text = "Szabályok";
            // 
            // AddRule_Button
            // 
            this.AddRule_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddRule_Button.Image = ((System.Drawing.Image)(resources.GetObject("AddRule_Button.Image")));
            this.AddRule_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddRule_Button.Name = "AddRule_Button";
            this.AddRule_Button.Size = new System.Drawing.Size(23, 22);
            this.AddRule_Button.Text = "Új szabály hozzáadása";
            this.AddRule_Button.Click += new System.EventHandler(this.AddRule_Button_Click);
            // 
            // EditRule_Button
            // 
            this.EditRule_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditRule_Button.Image = ((System.Drawing.Image)(resources.GetObject("EditRule_Button.Image")));
            this.EditRule_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditRule_Button.Name = "EditRule_Button";
            this.EditRule_Button.Size = new System.Drawing.Size(23, 22);
            this.EditRule_Button.Text = "Kiválasztott szabály szerkesztése";
            this.EditRule_Button.Click += new System.EventHandler(this.EditRule_Button_Click);
            // 
            // DeleteRules_Button
            // 
            this.DeleteRules_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteRules_Button.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRules_Button.Image")));
            this.DeleteRules_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteRules_Button.Name = "DeleteRules_Button";
            this.DeleteRules_Button.Size = new System.Drawing.Size(23, 22);
            this.DeleteRules_Button.Text = "Kiválasztott szabály(ok) törlése";
            this.DeleteRules_Button.Click += new System.EventHandler(this.DeleteRules_Button_Click);
            // 
            // Rules_ListBox
            // 
            this.Rules_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.Rules_ListBox, 2);
            this.Rules_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Rules_ListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rules_ListBox.FormattingEnabled = true;
            this.Rules_ListBox.IntegralHeight = false;
            this.Rules_ListBox.ItemHeight = 18;
            this.Rules_ListBox.Location = new System.Drawing.Point(3, 120);
            this.Rules_ListBox.Name = "Rules_ListBox";
            this.Rules_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Rules_ListBox.Size = new System.Drawing.Size(317, 90);
            this.Rules_ListBox.TabIndex = 7;
            this.Rules_ListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Rules_ListBox_DrawItem);
            this.Rules_ListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rules_ListBox_KeyDown);
            // 
            // Grammaticals_Label
            // 
            this.Grammaticals_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Grammaticals_Label.AutoSize = true;
            this.Grammaticals_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Grammaticals_Label.Location = new System.Drawing.Point(0, 9);
            this.Grammaticals_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Grammaticals_Label.Name = "Grammaticals_Label";
            this.Grammaticals_Label.Size = new System.Drawing.Size(91, 13);
            this.Grammaticals_Label.TabIndex = 0;
            this.Grammaticals_Label.Text = "Nyelvtani jelek";
            // 
            // Grammaticals_TextBox
            // 
            this.Grammaticals_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Grammaticals_TextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Grammaticals_TextBox.Location = new System.Drawing.Point(108, 3);
            this.Grammaticals_TextBox.Name = "Grammaticals_TextBox";
            this.Grammaticals_TextBox.Size = new System.Drawing.Size(212, 25);
            this.Grammaticals_TextBox.TabIndex = 1;
            this.Grammaticals_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grammaticals_TextBox_KeyDown);
            this.Grammaticals_TextBox.Leave += new System.EventHandler(this.Grammaticals_TextBox_Leave);
            // 
            // Terminals_Label
            // 
            this.Terminals_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Terminals_Label.AutoSize = true;
            this.Terminals_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Terminals_Label.Location = new System.Drawing.Point(0, 70);
            this.Terminals_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Terminals_Label.Name = "Terminals_Label";
            this.Terminals_Label.Size = new System.Drawing.Size(80, 13);
            this.Terminals_Label.TabIndex = 4;
            this.Terminals_Label.Text = "Terminálisok";
            // 
            // Terminals_TextBox
            // 
            this.Terminals_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Terminals_TextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terminals_TextBox.Location = new System.Drawing.Point(108, 64);
            this.Terminals_TextBox.Name = "Terminals_TextBox";
            this.Terminals_TextBox.Size = new System.Drawing.Size(212, 25);
            this.Terminals_TextBox.TabIndex = 5;
            this.Terminals_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Terminals_TextBox_KeyDown);
            this.Terminals_TextBox.Leave += new System.EventHandler(this.Terminals_TextBox_Leave);
            // 
            // StartSymbol_ComboBox
            // 
            this.StartSymbol_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StartSymbol_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartSymbol_ComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.StartSymbol_ComboBox.FormattingEnabled = true;
            this.StartSymbol_ComboBox.Location = new System.Drawing.Point(199, 34);
            this.StartSymbol_ComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.StartSymbol_ComboBox.Name = "StartSymbol_ComboBox";
            this.StartSymbol_ComboBox.Size = new System.Drawing.Size(121, 26);
            this.StartSymbol_ComboBox.TabIndex = 3;
            // 
            // SyntacticGrammarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SyntacticGrammarEditor";
            this.Size = new System.Drawing.Size(309, 213);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Rules_TooLStrip.ResumeLayout(false);
            this.Rules_TooLStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip Rules_TooLStrip;
        private System.Windows.Forms.ToolStripButton AddRule_Button;
        private System.Windows.Forms.ToolStripButton EditRule_Button;
        private System.Windows.Forms.ToolStripButton DeleteRules_Button;
        private System.Windows.Forms.ListBox Rules_ListBox;
        private System.Windows.Forms.Label Grammaticals_Label;
        private System.Windows.Forms.TextBox Grammaticals_TextBox;
        private System.Windows.Forms.Label Terminals_Label;
        private System.Windows.Forms.TextBox Terminals_TextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label StartSymbol_Label;
        private System.Windows.Forms.ComboBox StartSymbol_ComboBox;

    }
}
