using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVideo
{
    public class Cliente
    {
        //atributos de la clase pública Cliente
        //declaración de métodos get y set para acceder a los atributos de la clase Cliente
        public int id { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string cod_postal { get; set; }
        public string email { get; set; }

        public Cliente() { }
        //constructor de la clase para crear el objeto
        public Cliente(string nombre, string apPat, string apMat, int edad, string direcc, string cod_postal, string email)
        {
            this.nombre = nombre;
            this.apPaterno = apPat;
            this.apMaterno = apMat;
            this.edad = edad;
            this.direccion = direcc;
            this.cod_postal = cod_postal;
            this.email = email;
        }
    }
}
