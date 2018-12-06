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
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que los datos ingresados sean números
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        //en caso de que se desee salir llamamos a la ventana de empleado
        private void btnCancela_Click(object sender, EventArgs e)
        {
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            //ocultamos esta ventana
            this.Hide();
        }
        //botón para guardar la información
        private void btnSave_Click(object sender, EventArgs e)
        {
            //verificación que no haya campos vacíos
            if (txtAnio.Text == "" || txtGen.Text == "" || txtName.Text == "" || txtPrice.Text == "" || spin.Value.ToString() == "0")
            {
                //mensaje de información que faltan datos para la inserción
                MessageBox.Show("Campos sin rellenar", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
            {
                //creación de un objeto de tipo película
                Pelicula movie = new Pelicula();
                //asignación de los valores para la inserción en la base de datos
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
                //fin casteo

                //llamar a la función de agregar a la base de datos (EmpleadoDAO)
                int resultado = PeliculaDAO.Agregar(movie);
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

        private void AddMovie_Load(object sender, EventArgs e)
        {

        }
    }
}
