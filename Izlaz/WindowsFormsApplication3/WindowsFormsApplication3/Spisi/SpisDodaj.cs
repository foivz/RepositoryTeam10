using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3.Spisi
{
    public partial class SpisDodaj : Form
    {
        T10_DBEntities db = new T10_DBEntities();
        DataManipClass data = new DataManipClass();
        public SpisDodaj()
        {
            InitializeComponent();
            List<TipSpisa> list = new List<TipSpisa>();
            list = data.GetTipSpisaList();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
        }
        public SpisDodaj(int SpisID)
        {
            InitializeComponent();
            List<TipSpisa> list = new List<TipSpisa>();
            list = data.GetTipSpisaList();
            comboBox1.DataSource = list;
            comboBox1.Invalidate();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
            Spis n = data.GetSpisByID(SpisID);
            textBox1.Text = n.Naziv;
            textBox2.Text = n.Oznaka;
            comboBox1.SelectedValue = n.Tip;
        }

        public void provjeriTxt()
        {
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item2 in item.Controls)
                    {
                        if (item2 is TextBox)
                        {
                            if (string.IsNullOrWhiteSpace(item2.Text))
                            {
                                item2.BackColor = Color.IndianRed;
                            }
                            else
                            {
                                item2.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Ne može biti prazno");
            }
            else
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Ne može biti prazno");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        public void dodaj()
        {
            T10_DBEntities db = new T10_DBEntities();
            Spis novi = new Spis();
            novi.Naziv = textBox1.Text;
            novi.Oznaka = textBox2.Text;
            novi.TipPostupka = (int)comboBox1.SelectedValue;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsobaDodajForm nova = new OsobaDodajForm();
            nova.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OsobaDodajForm nova = new OsobaDodajForm();
            nova.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
