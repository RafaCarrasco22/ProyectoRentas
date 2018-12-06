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
    public partial class RentasHoy : Form
    {
        public RentasHoy()
        {
            InitializeComponent();
        }
        //función que carga a las entregas del día
        private void RentasHoy_Load(object sender, EventArgs e)
        {
            //se obtiene la fecha del día
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("yyyy/MM/dd");
            //se llama a la función que carga las entregas que son del día
            RentasDAO.MostrarPorDiaDeEntrega(dataviwe, fecha_actual);
        }

        private void dataviwe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //en caso de regresar a las rentas generales se abre la vetana
            VerRentas vr = new VerRentas();
            vr.Show();
            //se oculta esta ventana
            this.Hide();
        }
    }
}
