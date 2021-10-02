using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
   public class ContractViewModel
    {

        public int Id { get; set; }

        public string ContractType { get; set; }

        public string Price { get; set; }
    
        public CustomerViewModel CustomerId { get; set; }
      
        public RealEstateViewModel RealEstatedId { get; set; }
    }
}
