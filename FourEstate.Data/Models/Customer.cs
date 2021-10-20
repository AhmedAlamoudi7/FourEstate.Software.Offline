using FourEstate.Core.Constants;
using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class Customer : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        // New Feture
        public string IdentityImage { get; set; }
        public CustomerType CustomerType { get; set; }
        public string AnotherPhone { get; set; }
        public string TaxNumber { get; set; }
        /// 
        public List<Contract> Contract { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

   
    }
}
