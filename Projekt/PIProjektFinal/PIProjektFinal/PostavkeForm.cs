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
    public partial class PostavkeForm : Form
    {
        DataClass data = new DataClass();
        public PostavkeForm()
        {
            InitializeComponent();
            listBox1.DataSource = data.GetKorisnici();
            listBox1.DisplayMember = "KorisnickoIme";
            listBox1.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajKorisnikForm uredi = new DodajKorisnikForm(data.GetKorisnikByID((int)listBox1.SelectedValue));
            uredi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajKorisnikForm dodaj = new DodajKorisnikForm();
            dodaj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Jeste li sigurni da želite izbrisati ovog korisnika?", "Brisanje korisnika iz baze", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                data.DeleteKorisnik((int)listBox1.SelectedValue);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBox1.DataSource = data.GetKorisnici();
            listBox1.DisplayMember = "KorisnickoIme";
            listBox1.ValueMember = "ID";
        }

        private void PostavkeForm_Activated(object sender, EventArgs e)
        {
            listBox1.DataSource = data.GetKorisnici();
            listBox1.DisplayMember = "KorisnickoIme";
            listBox1.ValueMember = "ID";
        }
    }
}
