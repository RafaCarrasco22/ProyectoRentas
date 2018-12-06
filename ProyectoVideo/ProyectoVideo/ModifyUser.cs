using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVideo
{
    public partial class ModifyUser : Form
    {
        public ModifyUser()
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

        private void ModifyUser_Load(object sender, EventArgs e)
        {
            //creación el obejeto empleado
            Cliente user = new Cliente();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = ClienteDAO.Consultar();
            //se establece el patrón o marca que ayudará para que no se muestren todos los datos en un mismo renglón
            string patron = "-";
            //vacía al combo para después llenarlo
            cmbCuenta.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas = Regex.Split(resultado, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbCuenta.Items.Add(subcadena);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //verificación de que los campos no estén vacíos
            if (txtName.Text == "" || txtAP.Text == "" || txtAM.Text == "" || txDom.Text == "" || txtCP.Text == "" || txtmail.Text == "" || txtEdad.Text == "")
            {
                //mensaje de información que faltan datos para la inserción
                MessageBox.Show("Campos sin rellenar", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //creación del objeto de tipo empleado
                Cliente Usuario = new Cliente();
                //se obtiene al número de empleado seleccionado en el combobox
                //Usuario.nombre = cmbCuenta.SelectedItem.ToString().Trim();
                string a = cmbCuenta.SelectedItem.ToString();
                string[] separada = a.Split(' ');
                Usuario.nombre = separada[0];
                Usuario.apPaterno = separada[1];
                int id = ClienteDAO.ObtenerId(Usuario);


                //llamamos al objeto empleado
                Cliente emp = new Cliente();
                //vamos ingresando datos en el constructor
                emp.nombre = txtName.Text.Trim().ToUpper();
                emp.apPaterno = txtAP.Text.Trim().ToUpper();
                emp.apMaterno = txtAM.Text.Trim().ToUpper();
                emp.direccion = txDom.Text.Trim();
                emp.cod_postal = txtCP.Text.Trim();
                emp.email = txtmail.Text.Trim();
                //variables auxiliares para castear los datos a int
                string edad = txtEdad.Text.Trim();
                //casteo
                int ed = int.Parse(edad);
                //asignación de los datos faltantes 
                emp.edad = ed;
                
                //llamar a la función de agregar a la base de datos (EmpleadoDAO)
                int resultado = ClienteDAO.Modificar(emp, id);
                if (resultado > 0)
                {
                    //mensaje de inforamción que el usuario fuen guardado
                    MessageBox.Show("Usuario guardado con éxito!", "Usuario Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ahora los campos se vacían para un nuevo registro
                    txtAM.Text = "";
                    txtAP.Text = "";
                    txtCP.Text = "";
                    txDom.Text = "";
                    txtmail.Text = "";
                    txtName.Text = "";
                    txtEdad.Text = "";

                    //ahora los campos se vacían para un nuevo registro
                    string resultado2 = ClienteDAO.Consultar();
                    string patron = "-";
                    cmbCuenta.Items.Clear();
                    //se actualiza al combobox xd
                    String[] subcadenas = Regex.Split(resultado2, patron);
                    foreach (var subcadena in subcadenas)
                    {
                        cmbCuenta.Items.Add(subcadena);
                    }
                    //se resetea al combo
                    cmbCuenta.ResetText();
                }
                else
                {
                    //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                    MessageBox.Show("No se pudo guardar el usuario", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //función que valida que solo se ingresen números y no caracteres
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        //función que valida que solo se ingresen números y no caracteres
        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        //función que valida que solo se ingresen números y no caracteres
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        //función que ayuda al llenado de los campos al seleccionar un cliente
        private void btnFind_Click(object sender, EventArgs e)
        {
            //creación del objeto de tipo empleado
            Cliente Usuario = new Cliente();
            //se obtiene al número de empleado seleccionado en el combobox
            //Usuario.nombre = cmbCuenta.SelectedItem.ToString().Trim();
            string a = cmbCuenta.SelectedItem.ToString();
            string [] separada = a.Split(' ');
            Usuario.nombre = separada[0];
            Usuario.apPaterno = separada[1];

            //en la función obtener empleado se obtienen todos los datos del empleado
            Usuario = ClienteDAO.ObtenerCliente(Usuario);
            //se llenan los campos de la ventana
            txtName.Text = Usuario.nombre;
            txtAP.Text = Usuario.apPaterno;
            txtAM.Text = Usuario.apMaterno;
            txtCP.Text = Usuario.cod_postal;
            txDom.Text = Usuario.direccion;
            txtmail.Text = Usuario.email;
            //casteo de los datos que son números
            int edad = Usuario.edad;
            string c = edad.ToString();
            txtEdad.Text = c;
            
        }
    }
}
