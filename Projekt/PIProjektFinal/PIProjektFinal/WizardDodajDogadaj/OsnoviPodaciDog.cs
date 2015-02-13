using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PIProjektFinal.WizardDodajDogadaj
{
    public partial class OsnoviPodaciDog : UserControl
    {
        DataClass data = new DataClass();
        public OsnoviPodaciDog()
        {
            InitializeComponent();
            comboBox1.DataSource = data.GetTipDogadajaList();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
        }

        public string Naslov
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Opis
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public DateTime Pocetak
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public DateTime Zavrsetak
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker2.Value = value; }
        }

        public int TipDogadaja
        {
            get { return (int)comboBox1.SelectedValue; }
            set { comboBox1.SelectedValue = value; }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) == true)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Ne smije biti prazno");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) == true)
            {
                e.Cancel = true;
                errorProvider2.SetError(textBox2, "Ne smije biti prazno");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.Clear();
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(dateTimePicker2.Value,dateTimePicker1.Value) <= 0)
            {
                e.Cancel = true;
                errorProvider4.SetError(dateTimePicker2, "Ne može biti isti ili manji datum!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateChildren();
        }
    }
}
