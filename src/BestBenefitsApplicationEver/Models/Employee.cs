using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestBenefitsApplicationEver.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PayRate { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
    }

}
