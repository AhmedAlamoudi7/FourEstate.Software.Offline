using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "الاسم الأول")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "الاسم الثاني")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "الاسم كامل")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = " تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name = "الصورة الشخصية")]
        public IFormFile ImageUrl { get; set; }
        [Required]
        [Display(Name = "رقم الجوال")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "موقعك")]
        public int LocationId { get; set; }
    }
}
