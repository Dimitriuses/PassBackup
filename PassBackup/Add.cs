﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassBackup
{
    public partial class Add : Form
    {
        //public Acount acount { set; get; }
        public Backup acount { get; set; }
        public Add()
        {
            InitializeComponent();
            checkBox1_CheckedChanged(null, null);
            acount = new Backup();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) { textBoxPass.PasswordChar = '*'; }
            else { textBoxPass.PasswordChar ='\0' ; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acount.Site = textBoxName.Text;
            acount.URL = textBoxURL.Text;
            acount.Login = textBoxLogin.Text;
            acount.Password = textBoxPass.Text;
            acount.Decription = richTextBox1.Text;

            acount.Visible = "False";
            acount.Crupt = "False";
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComboBox combo = new ComboBox();

        }
    }
}
