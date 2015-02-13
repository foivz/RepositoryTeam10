using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PIProjektFinal
{
    public partial class DodajKorisnikForm : Form
    {
        DataClass data = new DataClass();
        private Match result;
        Korisnik korOdb = new Korisnik();
        int opcija;
        public DodajKorisnikForm()
        {
            InitializeComponent();
            comboBox1.DataSource = data.GetUlogaKorisnikaList();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
            opcija = 1;
        }

        public DodajKorisnikForm(Korisnik korisnik)
        {
            InitializeComponent();
            comboBox1.DataSource = data.GetUlogaKorisnikaList();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
            textBox1.Text = korisnik.Ime;
            textBox2.Text = korisnik.Prezime;
            textBox3.Text = korisnik.Adresa;
            textBox4.Text = korisnik.KorisnickoIme;
            textBox5.Text = korisnik.Lozinka;
            textBox6.Text = korisnik.TelefonGlavni;
            textBox7.Text = korisnik.email;
            comboBox1.SelectedValue = korisnik.Uloga;
            this.Text = "Uredi korisnika";
            korOdb = korisnik;
            opcija = 2;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            result = Regex.Match(textBox1.Text, "^[a-zA-ZžŽđĐćĆčČšŠ]+$");

            if (string.IsNullOrWhiteSpace(textBox1.Text) || result.Success == false)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Ne smije biti prazno ili imati brojeve u sebi");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            result = Regex.Match(textBox2.Text, "^[a-zA-ZžŽđĐćĆčČšŠ]+$");

            if (string.IsNullOrWhiteSpace(textBox2.Text) || result.Success == false)
            {
                e.Cancel = true;
                errorProvider2.SetError(textBox2, "Ne smije biti prazno ili imati brojeve u sebi");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.Clear();
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                errorProvider3.SetError(textBox3, "Ne smije biti prazno");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.Clear();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            result = Regex.Match(textBox4.Text, "^[a-zA-ZžŽđĐćĆčČšŠ]+$");

            if (string.IsNullOrWhiteSpace(textBox4.Text) || result.Success == false)
            {
                e.Cancel = true;
                errorProvider4.SetError(textBox4, "Ne smije biti prazno ili imati brojeve u sebi");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.Clear();
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider5.SetError(textBox5, "Ne smije biti prazno");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (opcija == 2)
                {
                    data.UpdateKorisnik(korOdb.ID, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, (int)comboBox1.SelectedValue);
                }
                else
                {
                    Korisnik novi = new Korisnik();
                    novi.Ime = textBox1.Text;
                    novi.Prezime = textBox2.Text;
                    novi.Adresa = textBox3.Text;
                    novi.KorisnickoIme = textBox4.Text;
                    novi.Lozinka = textBox5.Text;
                    novi.TelefonGlavni = textBox6.Text;
                    novi.email = textBox7.Text;
                    novi.Uloga = (int)comboBox1.SelectedValue;
                    data.DodajKorisnika(novi);
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
