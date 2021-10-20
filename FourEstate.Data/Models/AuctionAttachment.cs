using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class AuctionAttachment
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
        [Required]
        public string AttachmentUrl { get; set; }

    }
}
