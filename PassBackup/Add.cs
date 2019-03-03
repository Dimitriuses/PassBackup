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

namespace PassBackup
{
    public partial class Add : Form
    {
        //public Acount acount { set; get; }
        public Backup acount { get; private set; }
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        public Add( Backup backup)
        {
            InitializeComponent();
            checkBox1_CheckedChanged(null, null);
            acount = backup;
            textBoxName.Text = acount.Site;
            textBoxURL.Text = acount.URL;
            textBoxLogin.Text = acount.Login;
            textBoxPass.Text = acount.Password;
            richTextBox1.Text = acount.Decription;
            textBoxPass_TextChanged(null, null);

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

            acount.Visible = (acount.Visible == null) ? "False" : acount.Visible;
            acount.Crupt = (acount.Crupt == null) ? "False" : acount.Crupt;
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point point = new Point(0, 80);
            panel1.Location = point;

        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            //label6.Text = textBoxPass.Text.Length.ToString();
            string difficulty = "";
            Color TextColor = SystemColors.Control;
            PasswordScore score = CheckStrength(textBoxPass.Text);
            switch (score)
            {
                case PasswordScore.Blank:
                    difficulty = "None";
                    TextColor = Color.Gray;
                    break;
                case PasswordScore.VeryWeak:
                    difficulty = "VeryWeak";
                    TextColor = Color.Red;
                    break;
                case PasswordScore.Weak:
                    difficulty = "Weak";
                    TextColor = Color.Orange;
                    break;
                case PasswordScore.Medium:
                    difficulty = "Medium";
                    TextColor = Color.Yellow;
                    break;
                case PasswordScore.Strong:
                    difficulty = "Strong";
                    TextColor = Color.YellowGreen;
                    break;
                case PasswordScore.VeryStrong:
                    difficulty = "VeryStrong";
                    TextColor = Color.Green;
                    break;
            }
            label6.Text = $"{difficulty}";
            label6.ForeColor = TextColor;
        }
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
            {
                return PasswordScore.Blank;
            }
            if (password.Length < 2)
            {
                return PasswordScore.VeryWeak;
            }

            if (password.Length >= 4 )
            {
                score++;
            }
            if (password.Length >= 8)
            {
                score++;
            }
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success && Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            return (PasswordScore)score;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 && textBox1.Text != "@-(a-z)&-(A-Z)#-(0-9)$-(!?<>...)")
            {
                const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
                const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string NUMERIC_CHARACTERS = "0123456789";
                const string SPECIAL_CHARACTERS = @"!#$%&*@\";
                string result = "";
                textBoxPass.Text = result;
                Random random = new Random();
                foreach(char ch in textBox1.Text)
                {
                    switch (ch)
                    {
                        case '@':
                            result += LOWERCASE_CHARACTERS[random.Next(LOWERCASE_CHARACTERS.Length)];
                            break;
                        case '&':
                            result += UPPERCASE_CHARACTERS[random.Next(UPPERCASE_CHARACTERS.Length)];
                            break;
                        case '#':
                            result += NUMERIC_CHARACTERS[random.Next(NUMERIC_CHARACTERS.Length)];
                            break;
                        case '$':
                            result += SPECIAL_CHARACTERS[random.Next(SPECIAL_CHARACTERS.Length)];
                            break;
                        default:
                            result += ch;
                            break;
                    }
                }
                textBoxPass.Text = result;
                Point point = new Point(286, 80);
                panel1.Location = point;
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //numericUpDown2.Maximum = numericUpDown1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Point point = new Point(286, 80);
            panel1.Location = point;
        }
    }
}
