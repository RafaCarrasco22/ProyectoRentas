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
    public partial class BestEmpleado : Form
    {
        public BestEmpleado()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //llamando a la ventana de administrador
            Admin a = new Admin();
            a.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void BestEmpleado_Load(object sender, EventArgs e)
        {
            EmpleadoDAO.MostrarEmpleadosBest(dataviwe);
        }
    }
}
