using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.InventarioActivoDTOs
{
    public class GetIdResultInventarioActivoDTO
    {
        public int CountRow { get; set; }

        public List<InventarioActivoDTO> Data { get; set; }

        public class InventarioActivoDTO
        {
            public int Id { get; set; }
            [DisplayName("Activo")]
            public int ActivoId { get; set; }
            [DisplayName("Estante")]
            public int EstanteId { get; set; }
            public int Existencia { get; set; }
        }
    }
}
