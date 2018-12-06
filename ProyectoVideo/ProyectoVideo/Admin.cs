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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        //en caso de que se desee salir llamamos a la ventana principal para inicio de sesión
        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            //ocultamos esta ventana
            this.Hide();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            //se crea un switch de nuestro combo box para obtener los casos y abrir la respectiva ventana
            switch(cmbAction.SelectedIndex)
            {
                case 0:
                    //se llama y se muestra a la ventana de agregar empleado
                    AddEmpleado ae = new AddEmpleado();
                    ae.Show();
                    //ocultamos esta ventana
                    this.Hide();
                    break;
                case 1:
                    //se llama y se muestra a la ventana de modificar empleado
                    ModifyEmpleado me = new ModifyEmpleado();
                    me.Show();
                    //ocultamos esta ventana
                    this.Hide();
                    break;
                case 2:
                    //se llama y se muestra a la ventana de eliminar empleado
                    DeleteEmpleado de = new DeleteEmpleado();
                    de.Show();
                    //ocultamos nuestra ventana
                    this.Hide();
                    break;
                case 3:
                    //se llama y se muestra a la ventana de eliminar empleado
                    BestEmpleado be = new BestEmpleado();
                    be.Show();
                    //ocultamos nuestra ventana
                    this.Hide();
                    break;
                    //mensaje en caso de no elegir alguna opción
                default:
                    MessageBox.Show("Seleccione un campo para trabajar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
