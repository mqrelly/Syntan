namespace Syntan.Demo
{
    partial class SimpleSyntacticGrammarEditor
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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SyntacticRules_Label = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddRule_Button = new System.Windows.Forms.Button();
            this.EditRule_Button = new System.Windows.Forms.Button();
            this.DeleteRule_Button = new System.Windows.Forms.Button();
            this.Rules_ListBox = new System.Windows.Forms.ListBox();
            this.Grammaticals_Label = new System.Windows.Forms.Label();
            this.Grammaticals_TextBox = new System.Windows.Forms.TextBox();
            this.Terminals_Label = new System.Windows.Forms.Label();
            this.Terminals_TextBox = new System.Windows.Forms.TextBox();
            this.TableLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.AutoSize = true;
            this.TableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayout.ColumnCount = 1;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.SyntacticRules_Label, 0, 0);
            this.TableLayout.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.TableLayout.Controls.Add(this.Rules_ListBox, 0, 2);
            this.TableLayout.Controls.Add(this.Grammaticals_Label, 0, 3);
            this.TableLayout.Controls.Add(this.Grammaticals_TextBox, 0, 4);
            this.TableLayout.Controls.Add(this.Terminals_Label, 0, 5);
            this.TableLayout.Controls.Add(this.Terminals_TextBox, 0, 6);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 7;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(472, 355);
            this.TableLayout.TabIndex = 0;
            // 
            // SyntacticRules_Label
            // 
            this.SyntacticRules_Label.AutoSize = true;
            this.SyntacticRules_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SyntacticRules_Label.Location = new System.Drawing.Point(0, 0);
            this.SyntacticRules_Label.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.SyntacticRules_Label.Name = "SyntacticRules_Label";
            this.SyntacticRules_Label.Size = new System.Drawing.Size(105, 16);
            this.SyntacticRules_Label.TabIndex = 0;
            this.SyntacticRules_Label.Text = "Syntactic rules";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.AddRule_Button);
            this.flowLayoutPanel1.Controls.Add(this.EditRule_Button);
            this.flowLayoutPanel1.Controls.Add(this.DeleteRule_Button);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 16);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 27);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // AddRule_Button
            // 
            this.AddRule_Button.AutoSize = true;
            this.AddRule_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddRule_Button.Location = new System.Drawing.Point(0, 0);
            this.AddRule_Button.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.AddRule_Button.Name = "AddRule_Button";
            this.AddRule_Button.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.AddRule_Button.Size = new System.Drawing.Size(100, 27);
            this.AddRule_Button.TabIndex = 0;
            this.AddRule_Button.Text = "Add new rule...";
            this.AddRule_Button.UseVisualStyleBackColor = true;
            this.AddRule_Button.Click += new System.EventHandler(this.AddRule_Button_Click);
            // 
            // EditRule_Button
            // 
            this.EditRule_Button.AutoSize = true;
            this.EditRule_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditRule_Button.Location = new System.Drawing.Point(103, 0);
            this.EditRule_Button.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.EditRule_Button.Name = "EditRule_Button";
            this.EditRule_Button.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.EditRule_Button.Size = new System.Drawing.Size(76, 27);
            this.EditRule_Button.TabIndex = 1;
            this.EditRule_Button.Text = "Edit rule...";
            this.EditRule_Button.UseVisualStyleBackColor = true;
            this.EditRule_Button.Click += new System.EventHandler(this.EditRule_Button_Click);
            // 
            // DeleteRule_Button
            // 
            this.DeleteRule_Button.AutoSize = true;
            this.DeleteRule_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteRule_Button.Location = new System.Drawing.Point(182, 0);
            this.DeleteRule_Button.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.DeleteRule_Button.Name = "DeleteRule_Button";
            this.DeleteRule_Button.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.DeleteRule_Button.Size = new System.Drawing.Size(125, 27);
            this.DeleteRule_Button.TabIndex = 2;
            this.DeleteRule_Button.Text = "Delete selected rules";
            this.DeleteRule_Button.UseVisualStyleBackColor = true;
            this.DeleteRule_Button.Click += new System.EventHandler(this.DeleteRule_Button_Click);
            // 
            // Rules_ListBox
            // 
            this.Rules_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Rules_ListBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rules_ListBox.FormattingEnabled = true;
            this.Rules_ListBox.HorizontalScrollbar = true;
            this.Rules_ListBox.IntegralHeight = false;
            this.Rules_ListBox.ItemHeight = 18;
            this.Rules_ListBox.Location = new System.Drawing.Point(20, 46);
            this.Rules_ListBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.Rules_ListBox.Name = "Rules_ListBox";
            this.Rules_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Rules_ListBox.Size = new System.Drawing.Size(449, 162);
            this.Rules_ListBox.TabIndex = 2;
            // 
            // Grammaticals_Label
            // 
            this.Grammaticals_Label.AutoSize = true;
            this.Grammaticals_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Grammaticals_Label.Location = new System.Drawing.Point(0, 221);
            this.Grammaticals_Label.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.Grammaticals_Label.Name = "Grammaticals_Label";
            this.Grammaticals_Label.Size = new System.Drawing.Size(143, 16);
            this.Grammaticals_Label.TabIndex = 3;
            this.Grammaticals_Label.Text = "Grammatical symbols";
            // 
            // Grammaticals_TextBox
            // 
            this.Grammaticals_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Grammaticals_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Grammaticals_TextBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Grammaticals_TextBox.Location = new System.Drawing.Point(20, 240);
            this.Grammaticals_TextBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.Grammaticals_TextBox.Multiline = true;
            this.Grammaticals_TextBox.Name = "Grammaticals_TextBox";
            this.Grammaticals_TextBox.ReadOnly = true;
            this.Grammaticals_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Grammaticals_TextBox.Size = new System.Drawing.Size(449, 40);
            this.Grammaticals_TextBox.TabIndex = 4;
            this.Grammaticals_TextBox.Text = "S\' S";
            this.Grammaticals_TextBox.WordWrap = false;
            // 
            // Terminals_Label
            // 
            this.Terminals_Label.AutoSize = true;
            this.Terminals_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Terminals_Label.Location = new System.Drawing.Point(0, 293);
            this.Terminals_Label.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
            this.Terminals_Label.Name = "Terminals_Label";
            this.Terminals_Label.Size = new System.Drawing.Size(118, 16);
            this.Terminals_Label.TabIndex = 5;
            this.Terminals_Label.Text = "Terminal symbols";
            // 
            // Terminals_TextBox
            // 
            this.Terminals_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Terminals_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Terminals_TextBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Terminals_TextBox.Location = new System.Drawing.Point(20, 312);
            this.Terminals_TextBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.Terminals_TextBox.Multiline = true;
            this.Terminals_TextBox.Name = "Terminals_TextBox";
            this.Terminals_TextBox.ReadOnly = true;
            this.Terminals_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Terminals_TextBox.Size = new System.Drawing.Size(449, 40);
            this.Terminals_TextBox.TabIndex = 6;
            this.Terminals_TextBox.Text = "#";
            this.Terminals_TextBox.WordWrap = false;
            // 
            // SimpleSyntacticGrammarEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.TableLayout);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SimpleSyntacticGrammarEditor";
            this.Size = new System.Drawing.Size(472, 355);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label SyntacticRules_Label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox Rules_ListBox;
        private System.Windows.Forms.Label Grammaticals_Label;
        private System.Windows.Forms.TextBox Grammaticals_TextBox;
        private System.Windows.Forms.Label Terminals_Label;
        private System.Windows.Forms.TextBox Terminals_TextBox;
        private System.Windows.Forms.Button AddRule_Button;
        private System.Windows.Forms.Button EditRule_Button;
        private System.Windows.Forms.Button DeleteRule_Button;
    }
}
