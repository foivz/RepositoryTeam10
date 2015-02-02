using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI
{
    public partial class MainMenuForm : Form
    {
        DatabaseManipulationClass data = new DatabaseManipulationClass();
        Odvjetnik trenutniKorisnik = new Odvjetnik();
        public MainMenuForm(Odvjetnik korisnik)
        {
            InitializeComponent();
            trenutniKorisnik = korisnik;
            label2.Text = korisnik.Ime + " " + korisnik.Prezime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpisiMainMenuForm form = new SpisiMainMenuForm(trenutniKorisnik);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KontaktiMainMenuForm nova = new KontaktiMainMenuForm();
            nova.ShowDialog();
        }
    }
}
