using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaPersonal
{
    class Contactos
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private string telefono;
        private string direccion;
        private string fecha_guardado;
        private string fecha_modificado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Fecha_guardado { get => fecha_guardado; set => fecha_guardado = value; }
        public string Fecha_modificado { get => fecha_modificado; set => fecha_modificado = value; }
    }
}
