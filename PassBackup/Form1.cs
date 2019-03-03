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
            db.Backup.Load();
            dataGridView1.DataSource = db.Backup.Local.ToBindingList();
            //UpdaterTableWiwer();
            //DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(5, 0);
            //dataGridView1_CellDoubleClick(null, e);
            //dataGridView1_CellDoubleClick(null, e);
            
        }

        private void додатиАкаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add form = new Add(new Backup());
            //DataGridViewCheckBoxColumn Visible = new DataGridViewCheckBoxColumn(false);
            //Visible.Checked = false;
            //Visible.CheckState = CheckState.Indeterminate;
            //DataGridViewCheckBoxColumn Crupt = new DataGridViewCheckBoxColumn(false);
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
                backup.id = dataGridView1.RowCount + 1;
                db.Backup.Add(backup);
                db.SaveChanges();
                UpdaterTableWiwer();

            }
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count == 0)
            //{
            //    OpenFileDialog dlg = new OpenFileDialog();
            //    dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
            //    if (dlg.ShowDialog() == DialogResult.OK)
            //    {
            //        pach = true;
            //        SavePach = dlg.FileName;
            //        //UpdateTab();
            //    }
            //}
            //else
            //{
            //    var rez = MessageBox.Show(" ", "Seving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (DialogResult.Yes == rez)
            //    {
            //        OpenFileDialog dlg = new OpenFileDialog();
            //        dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
            //        if (dlg.ShowDialog() == DialogResult.OK)
            //        {
            //            pach = true;
            //            SavePach = dlg.FileName;
            //            //UpdateTab();
            //        }
            //    }
            //}
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
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = " SQLite files (*.sqlite) | *.sqlite";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    SavePach = dlg.FileName;
            //    pach = true;
            //    SQLiteConnection con =
            //    new SQLiteConnection($"Data Source={SavePach}");
            //    con.Open();
            //    string query =
            //        "CREATE TABLE Backup (" +
            //        "Id integer PRIMARY KEY AUTOINCREMENT, " +
            //        "Site text NOT NULL, " +
            //        "URL text NOT NULL, " +
            //        "Login text NOT NULL, " +
            //        "Password text NOT NULL," +
            //        "Visible text NOT NULL"+
            //        "Crupt text NOT NULL"+
            //        "Decription test NOT NULL );";// +
            //    //"TFuelConsumption real NOT NULL";
            //    SQLiteCommand cmd = new SQLiteCommand(query, con);
            //    cmd.ExecuteNonQuery();
            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString()+" "+e.RowIndex.ToString());
            Backup backup = db.Backup.Find(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if(e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (backup != null)
                {
                    switch (e.ColumnIndex)
                    {
                        case 5:
                            backup.Visible = T_bool(backup.Visible);
                            break;
                        case 6:
                            backup.Crupt = T_bool(backup.Crupt);
                            break;
                        default:
                            break;
                    }

                    db.Entry(backup).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdaterTableWiwer();
                }
            }
            else
            {
                
                Add form = new Add(backup);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Backup tmp = form.acount;

                    db.SaveChanges();
                    UpdaterTableWiwer();
                }
            }
        }
        private string T_bool(string B_in)
        {
            return (B_in == "True") ? "False" : (B_in == "False") ? "True" : "False";
        }
        private void UpdaterTableWiwer()
        {
            dataGridView1.Update();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(dataGridView1.Rows[i].Cells[5].Value.ToString() == "True")
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;

                }
                else if(dataGridView1.Rows[i].Cells[5].Value.ToString() == "False")
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.IndianRed;
                    //dataGridView1.Rows[i].Cells[4].Value
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.LightYellow;
                }


                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "True")
                {
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                }
                else if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "False")
                {
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.IndianRed;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Style.BackColor = Color.LightYellow;
                }
            }
            //dataGridView1.Update();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    UpdaterTableWiwer();
        //    timer1.Stop();
        //}

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "False" &&e.Value != null)
            {
                //dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdaterTableWiwer();
        }

        //private void dataGridView1_ControlRemoved(object sender, ControlEventArgs e)
        //{
            
        //}

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var rez = MessageBox.Show("Do you really want to delete it?", "Deleting",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == rez)
            {
                if (e.Row == null) return;
                Backup backup = db.Backup.Find(e.Row.Cells[0].Value);
                db.Backup.Remove(backup);
                db.SaveChanges();
            }
            else if (DialogResult.No == rez)
            {
                //MessageBox.Show("");
                e.Cancel = true;
            }
        }
    }
}
