using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVideo
{
    public class Pelicula
    {
        //declaración de atributos de la clase Pelicula
        //Se agregan sus métodos get y set para accesar a cada atributo
        public int id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int estreno { get; set; }
        public double precio { get; set; }
        public int existencia { get; set; }

        public Pelicula() { }
        //constructor con parámetros para crear un objeto Pelicula
        public Pelicula(string nombre, string genero, int anio_estreno, double precio, int existencia)
        {
            this.nombre = nombre;
            this.genero = genero;
            this.estreno = anio_estreno;
            this.precio = precio;
            this.existencia = existencia;
        }
    }
}
