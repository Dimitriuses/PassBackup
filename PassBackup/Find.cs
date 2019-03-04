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
    public partial class Find : Form
    {
        private ApplicationContext db;
        public Find (ApplicationContext context)
        {
            InitializeComponent();
            db = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($" combobox - {comboBox1.SelectedIndex} and find {textBox1.Text}");
            int tmp = ComboBoxId_To_Cell(comboBox1.SelectedIndex);
            if(tmp != -1)
            {
                
            }
            else
            {

            }
        }

        private int ComboBoxId_To_Cell(int id)
        {
            switch (id)
            {
                case 0:
                    return -1;
                    break;
                case 1:
                    return 1;
                    break;
                case 2:
                    return 2;
                    break;
                case 3:
                    return 3;
                    break;
                case 4:
                    return 4;
                    break;
                case 5:
                    return 7;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
