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
    public class RentasDAO
    {
        //inserción en la renta
        public static int Insertar(Pelicula movie, Cliente cliente, Empleado emp, string fecha1, string fecha2)
        {
            //asignación de los valores obtenidos del constructor
            int retorno = 0;
            int id_emp = emp.id;
            int id_cl = cliente.id;
            int id_mv = movie.id;
            //creación de la consulta
            string cadena = string.Format("Insert into renta (id_cliente, id_emp, id_pelicula, fecha_renta, fecha_entrega, pagado) values ('{0}','{1}','{2}','{3}','{4}','{5}')", id_cl, id_emp, id_mv,fecha1, fecha2, 0);//agregar fechas
            //ejecución de la consulta
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            if (retorno > 0)
            {
                //suma de ventas al empleado
                string cadena1 = "Select num_ventas from empleado where id_emp='" + id_emp + "'";
                comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
                MySqlDataReader registros = comando.ExecuteReader();
                int ventas = 0;
                //obtención del valor solicitado en la consulta
                while (registros.Read())
                {
                    ventas = int.Parse(registros["num_ventas"].ToString());
                }
                ventas++;
                //acutalización de las ventas del empleado
                string cadena2 = "Update empleado set num_ventas = '" + ventas + "' where id_emp = '" + id_emp + "' ";
                //ejecución del update
                comando = new MySqlCommand(cadena2, BDConn.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        //método estático para obtener el total a pagar por la renta de las películas hechas por el cliente
        public static double ObtenerTotal(Cliente cliente)
        {
            double total = 0.0;
            //en este comando de mysql se hace la sumatoria de las peliculas que le corresponden al cliente
            string cadena = "select sum(p.precio) Total from pelicula p, renta r where r.id_cliente = "+ cliente.id +" and p.id_pelicula = r.id_pelicula and pagado = 0;";
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //try catch para verificar que los campos retornados no sean nulos
            try
            {
                //ciclo en el ue se obtiene el total (de la suma del select)
                while (registros.Read())
                {
                    total = double.Parse(registros["Total"].ToString());
                }
            } catch (Exception)
            {
                //mensaje para mostrar que no tiene adeudo
                MessageBox.Show("No tiene adeudos");
            }
                
            
            return total;
        }
        //se muestran las películas pedidas
        public static void MostrarPeliculasPedidas(DataGridView dgv, int clientito)
        {
            string cadena = "select r.id_renta , (select concat (p.nombre)) Pelicula, p.id_pelicula , r.fecha_renta Renta, r.fecha_entrega Entrega from renta r, pelicula p, empleado e where r.id_cliente = " + clientito +" and r.id_pelicula = p.id_pelicula and r.id_emp = e.id_emp and r.pagado = 0;";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        //proceso para borrar una renta
        public static int Eliminar(int id)
        {
            int retorno = 0;
            //cadena donde encontramos al cliente
            string cadena = "Delete from renta where id_renta = '" + id+ "'";
            //se ingresa la cadena y la conexión para que el programa sepa a que base de datos guardará la información
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            //ejecución del comando
            retorno = comando.ExecuteNonQuery();
            //en caso de ejecutarse bien nos retornará un número, mismo que sirve para mostrar mensajes
            return retorno;
        }

        //proceso para borrar una renta pasada
        public static int EliminarPorDiaEntrega(string fehca)
        {
            int retorno = 0;
            //cadena donde encontramos al cliente
            string cadena = "Delete from renta where fecha_entrega < ' " + fehca + "'";
            //se ingresa la cadena y la conexión para que el programa sepa a que base de datos guardará la información
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            //ejecución del comando
            retorno = comando.ExecuteNonQuery();
            //en caso de ejecutarse bien nos retornará un número, mismo que sirve para mostrar mensajes
            return retorno;
        }

        //método para la validación de pagos
        public static int Cobrar(int id)
        {
            int retorno = 0;
            //en el siguiente comando se realiza la actualización de los datos
            MySqlCommand comando = new MySqlCommand(string.Format("Update renta set pagado = 1 where id_cliente = " + id), BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //se muestran las películas pagadas
        public static void MostrarPeliculasRentadas(DataGridView dgv)
        {
            string cadena = "select r.id_renta, (select concat (a.nombre,' ',a.apPaterno,' ',a.apMaterno)) Cliente , (select concat (p.nombre)) Pelicula, (select concat (e.nombre,' ',e.apPaterno,' ',e.apMaterno )) Empleado, r.fecha_renta Renta, r.fecha_entrega Entrega from cliente a, renta r, pelicula p, empleado e where a.id_cliente = r.id_cliente and r.id_pelicula = p.id_pelicula and r.id_emp = e.id_emp and r.pagado = 0";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        //muestra a las peliculas que se entregan en el día
        public static void MostrarPorDiaDeEntrega(DataGridView dgv, string fecha)
        {
            //cadena que contiene a la consulta
            string cadena = "select p.nombre Pelicula, concat(c.nombre,' ',c.apPaterno,' ',apMaterno)  Cliente, r.fecha_entrega  from pelicula p, cliente c, renta r where p.id_pelicula = r.id_pelicula and c.id_cliente = r.id_cliente and r.fecha_entrega = '" + fecha + "'";
            //ejecución y conexión de la base de datos
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla
            da.Fill(dt);
            dgv.DataSource = dt;
        }
    }
}
