using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersonas
{
    internal class Alumno : Persona
    {
        public string Carrera { get; set; }
        public override string InfoExtra => Carrera;
        public override string Tipo => "Alumno";
        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"; {Carrera}";
        }
    }
}
