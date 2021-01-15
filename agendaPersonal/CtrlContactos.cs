using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaPersonal
{
    class CtrlContactos: Conexion
    {
        public List<Object> consulta (String dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                // sql = "SELECT id, nombre, apellido, correo, telefono, direccion, fecha_guardado FROM contactos ORDER BY nombre ASC";
                sql = "CALL muestra_contactos()";
            }
            else
            {
                // sql = "SELECT id, nombre, apellido, correo, telefono, direccion, fecha_guardado FROM contactos WHERE nombre LIKE'%" + dato + "%'";
                sql = "CALL busqueda('"+dato+"')";
            }
                try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Contactos _contactos = new Contactos();
                        _contactos.Id = int.Parse(reader.GetString("id"));
                        _contactos.Nombre = reader.GetString("nombre");
                        _contactos.Apellido = reader.GetString("apellido");
                        _contactos.Correo = reader.GetString("correo");
                        _contactos.Telefono = reader.GetString("telefono");
                         _contactos.Direccion = reader[5].ToString();
                        _contactos.Fecha_guardado = reader.GetString("fecha_guardado");
                        _contactos.Fecha_modificado = reader[7].ToString();  // de esta manera no genera error al verificar datos null
                    lista.Add(_contactos); // se coloca para agregar la lista recien instanciada
                }

            } catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return lista;

        }

        public bool insertar(Contactos datos)
        {
            bool bandera = false;
            string sql = "CALL nuevo_contacto(" +
                "'" + datos.Nombre + "'," +
                " '" + datos.Apellido + "'," +
                " '" + datos.Correo + "'," +
                " '" + datos.Telefono + "'," +
                " '" + datos.Direccion + "')";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }

            return bandera;
        }

        public bool actualiza( Contactos datos)
        {
            bool bandera = false;
            string sql = "CALL update_contacto ('" + datos.Id + "','" + datos.Nombre + "'," +
                "'" + datos.Apellido + "'," +
                "'" + datos.Correo + "'," +
                "'" + datos.Telefono + "'," +
                "'" + datos.Direccion + "') " ;

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;

            }catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }

            return bandera;

        }

        public bool eliminar (int id)
        {
            bool bandera = false;
            string sql = "CALL eliminar('" + id + "')";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }


    }
}
