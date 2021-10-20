using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class CreateHolidayDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "العنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "بداية الاجازة")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نهاية الاجازة")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}
