using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PassBackup
{
    public class Backup : INotifyPropertyChanged
    {
        
        //private string title;
        private string site;
        private string url;
        private string login;
        private string pass;
        private string visible;
        private string crupt;
        private string decription;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
        //        OnPropertyChanged("Title");
        //    }
        //}
        public string Site
        {
            get { return site; }
            set
            {
                site = value;
                OnPropertyChanged("site");
            }
        }
        public string URL
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("URL");
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return pass; }
            set
            {
                pass = value;
                OnPropertyChanged("Password");
            }
        }
        public string Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }
        public string Crupt
        {
            get { return crupt; }
            set
            {
                crupt = value;
                OnPropertyChanged("Crupt");
            }
        }
        public string Decription
        {
            get { return decription; }
            set
            {
                decription = value;
                OnPropertyChanged("Decription");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }//*/
        /*public int id { get; set; }
        public string site { get; set; }
        public string URL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Visible { get; set; }
        public string Crupt { get; set; }
        public string Decription { get; set; }*/
    }
}
