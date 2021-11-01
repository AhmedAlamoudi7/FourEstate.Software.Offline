using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class AuctionDbAttachment
    {
        public int Id { get; set; }
        public int AuctionDbId { get; set; }
        public AuctionDb AuctionDb { get; set; }
        [Required]
        public string AttachmentUrl { get; set; }
    }
}
