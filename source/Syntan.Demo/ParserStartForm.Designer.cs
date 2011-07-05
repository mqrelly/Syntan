namespace Syntan.Demo
{
    partial class ParserStartForm
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
            this.AutoPlay_CheckBox = new System.Windows.Forms.CheckBox();
            this.AutoPlay_Label = new System.Windows.Forms.Label();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.StepIntervall_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StepIntervall_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.AutoPlay_CheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AutoPlay_Label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Ok_Button, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_Button, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.StepIntervall_NumericUpDown, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 118);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AutoPlay_CheckBox
            // 
            this.AutoPlay_CheckBox.AutoSize = true;
            this.AutoPlay_CheckBox.Checked = true;
            this.AutoPlay_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.AutoPlay_CheckBox, 4);
            this.AutoPlay_CheckBox.Location = new System.Drawing.Point(13, 13);
            this.AutoPlay_CheckBox.Name = "AutoPlay_CheckBox";
            this.AutoPlay_CheckBox.Size = new System.Drawing.Size(127, 17);
            this.AutoPlay_CheckBox.TabIndex = 0;
            this.AutoPlay_CheckBox.Text = "Automatikus léptetés";
            this.AutoPlay_CheckBox.UseVisualStyleBackColor = true;
            this.AutoPlay_CheckBox.CheckedChanged += new System.EventHandler(this.AutoPlay_CheckBox_CheckedChanged);
            // 
            // AutoPlay_Label
            // 
            this.AutoPlay_Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AutoPlay_Label.AutoSize = true;
            this.AutoPlay_Label.Location = new System.Drawing.Point(33, 40);
            this.AutoPlay_Label.Name = "AutoPlay_Label";
            this.AutoPlay_Label.Size = new System.Drawing.Size(115, 13);
            this.AutoPlay_Label.TabIndex = 1;
            this.AutoPlay_Label.Text = "Lépés időköz (millisec):";
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.AutoSize = true;
            this.Ok_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Location = new System.Drawing.Point(154, 76);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Ok_Button.Size = new System.Drawing.Size(58, 29);
            this.Ok_Button.TabIndex = 3;
            this.Ok_Button.Text = "&Indítás";
            this.Ok_Button.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.AutoSize = true;
            this.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(254, 76);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel_Button.Size = new System.Drawing.Size(56, 29);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "&Mégse";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // StepIntervall_NumericUpDown
            // 
            this.StepIntervall_NumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.SetColumnSpan(this.StepIntervall_NumericUpDown, 2);
            this.StepIntervall_NumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.StepIntervall_NumericUpDown.Location = new System.Drawing.Point(224, 36);
            this.StepIntervall_NumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StepIntervall_NumericUpDown.Name = "StepIntervall_NumericUpDown";
            this.StepIntervall_NumericUpDown.Size = new System.Drawing.Size(86, 21);
            this.StepIntervall_NumericUpDown.TabIndex = 2;
            this.StepIntervall_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StepIntervall_NumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ParserStartForm
            // 
            this.AcceptButton = this.Ok_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(323, 118);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ParserStartForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elemzés indítása";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StepIntervall_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox AutoPlay_CheckBox;
        private System.Windows.Forms.Label AutoPlay_Label;
        private System.Windows.Forms.Button Ok_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.NumericUpDown StepIntervall_NumericUpDown;
    }
}