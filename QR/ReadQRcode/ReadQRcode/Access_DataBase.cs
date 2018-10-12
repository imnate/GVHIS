using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ReadQRcode
{
    class Access_DataBase
    {
        public static OleDbConnection DB_Conn_Open(string db)
        {
            OleDbConnection conn = new OleDbConnection(db);
            conn.Open();
            return conn;
        }
        public bool Check_Admin(string psw)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=admin;Data Source=C:\\Users\\info\\Desktop\\QR\\SystemDB.accdb;";
            using (OleDbCommand cmd = new OleDbCommand())
            {
                OleDbDataReader dr;
                cmd.Connection = DB_Conn_Open(connectionString);
                cmd.CommandText = "SELECT * FROM admin WHERE account='admin' And psw='" + psw + "'";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
