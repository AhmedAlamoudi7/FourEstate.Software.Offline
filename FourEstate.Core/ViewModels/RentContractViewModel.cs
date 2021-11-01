using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
     public class RentContractViewModel
    {
        public int Id { get; set; }
        public string NumberOfContract { get; set; }
        public string DateType { get; set; }
        public string DateTime { get; set; }
        public string DateTimeStartRent { get; set; }
        public string DateTimeEndRent { get; set; }
        public string FormulaContract { get; set; }
        public RealEstateViewModel RealEstate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public string Status { get; set; }

    }
}
