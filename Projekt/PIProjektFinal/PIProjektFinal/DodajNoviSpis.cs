using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal
{
    public partial class DodajNoviSpis : Form
    {
        WizardDodajSpis.PrviKorak prvi = new WizardDodajSpis.PrviKorak();
        WizardDodajSpis.DrugiKorak drugi = new WizardDodajSpis.DrugiKorak();
        WizardDodajSpis.TreciKorak treci = new WizardDodajSpis.TreciKorak();
        DataClass data = new DataClass();
        Korisnik korisnikTrenutni = new Korisnik();
        public DodajNoviSpis(Korisnik korisnik)
        {
            InitializeComponent();
            button3.Enabled = false;
            button1.Enabled = false;
            tabPage1.Controls.Add(prvi);
            tabPage2.Controls.Add(drugi);
            tabPage3.Controls.Add(treci);
            label1.Text = tabControl1.SelectedTab.Text;
            korisnikTrenutni = korisnik;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedIndex > 0)
            {
                button1.Enabled = false;
                button3.Enabled = true;
                if (tabControl1.SelectedIndex == 2)
                {
                    button2.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {
                    button2.Enabled = true;
                }
            }
            else
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    button3.Enabled = false;
                }

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserControl nesto = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as UserControl;
            if (nesto.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl nesto = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as UserControl;
            if (nesto.ValidateChildren())
            {
                Spis novi = new Spis();
                novi.Naziv = prvi.Naziv;
                novi.TipPostupka = prvi.TipSpisa;
                novi.Biljeska = prvi.Biljeska;
                novi.Stranka = drugi.Stranka;
                novi.Protustranka = drugi.Protustranka;
                novi.NadlezniSud = drugi.NadlezniSud;
                novi.NadlezniSudac = drugi.NadlezniSudac;
                novi.DatumPocetka = treci.DatumPocetka;
                if (treci.NepoznatDatumZav == true)
                {
                    novi.DatumZavrsetak = null;
                }
                else
                {
                    novi.DatumZavrsetak = treci.DatumZavrsetka;
                }
                novi.DatumZastare = treci.DatumZastare;
                novi.KreiraoOdvjetnik = korisnikTrenutni.ID;
                data.DodajSpis(novi);
                MessageBox.Show("Uspješno ste dodali spis " + prvi.Naziv);
                this.Close();
            }
            
        }
    }
}
