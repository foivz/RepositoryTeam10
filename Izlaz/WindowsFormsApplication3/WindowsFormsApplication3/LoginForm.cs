using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class LoginForm : Form
    {
        DataManipClass data = new DataManipClass();
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.checkLoginData(maskedTextBox1.Text, textBox2.Text, this);
            //gum za login koji salje unesene podatke datamanipclass-u koji ih provjerava u bazi i omogucuje login
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //gumb za izlazak iz aplikacije
        }
    }
}
