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
    public partial class SpisUrediForm : Form
    {
        DataClass data = new DataClass();
        Spis odbSpis;
        public SpisUrediForm(Spis odabraniSpis)
        {
            InitializeComponent();
            int nesto;
            odbSpis = odabraniSpis;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            textBox1.Text = odabraniSpis.Naziv;
            comboBox1.DataSource = data.GetTipPostupkaList();
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = odabraniSpis.TipPostupka;
            dateTimePicker1.Value = odabraniSpis.DatumPocetka;
            dateTimePicker2.Value = odabraniSpis.DatumZastare.Value;
            if (odabraniSpis.DatumZavrsetak.HasValue == false)
            {
                label6.ForeColor = System.Drawing.Color.Red;
                dateTimePicker2.Value = DateTime.Now;
            }
            else
            {
                dateTimePicker2.Value = odabraniSpis.DatumZavrsetak.Value;
            }
            comboBox6.DataSource = data.GetInstitucijaList();
            comboBox6.DisplayMember = "Naziv";
            comboBox6.ValueMember = "ID";
            if (int.TryParse(comboBox6.ValueMember, out nesto) == false)
            {
                comboBox5.DataSource = data.GetKontaktiByID((int)comboBox6.SelectedValue, 4);
                comboBox5.DisplayMember = "Prezime";
                comboBox5.ValueMember = "ID";
                comboBox5.SelectedValue = odabraniSpis.ID;
            }
            else
            {
                comboBox5.DataSource = null;
            }
            comboBox5.SelectedValue = odabraniSpis.NadlezniSudac;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nesto;
            if (int.TryParse(comboBox6.ValueMember, out nesto) == false)
            {
                comboBox5.DataSource = data.GetKontaktiByID((int)comboBox6.SelectedValue, 4);
                comboBox5.DisplayMember = "Prezime";
                comboBox5.ValueMember = "ID";
                comboBox5.SelectedValue = odbSpis.Kontakt.ID;
            }
            else
            {
                comboBox5.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
