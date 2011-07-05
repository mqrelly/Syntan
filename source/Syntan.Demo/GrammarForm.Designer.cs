namespace Syntan.Demo
{
    partial class GrammarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrammarForm));
            this.Editor = new Syntan.Demo.SyntacticGrammarEditor();
            this.Grammar_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.NewGrammar_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.LoadGrammar_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.SaveGrammer_ToolButton = new System.Windows.Forms.ToolStripButton();
            this.LoadGrammar_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveGrammar_Dialog = new System.Windows.Forms.SaveFileDialog();
            this.DialogButtons_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Grammar_ToolStrip.SuspendLayout();
            this.DialogButtons_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Editor
            // 
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Editor.Location = new System.Drawing.Point(0, 25);
            this.Editor.Name = "Editor";
            this.Editor.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Editor.Size = new System.Drawing.Size(385, 244);
            this.Editor.TabIndex = 0;
            // 
            // Grammar_ToolStrip
            // 
            this.Grammar_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Grammar_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGrammar_ToolButton,
            this.LoadGrammar_ToolButton,
            this.SaveGrammer_ToolButton});
            this.Grammar_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Grammar_ToolStrip.Name = "Grammar_ToolStrip";
            this.Grammar_ToolStrip.Size = new System.Drawing.Size(385, 25);
            this.Grammar_ToolStrip.TabIndex = 1;
            // 
            // NewGrammar_ToolButton
            // 
            this.NewGrammar_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NewGrammar_ToolButton.Image = ((System.Drawing.Image)(resources.GetObject("NewGrammar_ToolButton.Image")));
            this.NewGrammar_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewGrammar_ToolButton.Name = "NewGrammar_ToolButton";
            this.NewGrammar_ToolButton.Size = new System.Drawing.Size(70, 22);
            this.NewGrammar_ToolButton.Text = "Ú&j nyelvtan";
            this.NewGrammar_ToolButton.Click += new System.EventHandler(this.NewGrammar_ToolButton_Click);
            // 
            // LoadGrammar_ToolButton
            // 
            this.LoadGrammar_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadGrammar_ToolButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadGrammar_ToolButton.Image")));
            this.LoadGrammar_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadGrammar_ToolButton.Name = "LoadGrammar_ToolButton";
            this.LoadGrammar_ToolButton.Size = new System.Drawing.Size(53, 22);
            this.LoadGrammar_ToolButton.Text = "&Betöltés";
            this.LoadGrammar_ToolButton.Click += new System.EventHandler(this.LoadGrammar_ToolButton_Click);
            // 
            // SaveGrammer_ToolButton
            // 
            this.SaveGrammer_ToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveGrammer_ToolButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveGrammer_ToolButton.Image")));
            this.SaveGrammer_ToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveGrammer_ToolButton.Name = "SaveGrammer_ToolButton";
            this.SaveGrammer_ToolButton.Size = new System.Drawing.Size(50, 22);
            this.SaveGrammer_ToolButton.Text = "Me&ntés";
            this.SaveGrammer_ToolButton.Click += new System.EventHandler(this.SaveGrammer_ToolButton_Click);
            // 
            // LoadGrammar_Dialog
            // 
            this.LoadGrammar_Dialog.DefaultExt = "syngr";
            this.LoadGrammar_Dialog.Filter = "Syntactical Grammar (*.syngr)|*.syngr|All files (*.*)|*.*";
            this.LoadGrammar_Dialog.Title = "Load Grammar from file";
            // 
            // SaveGrammar_Dialog
            // 
            this.SaveGrammar_Dialog.DefaultExt = "syngr";
            this.SaveGrammar_Dialog.Filter = "Syntactical Grammar (*.syngr)|*.syngr|All files (*.*)|*.*";
            this.SaveGrammar_Dialog.Title = "Save Grammar to file";
            // 
            // DialogButtons_Panel
            // 
            this.DialogButtons_Panel.AutoSize = true;
            this.DialogButtons_Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DialogButtons_Panel.ColumnCount = 2;
            this.DialogButtons_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DialogButtons_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.DialogButtons_Panel.Controls.Add(this.OK_Button, 0, 0);
            this.DialogButtons_Panel.Controls.Add(this.Cancel_Button, 1, 0);
            this.DialogButtons_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DialogButtons_Panel.Location = new System.Drawing.Point(0, 269);
            this.DialogButtons_Panel.Name = "DialogButtons_Panel";
            this.DialogButtons_Panel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.DialogButtons_Panel.RowCount = 1;
            this.DialogButtons_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DialogButtons_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.DialogButtons_Panel.Size = new System.Drawing.Size(385, 41);
            this.DialogButtons_Panel.TabIndex = 2;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OK_Button.AutoSize = true;
            this.OK_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(280, 8);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OK_Button.Size = new System.Drawing.Size(38, 27);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "&OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.AutoSize = true;
            this.Cancel_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(324, 8);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancel_Button.Size = new System.Drawing.Size(55, 27);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "&Mégse";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // GrammarForm
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(385, 310);
            this.Controls.Add(this.Editor);
            this.Controls.Add(this.Grammar_ToolStrip);
            this.Controls.Add(this.DialogButtons_Panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrammarForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szintatikus nyelvtan";
            this.Grammar_ToolStrip.ResumeLayout(false);
            this.Grammar_ToolStrip.PerformLayout();
            this.DialogButtons_Panel.ResumeLayout(false);
            this.DialogButtons_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SyntacticGrammarEditor Editor;
        private System.Windows.Forms.ToolStrip Grammar_ToolStrip;
        private System.Windows.Forms.ToolStripButton NewGrammar_ToolButton;
        private System.Windows.Forms.ToolStripButton LoadGrammar_ToolButton;
        private System.Windows.Forms.ToolStripButton SaveGrammer_ToolButton;
        private System.Windows.Forms.OpenFileDialog LoadGrammar_Dialog;
        private System.Windows.Forms.SaveFileDialog SaveGrammar_Dialog;
        private System.Windows.Forms.TableLayoutPanel DialogButtons_Panel;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
    }
}