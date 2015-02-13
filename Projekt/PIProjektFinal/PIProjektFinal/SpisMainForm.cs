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
    public partial class SpisMainForm : Form
    {
        DataClass data = new DataClass();
        Korisnik korisnikTrenutni = new Korisnik();
        public SpisMainForm(Korisnik korisnik)
        {
            InitializeComponent();
            korisnikTrenutni = korisnik;
            
        }

        public void DisplayData()
        {
            listBox1.DataSource = data.GetAllSpis();
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajNoviSpis dodaj = new DodajNoviSpis(korisnikTrenutni);
            dodaj.ShowDialog();
        }

        private void SpisMainForm_Activated(object sender, EventArgs e)
        {
            this.DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpisUrediForm uredi = new SpisUrediForm(data.GetSpisByID((int)listBox1.SelectedValue));
            uredi.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listBox1.DataSource = data.GetAllSpis();
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.DeleteSpis((int)listBox1.SelectedValue, korisnikTrenutni);
        }
    }
}
