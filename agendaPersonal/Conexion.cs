using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaPersonal
{
    class Conexion
    {
        public MySqlConnection  conexion()
        {
            string usuario = "root";
            string password = "ninguno";
            string bd = "agenda";
            string servidor = "localhost";

            string cadenaDeConexion = "Database= "+ bd +"; " +
                " Data Source=" + servidor+ ";" +
                " User ID= " + usuario + ";" +
                " password= " + password + "";
            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaDeConexion);
                return conexionBD;
            }
            catch (MySqlException ex) 
            {
                Console.WriteLine("error: "+ex.Message);
                return null;
            }
            
        }

    }
}
