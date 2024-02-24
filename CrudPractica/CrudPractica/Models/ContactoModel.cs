﻿using System.ComponentModel.DataAnnotations;

namespace CrudPractica.Models
{
    public class ContactoModel
    {
        public int Idcontacto { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        public string Correo { get; set; }

    }
}
