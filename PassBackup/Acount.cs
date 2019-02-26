using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassBackup
{
     public class Acount
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        public object[] To_DataTable(DataTable table)
        {
            object[] row =
            {
                table.Rows.Count + 1,
                Name,
                URL,
                Login,
                Password,
                "False",
                "False",
                Description
            };
            return row;
        }
    }
}
