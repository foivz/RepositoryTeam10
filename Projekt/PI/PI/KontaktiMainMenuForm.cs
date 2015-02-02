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
    public partial class KontaktiMainMenuForm : Form
    {
        DatabaseManipulationClass data = new DatabaseManipulationClass();
        public KontaktiMainMenuForm()
        {
            InitializeComponent();
        }

        private void KontaktiMainMenuForm_Load(object sender, EventArgs e)
        {
            List<Kontakt> kontakti = data.getKontakti();
            listBox1.DataSource = kontakti;
            listBox1.DisplayMember = "Prezime";
            listBox1.ValueMember = "ID";
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Kontakt n = new Kontakt();
            n = listBox1.SelectedItem as Kontakt;
            KontaktiUC nova = new KontaktiUC(n);
            TabPage nov = new TabPage(n.Prezime);
            nov.Controls.Add(nova);
            tabControl1.TabPages.Add(nov);
        }
    }
}
