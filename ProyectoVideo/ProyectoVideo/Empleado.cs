using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVideo
{
    public class Empleado
    {
        //atributos de la clase pública Empleado
        //declaración de métodos get y set para acceder a los atributos de la clase empleado
        public int id { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string num_empleado { get; set; }
        public int num_ventas { get; set; }

        public Empleado() { }
        //constructor de la clase para crear el objeto
        public Empleado(string nombre, string apPat, string apMat, int edad, string direcc, string cod_postal, string num_emplado)
        {
            this.nombre = nombre;
            this.apPaterno = apPat;
            this.apMaterno = apMat;
            this.edad = edad;
            this.direccion = direcc;
            this.cod_postal = cod_postal;
            this.num_empleado = num_emplado;
        }
    }
}
