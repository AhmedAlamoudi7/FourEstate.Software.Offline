using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
    public class SaleContractViewModel
    {
        public int Id { get; set; }
        public string DateType { get; set; }
        public string DateTime { get; set; }
        public string FormulaContract { get; set; }
        public string LocationDetails { get; set; }
        public UserViewModel User { get; set; }
        public RealEstateViewModel RealEstate { get; set; }
        public CustomerViewModel Customer { get; set; }
        public double Price { get; set; }
        public string CurrenyType { get; set; }
        public string Status { get; set; }

    }
}
