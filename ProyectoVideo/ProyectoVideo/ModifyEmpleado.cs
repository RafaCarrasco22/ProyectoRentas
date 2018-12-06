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
    public partial class ModifyEmpleado : Form
    {
        //id global para encontrar el registro correcto a modificar
        int id = 0;
        public ModifyEmpleado()
        {
            InitializeComponent();
        }
        //función en caso de que se desee regresar a la ventana de admin
        private void btnBack_Click(object sender, EventArgs e)
        {
            //llamado de la casle admin
            Admin a = new Admin();
            a.Show();
            //oculta esta ventana
            this.Hide();
        }

        private void ModifyEmpleado_Load(object sender, EventArgs e)
        {
            //creación el obejeto empleado
            Empleado user = new Empleado();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = EmpleadoDAO.Consultari();
            //se establece el patrón o marca que ayudará para que no se muestren todos los datos en un mismo renglón
            string patron = "-";
            //vacía al combo para después llenarlo
            cmbId.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas = Regex.Split(resultado, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbId.Items.Add(subcadena);
            }
        }
        //función que rellena a los campos de la ventana
        private void btnFind_Click(object sender, EventArgs e)
        {
            //creación del objeto de tipo empleado
            Empleado Usuario = new Empleado();
            //se obtiene al número de empleado seleccionado en el combobox
            Usuario.num_empleado = cmbId.SelectedItem.ToString().Trim();
            
            //en la función obtener empleado se obtienen todos los datos del empleado
            Usuario = EmpleadoDAO.ObtenerEmpleado(Usuario);
            //se llenan los campos de la ventana
            txtName.Text = Usuario.nombre;
            txtAP.Text = Usuario.apPaterno;
            txtAM.Text = Usuario.apMaterno;
            txtCP.Text = Usuario.cod_postal;
            txtDir.Text = Usuario.direccion;
            //casteo de los datos que son números
            int edad = Usuario.edad;
            string a = edad.ToString();
            txtEdad.Text = a;
            int venta = Usuario.num_ventas;
            string b = venta.ToString();
            txtVentas.Text = b;
           


        }
        //función que valida que solo se ingresen números y no caracteres
        private void txtVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //verificación de que los campos no estén vacíos
            if (txtName.Text == "" || txtAP.Text == "" || txtAM.Text == "" || txtDir.Text == "" || txtCP.Text == "" || txtVentas.Text == "" || txtEdad.Text == "")
            {
                //mensaje de información que faltan datos para la inserción
                MessageBox.Show("Campos sin rellenar", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //llamamos al objeto empleado
                Empleado emp = new Empleado();
                //vamos ingresando datos en el constructor
                emp.nombre = txtName.Text.Trim().ToUpper();
                emp.apPaterno = txtAP.Text.Trim().ToUpper();
                emp.apMaterno = txtAM.Text.Trim().ToUpper();
                emp.direccion = txtDir.Text.Trim();
                emp.cod_postal = txtCP.Text.Trim();
                emp.num_empleado = cmbId.SelectedItem.ToString().Trim();
                //variables auxiliares para castear los datos a int
                string edad = txtEdad.Text.Trim();
                string ventas = txtVentas.Text.Trim();
                //casteo
                int ed = int.Parse(edad);
                int ven = int.Parse(ventas);
                //asignación de los datos faltantes 
                emp.edad = ed;
                emp.num_ventas = ven;
                
               

                //llamar a la función de agregar a la base de datos (EmpleadoDAO)
                int resultado = EmpleadoDAO.Modificar(emp);
                if (resultado > 0)
                {
                    //mensaje de inforamción que el usuario fuen guardado
                    MessageBox.Show("Usuario guardado con éxito!", "Usuario Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ahora los campos se vacían para un nuevo registro
                    txtAM.Text = "";
                    txtAP.Text = "";
                    txtCP.Text = "";
                    txtDir.Text = "";
                    txtVentas.Text = "";
                    txtName.Text = "";
                    txtEdad.Text = "";

                    //ahora los campos se vacían para un nuevo registro
                    string resultado2 = EmpleadoDAO.Consultari();
                    string patron = "-";
                    cmbId.Items.Clear();
                    //se actualiza al combobox xd
                    String[] subcadenas = Regex.Split(resultado2, patron);
                    foreach (var subcadena in subcadenas)
                    {
                        cmbId.Items.Add(subcadena);
                    }
                    //se resetea al combo
                    cmbId.ResetText();
                }
                else
                {
                    //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                    MessageBox.Show("No se pudo guardar el usuario", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //función que valida que solo se ingresen números y no caracteres
        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }
        //función que valida que solo se ingresen números y no caracteres
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}
