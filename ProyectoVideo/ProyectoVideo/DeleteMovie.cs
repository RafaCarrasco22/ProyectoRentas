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
    public partial class DeleteMovie : Form
    {
        public DeleteMovie()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //llamamos al objeto pelicula
            Pelicula emp = new Pelicula();
            //vamos ingresando datos en el constructor
            emp.nombre = cmbCuenta.SelectedItem.ToString().Trim();


            //llamar a la función de agregar a la base de datos (PeliculaDAO)
            int resultado = PeliculaDAO.Eliminar(emp);
            if (resultado > 0)
            {
                //mensaje de inforamción que el usuario fuen guardado
                MessageBox.Show("Película borrada con éxito!", "Película", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ahora los campos se vacían para un nuevo registro
                string resultado2 = PeliculaDAO.ConsultaNombres();
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
                MessageBox.Show("No se pudo borrar la película", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteMovie_Load(object sender, EventArgs e)
        {
            //creación el obejeto pelicula
            Pelicula user = new Pelicula();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = PeliculaDAO.ConsultaNombres();
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
        //en caso de que se desee salir llamamos a la ventana de empleado
        private void btnBack_Click(object sender, EventArgs e)
        {
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            //ocultamos esta ventana
            this.Hide();
        }
    }
}
