using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
   public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceType { get; set; }

        public UserViewModel User { get; set; }

        public CustomerViewModel Customer { get; set; }

        public double Quentity { get; set; }

        public double Value { get; set; }
        public double FullValueBefore { get; set; }

        public RealEstateViewModel RealEstate { get; set; }


        public double FullValueWithOutTaxValue { get; set; }
        public double TaxValue { get; set; }
        public double FullValueAfter { get; set; }
        public double BalanceDue { get; set; }
        public string Notes { get; set; }
    }
}
