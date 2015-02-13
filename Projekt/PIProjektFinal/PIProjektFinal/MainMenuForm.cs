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
    public partial class MainMenuForm : Form
    {
        DataClass data = new DataClass();
        Korisnik korisnikTrenutni = new Korisnik();
        public MainMenuForm(Korisnik korisnik)
        {
            InitializeComponent();
            this.ShowData();
            label2.Text = "Popis spisa koje je kreirao korisnik: " + korisnik.Ime + " " + korisnik.Prezime;
            if (data.ProvjeriOvlasti(korisnik) == true)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
            korisnikTrenutni = korisnik;
        }

        public void ShowData()
        {
            listBox1.DataSource = data.GetSpisByUserID(korisnikTrenutni.ID);
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpisMainForm novi = new SpisMainForm(korisnikTrenutni);
            novi.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 forma = new Form1();
            forma.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PostavkeForm postavke = new PostavkeForm();
            postavke.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DogadajMainForm dogadaji = new DogadajMainForm();
            dogadaji.ShowDialog();
        }

        private void MainMenuForm_Activated(object sender, EventArgs e)
        {
            this.ShowData();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SpisUrediForm uredi = new SpisUrediForm(data.GetSpisByID((int)listBox1.SelectedValue));
            uredi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KontaktiForm kontak = new KontaktiForm();
            kontak.ShowDialog();
        }
    }
}
