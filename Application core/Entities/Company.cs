﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudio.Application_core.Entities
{
    public class Company
    {
        [Column("Company Id")]
        public Guid id { get; set; }


        [Required(ErrorMessage ="Company name is required")]
        [MaxLength(60, ErrorMessage ="Maximum length for the name is 60 character")]
        public string Name { get; set; }


        [Required(ErrorMessage = " Company address is a required field")]
        [MaxLength(60, ErrorMessage ="Maximum length for the required Address is 60 characters")]
        public string Address { get; set; }

        public string Country { get; set; }


        public ICollection<Employee> Employees { get; set; }

        

    }
}
