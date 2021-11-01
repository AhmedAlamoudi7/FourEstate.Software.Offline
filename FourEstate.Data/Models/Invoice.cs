using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class Invoice :BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public double Quentity { get; set; }

        public double Value { get; set; }
        public double FullValueBefore { get; set; }



        //public double FullValueWithOutTaxValue
        //{ get{return FullValueWithOutTaxValue;}set{FullValueWithOutTaxValue = value;}}
        public double FullValueWithOutTaxValue { get; set; }
        public double TaxValue { get; set; }
        public double FullValueAfter { get; set; }
        public double BalanceDue { get; set; }
        public string Notes { get; set; }

        //public Invoice() {
        //    FullValueWithOutTaxValue = FullValueBefore;
        //    TaxValue = FullValueBefore * .05;
        //    FullValueAfter = FullValueBefore - TaxValue;
        //    BalanceDue = FullValueAfter;


        //}

    }
}
