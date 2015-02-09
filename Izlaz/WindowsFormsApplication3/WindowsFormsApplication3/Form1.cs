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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpisForm nova = new SpisForm(lista);
            nova.ShowDialog();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Spisi.SpisDodaj novi = new Spisi.SpisDodaj((int)listBox1.SelectedValue);
                novi.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show("Molimo odaberite spis koji želite urediti!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KontaktForm n = new KontaktForm();
            n.ShowDialog();
        }
    }
}
