namespace Syntan.Demo
{
    partial class DfsmView
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
            this.Graph = new Syntan.Demo.GraphDrawing.GraphView();
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.BackColor = System.Drawing.Color.White;
            this.Graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Graph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph.Location = new System.Drawing.Point(0, 0);
            this.Graph.Margin = new System.Windows.Forms.Padding(1);
            this.Graph.Name = "Graph";
            this.Graph.PageColor = System.Drawing.Color.White;
            this.Graph.PageMargin = new System.Windows.Forms.Padding(30, 50, 30, 30);
            this.Graph.Size = new System.Drawing.Size(200, 196);
            this.Graph.TabIndex = 0;
            // 
            // DfsmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Graph);
            this.Font = new System.Drawing.Font("Arial", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DfsmView";
            this.Size = new System.Drawing.Size(200, 196);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphDrawing.GraphView Graph;
    }
}
