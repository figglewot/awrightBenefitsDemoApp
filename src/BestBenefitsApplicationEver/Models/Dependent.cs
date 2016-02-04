using System;
using System.ComponentModel.DataAnnotations;

namespace BestBenefitsApplicationEver.Models
{
    public class Dependent
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}