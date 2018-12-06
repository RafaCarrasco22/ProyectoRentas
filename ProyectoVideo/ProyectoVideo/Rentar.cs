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
    public partial class Rentar : Form
    {
        public Rentar()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            this.Hide();
          
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //creación de los objetos que requiere para rentar
            Cliente cliente = new Cliente();
            Pelicula movie = new Pelicula();
            Empleado employe = new Empleado();

            //verificación de que fueron ingresados todos los datos
            if (cmbCliente.SelectedItem == null || cmbEmp.SelectedItem == null || cmbPeli.SelectedItem == null)
            {
                //mensaje
                MessageBox.Show("Seleccione a un cliente");
            } else
            {
                //obtención de los datos que contiene la ventana
                string c = cmbCliente.SelectedItem.ToString().Trim();
                int clie = int.Parse(c);
                cliente.id = clie;

                string m = cmbPeli.SelectedItem.ToString().Trim();
                int mo = int.Parse(m);
                movie.id = mo;

                string g = cmbEmp.SelectedItem.ToString().Trim();
                int em = int.Parse(g);
                employe.id = em;
                //obtención de la fecha del sistema
                DateTime Hoy = DateTime.Today;
                string fecha_actual = Hoy.ToString("yyyy/MM/dd");

                //se le da formato a la fecha que nos da el datepicker
                dateEntrega.Format = DateTimePickerFormat.Custom;
                dateEntrega.CustomFormat = "yyyy/MM/dd";
                string fecha2 = dateEntrega.Text.Trim();

                //rec.ProximaCita = dateProxCita.Text.Trim();
                string r = PeliculaDAO.ConsultarExistencia(movie);
                MessageBox.Show(r);

                if (r != "Ya no hay películas disponibles")
                {
                    int resultado = RentasDAO.Insertar(movie, cliente, employe, fecha_actual, fecha2);
                    if (resultado > 0)
                    {
                        //mensaje de inforamción que el usuario fuen guardado
                        MessageBox.Show("Renta guardada con éxito!", "Renta Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                        MessageBox.Show("No se pudo guardar el registro", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Rentar_Load(object sender, EventArgs e)
        {
            //creación el obejeto empleado
            Empleado user = new Empleado();
            //por medio de una consulta carga en un combobox a los datos
            string resultado = EmpleadoDAO.ConsultaID();
            //se establece el patrón o marca que ayudará para que no se muestren todos los datos en un mismo renglón
            string patron = "-";
            //vacía al combo para después llenarlo
            cmbEmp.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas = Regex.Split(resultado, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbEmp.Items.Add(subcadena);
            }

           
            //creación el obejeto cliente
            Cliente clie = new Cliente();
            //por medio de una consulta carga en un combobox a los datos
            string resultado2 = ClienteDAO.ConsultaID();
            //vacía al combo para después llenarlo
            cmbCliente.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas2 = Regex.Split(resultado2, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas2)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbCliente.Items.Add(subcadena);
            }

            //creación el obejeto cliente
            Pelicula movie = new Pelicula();
            //por medio de una consulta carga en un combobox a los datos
            string resultado3 = PeliculaDAO.ConsultaID();
            //vacía al combo para después llenarlo
            cmbPeli.Items.Clear();
            //se ingresa en un arreglo a los datos de la consulta
            String[] subcadenas22 = Regex.Split(resultado3, patron);
            // este ciclo se realiza para el llenado del combobox mientras haya datos, ya que esta cantidad suele ser variable
            foreach (var subcadena in subcadenas22)
            {
                //llena al combo con los datos obtenidos de la consulta
                cmbPeli.Items.Add(subcadena);
            }
            
        }

        private void dateEntrega_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione a un cliente");
            }else
            {
                string c = cmbCliente.SelectedItem.ToString().Trim();
                int clie = int.Parse(c);

                Cobrar dd = new Cobrar(clie);
                dd.Show();
                this.Hide();
            }
            
        }
    }
}
