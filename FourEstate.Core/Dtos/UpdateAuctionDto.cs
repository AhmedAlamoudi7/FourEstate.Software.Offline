using FourEstate.Core.Constants;
using FourEstate.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class UpdateAuctionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "عنوان المزاد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "وصف المزاد")]
        public string Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ المزاد")]
        public DateTime DOAuction { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "عدد القطع")]
        public int NumberOfPieces { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نوع المزاد")]
        public AuctionType AuctionType { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تابع لمحكمة")]
        public CourtType CourtType { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "العقار")]
        public int RealEstateId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إضافة ملفات")]
        public List<IFormFile> Attachments { get; set; }

        public List<AuctionAttachmentViewModel> AuctionAttachments { get; set; }

    }
}
