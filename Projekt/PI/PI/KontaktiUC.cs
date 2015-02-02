using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI
{
    public partial class KontaktiUC : UserControl
    {
        public KontaktiUC(Kontakt kontakt)
        {
            InitializeComponent();
            label7.Text = kontakt.Ime;
            label8.Text = kontakt.Prezime;
            label9.Text = kontakt.Adresa;
            label10.Text = kontakt.UlogaKontakta.Naziv;
            label11.Text = kontakt.Telefon;
            label12.Text = kontakt.email;
        }
    }
}
