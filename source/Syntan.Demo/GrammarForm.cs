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
    public partial class GrammarForm : Form
    {
        public GrammarForm()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Syntan.SyntacticAnalysis.Grammar Grammar
        {
            get { return this.Editor.Grammar; }
            set { this.Editor.Grammar = value; }
        }

        [DefaultValue("&OK")]
        public string OKButtonText
        {
            get { return this.OK_Button.Text; }
            set { this.OK_Button.Text = value; }
        }

        [DefaultValue(true)]
        public bool DialogButtonsVisible
        {
            get { return this.DialogButtons_Panel.Visible; }
            set { this.DialogButtons_Panel.Visible = value; }
        }

        private void NewGrammar_ToolButton_Click( object sender, EventArgs e )
        {
            this.Editor.Grammar = null;
        }

        private void LoadGrammar_ToolButton_Click( object sender, EventArgs e )
        {
            if( this.LoadGrammar_Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK )
            {
                try
                {
                    SyntacticAnalysis.Grammar grammar;
                    using( var stream = System.IO.File.OpenRead(this.LoadGrammar_Dialog.FileName) )
                    {
                        var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        grammar = (SyntacticAnalysis.Grammar)bf.Deserialize(stream);
                    }

                    this.Editor.Grammar = grammar;
                }
                catch( Exception ex )
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Hiba nyelvtan betöltése közben",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveGrammer_ToolButton_Click( object sender, EventArgs e )
        {
            this.Editor.RebuildGrammaticals();
            this.Editor.RebuildTerminals();

            if( this.SaveGrammar_Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK )
            {
                try
                {
                    var grammar = this.Editor.Grammar;
                }
                catch( Syntan.SyntacticAnalysis.GrammarException ex )
                {
                    string msg;
                    if( ex is SyntacticAnalysis.MissingStartSymbolException )
                        msg = "Legalább egy nyelvtani jelet meg kell adni.";
                    else if( ex is SyntacticAnalysis.MissingStartRuleException )
                        msg = "Legalább egy szabályt meg kell adni.";
                    else
                        msg = "Ismeretlen hiba nyelvtan létrehozásakor.";

                    MessageBox.Show(
                        this,
                        msg,
                        "Hiba nyelvtan mentése közben",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
                catch( Exception ex )
                {
                    MessageBox.Show(
                        this,
                        "Váratlan hiba lépett fel a nyelvtan létrehozásakor.\n\n" + ex.Message,
                        "Hiba nyelvtan mentése közben",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                try
                {
                    using( var stream = System.IO.File.OpenWrite(this.SaveGrammar_Dialog.FileName) )
                    {
                        var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        bf.Serialize(stream, this.Editor.Grammar);
                    }
                }
                catch( Exception ex )
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Hiba nyelvtan mentése közben",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
