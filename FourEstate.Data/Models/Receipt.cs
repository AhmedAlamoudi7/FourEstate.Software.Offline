using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class Receipt :BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime DateReceipt { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public int RentContractId { get; set; }
        public RentContract RentContract { get; set; }

        public string ReceiptNumber { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public double ValueReceipt { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd{ get; set; }
        
  
        public InvoiceType InvoiceType { get; set; }
        //بيان
        public string statment { get; set; }

    }
}
