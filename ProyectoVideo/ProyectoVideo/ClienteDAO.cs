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
    public class ClienteDAO
    {
        //función para agregar datos en la base de datos
        public static int Agregar(Cliente cliente)
        {
            int retorno = 0;
            string cadena = string.Format("Insert into cliente (nombre, apPaterno, apMaterno, edad, direccion, cp, email) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", cliente.nombre, cliente.apPaterno, cliente.apMaterno, cliente.edad, cliente.direccion, cliente.cod_postal, cliente.email);
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //función para el llenado de datos en las tablas de tipo DataGridView
        public static void MostrarClientes(DataGridView dgv)
        {
            //consulta sql
            string cadena = "Select * from cliente";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con la información obtenida
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        //se hace esta consulta para obterner los nombres de los clientes
        public static string Consultar()
        {
            string retorno = "";
            //consulta sql
            string cadena = "Select nombre, apPaterno from cliente";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el cual se almacenan en una variable los datos ontenidos del MySqlReader
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["nombre"].ToString()+" "+registros["apPaterno"].ToString();
            }
            return retorno;
        }
        //función para obtener los id de los clientes
        public static string ConsultaID()
        {
            string retorno = "";
            //consulta sql
            string cadena = "select id_cliente from cliente";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comnado = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comnado.ExecuteReader();
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["id_cliente"].ToString();
            }
            return retorno;
        }
        //función para eliminar
        public static int Eliminar(int cliente)
        {
            int retorno = 0;
            //cadena donde encontramos al cliente
            string cadena = "Delete from cliente where id_cliente = " + cliente;
            //se ingresa la cadena y la conexión para que el programa sepa a que base de datos guardará la información
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            //ejecución del programa
            retorno = comando.ExecuteNonQuery();
            //en caso de ejecutarse bien nos retornará un número, mismo que sirve para mostrar mensajes
            return retorno;
        }
        //acutalización de la información
        public static int Modificar(Cliente cliente, int id)
        {
            int retorno = 0;
            //en el siguiente comando se realiza la actualización de los datos
            MySqlCommand comando = new MySqlCommand(string.Format("Update cliente set nombre='" + cliente.nombre + "',apPaterno='" + cliente.apPaterno + "', apMaterno='" + cliente.apMaterno + "', edad='" + cliente.edad + "', direccion='" + cliente.direccion + "', cp ='" + cliente.cod_postal + "', email='" + cliente.email + "' where id_cliente = '" + id + "'"), BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //función que ayuda para la obtenciónde la información
        public static Cliente ObtenerCliente(Cliente cliente)
        {
            //creación de nuestro objeto cliente
            Cliente c = new Cliente();
            //generación de la cadena que es nuestra consulta SQL
            string cadena1 = "Select * from cliente where nombre='" + cliente.nombre + "' AND apPaterno = '" + cliente.apPaterno + "'";
            //se ingresa la consulta y se hace referencia a la base de datos para que la aplicación haga los cambios requeridos
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            //se almacena en registros lo que nos retorna nuestro comando
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que obtuvimos
            while (registros.Read())
            {
                //asignación de los datos para retornar la información requerida
                c.nombre = registros["nombre"].ToString();
                c.apPaterno = registros["apPaterno"].ToString();
                c.apMaterno = registros["apMaterno"].ToString();
                c.edad = int.Parse(registros["edad"].ToString());
                c.direccion = registros["direccion"].ToString();
                c.cod_postal = registros["cp"].ToString();
                c.email = registros["email"].ToString();
            }
            //se retorna la información de nuestro cliente
            return c;
        }
        //función que nos ayuda a obtener el ID de los clientes
        public static int ObtenerId(Cliente cliente)
        {
            int id = 0;
            //con esta consulta se obtiene el id de la pelicula almacenada en la tabla
            string cadena1 = "Select id_cliente from cliente where nombre='" + cliente.nombre + "' AND apPaterno = '"+cliente.apPaterno+"'";
            //se ingresa la consulta y se hace referencia a la base de datos para que la aplicación haga los cambios requeridos
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            //se almacena en registros lo que nos retorna nuestro comando
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                id = int.Parse(registros["id_cliente"].ToString());
            }
            //se retorna la información de nuestro cliente
            return id;
        }
    }
}
