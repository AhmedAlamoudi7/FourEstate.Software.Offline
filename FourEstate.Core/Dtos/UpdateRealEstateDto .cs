using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.Dtos
{
    public class UpdateRealEstateDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم العقار")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "الموقع")]
        public string LocationId { get; set; }
        [Required]
        [Display(Name = "التصنيف")]
        public string CategoryId { get; set; }
        
        [Required]
        [Display(Name = "الصور")]
        public List<IFormFile> Images { get; set; }
    }
}
