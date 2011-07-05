using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Syntan.Demo
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        public string OKButtonLabel
        {
            get { return this.OK_Button.Text; }
            set { this.OK_Button.Text = value; }
        }

        public string Value
        {
            get { return this.Value_TextBox.Text; }
            set { this.Value_TextBox.Text = value; }
        }

        public Action<string> ValidatorCallback { get; set; }

        private void OK_Button_Click( object sender, EventArgs e )
        {
            try
            {
                this.ValidatorCallback(this.Value);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch( Exception ex )
            {
                this.Info_Label.Text = ex.Message;
                this.Value_TextBox.BackColor = Color.Salmon;
            }
        }

        private void Value_TextBox_TextChanged( object sender, EventArgs e )
        {
            this.Value_TextBox.BackColor = SystemColors.Window;
        }
    }
}
