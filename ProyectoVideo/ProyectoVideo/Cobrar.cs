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
    public partial class Cobrar : Form
    {
        //creación de variables globales que ayudarán para el cobro
        private static int identificador = 0;
        private static int clientito ;
        private static double total = 0;
        private static string peliculaid ;
        public Cobrar(int cliente)
        {
            
            InitializeComponent();
            //se asigna el valor del id del cliente en nuestra variable identificador
            identificador = cliente;
        }
        //en caso de que se desee salir llamamos a la ventana de renta en caso de agregar más películas
        private void btnBack_Click(object sender, EventArgs e)
        {
            Rentar fe = new Rentar();
            fe.Show();
            //ocultamos esta ventana
            this.Hide();
        }
        //botón que activa el cobro
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int resultado = RentasDAO.Cobrar(identificador);
            if (resultado > 0)
            {
                //mensaje de inforamción que el usuario fuen guardado
                MessageBox.Show("Película pagada con éxito!", "Película Pagada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ahora los campos se vacían para un nuevo registro
                
            }
            else
            {
                //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                MessageBox.Show("No se pudo pagar la película", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        //función que se activa cuando carga la ventana
        private void Cobrar_Load(object sender, EventArgs e)
        {
            //se obtiene el id y se pone en el textarea correspondiente 
            string idc = identificador.ToString();
            txtID.Text = idc;
            clientito = int.Parse(idc);
            //ahora se crea el objeto cliente
            Cliente c = new Cliente();
            //se asigna el valor del id al idntificador
            c.id = identificador;
            //se realiza la consulta correspondiente para obtener el adeudo del cliente
            total = RentasDAO.ObtenerTotal(c);
            //se llena el campo correspondiente al total
            string to = total.ToString();
            txtTOT.Text = to;


            //llenado de las peliculas que adeuda el cliente
            RentasDAO.MostrarPeliculasPedidas(tabPelis, clientito);
        }

        private void tabPelis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            peliculaid = tabPelis.Rows[e.RowIndex].Cells["id_renta"].Value.ToString();
            MessageBox.Show("id seleccionada "+peliculaid);
        }

        private void btnBorra_Click(object sender, EventArgs e)
        {
            //int ren = int.Parse(peliculaid);
            
            int resultado = RentasDAO.Eliminar(ren);
            if (resultado > 0)
            {
                //mensaje de inforamción que el usuario fue guardado
                MessageBox.Show("Usuario borrado con éxito!", "Usuario Borrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ahora los campos se vacían para un nuevo registro
                RentasDAO.MostrarPeliculasPedidas(tabPelis, clientito);
                //ahora se crea el objeto cliente
                Cliente c = new Cliente();
                //se asigna el valor del id al idntificador
                c.id = identificador;
                //se realiza la consulta correspondiente para obtener el adeudo del cliente
                total = RentasDAO.ObtenerTotal(c);
                //se llena el campo correspondiente al total
                string to = total.ToString();
                txtTOT.Text = to;
            }
            else
            {
                //en caso de no hacer una buena conexión con la base de datos nos muestra este error
                MessageBox.Show("No se pudo borrar del pedido", "Fallo al insetar!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
