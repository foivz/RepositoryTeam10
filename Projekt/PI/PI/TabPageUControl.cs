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
    public partial class TabPageUControl : UserControl
    {
        T10_DBEntities db = new T10_DBEntities();
        Spis trenutniSpis = new Spis();
        public TabPageUControl(Spis spis)
        {
            InitializeComponent();
            trenutniSpis = spis;
            label11.Text = spis.Naziv;
            label12.Text = spis.Oznaka;
            label13.Text = spis.TipPostupka1.Naziv;
            label14.Text = spis.Biljeska;
            label15.Text = spis.DatumPocetka.ToShortDateString(); ;
            label16.Text = spis.Institucija.TipInstitucije1.Naziv + " u " + spis.Institucija.Mjesto1.Naziv;
            label17.Text = spis.Osoba.Ime + " " + spis.Osoba.Prezime;
            label18.Text = spis.Protustranka;
            label19.Text = spis.Odvjetnik.Ime + " " + spis.Odvjetnik.Prezime;
        }
    }
}
