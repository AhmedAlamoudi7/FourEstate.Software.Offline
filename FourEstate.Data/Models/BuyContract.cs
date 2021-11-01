using FourEstate.Core.Constants;
using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class BuyContract : BaseEntity
    {
        public DateType DateType { get; set; }
        public string DateTime { get; set; }
        public FormulaContract FormulaContract { get; set; }

        public string LocationDetails { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public double Price { get; set; }

        public CurrenyType CurrenyType { get; set; }

        public ContentStatus Stauts { get; set; }


        public BuyContract()
        {
            Stauts = ContentStatus.Pending;
        }
    }
    }
