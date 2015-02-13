using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace PIProjektFinal.WizardDodajSpis
{
    public partial class TreciKorak : UserControl
    {
        
        public TreciKorak()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker3.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
        }



        #region Public properties

        public DateTime DatumPocetka
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public DateTime DatumZavrsetka
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker2.Value = value; }
        }

        public DateTime DatumZastare
        {
            get { return dateTimePicker3.Value; }
            set { dateTimePicker3.Value = value; }
        }

        public bool NepoznatDatumZav
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }


        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            Debug.WriteLine(dateTimePicker1.Value.ToShortDateString());
            this.ValidateChildren();
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            int rez = 0;
            rez = DateTime.Compare(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            Debug.WriteLine(rez);
            if (rez >= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(dateTimePicker1, "Ne može biti manji ili isti datum");
                errorProvider2.SetError(dateTimePicker2, "Provjerite datume!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
                errorProvider2.Clear();
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            int rez = 0;
            rez = DateTime.Compare(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            Debug.WriteLine(rez);
            if (rez >= 0)
            {
                e.Cancel = true;
                errorProvider2.SetError(dateTimePicker2, "Provjerite datume!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.Clear();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }

        private void dateTimePicker3_Validating(object sender, CancelEventArgs e)
        {
            int rez = 0;
            rez = DateTime.Compare(dateTimePicker3.Value.Date, dateTimePicker2.Value.Date);
            Debug.WriteLine(rez);
            if (rez <= 0)
            {
                e.Cancel = true;
                errorProvider3.SetError(dateTimePicker3, "Provjerite datume!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.Clear();
            }
        }
    }
}
