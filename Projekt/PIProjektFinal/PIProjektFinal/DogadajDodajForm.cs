using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIProjektFinal.WizardDodajDogadaj;

namespace PIProjektFinal
{
    public partial class DogadajDodajForm : Form
    {
        OsnoviPodaciDog op = new OsnoviPodaciDog();
        SudioniciDog sud = new SudioniciDog();
        PovezanostSpisDog pov = new PovezanostSpisDog();
        DataClass data = new DataClass();

        public DogadajDodajForm()
        {
            InitializeComponent();
            tabPage1.Controls.Add(op);
            tabPage2.Controls.Add(sud);
            tabPage3.Controls.Add(pov);
            button3.Enabled = false;
            button1.Enabled = false;
            label1.Text = tabControl1.SelectedTab.Text;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedIndex > 0)
            {
                if (sud.SudjelujeStranka == true)
                {
                    pov.GetSpisByStranka(sud.StrankaOIB);
                }
                else
                {
                    pov.GetSpis();
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            UserControl nesto = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as UserControl;
            if (nesto.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dogadaj novi = new Dogadaj();
            novi.Naslov = op.Naslov;
            novi.Opis = op.Opis;
            novi.Pocetak = op.Pocetak;
            novi.Zavrsetak = op.Zavrsetak;
            novi.TipDogadaja = op.TipDogadaja;
            if (sud.SudjelujeStranka == true)
            {
                data.DodajDogadaj(novi, pov.SpisID);
                OdvjetnikStrankaImajuDogadaj odvstr = new OdvjetnikStrankaImajuDogadaj();
                odvstr.OdvjetnikID = sud.OdvjetnikID;
                odvstr.StrankaOIB = sud.StrankaOIB;
                odvstr.Dogadaj = novi;
                data.DodajOdvStrDog(odvstr);
                MessageBox.Show("Uspješno ste dodali događaj!");
            }
            else
            {
                data.DodajDogadaj(novi, pov.SpisID, sud.OdvjetnikID);
                data.GetSpisByID(pov.SpisID).Dogadaj.Add(novi);
                data.DodajDogadaj(novi);
                MessageBox.Show("Uspješno ste dodali događaj!");
                this.Close();
            }
        }
    }
}
