using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada.Entidades
{
    public  class Suplidores
    {
        [Key]
        public int SuplidoreId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Empresa { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Suplidores()
        {
            SuplidoreId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Empresa = string.Empty;
            FechaIngreso = DateTime.Now;
            Email = string.Empty;
        }
    }
}
