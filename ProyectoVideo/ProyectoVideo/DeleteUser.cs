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
    public partial class DeleteUser : Form
    {
        public DeleteUser()
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

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            //creación el obejeto cliente
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //creación del objeto de tipo cliente
            Cliente Usuario = new Cliente();
            //se obtiene al número de empleado seleccionado en el combobox
            //Usuario.nombre = cmbCuenta.SelectedItem.ToString().Trim();
            string a = cmbCuenta.SelectedItem.ToString();
            string[] separada = a.Split(' ');
            Usuario.nombre = separada[0];
            Usuario.apPaterno = separada[1];
            int id = ClienteDAO.ObtenerId(Usuario);

            //llamar a la función de agregar a la base de datos (ClienteDAO)
            int resultado = ClienteDAO.Eliminar(id);
            if (resultado > 0)
            {
                //mensaje de inforamción que el usuario fue guardado
                MessageBox.Show("Usuario borrado con éxito!", "Usuario Borrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No se pudo borrar el usuario", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
