using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Entidades
{
    public class Roles
    {

        [Key]
        public int RolId { get; set; }
        public string Descripcion { get; set; }
    }
}
