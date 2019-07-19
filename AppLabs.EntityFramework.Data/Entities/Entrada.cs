using System;

namespace AppLabs.EntityFramework.Data.Entities
{
    public class Entrada
    {
        public int EntradaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public int EtiquetaId { get; set; }

        public Etiqueta Etiqueta { get; set; }

        public int ProyectoId { get; set; }

        public Proyecto Proyecto { get; set; }

    }
}
