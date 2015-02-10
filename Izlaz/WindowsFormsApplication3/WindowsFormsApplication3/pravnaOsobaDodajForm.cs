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
    public partial class pravnaOsobaDodajForm : Form
    {
        public pravnaOsobaDodajForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //gumb za izlazak iz forme
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int ab;
            if (int.TryParse(textBox1.Text,out ab) == false)
            {
                errorProvider1.SetError(textBox1, "Samo brojevi!");
            }
            else
            {
                errorProvider1.Clear();
            }
            //provjera da li su unešeni samo brojevi u polje za oib
        }
    }
}
