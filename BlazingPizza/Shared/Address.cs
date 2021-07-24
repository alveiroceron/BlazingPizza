﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.Shared
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="¿Quién recibirá la orde?"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Es necesaria la dirección de envío"), MaxLength(100)]
        public string Line1 { get; set; }
        [MaxLength(100)]
        public string Line2 { get; set; }
        [Required(ErrorMessage ="La ciudad debe ser especificada"), MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage ="El estado debe ser especificado"), MaxLength(20)]
        public string Region { get; set; }
        [Required(ErrorMessage ="El CP debe ser especificado"), MaxLength(6)]
        public string PostalCode { get; set; }
    }

}
