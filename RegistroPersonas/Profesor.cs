using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersonas
{
    internal class Profesor : Persona
    {
        public string Materia { get; set; }
        public override string InfoExtra => Materia;
        public override string Tipo => "Profesor";
        public override string MostrarDatos()
        {
            return base.MostrarDatos() + $"; {Materia}";
        }
    }
}
