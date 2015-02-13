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
    public partial class DrugiKorak : UserControl
    {
        DataClass data = new DataClass();
        public DrugiKorak()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            vrstaSudaCmbx.DataSource = data.GetTipInstitucijeList();//punjenje comboboxa direktno iz baze
            vrstaSudaCmbx.DisplayMember = "Naziv";// namještanje vrijednosti koju će prikazivati
            vrstaSudaCmbx.ValueMember = "ID";// namještanje vrijednosti koju će odabirom prikazanog itema iz comboboxa prosljeđivati (combobox.selectedvalue)
            comboBox3.DataSource = data.GetInstitucijaListByID(((int)vrstaSudaCmbx.SelectedIndex));// isto kao i za gore napisano
            comboBox3.DisplayMember = "Naziv";
            comboBox3.ValueMember = "ID";
        }


        #region Properties sva svojstva koja cemo dalje prosljedivati glavnoj formi za akciju spremanja spisa!
        public string Stranka
        {
            get { return (string)comboBox1.SelectedValue; }
            set { comboBox1.SelectedValue = value; }
        }

        public string Protustranka
        {
            get { return (string)comboBox2.SelectedValue; }
            set { comboBox2.SelectedValue = value; }
        }

        public int NadlezniSud
        {
            get { return (int)comboBox3.SelectedValue; }
            set { comboBox3.SelectedValue = value; }
        }

        public int NadlezniSudac
        {
            get { return (int)comboBox4.SelectedValue; }
            set { comboBox4.SelectedValue = value; }
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
            comboBox1.DataSource = data.GetOsobaList(1, 1);
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "OIB";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = !checkBox4.Checked;
            comboBox2.DataSource = data.GetOsobaList(1, 2);
            comboBox2.DisplayMember = "Naziv";
            comboBox2.ValueMember = "OIB";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
            comboBox1.DataSource = data.GetOsobaList(2, 1);
            comboBox1.DisplayMember = "Prezime";
            comboBox1.ValueMember = "OIB";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = !checkBox3.Checked;
            comboBox2.DataSource = data.GetOsobaList(2, 2);
            comboBox2.DisplayMember = "Prezime";
            comboBox2.ValueMember = "OIB";
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedItem == comboBox2.SelectedItem || comboBox1.SelectedItem == null)// validacija comboboxa 1 provjera je su li odabrani itemi u cmbx1 i cmbx2 jednaki ili prazni
            {
                errorProvider1.SetError(comboBox1, "Stranka i protustranka ne mogu biti jednake/prazne!");// postavlja error provider (ikonica crvena sto blinka)
                e.Cancel = true;// zaustavlja korisnika i ne da mi dalje tj, event validacije se zaustavlja --> ne može doći do event validated
            }
            else
            {
                errorProvider1.Clear();// miće sve podatke o erroru
                e.Cancel = false;// validating --> validated
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.SelectedItem == comboBox1.SelectedItem || comboBox2.SelectedItem == null)// isto kao i gornji
            {
                errorProvider2.SetError(comboBox2, "Stranka i protustranka ne mogu biti jednake/prazne!");
                e.Cancel = true;
            }
            else
            {
                errorProvider2.Clear();
                e.Cancel = false;
            }
        }

        private void vrstaSudaCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = data.GetInstitucijaListByID((int)vrstaSudaCmbx.SelectedValue);// ovisno o odabire vrste suda iz ovog cmbx on prikazuje kontakte institucije
            comboBox3.DisplayMember = "Naziv";
            comboBox3.ValueMember = "ID";
            if (comboBox3.Items.Count == 0)//ako nema itema u comboboxu 3 (popis sudova) tada  u cmbx4 (u kojem bi se trebali nalaziti kontakti koji su suci i vezani uz odabranu instituciju) nema ništa
            {
                comboBox4.DataSource = null;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nesto;
            
            if (int.TryParse(comboBox3.SelectedValue.ToString(), out nesto) == true)//ako ima nesto u cmbx napuni cmb4 sa kontaktima
            {
                comboBox4.DataSource = data.GetKontaktiByID((int)comboBox3.SelectedValue, 4);
                comboBox4.DisplayMember = "Prezime";
                comboBox4.ValueMember = "ID";
            }
        }

        private void DrugiKorak_Enter(object sender, EventArgs e)
        {
            comboBox1.Refresh();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsobaDodaj dodaj = new OsobaDodaj(1);
            dodaj.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsobaDodaj dodaj = new OsobaDodaj(2);
            dodaj.ShowDialog();
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox4.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox4, "Odaberite suca ili promijenite sud");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }
    }
}
