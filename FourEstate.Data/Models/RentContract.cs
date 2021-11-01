using FourEstate.Core.Constants;
using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class RentContract : BaseEntity
    {
        public string NumberOfContract { get; set; }
        public DateType DateType { get; set; }
        public string DateTime { get; set; }
        public string DateTimeStartRent { get; set; }
        public string DateTimeEndRent { get; set; }
        public FormulaContract FormulaContract { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ContentStatus Stauts { get; set; }


        public RentContract()
        {
            Stauts = ContentStatus.Pending;
        }
    }
}
