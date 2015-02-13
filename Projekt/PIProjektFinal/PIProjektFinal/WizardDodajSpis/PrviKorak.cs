using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal.WizardDodajSpis
{
    public partial class PrviKorak : UserControl
    {
        DataClass data = new DataClass();
        public PrviKorak()
        {
            InitializeComponent();
            comboBox1.DataSource = data.GetTipPostupkaList();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) == true)
            {
                errorProvider1.SetError(textBox1, "Ovo polje ne može biti prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        public string Naziv
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int TipSpisa
        {
            get { return (int)comboBox1.SelectedValue; }
            set { comboBox1.SelectedValue = value; }
        }

        public string Biljeska
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
    }
}
