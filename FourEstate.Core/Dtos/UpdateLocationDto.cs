using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class UpdateLocationDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم الدولة")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "اسم المدينة")]
        public string City { get; set; }

        [Required]
        [Display(Name = "اسم الشارع")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "رقم الشارع")]
        public string StreetNumber { get; set; }
    }
}
