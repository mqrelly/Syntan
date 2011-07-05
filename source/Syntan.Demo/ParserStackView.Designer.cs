namespace Syntan.Demo
{
    partial class ParserStackView
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
            this.Stack_ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Stack_ListBox
            // 
            this.Stack_ListBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Stack_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Stack_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Stack_ListBox.FormattingEnabled = true;
            this.Stack_ListBox.IntegralHeight = false;
            this.Stack_ListBox.ItemHeight = 20;
            this.Stack_ListBox.Location = new System.Drawing.Point(0, 0);
            this.Stack_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.Stack_ListBox.Name = "Stack_ListBox";
            this.Stack_ListBox.ScrollAlwaysVisible = true;
            this.Stack_ListBox.Size = new System.Drawing.Size(200, 208);
            this.Stack_ListBox.TabIndex = 0;
            this.Stack_ListBox.TabStop = false;
            this.Stack_ListBox.UseTabStops = false;
            this.Stack_ListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Stack_ListBox_DrawItem);
            // 
            // ParserStackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Stack_ListBox);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ParserStackView";
            this.Size = new System.Drawing.Size(200, 208);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Stack_ListBox;
    }
}
