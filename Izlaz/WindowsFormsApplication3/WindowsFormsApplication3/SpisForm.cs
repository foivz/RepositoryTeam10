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
    public partial class SpisForm : Form
    {
        public SpisForm(List<Spis> listaSpisa)
        {
            InitializeComponent();
            listBox1.DataSource = listaSpisa;
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Spisi.SpisDodaj novi = new Spisi.SpisDodaj();
            novi.ShowDialog();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Spisi.SpisDodaj novi = new Spisi.SpisDodaj((int)listBox1.SelectedValue);
            novi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
