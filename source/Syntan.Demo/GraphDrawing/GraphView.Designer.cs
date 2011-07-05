namespace Syntan.Demo.GraphDrawing
{
    partial class GraphView
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
            if( disposing )
            {
                if( this.buff_g != null )
                    this.buff_g.Dispose();
                if( this.buff_img != null )
                    this.buff_img.Dispose();

                if( components != null )
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
            this.ZoomAll_Button = new System.Windows.Forms.Button();
            this.ZoomIn_Button = new System.Windows.Forms.Button();
            this.ZoomOut_Button = new System.Windows.Forms.Button();
            this.Zoom_Label = new System.Windows.Forms.Label();
            this.Zoom_LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Zoom_LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZoomAll_Button
            // 
            this.ZoomAll_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomAll_Button.Image = global::Syntan.Demo.Properties.Resources.page_white;
            this.ZoomAll_Button.Location = new System.Drawing.Point(67, 0);
            this.ZoomAll_Button.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomAll_Button.Name = "ZoomAll_Button";
            this.ZoomAll_Button.Size = new System.Drawing.Size(24, 24);
            this.ZoomAll_Button.TabIndex = 0;
            this.ZoomAll_Button.UseVisualStyleBackColor = true;
            this.ZoomAll_Button.Click += new System.EventHandler(this.ZoomAll_Button_Click);
            // 
            // ZoomIn_Button
            // 
            this.ZoomIn_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomIn_Button.Image = global::Syntan.Demo.Properties.Resources.zoom_in;
            this.ZoomIn_Button.Location = new System.Drawing.Point(0, 0);
            this.ZoomIn_Button.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomIn_Button.Name = "ZoomIn_Button";
            this.ZoomIn_Button.Size = new System.Drawing.Size(24, 24);
            this.ZoomIn_Button.TabIndex = 1;
            this.ZoomIn_Button.UseVisualStyleBackColor = true;
            this.ZoomIn_Button.Click += new System.EventHandler(this.ZoomIn_Button_Click);
            // 
            // ZoomOut_Button
            // 
            this.ZoomOut_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOut_Button.Image = global::Syntan.Demo.Properties.Resources.zoom_out;
            this.ZoomOut_Button.Location = new System.Drawing.Point(24, 0);
            this.ZoomOut_Button.Margin = new System.Windows.Forms.Padding(0);
            this.ZoomOut_Button.Name = "ZoomOut_Button";
            this.ZoomOut_Button.Size = new System.Drawing.Size(24, 24);
            this.ZoomOut_Button.TabIndex = 2;
            this.ZoomOut_Button.UseVisualStyleBackColor = true;
            this.ZoomOut_Button.Click += new System.EventHandler(this.ZoomOut_Button_Click);
            // 
            // Zoom_Label
            // 
            this.Zoom_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Zoom_Label.AutoSize = true;
            this.Zoom_Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Zoom_Label.Location = new System.Drawing.Point(48, 5);
            this.Zoom_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Zoom_Label.Name = "Zoom_Label";
            this.Zoom_Label.Size = new System.Drawing.Size(19, 13);
            this.Zoom_Label.TabIndex = 3;
            this.Zoom_Label.Text = "x1";
            // 
            // Zoom_LayoutPanel
            // 
            this.Zoom_LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Zoom_LayoutPanel.AutoSize = true;
            this.Zoom_LayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Zoom_LayoutPanel.Controls.Add(this.ZoomIn_Button);
            this.Zoom_LayoutPanel.Controls.Add(this.ZoomOut_Button);
            this.Zoom_LayoutPanel.Controls.Add(this.Zoom_Label);
            this.Zoom_LayoutPanel.Controls.Add(this.ZoomAll_Button);
            this.Zoom_LayoutPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Zoom_LayoutPanel.Location = new System.Drawing.Point(45, 1);
            this.Zoom_LayoutPanel.Margin = new System.Windows.Forms.Padding(1);
            this.Zoom_LayoutPanel.Name = "Zoom_LayoutPanel";
            this.Zoom_LayoutPanel.Size = new System.Drawing.Size(91, 24);
            this.Zoom_LayoutPanel.TabIndex = 4;
            this.Zoom_LayoutPanel.Resize += new System.EventHandler(this.Zoom_LayoutPanel_Resize);
            // 
            // GraphView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Zoom_LayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "GraphView";
            this.Size = new System.Drawing.Size(137, 137);
            this.Zoom_LayoutPanel.ResumeLayout(false);
            this.Zoom_LayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ZoomAll_Button;
        private System.Windows.Forms.Button ZoomIn_Button;
        private System.Windows.Forms.Button ZoomOut_Button;
        private System.Windows.Forms.Label Zoom_Label;
        private System.Windows.Forms.FlowLayoutPanel Zoom_LayoutPanel;


    }
}
