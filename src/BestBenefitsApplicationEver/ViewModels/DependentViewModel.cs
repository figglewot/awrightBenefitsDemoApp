using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace BestBenefitsApplicationEver.ViewModels
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal CostOfBenefits
        {
            get
            {
                if (Name.ToUpper().StartsWith("A"))
                {
                    return (decimal) (1000.00/26 - (1000.00/26*.1));
                }
                else
                {
                    return (decimal) (1000.00/26);
                }
            }
        }
    }
}
