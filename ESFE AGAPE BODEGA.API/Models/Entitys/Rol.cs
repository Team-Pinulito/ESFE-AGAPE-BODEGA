using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
