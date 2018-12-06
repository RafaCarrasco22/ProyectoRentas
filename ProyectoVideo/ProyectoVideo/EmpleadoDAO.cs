using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVideo
{
    public class EmpleadoDAO
    {
        //funcion para agregar a la base de datos
        public static int Agregar(Empleado emp)
        {
            int retorno = 0;
            //realización de la consulta con la cadena y llamando a la conexión
            string cadena = string.Format("Insert into empleado (nombre, apPaterno, apMaterno, edad, direccion, cp, num_emp, num_ventas) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", emp.nombre, emp.apPaterno, emp.apMaterno, emp.edad, emp.direccion, emp.cod_postal, emp.num_empleado, 0);
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //función para el llenado de datos en las tablas de tipo DataGridView
        public static void MostrarEmpleados(DataGridView dgv)
        {
            string cadena = "Select * from empleado";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con la información obtenida
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        public static string ConsultaLogin(string User)
        {
            string retorno = "";
            //realización de la consulta con la cadena y llamando a la conexión
            string cadena = "select num_emp from empleado where nombre = '" + User + "'";
            MySqlCommand comnado = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comnado.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                retorno = registros["num_emp"].ToString();
            }
            //se retorna la información de nuestro cliente
            return retorno;
        }
        public static string ConsultaID()
        {
            string retorno = "";
            //realización de la consulta con la cadena y llamando a la conexión
            string cadena = "select id_emp from empleado";
            MySqlCommand comnado = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comnado.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["id_emp"].ToString();
            }
            //se retorna la información de nuestro cliente
            return retorno;
        }

        public static string Consultar()
        {
            string retorno = "";
            string cadena = "Select nombre from empleado";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["nombre"].ToString();
            }
            //se retorna la información de nuestro cliente
            return retorno;
        }
        public static string Consultari()
        {
            string retorno = "";
            string cadena = "Select num_emp from empleado";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["num_emp"].ToString();
            }
            //se retorna la información de nuestro cliente
            return retorno;
        }


        public static int Eliminar(int emp)
        {
            int retorno = 0;
            //cadena donde encontramos al cliente
            string cadena = "Delete from empleado where num_emp = " + emp ;
            //se ingresa la cadena y la conexión para que el programa sepa a que base de datos guardará la información
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            //ejecución del comando
            retorno = comando.ExecuteNonQuery();
            //en caso de ejecutarse bien nos retornará un número, mismo que sirve para mostrar mensajes
            return retorno;
        }

        public static int Modificar(Empleado emp)
        {
            int retorno = 0;
            MessageBox.Show(emp.num_empleado);
            //en el siguiente comando se realiza la actualización de los datos
            MySqlCommand comando = new MySqlCommand(string.Format("Update empleado set nombre='" + emp.nombre + "',apPaterno='" + emp.apPaterno + "', apMaterno='" + emp.apMaterno + "', edad='" + emp.edad + "', direccion='" + emp.direccion + "', cp ='" + emp.cod_postal  + "', num_ventas='" + emp.num_ventas + "' where num_emp = '" + emp.num_empleado + "'"), BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static Empleado ObtenerEmpleado(Empleado emp)
        {
            Empleado e = new Empleado();
            string cadena1 = "Select * from empleado where num_emp='" + emp.num_empleado + "'";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                e.nombre = registros["nombre"].ToString();
                e.apPaterno = registros["apPaterno"].ToString();
                e.apMaterno = registros["apMaterno"].ToString();
                e.edad = int.Parse(registros["edad"].ToString());
                e.direccion = registros["direccion"].ToString();
                e.cod_postal = registros["cp"].ToString();
                e.num_empleado = registros["num_emp"].ToString();
                e.num_ventas = int.Parse(registros["num_ventas"].ToString());
            }
            //se retorna la información de nuestro cliente
            return e;
        }

        public static int ObtenerId(Empleado emp)
        {
            int id = 0;
            //con esta consulta se obtiene el id de la pelicula almacenada en la tabla
            //realización de la consulta con la cadena y llamando a la conexión
            string cadena1 = "Select id_empleado from empleado where num_emp= '" +  emp.num_empleado+"'";
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                id = int.Parse(registros["id_empleado"].ToString());
            }
            //se retorna la información de nuestro cliente
            return id;
        }

        //SELECT* FROM empleado order by num_ventas desc;
        //se muestran los empleados por orden de número de ventas
        public static void MostrarEmpleadosBest(DataGridView dgv)
        {
            string cadena = "SELECT id_emp, nombre, apPaterno, apMaterno, num_emp, num_ventas FROM empleado order by num_ventas desc;";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla
            da.Fill(dt);
            dgv.DataSource = dt;
        }
    }
}
