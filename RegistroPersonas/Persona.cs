using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersonas
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public virtual string MostrarDatos()
        {
            return $"{Nombre}; {Apellido}; {Edad} años";
        }
        public virtual string InfoExtra => "";
        public virtual string Tipo => "Persona";
    }
}
