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
    public partial class ModifyMovie : Form
    {
        public ModifyMovie()
        {
            InitializeComponent();
        }

        private void ModifyMovie_Load(object sender, EventArgs e)
        {
            //creación el obejeto empleado
            Pelicula user = new Pelicula();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = PeliculaDAO.ConsultaNombres();
            //se establece el patrón o marca que ayudará para que no se muestren todos los datos en un mismo renglón
            string patron = "-";
            //vacía al combo para después llenarlo
            cmbName.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas = Regex.Split(resultado, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbName.Items.Add(subcadena);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "" || txtGen.Text == "" || txtName.Text == "" || txtPrice.Text == "" || spin.Value.ToString() == "0")
            {
                //mensaje de información que faltan datos para la inserción
                MessageBox.Show("Campos sin rellenar", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Pelicula movie = new Pelicula();
                movie.nombre = txtName.Text.Trim();
                movie.genero = txtGen.Text.Trim();

                //casteo para conversión de cadenas a valores enteros 
                string anio = txtAnio.Text.Trim();
                int a = int.Parse(anio);
                movie.estreno = a;

                string price = txtPrice.Text.Trim();
                float p = float.Parse(price);
                movie.precio = p;

                string exist = spin.Value.ToString();
                int ex = int.Parse(exist);
                movie.existencia = ex;
                //fin de casteo

                //variable que ayuda en la modificación
                string lastname = cmbName.SelectedItem.ToString().Trim();

                //llamar a la función de agregar a la base de datos (EmpleadoDAO)
                int resultado = PeliculaDAO.Modificar(movie, lastname);
                if (resultado > 0)
                {
                    //mensaje de inforamción que el usuario fuen guardado
                    MessageBox.Show("Película guardada con éxito!", "Película Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ahora los campos se vacían para un nuevo registro
                    txtAnio.Text = "";
                    txtGen.Text = "";
                    txtName.Text = "";
                    txtPrice.Text = "";
                }
                else
                {
                    //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                    MessageBox.Show("No se pudo guardar la película", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            //se llama a la ventana principal del empleado
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            //se oculta esta ventana
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //creación del objeto de tipo empleado
            Pelicula Usuario = new Pelicula();
            Usuario.nombre = cmbName.SelectedItem.ToString().Trim();
            Usuario = PeliculaDAO.ObtenerPelicula(Usuario);
            //se llenan los campos de la ventana
            txtName.Text = Usuario.nombre;
            txtGen.Text = Usuario.genero;
            //casteo de los datos que son números
            int an = Usuario.estreno;
            string anio = an.ToString();
            txtAnio.Text = anio;
            double pri = Usuario.precio;
            string precio = pri.ToString();
            txtPrice.Text = precio;
            int va = Usuario.existencia;
            string valor = va.ToString();
            spin.Text = valor;
            //fin de casteo
        }
    }
}
