using System;
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
        public string Name { get; set; }
        public string URL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public Add()
        {
            InitializeComponent();
            checkBox1_CheckedChanged(null, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) { textBoxPass.PasswordChar = '*'; }
            else { textBoxPass.PasswordChar ='\0' ; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            URL = textBoxURL.Text;
            Login = textBoxLogin.Text;
            Password = textBoxPass.Text;
            Description = richTextBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComboBox combo = new ComboBox();

        }
    }
}
