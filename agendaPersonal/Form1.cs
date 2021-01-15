using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agendaPersonal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarTabla (null);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // btnBuscar datos
        {
            string dato = txtBuscar.Text;
            cargarTabla(dato);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

            Contactos _contactos = new Contactos();
            
            _contactos.Nombre = txtNombre.Text;
            _contactos.Apellido = txtApellido.Text;
            _contactos.Correo = txtEmail.Text;
            _contactos.Telefono = txtTelefono.Text;
            _contactos.Direccion = txtDireccion.Text;

            CtrlContactos ctrl = new CtrlContactos();

            if (txtId.Text != "")
            {
                _contactos.Id = int.Parse(txtId.Text);
                ctrl.actualiza(_contactos);
                MessageBox.Show("contacto acutalizado");
                limpiar();
                cargarTabla(null);
            }
            else
            {   if (txtNombre.Text != "" || txtApellido.Text != "" || txtEmail.Text != "" || txtTelefono.Text != "" || txtDireccion.Text != "")  { 
                ctrl.insertar(_contactos);
                MessageBox.Show("Contacto guardado");
                limpiar();
                cargarTabla(null);
                }
                else
                {
                    MessageBox.Show("necesita ingresar los datos");
                }

            }


        }

        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtBuscar.Text = "";
            txtDireccion.Text = "";
            
        }

        private void cargarTabla (String dato)
        {
            List < Contactos > lista = new List<Contactos>();
            CtrlContactos _ctContactos = new CtrlContactos();
            dataGridView1.DataSource = _ctContactos.consulta(dato);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("seguro que desea eliminar? ", "salir", MessageBoxButtons.YesNoCancel);
            
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlContactos _ctrl = new CtrlContactos();
                bandera = _ctrl.eliminar(id);

                if (bandera)
                {
                    MessageBox.Show("registro eliminado");
                    limpiar();
                    cargarTabla(null);
                }


            }

        }




    }
}
