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
    public partial class FormEmpleado : Form
    {
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de login
            Form1 f = new Form1();
            f.Show();
            //ocultamos esta ventana
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de agregar usuario
            AddUser au = new AddUser();
            au.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de modificar usuario
            ModifyUser mu = new ModifyUser();
            mu.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de eliminar usuario
            DeleteUser du = new DeleteUser();
            du.Show();
            //ocultamos esta ventana
            this.Hide();
        }
        //se llena la tabla principal
        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            //función para llenar la tabla
            PeliculaDAO.MostrarPeliculas(tabBusqueda);
            tabBusqueda.Width = this.Width;


            //obtención de la fecha del sistema
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("yyyy/MM/dd");
            //se eliminan todas aquellas películas que haya pasado el día de entrega
            RentasDAO.EliminarPorDiaEntrega(fecha_actual);

        }

        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana rentar
            Rentar r = new Rentar();
            r.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de ver las rentas
            VerRentas vr = new VerRentas();
            vr.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarPelículaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de agregar pelicula
            AddMovie am = new AddMovie();
            am.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void modificarPelículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de modificar pelicula
            ModifyMovie mm = new ModifyMovie();
            mm.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void eliminarPelículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se llama a la ventana de eliminar pelicula
            DeleteMovie dm = new DeleteMovie();
            dm.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void tabBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //en caso de dar al botón de refresh se refresca la tabla y queda original
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PeliculaDAO.MostrarPeliculas(tabBusqueda);
            txtBusqueda.Text = "";
        }
        //función para buscar dependiendo la categoría seleccionada a la pelicula
        private void btnFind_Click(object sender, EventArgs e)
        {
            //obtención de los datos ingresados
            int combo = cmbBusca.SelectedIndex;
            string busqueda = txtBusqueda.Text.Trim();
            //switch para la actualización de la tabla principal
            switch (combo)
            {
                case 0:
                    //llamado a la función que filtra por nombre
                    PeliculaDAO.MostrarPeliculasNombre(tabBusqueda,busqueda);
                    break;
                case 1:
                    //llamado a la función que filtra por genero
                    PeliculaDAO.MostrarPeliculasGenero(tabBusqueda, busqueda);
                    break;
                case 2:
                    //llamado a la función que filtra por año de lanzamiento
                    PeliculaDAO.MostrarPeliculasAno(tabBusqueda, busqueda);
                    break;
                default:
                    MessageBox.Show("Seleccione primero una categoría");
                    break;
            }
        }
    }
}
