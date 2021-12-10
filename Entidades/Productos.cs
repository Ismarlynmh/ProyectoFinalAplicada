using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public decimal Inventario { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public decimal PrecioDeCompra { get; set; }



        public Productos()
        {
            ProductoId = 0;
            Nombre = string.Empty;
            Marca = string.Empty;
            Inventario = 0;
            Cantidad = 0;
            PrecioDeCompra = 0;
            PrecioDeVenta = 0;
        }
    }
}
