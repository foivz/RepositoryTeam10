using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        DataManipClass data = new DataManipClass();
        List<Spis> lista = new List<Spis>();
        public Form1(Odvjetnik korisnik)
        {
            lista = data.GetSpisByUserID(korisnik.ID);
            InitializeComponent();
            label2.Text = "Popis spisa koje je kreirao korisnik: " + korisnik.Ime + " " + korisnik.Prezime;
            label4.Text = korisnik.Ime + " " + korisnik.Prezime;
            listBox1.DataSource = lista;
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
            //prikazuje podatke o ulogiranom korisniku, korisniku koji je kreirao spis i puni listbox s vrijednostima, odnosno spisima
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpisForm nova = new SpisForm(lista);
            nova.ShowDialog();
            //instancira novu formu sa spisima
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Spisi.SpisDodaj novi = new Spisi.SpisDodaj((int)listBox1.SelectedValue);
                novi.ShowDialog();
                //prikazuje prozor za dodavanje novih spisa
            }
            catch (Exception)
            {

                MessageBox.Show("Molimo odaberite spis koji želite urediti!");
                //javlja pogresku ako nije odabran spis
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KontaktForm n = new KontaktForm();
            n.ShowDialog();
            //instancira formu za prikaz kontakti
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
            //gumb za izlazak iz aplikacije
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
            //gumb za odjavu korisnika, odnosno prikaz login forme
        }
    }
}
