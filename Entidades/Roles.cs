using System;
using System.ComponentModel.DataAnnotations;

namespace Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.Entidades
{
    public class Roles
    {
        [Key]
        public int RolesId { get; set; }
        public string DescripcionRol { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacionRol { get; set; } = DateTime.Now;
    }
}
