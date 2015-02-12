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
    public partial class KontaktForm : Form
    {
        T10_DBEntities db = new T10_DBEntities();
        List<Kontakt> kontakti = new List<Kontakt>();
        public KontaktForm()
        {
            InitializeComponent();
            kontakti = db.Kontakt.ToList();
            dataGridView1.DataSource = kontakti;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["uloga"].Visible = false;
            dataGridView1.Columns["Uloga1"].Visible = false;
            dataGridView1.Columns["UlogaKontakta"].Visible = false;
            dataGridView1.Columns["Institucija"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajKontaktForm dodaj = new DodajKontaktForm();
            dodaj.ShowDialog();
        }
    }
}
