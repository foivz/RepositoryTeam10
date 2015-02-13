using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProjektFinal.WizardDodajDogadaj
{
    public partial class PovezanostSpisDog : UserControl
    {
        DataClass data = new DataClass();
        Spis nesto = new Spis();
        public PovezanostSpisDog()
        {
            InitializeComponent();
        }

        public void GetSpisByStranka(string OIB)
        {
            listBox1.DataSource = data.GetSpisByOIB(OIB);
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }
        
        public void GetSpis()
        {
            listBox1.DataSource = data.GetAllSpis();
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nesto = listBox1.SelectedItem as Spis;
            linkLabel1.Text = nesto.Naziv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nesto = listBox1.SelectedItem as Spis;
            linkLabel1.Text = nesto.Naziv;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nesto = listBox1.SelectedItem as Spis;
            SpisUrediForm spis = new SpisUrediForm(nesto);
            spis.ShowDialog();
        }

        public int SpisID
        {
            get { return (int)listBox1.SelectedValue; }
            set { listBox1.SelectedValue = value; }
        }
    }
}
