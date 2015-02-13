using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal
{
    public partial class OsobaDodaj : Form
    {
        int tip;
        DataClass data = new DataClass();
        WizardDodajOsobu.PrviKorak prvi = new WizardDodajOsobu.PrviKorak();
        WizardDodajOsobu.DrugiKorak drugi = new WizardDodajOsobu.DrugiKorak();
        public OsobaDodaj(int tipOsobe)
        {
            InitializeComponent();
            comboBox1.DataSource = data.GetStatusiOsobe();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
            prvi.Location = new Point(-30, 50);
            drugi.Location = new Point(-30, 40);
            tip = tipOsobe;
            if (tipOsobe == 1)
            {
                label2.Text = "Stranka";
            }
            else
            {
                label2.Text = "Protustranka";
            }
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if ((int)comboBox1.SelectedValue == 1)// provjeri vrijednost odabranog itema iz comboboxa 1 (pravna ili fizička osoba)
            {
                if (this.Controls.Count > 2)
                {
                    this.Controls.RemoveByKey(drugi.Name);
                    this.Controls.Add(prvi);
                }
                else
                {
                    this.Controls.Add(prvi);
                }

            }
            else
            {
                if (this.Controls.Count > 2)
                {
                    this.Controls.RemoveByKey(prvi.Name);
                    this.Controls.Add(drugi);
                }
                else
                {
                    this.Controls.Add(drugi);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if ((int)comboBox1.SelectedValue == 1 && this.ValidateChildren())
            {
                Osoba nova = new Osoba();
                nova.OIB = prvi.OIB;
                nova.Naziv = prvi.Naziv;
                nova.Adresa = prvi.Adresa;
                nova.StatusOsobe = (int)comboBox1.SelectedValue;
                nova.TipOsobe = tip;
                nova.Racun = prvi.Račun;
                nova.Telefon = prvi.Telefon;
                nova.Faks = prvi.Faks;
                nova.Web = prvi.Web;
                
                if (data.DodajOsobu(nova) == true)
                {
                    MessageBox.Show("Uspješno ste dodali osobu: " + prvi.Naziv);
                }
                else
                {
                    MessageBox.Show("Greška pri upisu!");
                }                
            }
            else if ((int)comboBox1.SelectedValue == 2 && this.ValidateChildren())
            {
                Osoba snova = new Osoba();
                snova.OIB = drugi.OIB;
                snova.Ime = drugi.Ime;
                snova.Prezime = drugi.Prezime;
                snova.Adresa = drugi.Adresa;
                snova.Faks = drugi.Faks;
                snova.Telefon = drugi.Telefon;
                snova.Racun = drugi.Račun;
                snova.StatusOsobe = (int)comboBox1.SelectedValue;
                snova.TipOsobe = tip;

                if (data.DodajOsobu(snova) == true)
                {
                    MessageBox.Show("Uspješno ste dodali osobu: " + drugi.Ime + " " + drugi.Prezime);
                }
                else
                {
                    MessageBox.Show("Greška pri upisu!");
                }
            }
        }
    }
}
