using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
   public class UpdateInvoiceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم الفاتورة")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ الفاتورة")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع الفاتورة")]
   
        public InvoiceType InvoiceType { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "المندوب")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الزبون")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "اسم العقار")]
        public int RealEstateId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الكمية")]
        public double Quentity { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "القيمة")]
        public double Value { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الاجمالي")]
        public double FullValueBefore { get; set; }



        //public double FullValueWithOutTaxValue
        //{ get { return FullValueWithOutTaxValue; } set {FullValueWithOutTaxValue = value; } }
        [Display(Name = "الاجمالي بدون الضريبة")]
        public double FullValueWithOutTaxValue { get; set; }
        [Display(Name = " الضرائب:%5")]
        public double TaxValue { get; set; }
        [Display(Name = "المجموع")]
        public double FullValueAfter { get; set; }
        [Display(Name = "الرصيد المستحق")]
        public double BalanceDue { get; set; }
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }
    }
}
