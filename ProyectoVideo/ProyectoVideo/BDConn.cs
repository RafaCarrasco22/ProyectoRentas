using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVideo
{
    //clase para hacer la conexión a la base de datos
    public class BDConn
    {
        public static MySqlConnection ObtenerConexion()
        {
            //se establecen los parámetros para el ingreso de la base de datos
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=videoclub; Userid=root; password=4426;");
            //se abre la conexión
            conectar.Open();
            //se retorna la conexión
            return conectar;
        }
    }
}
