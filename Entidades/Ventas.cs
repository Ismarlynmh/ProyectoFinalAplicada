using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Entidades
{
    public class Ventas
    {

        [Key]
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public double ITBIS { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> Detalle { get; set; } = new List<VentasDetalle>();

        public int ProductoId { get; set; }
        public Ventas()
        {
            VentaId = 0;
            SubTotal = 0;
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            ProductoId = 0;
        }
    }
}
