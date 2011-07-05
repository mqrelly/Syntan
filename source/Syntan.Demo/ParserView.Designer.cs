namespace Syntan.Demo
{
    partial class ParserView
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
            this.State_Label = new System.Windows.Forms.Label();
            this.StateValue_Label = new System.Windows.Forms.Label();
            this.InputSymbolValue_Label = new System.Windows.Forms.Label();
            this.InputSymbol_Label = new System.Windows.Forms.Label();
            this.NextAction_Label = new System.Windows.Forms.Label();
            this.Input_Label = new System.Windows.Forms.Label();
            this.ParserStack_Label = new System.Windows.Forms.Label();
            this.Rule_TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RuleIndex_Label = new System.Windows.Forms.Label();
            this.RuleLhs_Label = new System.Windows.Forms.Label();
            this.RuleArrow_Label = new System.Windows.Forms.Label();
            this.RuleRhs_Label = new System.Windows.Forms.Label();
            this.Input_ComboBox = new System.Windows.Forms.ComboBox();
            this.ParserStackView = new Syntan.Demo.ParserStackView();
            this.InternalStepsView = new Syntan.Demo.StepsView();
            this.Rule_TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // State_Label
            // 
            this.State_Label.AutoSize = true;
            this.State_Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State_Label.Location = new System.Drawing.Point(16, 86);
            this.State_Label.Name = "State_Label";
            this.State_Label.Size = new System.Drawing.Size(123, 19);
            this.State_Label.TabIndex = 5;
            this.State_Label.Text = "Aktuális állapot:";
            this.State_Label.Visible = false;
            // 
            // StateValue_Label
            // 
            this.StateValue_Label.AutoSize = true;
            this.StateValue_Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StateValue_Label.Location = new System.Drawing.Point(216, 81);
            this.StateValue_Label.Name = "StateValue_Label";
            this.StateValue_Label.Padding = new System.Windows.Forms.Padding(5);
            this.StateValue_Label.Size = new System.Drawing.Size(28, 29);
            this.StateValue_Label.TabIndex = 6;
            this.StateValue_Label.Text = "0";
            this.StateValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StateValue_Label.Visible = false;
            // 
            // InputSymbolValue_Label
            // 
            this.InputSymbolValue_Label.AutoSize = true;
            this.InputSymbolValue_Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InputSymbolValue_Label.Location = new System.Drawing.Point(216, 117);
            this.InputSymbolValue_Label.Name = "InputSymbolValue_Label";
            this.InputSymbolValue_Label.Padding = new System.Windows.Forms.Padding(5);
            this.InputSymbolValue_Label.Size = new System.Drawing.Size(25, 29);
            this.InputSymbolValue_Label.TabIndex = 8;
            this.InputSymbolValue_Label.Text = "-";
            this.InputSymbolValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InputSymbolValue_Label.Visible = false;
            // 
            // InputSymbol_Label
            // 
            this.InputSymbol_Label.AutoSize = true;
            this.InputSymbol_Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputSymbol_Label.Location = new System.Drawing.Point(16, 122);
            this.InputSymbol_Label.Name = "InputSymbol_Label";
            this.InputSymbol_Label.Size = new System.Drawing.Size(135, 19);
            this.InputSymbol_Label.TabIndex = 7;
            this.InputSymbol_Label.Text = "Input szimbólum:";
            this.InputSymbol_Label.Visible = false;
            // 
            // NextAction_Label
            // 
            this.NextAction_Label.AutoSize = true;
            this.NextAction_Label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NextAction_Label.Location = new System.Drawing.Point(11, 11);
            this.NextAction_Label.Name = "NextAction_Label";
            this.NextAction_Label.Size = new System.Drawing.Size(80, 19);
            this.NextAction_Label.TabIndex = 9;
            this.NextAction_Label.Text = "Léptetés";
            this.NextAction_Label.Visible = false;
            // 
            // Input_Label
            // 
            this.Input_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Input_Label.AutoSize = true;
            this.Input_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Input_Label.Location = new System.Drawing.Point(11, 218);
            this.Input_Label.Name = "Input_Label";
            this.Input_Label.Size = new System.Drawing.Size(38, 13);
            this.Input_Label.TabIndex = 12;
            this.Input_Label.Text = "Input";
            // 
            // ParserStack_Label
            // 
            this.ParserStack_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParserStack_Label.AutoSize = true;
            this.ParserStack_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ParserStack_Label.Location = new System.Drawing.Point(280, 11);
            this.ParserStack_Label.Name = "ParserStack_Label";
            this.ParserStack_Label.Size = new System.Drawing.Size(87, 13);
            this.ParserStack_Label.TabIndex = 13;
            this.ParserStack_Label.Text = "Elemző verem";
            // 
            // Rule_TableLayout
            // 
            this.Rule_TableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Rule_TableLayout.ColumnCount = 4;
            this.Rule_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Rule_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Rule_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Rule_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Rule_TableLayout.Controls.Add(this.RuleIndex_Label, 0, 0);
            this.Rule_TableLayout.Controls.Add(this.RuleLhs_Label, 1, 0);
            this.Rule_TableLayout.Controls.Add(this.RuleArrow_Label, 2, 0);
            this.Rule_TableLayout.Controls.Add(this.RuleRhs_Label, 3, 0);
            this.Rule_TableLayout.Location = new System.Drawing.Point(20, 158);
            this.Rule_TableLayout.Name = "Rule_TableLayout";
            this.Rule_TableLayout.RowCount = 1;
            this.Rule_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Rule_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.Rule_TableLayout.Size = new System.Drawing.Size(231, 29);
            this.Rule_TableLayout.TabIndex = 15;
            this.Rule_TableLayout.Visible = false;
            // 
            // RuleIndex_Label
            // 
            this.RuleIndex_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RuleIndex_Label.AutoSize = true;
            this.RuleIndex_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RuleIndex_Label.Location = new System.Drawing.Point(0, 6);
            this.RuleIndex_Label.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.RuleIndex_Label.Name = "RuleIndex_Label";
            this.RuleIndex_Label.Size = new System.Drawing.Size(25, 16);
            this.RuleIndex_Label.TabIndex = 0;
            this.RuleIndex_Label.Text = "(0)";
            // 
            // RuleLhs_Label
            // 
            this.RuleLhs_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RuleLhs_Label.AutoSize = true;
            this.RuleLhs_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RuleLhs_Label.Location = new System.Drawing.Point(40, 2);
            this.RuleLhs_Label.Margin = new System.Windows.Forms.Padding(0);
            this.RuleLhs_Label.Name = "RuleLhs_Label";
            this.RuleLhs_Label.Padding = new System.Windows.Forms.Padding(3);
            this.RuleLhs_Label.Size = new System.Drawing.Size(25, 24);
            this.RuleLhs_Label.TabIndex = 1;
            this.RuleLhs_Label.Text = "A";
            // 
            // RuleArrow_Label
            // 
            this.RuleArrow_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RuleArrow_Label.AutoSize = true;
            this.RuleArrow_Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RuleArrow_Label.Location = new System.Drawing.Point(70, 6);
            this.RuleArrow_Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RuleArrow_Label.Name = "RuleArrow_Label";
            this.RuleArrow_Label.Size = new System.Drawing.Size(22, 16);
            this.RuleArrow_Label.TabIndex = 2;
            this.RuleArrow_Label.Text = "->";
            // 
            // RuleRhs_Label
            // 
            this.RuleRhs_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RuleRhs_Label.AutoSize = true;
            this.RuleRhs_Label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RuleRhs_Label.Location = new System.Drawing.Point(97, 2);
            this.RuleRhs_Label.Margin = new System.Windows.Forms.Padding(0);
            this.RuleRhs_Label.Name = "RuleRhs_Label";
            this.RuleRhs_Label.Padding = new System.Windows.Forms.Padding(3);
            this.RuleRhs_Label.Size = new System.Drawing.Size(40, 24);
            this.RuleRhs_Label.TabIndex = 3;
            this.RuleRhs_Label.Text = "abc";
            // 
            // Input_ComboBox
            // 
            this.Input_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Input_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Input_ComboBox.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_ComboBox.FormattingEnabled = true;
            this.Input_ComboBox.Location = new System.Drawing.Point(55, 212);
            this.Input_ComboBox.Name = "Input_ComboBox";
            this.Input_ComboBox.Size = new System.Drawing.Size(383, 25);
            this.Input_ComboBox.TabIndex = 16;
            // 
            // ParserStackView
            // 
            this.ParserStackView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ParserStackView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ParserStackView.Location = new System.Drawing.Point(283, 28);
            this.ParserStackView.Margin = new System.Windows.Forms.Padding(4);
            this.ParserStackView.Name = "ParserStackView";
            this.ParserStackView.Size = new System.Drawing.Size(155, 169);
            this.ParserStackView.TabIndex = 11;
            // 
            // InternalStepsView
            // 
            this.InternalStepsView.ArrowColor = System.Drawing.Color.DarkGray;
            this.InternalStepsView.ArrowWidth = 8;
            this.InternalStepsView.BackColor = System.Drawing.Color.White;
            this.InternalStepsView.CircleSize = 35;
            this.InternalStepsView.CurrentBackColor = System.Drawing.Color.LightGreen;
            this.InternalStepsView.CurrentForeColor = System.Drawing.Color.Green;
            this.InternalStepsView.DoneBackColor = System.Drawing.Color.LightGreen;
            this.InternalStepsView.DoneForeColor = System.Drawing.Color.Gray;
            this.InternalStepsView.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InternalStepsView.Location = new System.Drawing.Point(14, 35);
            this.InternalStepsView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.InternalStepsView.MinimumSize = new System.Drawing.Size(0, 35);
            this.InternalStepsView.Name = "InternalStepsView";
            this.InternalStepsView.Size = new System.Drawing.Size(150, 38);
            this.InternalStepsView.TabIndex = 3;
            this.InternalStepsView.UndoneBackColor = System.Drawing.Color.LightGray;
            this.InternalStepsView.UndoneForeColor = System.Drawing.Color.Gray;
            // 
            // ParserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Input_ComboBox);
            this.Controls.Add(this.Rule_TableLayout);
            this.Controls.Add(this.ParserStack_Label);
            this.Controls.Add(this.Input_Label);
            this.Controls.Add(this.ParserStackView);
            this.Controls.Add(this.NextAction_Label);
            this.Controls.Add(this.InputSymbolValue_Label);
            this.Controls.Add(this.InputSymbol_Label);
            this.Controls.Add(this.StateValue_Label);
            this.Controls.Add(this.State_Label);
            this.Controls.Add(this.InternalStepsView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MinimumSize = new System.Drawing.Size(450, 248);
            this.Name = "ParserView";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(450, 248);
            this.Rule_TableLayout.ResumeLayout(false);
            this.Rule_TableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label State_Label;
        private StepsView InternalStepsView;
        private System.Windows.Forms.Label StateValue_Label;
        private System.Windows.Forms.Label InputSymbolValue_Label;
        private System.Windows.Forms.Label InputSymbol_Label;
        private System.Windows.Forms.Label NextAction_Label;
        private ParserStackView ParserStackView;
        private System.Windows.Forms.Label Input_Label;
        private System.Windows.Forms.Label ParserStack_Label;
        private System.Windows.Forms.TableLayoutPanel Rule_TableLayout;
        private System.Windows.Forms.Label RuleIndex_Label;
        private System.Windows.Forms.Label RuleLhs_Label;
        private System.Windows.Forms.Label RuleArrow_Label;
        private System.Windows.Forms.Label RuleRhs_Label;
        private System.Windows.Forms.ComboBox Input_ComboBox;
    }
}
