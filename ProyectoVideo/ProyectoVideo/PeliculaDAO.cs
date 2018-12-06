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
    public class PeliculaDAO
    {
        //método estatico para insertar un nuevo registro en la tabla pelicula
        public static int Agregar(Pelicula movie)
        {
            int retorno = 0;
            string cadena = string.Format("Insert into pelicula (nombre, genero, anio_estreno, precio, existencia) values ('{0}','{1}','{2}','{3}','{4}')", movie.nombre, movie.genero, movie.estreno, movie.precio, movie.existencia);
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        //método estático para consultar en la base de datos si hay peliculas disponibles para renta
        public static string ConsultarExistencia(Pelicula movie)
        {
            string retorno = "";
            int id = 0;
            int exist = 0;
            //con esta consulta se obtiene el id de la pelicula almacenada en la tabla
            //id = ObtenerId(movie);
            //en esta consulta a partir del id encontrado se realiza la operación de resta de acuerdo a la tabla renta
            //la cual lleva el control de las peliculas rentadas relacionada con el cliente y el empleado
            string cadena = "select u.existencia-(select count(r.id_pelicula) from renta r where r.id_pelicula = "+ movie.id +") existencia_real from pelicula u where u.id_pelicula = "+ movie.id +";";
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                exist = int.Parse(registros["existencia_real"].ToString());
            }
            if (exist > 0)
            {
                retorno = "Hay " + exist + " disponible(s)";
            }
            else
            {
                retorno = "Ya no hay películas disponibles";
            }
            return retorno;
        }
        //muestra las películas para la pestaña principal
        public static void MostrarPeliculas(DataGridView dgv)
        {
            //realización de la consulta necesaria
            string cadena = "Select id_pelicula ID, nombre Nombre, genero Genero, anio_estreno AnioEstreno, precio Precio, Existencia from pelicula";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con el resultado de la consulta
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        internal static void MostrarPeliculasPedidas(DataGridView tabPelis, int clientito)
        {
            throw new NotImplementedException();
        }

        //muestra las películas para la pestaña filtradas por nombre
        public static void MostrarPeliculasNombre(DataGridView dgv, string nombre)
        {
            string aux = "\"";
            
            //realización de la consulta necesaria
            string cadena = "Select id_pelicula ID, nombre Nombre, genero Genero, anio_estreno AnioEstreno, precio Precio, Existencia from pelicula where nombre = '" +nombre + "' ;";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con el resultado de la consulta
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        //muestra las películas para la pestaña filtradas por genero
        public static void MostrarPeliculasGenero(DataGridView dgv, string nombre)
        {
            string aux = "\"";

            //realización de la consulta necesaria
            string cadena = "Select id_pelicula ID, nombre Nombre, genero Genero, anio_estreno AnioEstreno, precio Precio, Existencia from pelicula where genero = '" + nombre + "' ;";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con el resultado de la consulta
            da.Fill(dt);
            dgv.DataSource = dt;
        }
        //muestra las películas para la pestaña filtradas por año de lanzamiento
        public static void MostrarPeliculasAno(DataGridView dgv, string nombre)
        {
            string aux = "\"";

            //realización de la consulta necesaria
            string cadena = "Select id_pelicula ID, nombre Nombre, genero Genero, anio_estreno AnioEstreno, precio Precio, Existencia from pelicula where anio_estreno = '" + nombre + "' ;";
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, BDConn.ObtenerConexion());
            DataTable dt = new DataTable();
            //llenado de la tabla con el resultado de la consulta
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        //método estático para obtener los títulos de todas las películas registradas en la BD
        public static string ConsultaNombres()
        {
            string retorno = "";
            string cadena = "Select nombre from pelicula";
            //realización de la consulta con la cadena y llamando a la conexión
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["nombre"].ToString();
            }
            return retorno;
        }

        //método estático para realizar una modificación en los campos de la película deseada
        public static int Modificar(Pelicula movie, string id)
        {
            int retorno = 0;
            //en el siguiente comando se realiza la actualización de los datos
            MySqlCommand comando = new MySqlCommand(string.Format("Update pelicula set nombre='" + movie.nombre + "',genero='" + movie.genero + "', anio_estreno='" + movie.estreno + "', precio='" + movie.precio + "', existencia='" + movie.existencia + "' where nombre = '" + id + "'"), BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //ayuda para la obtención de los id de las peliculas
        public static string ConsultaID()
        {
            string retorno = "";
            //realización de la consulta con la cadena y llamando a la conexión
            string cadena = "select id_pelicula from pelicula";
            MySqlCommand comnado = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            MySqlDataReader registros = comnado.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                //se guardan todos los nombres en una cadena, cada uno separado por el caracter '-' 
                retorno += "-" + registros["id_pelicula"].ToString();
            }
            return retorno;
        }
        //método estático para eliminar un registro de la tabla 
        public static int Eliminar(Pelicula movie)
        {
            int retorno = 0;
            string cadena = "Delete from pelicula where nombre = '" + movie.nombre + "'";
            MySqlCommand comando = new MySqlCommand(cadena, BDConn.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        //método estático para obtener todo un el objeto película, con todos los datos encontrados en la BD
        public static Pelicula ObtenerPelicula(Pelicula movie)
        {
            //creación del obheto pelicula
            Pelicula p = new Pelicula();
            //cadena que contiene la búsqueda sql
            string cadena1 = "Select * from pelicula where nombre='" + movie.nombre + "'";
            //ejecución de la búsqueda
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                p.nombre = registros["nombre"].ToString();
                p.genero = registros["genero"].ToString();
                p.estreno = int.Parse(registros["anio_estreno"].ToString());
                p.precio = double.Parse(registros["precio"].ToString());
                p.existencia = int.Parse(registros["existencia"].ToString());
            }
            //se retorna la información de nuestra movie
            return p;
        }

        public static int ObtenerId(Pelicula movie)
        {
            int id = 0;
            //con esta consulta se obtiene el id de la pelicula almacenada en la tabla
            string cadena1 = "Select id_pelicula from pelicula where nombre='" + movie.nombre + "'";
            MySqlCommand comando = new MySqlCommand(cadena1, BDConn.ObtenerConexion());
            MySqlDataReader registros = comando.ExecuteReader();
            //ciclo en el que se obtiene la información que necesitamos
            while (registros.Read())
            {
                id = int.Parse(registros["id_pelicula"].ToString());
            }
            //se retorna la información de nuestra movie
            return id;
        }
    }
}
