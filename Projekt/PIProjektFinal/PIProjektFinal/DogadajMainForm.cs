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
    public partial class DogadajMainForm : Form
    {
        DataClass data = new DataClass();
        public DogadajMainForm()
        {
            InitializeComponent();
            this.DisplayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DogadajDodajForm dodaj = new DogadajDodajForm();
            dodaj.ShowDialog();
            dodaj.FormClosed += Dodaj_FormClosed;
        }

        private void Dodaj_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.DeleteDogadaj((int)listBox1.SelectedValue);
            this.DisplayData();
        }

        private void DisplayData()
        {
            listBox1.DataSource = data.GetDogadaji();
            listBox1.DisplayMember = "Naslov";
            listBox1.ValueMember = "ID";
        }

        private void DogadajMainForm_Activated(object sender, EventArgs e)
        {
            this.DisplayData();
        }
    }
}
