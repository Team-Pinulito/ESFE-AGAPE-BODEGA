﻿using Bodega_Api_Esfe_Agape.Models.EN;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string DUI { get; set; }
        public string Password { get; set; }
        public string Codigo { get; set; }

        public bool Estatus {  get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Rol")]
        public int RolId { get; set; }

        public Rol Rol { get; set; }

        public ICollection<SolicitudActivo> SolicitudActivos { get; set; }
        public ICollection<SolicitudActivo> BodegasEntregaSolicitudes { get; set; }
        public ICollection<SolicitudActivo> BodegaRecibeSolicitudes { get; set; }
        public virtual ICollection<IngresoActivo> IngresoActivos { get; set; }

    }
}
