using FourEstate.Core.Constants;
using FourEstate.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
   public class AuctionDb : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DOAuction { get; set; }
        public int NumberOfPieces { get; set; }
        public AuctionType AuctionType { get; set; }
        public CourtType CourtType { get; set; }

        public ContentStatus Stauts { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public List<AuctionDbAttachment> Attachments { get; set; }

        public AuctionDb()
        {
            Stauts = ContentStatus.Pending;
        }
    }
}
