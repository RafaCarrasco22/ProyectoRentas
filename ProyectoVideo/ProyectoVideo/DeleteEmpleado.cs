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
    public partial class DeleteEmpleado : Form
    {
        public DeleteEmpleado()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //llamado de la clase admin
            Admin a = new Admin();
            a.Show();
            //oculta esta ventana
            this.Hide();
        }

        private void DeleteEmpleado_Load(object sender, EventArgs e)
        {
            //creación el obejeto empleado
            Empleado user = new Empleado();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = EmpleadoDAO.Consultari();
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

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //llamamos al objeto empleado
            Empleado emp = new Empleado();
            //vamos ingresando datos en el constructor
            emp.num_empleado = cmbCuenta.SelectedItem.ToString().Trim();
            string xx = cmbCuenta.SelectedItem.ToString().Trim();
            int em = int.Parse(xx);

            //llamar a la función de agregar a la base de datos (EmpleadoDAO)
            int resultado = EmpleadoDAO.Eliminar(em);
            if (resultado > 0)
            {
                //mensaje de inforamción que el usuario fuen guardado
                MessageBox.Show("Usuario borrado con éxito!", "Usuario Borrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ahora los campos se vacían para un nuevo registro
                string resultado2 = EmpleadoDAO.Consultari();
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
                MessageBox.Show("No se pudo borrar el usuario", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
