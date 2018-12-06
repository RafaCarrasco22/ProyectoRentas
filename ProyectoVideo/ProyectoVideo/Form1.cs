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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Aplicación del botón
        private void btnOk_Click(object sender, EventArgs e)
        {
            //verificación que ninguno de los campos esté vacío
            if (txtUser.Text == "")
            {
                //mensaje de alerta en caso que los campos estén vacíos
                MessageBox.Show("Ingrese usuario!", "Campo sin llenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (txtUser.Text == "")
            {
                MessageBox.Show("Ingrese contraseña!", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (cmbTipo.Text == "")
            {
                MessageBox.Show("Seleccione tipo de usuario", "Campo sin llenar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                //En caso de que los campos estén llenos se verifica que sea administrador o empleado
                if (cmbTipo.SelectedIndex == 1 && txtPass.Text == "password" && txtUser.Text == "admin")
                {
                    //En caso correcto (para administrador) se llama a la ventana de Admin
                    Admin ad = new Admin();
                    ad.Show();
                    this.Hide();
                } else if(cmbTipo.SelectedIndex == 0)
                {
                    //en caso de elegir que es un empleado se verifica que el login sea correcto
                    //se asignan a variables de tipo string el contenido de los TEXTBOX
                    string us = txtUser.Text.Trim().ToUpper();
                    string pa = txtPass.Text.Trim();
                    //se asigna a una variable la cadena que nos retornará a la contraseña
                    string pass = EmpleadoDAO.ConsultaLogin(us);

                    if (pass == pa)
                    {
                        //En caso de que las contraseñas escritas y la de la función coincida se llama a la ventana de empleado
                        FormEmpleado fe = new FormEmpleado();
                        fe.Show();
                        this.Hide();
                    }else
                    {
                        //mensaje de alerta en caso de ingresar información errónea
                        MessageBox.Show("Información errónea", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                } else
                {
                    //mensaje de alerta en caso de ingresar información errónea
                    MessageBox.Show("Información errónea", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
