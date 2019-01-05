using System;
using System.Collections.Generic;
using System.Text;

namespace AppLabs.EntityFramework.Test.Entities
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public IEnumerable<Entrada> Entradas { get; set; }


        public Proyecto()
        {
            Entradas = new HashSet<Entrada>();
        }
    }
}
