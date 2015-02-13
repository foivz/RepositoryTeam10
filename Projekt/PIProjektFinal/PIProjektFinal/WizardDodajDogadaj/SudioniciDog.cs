using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal.WizardDodajDogadaj
{
    public partial class SudioniciDog : UserControl
    {
        DataClass data = new DataClass();
        public SudioniciDog()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            comboBox1.DataSource = new BindingSource(data.GetListaOdvjetnika(), null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
            checkBox1.Enabled = false;
            checkBox2.Enabled = true;
            groupBox1.Visible = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
            checkBox1.Enabled = true;
            checkBox2.Enabled = false;
            groupBox1.Visible = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = !checkBox3.Checked;
            checkBox3.Enabled = false;
            checkBox4.Enabled = true;
            comboBox2.DataSource = new BindingSource(data.GetListaStranaka(2), null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = !checkBox4.Checked;
            checkBox4.Enabled = false;
            checkBox3.Enabled = true;
            comboBox2.DataSource = new BindingSource(data.GetListaStranaka(1), null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        public bool SudjelujeStranka
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        public int OdvjetnikID
        {
            get { return (int)comboBox1.SelectedValue; }
            set { comboBox1.SelectedValue = value; }
        }

        public string StrankaOIB
        {
            get { return (string)comboBox2.SelectedValue; }
            set { comboBox2.SelectedValue = value; }
        }

    }
}
