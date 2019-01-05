using System;
using System.Collections.Generic;
using System.Text;

namespace AppLabs.EntityFramework.Test.Entities
{
    public class Etiqueta
    {
        public int EtiquetaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public IEnumerable<Entrada> Entradas { get; set; }

        public Etiqueta()
        {
            Entradas = new HashSet<Entrada>();
        }
    }
}
