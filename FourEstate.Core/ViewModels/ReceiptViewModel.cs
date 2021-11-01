using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        public CustomerViewModel Customer { get; set; }

        public string DateReceipt { get; set; }

        public RealEstateViewModel RealEstate { get; set; }

        public RentContractViewModel RentContract { get; set; }

        public string ReceiptNumber { get; set; }

        public UserViewModel User { get; set; }

        public double ValueReceipt { get; set; }

        public string DateTimeStart { get; set; }
        public string DateTimeEnd { get; set; }

        public string InvoiceType { get; set; }
        //بيان
        public string statment { get; set; }
    }
}
