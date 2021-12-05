using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cargo { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Empleados()
        {
            EmpleadoId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Cargo = string.Empty;
            Sueldo = 0;
            FechaNacimiento = DateTime.Now;
            FechaIngreso = DateTime.Now;

        }
    }
}
