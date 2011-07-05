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
    public partial class ParserStartForm : Form
    {
        public ParserStartForm()
        {
            InitializeComponent();
        }

        public bool AutoStep
        {
            get { return this.AutoPlay_CheckBox.Checked; }
            set { this.AutoPlay_CheckBox.Checked = value; }
        }

        public int StepIntervall
        {
            get { return (int)this.StepIntervall_NumericUpDown.Value; }
            set { this.StepIntervall_NumericUpDown.Value = value; }
        }

        private void AutoPlay_CheckBox_CheckedChanged( object sender, EventArgs e )
        {
            this.AutoPlay_Label.Enabled = this.AutoPlay_CheckBox.Checked;
            this.StepIntervall_NumericUpDown.Enabled = this.AutoPlay_CheckBox.Checked;
        }
    }
}
