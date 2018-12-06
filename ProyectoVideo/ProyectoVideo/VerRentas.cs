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
    public partial class VerRentas : Form
    {
        public VerRentas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //en caso de querer cerrar se llama a la ventana de empleado (principal)
        private void btnOk_Click(object sender, EventArgs e)
        {
            FormEmpleado fe = new FormEmpleado();
            fe.Show();
            //oculta esta ventana
            this.Hide();
        }

        private void dataviwe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void VerRentas_Load(object sender, EventArgs e)
        {
            //función para llenar la tabla
            RentasDAO.MostrarPeliculasRentadas(dataviwe);
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            //se llama a la ventana que nos muestra las entregas del día
            RentasHoy rh = new RentasHoy();
            rh.Show();
            //se oculta esta ventana
            this.Hide();
        }
    }
}
