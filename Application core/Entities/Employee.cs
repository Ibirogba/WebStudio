﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStudio.Application_core.Entities
{
    public class Employee
    {
        [Column("Employee Id")]
        public Guid id{ get; set; }

        [Required(ErrorMessage = "Employee Name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        [Required (ErrorMessage = "Position is a required field .")]
        [MaxLength(20, ErrorMessage ="Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }


        //Navigation Properties
        [ForeignKey(nameof(Company))]
        public Guid  CompanyId { get; set; }
        public Company company { get; set; }
    }
}
