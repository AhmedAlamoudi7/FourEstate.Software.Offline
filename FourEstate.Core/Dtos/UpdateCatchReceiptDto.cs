using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class UpdateCatchReceiptDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = " العميل- مدين")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = " تاريخ السند")]
        [DataType(DataType.Date)]
        public DateTime DateReceipt { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = " عن العقار")]
        public int RealEstateId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "عن العقد")]
        public int RentContractId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم السند")]
        public string ReceiptNumber { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "موظف التحصيل")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "قيمة السند ")]
        public double ValueReceipt { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الفترة من")]
        [DataType(DataType.Date)]
        public DateTime DateTimeStart { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الفترة إلى")]
        [DataType(DataType.Date)]
        public DateTime DateTimeEnd { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع الدفع")]
        public InvoiceType InvoiceType { get; set; }
        //بيان
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "البيان")]
        public string statment { get; set; }
    }
}
