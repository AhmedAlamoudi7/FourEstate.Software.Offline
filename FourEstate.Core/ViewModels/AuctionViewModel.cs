using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
     
        public string Title { get; set; }
    
        public string Description { get; set; }
   
        public string DOAuction { get; set; }

        public int NumberOfPieces { get; set; }

        public string AuctionType { get; set; }

        public string CourtType { get; set; }
        public string Status { get; set; }

        public RealEstateViewModel RealEstate { get; set; }

        public List<AuctionAttachmentViewModel> AuctionAttachmentViewModel { get; set; }
    }
}
