using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class Contract :BaseEntity
    {   
        [Required]
        public ContractType ContractType { get; set; }
        [Required]
        public double Price { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int RealEstatedId { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
