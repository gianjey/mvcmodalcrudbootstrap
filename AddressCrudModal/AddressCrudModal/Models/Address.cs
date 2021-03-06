﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressCrudModal.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Surname { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string City { get; set; }

        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Phone]
        public string Phone { get; set; }
     
    }
}