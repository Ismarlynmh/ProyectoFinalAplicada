using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada.Entidades
{
    public  class ComprasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }


        public ComprasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            CompraId = 0;
            Cantidad = 0;
            Precio = 0;

        }
    }
}
