using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVideo
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        //en caso de que se desee salir llamamos a la ventana del empleado
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void txtCd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que los datos ingresados sean números
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que los datos ingresados sean números
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //verificación de que los campos no estén vacíos
            if (txtName.Text == "" || txtAP.Text == "" || txtAM.Text == "" || txtCP.Text == "" || txtEdad.Text == "" || txtmail.Text == "" || txtDom.Text == "")
            {
                //mensaje de información que faltan datos para la inserción
                MessageBox.Show("Campos sin rellenar", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //llamamos al objeto empleado
                Cliente emp = new Cliente();
                //vamos ingresando datos en el constructor
                emp.nombre = txtName.Text.Trim().ToUpper();
                emp.apPaterno = txtAP.Text.Trim().ToUpper();
                emp.apMaterno = txtAM.Text.Trim().ToUpper();
                emp.direccion = txtDom.Text.Trim();
                emp.cod_postal = txtCP.Text.Trim();
                emp.email = txtmail.Text.Trim();
                //variables auxiliares para castear los datos a int
                string edad = txtEdad.Text.Trim();
                //casteo
                int ed = int.Parse(edad);
                //asignación de los datos faltantes 
                emp.edad = ed;

                //llamar a la función de agregar a la base de datos (EmpleadoDAO)
                int resultado = ClienteDAO.Agregar(emp);
                if (resultado > 0)
                {
                    //mensaje de inforamción que el usuario fuen guardado
                    MessageBox.Show("Usuario guardado con éxito!", "Usuario Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ahora los campos se vacían para un nuevo registro
                    txtAM.Text = "";
                    txtAP.Text = "";
                    txtCP.Text = "";
                    txtDom.Text = "";
                    txtmail.Text = "";
                    txtName.Text = "";
                    txtEdad.Text = "";
                }
                else
                {
                    //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                    MessageBox.Show("No se pudo guardar el usuario", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
