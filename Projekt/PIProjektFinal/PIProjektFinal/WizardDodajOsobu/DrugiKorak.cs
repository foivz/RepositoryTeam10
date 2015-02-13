using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal.WizardDodajOsobu
{
    public partial class DrugiKorak : UserControl
    {
        public DrugiKorak()
        {
            InitializeComponent();
        }

        #region Properties
        public string OIB
        {
            get { return maskedTextBox1.Text; }
            set { maskedTextBox1.Text = value; }
        }
        public string Ime
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Prezime
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string Adresa
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
        public string Faks
        {
            get { return maskedTextBox2.Text; }
            set { maskedTextBox2.Text = value; }
        }
        public string Telefon
        {
            get { return maskedTextBox3.Text; }
            set { maskedTextBox3.Text = value; }
        }
        public string Račun
        {
            get { return textBox7.Text; }
            set { textBox7.Text = value; }
        }
        #endregion

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || maskedTextBox1.Text.Count() < 11)
            {
                errorProvider1.SetError(maskedTextBox1, "Ne smije biti prazno i/ili sadržavati slova");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider2.SetError(textBox2, "Ne smije biti prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider2.Clear();
                e.Cancel = false;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider3.SetError(textBox3, "Ne smije biti prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider3.Clear();
                e.Cancel = false;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                errorProvider6.SetError(textBox6, "Ne smije biti prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider6.Clear();
                e.Cancel = false;
            }
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBox2.Text.Length < 13)
            {
                errorProvider4.SetError(maskedTextBox2, "Provjerite upisani broj");
                e.Cancel = true;
            }
            else
            {
                errorProvider4.Clear();
                e.Cancel = false;
            }
        }

        private void maskedTextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (maskedTextBox3.Text.Length < 13)
            {
                errorProvider5.SetError(maskedTextBox3, "Provjerite upisani broj");
                e.Cancel = true;
            }
            else
            {
                errorProvider5.Clear();
                e.Cancel = false;
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                errorProvider7.SetError(textBox7, "Ne smije biti prazno");
                e.Cancel = true;
            }
            else
            {
                errorProvider7.Clear();
                e.Cancel = false;
            }
        }
    }
}
