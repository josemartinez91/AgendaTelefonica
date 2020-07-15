using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace My_Agenda
{
    class Conexion
    {
        public static SQLiteConnection conectar()
        {
           // string database = Application.StartupPath + "\\AgendaTelefonica.db;";
            SQLiteConnection cn = new SQLiteConnection("Data Source = C:/Users/Jose/Desktop/AgendaTelefonica.db");
            return cn;
        }

        
    }
}
