using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs
{
    public class GetIdResultAjusteInvetarioDTO
    { 
        public int CountRow { get; set; }

        public List<AjusteInventarioDTO> Data { get; set; }

        public class AjusteInventarioDTO
        {
            public int Id { get; set; }
            [DisplayName("Usuario")]
            public int UsuarioId { get; set; }
            public DateTime FechaIngreso { get; set; }
            public int Correlativo { get; set; }
            public int Cantidad { get; set; }
            public int TipoMantenimiento { get; set; }
            public string Comentario { get; set; }
        }
    }
}
