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
    public partial class SpisiMainMenuForm : Form
    {
        List<Spis> lista = new List<Spis>();
        DatabaseManipulationClass data = new DatabaseManipulationClass();
        public SpisiMainMenuForm(Odvjetnik korisnik)
        {
            InitializeComponent();
            tabPage1.Text = "PREDMETI";
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            lista = data.getSpis();
            listBox1.DataSource = lista;
            listBox1.DisplayMember = "Naziv";
            listBox1.ValueMember = "ID";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Spis spis = listBox1.SelectedItem as Spis;
            TabPage nova = new TabPage(spis.Naziv);
            TabPageUControl tcp = new TabPageUControl(spis);
            nova.Controls.Add(tcp);
            tabControl1.TabPages.Add(nova);
        }
    }
}
