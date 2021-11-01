using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class CreateRentContractDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم العقد")]
        public string NumberOfContract { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع تاريخ")]
        public DateType DateType { get; set; }
       
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "التاريخ")]
        public string DateTime { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ  بداية الإيجار")]
        public string DateTimeStartRent { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ نهاية الإيجار")]
        public string DateTimeEndRent { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صيفة العقد")]
        public FormulaContract FormulaContract { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "العقار")]
        public int RealEstateId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "المستأجر")]
        public int CustomerId { get; set; }
    }
}
