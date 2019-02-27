using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassBackup
{
    public partial class Form1 : Form
    {
        public bool pach { get; set; }
        private string SavePach;
       
        ApplicationContext db;

        public Form1()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Backups.Load();
            dataGridView1.DataSource = db.Backups.Local.ToBindingList();
           
        }

        private void додатиАкаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add form = new Add();
            DataGridViewCheckBoxColumn Visible = new DataGridViewCheckBoxColumn(false);
            //Visible.Checked = false;
            //Visible.CheckState = CheckState.Indeterminate;
            DataGridViewCheckBoxColumn Crupt = new DataGridViewCheckBoxColumn(false);
            //Crupt.Checked = false;
            //Crupt.CheckState = CheckState.Indeterminate;
            if(form.ShowDialog() == DialogResult.OK)
            {
                //var id = Guid.NewGuid();
                //object[] item =
                //{
                //    id,
                //    form.Name,
                //    form.URL,
                //    form.Login,
                //    form.Password,
                //    Visible,
                //    Crupt,
                //    form.Description
                //};


                //dataGridView1.DataSource = LogPass;
                //dataGridView1.DataMember = "Backup";

                Backup backup = form.acount;
                db.Backups.Add(backup);
                db.SaveChanges();
                dataGridView1.Update();

            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pach = true;
                    SavePach = dlg.FileName;
                    //UpdateTab();
                }
            }
            else
            {
                var rez = MessageBox.Show(" ", "Seving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == rez)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pach = true;
                        SavePach = dlg.FileName;
                        //UpdateTab();
                    }
                }
            }
        }

        //private void UpdateTab()
        //{
        //    SQLiteConnection sqliteConnection = new SQLiteConnection($"Data Source={SavePach}");
        //    DataTable table = new DataTable();
        //    var sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM Backup", sqliteConnection);
        //    var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
        //    sqliteAdapter.Update(table);
        //    foreach (DataRow item in table.Rows)
        //    {
        //        LogPass.Backup.Rows.Add(item);
        //    }
        //    //LogPass.Tables.Add(table);
        //    //dataGridView1.DataSource = LogPass;
        //    //dataGridView1.DataMember = "Backup";
        //    dataGridView1.Update();
        //}

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SavePach = dlg.FileName;
                pach = true;
                SQLiteConnection con =
                new SQLiteConnection($"Data Source={SavePach}");
                con.Open();
                string query =
                    "CREATE TABLE Backup (" +
                    "Id integer PRIMARY KEY AUTOINCREMENT, " +
                    "Site text NOT NULL, " +
                    "URL text NOT NULL, " +
                    "Login text NOT NULL, " +
                    "Password text NOT NULL," +
                    "Decription test NOT NULL );";// +
                //"TFuelConsumption real NOT NULL";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
