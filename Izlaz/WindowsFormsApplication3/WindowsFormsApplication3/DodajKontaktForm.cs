using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsFormsApplication3
{
    public partial class DodajKontaktForm : Form
    {
        T10_DBEntities db = new T10_DBEntities();
        List<UlogaKontakta> uloga = new List<UlogaKontakta>();

        public DodajKontaktForm()
        {
            InitializeComponent();
            uloga = db.UlogaKontakta.ToList();
            comboBox1.DataSource = uloga;
            comboBox1.DisplayMember = "Naziv";
            comboBox2.ValueMember = "ID";
            //puni combobox sa ulogom kontakta i nazivima institucije kontakta koji se povlace iz baze preko id-a 
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            maskedTextBox2.BackColor = Color.White;
            Regex novi = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match rez = novi.Match(maskedTextBox2.Text);
            if (rez.Success)
            {
                button1.Enabled = true;
                maskedTextBox2.ForeColor = Color.Black;
            }
            else
            {
                ToolTip toltip = new ToolTip();
                toltip.Show("Nije email adresa", maskedTextBox1, maskedTextBox1.Location, 3000);
                toltip.IsBalloon = true;
                button1.Enabled = false;
                maskedTextBox2.ForeColor = Color.Red;
            }
            //provjerava da li je unešena e-mail adresa, ukoliko nije text je crven i javlja pogrešku
        }

        private void button1_Click(object sender, EventArgs e)
        {
            provjeriTxt();
            Regex novi = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match rez = novi.Match(maskedTextBox2.Text);
            if (rez.Success)
            {                
                DialogResult dialogResult = MessageBox.Show(this, "Jeste li sigurni da želite spremiti kontakt?", "Spremanje kontakta", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //spremi kontakt
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                    //odustajanje od novog kontakta
                }
            }
                //unošenje podataka novog korisnika i poruka da li korisnik želi spremiti novi kontakt
            else
            {
                ToolTip toltip = new ToolTip();
                toltip.Show("Nije email adresa", maskedTextBox1, maskedTextBox1.Location, 3000);
                maskedTextBox2.BackColor = Color.Red;
                //provjerava da li je unešena e-mail adresa, ukoliko nije text je crven i javlja pogrešku
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //zatvara formu
        }

        public void provjeriTxt()
        {
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        if (item2 is TextBox)
                        {
                            if (string.IsNullOrWhiteSpace(item2.Text))
                            {
                                item2.BackColor = Color.IndianRed;
                            }
                            else
                            {
                                item2.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
            //provjera da li su određena polja ostala prazna
        }
    }
}
