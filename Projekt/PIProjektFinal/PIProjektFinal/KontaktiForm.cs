﻿using System;
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
    public partial class KontaktiForm : Form
    {
        DataClass data = new DataClass();
        public KontaktiForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = data.GetOsobaByUloga(1);
        }
    }
}
