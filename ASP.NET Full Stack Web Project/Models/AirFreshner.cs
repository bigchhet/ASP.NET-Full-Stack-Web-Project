using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Full_Stack_Web_Project.Models
{
    public class AirFreshner
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Scent { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
