using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModel;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.Auctions
{
    public class AuctionService : IAuctionService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public AuctionService(FourEstateDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Auctions.Include(x => x.RealEstate).Where(x => !x.IsDelete && (x.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var auction = _mapper.Map<List<AuctionViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = auction,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }




        public async Task<List<AuctionViewModel>> GetAllAPI(/*int page*/string serachKey)
        {
            var auction = await _db.Auctions.Include(x => x.RealEstate).Where(x => x.Title.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).ToListAsync();
            return _mapper.Map<List<AuctionViewModel>>(auction);


        }


        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id && x.Type == ContentType.RealEstate).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }




        public async Task<List<AuctionViewModel>> GetAuctionName()
        {
            var auction = await _db.Auctions.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<AuctionViewModel>>(auction);
        }


        public async Task<int> Delete(int id)
        {
            var auction = await _db.Auctions.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (auction == null)
            {
                throw new EntityNotFoundException();
            }
            auction.IsDelete = true;
            _db.Auctions.Update(auction);
            await _db.SaveChangesAsync();
            return auction.Id;
        }



        public async Task<UpdateAuctionDto> Get(int id)
        {
            var auction = await _db.Auctions.Include(x => x.RealEstate).Include(x => x.Attachments).SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (auction == null)
            {
                throw new EntityNotFoundException();
            }
            var dto = _mapper.Map<UpdateAuctionDto>(auction);


            if (auction.Attachments != null)
            {
                dto.AuctionAttachments = _mapper.Map<List<AuctionAttachmentViewModel>>(auction.Attachments);
            }

            return dto;
        }




        public async Task<int> Create(CreateAuctionDto dto)
        {
            var auctions = _mapper.Map<Auction>(dto);
            await _db.Auctions.AddAsync(auctions);
            await _db.SaveChangesAsync();


            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var auctionsAttachment = new AuctionAttachment();
                    auctionsAttachment.AttachmentUrl = await _fileService.SaveFile(a, "Images");
                    auctionsAttachment.AuctionId = auctions.Id;
                    await _db.AuctionAttachments.AddAsync(auctionsAttachment);
                    await _db.SaveChangesAsync();
                }
            }
            return auctions.Id;
        }


        public async Task<int> Update(UpdateAuctionDto dto)
        {

            var auctions = await _db.Auctions.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (auctions == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedauctions = _mapper.Map(dto, auctions);
            _db.Auctions.Update(updatedauctions);
            await _db.SaveChangesAsync();

            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var auctionAttachment = new AuctionAttachment();
                    auctionAttachment.AttachmentUrl = await _fileService.SaveFile(a, "Images");
                    auctionAttachment.AuctionId = auctions.Id;
                    await _db.AuctionAttachments.AddAsync(auctionAttachment);
                    await _db.SaveChangesAsync();
                }
            }



            return auctions.Id;
        }

        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var auctions = await _db.Auctions.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (auctions == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = auctions.Id;
            changeLog.Type = ContentType.RealEstate;
            changeLog.Old = auctions.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();

            auctions.Stauts = status;
            _db.Auctions.Update(auctions);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return auctions.Id;
        }





        public async Task<byte[]> ExportToExcel()
        {
            var auction = await _db.Auctions.Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"Name", new ExcelColumn("Name", 0)},
                {"Description", new ExcelColumn("Description", 1)},
                {"DOAuction", new ExcelColumn("DOAuction", 2)},
                {"AuctionType", new ExcelColumn("AuctionType", 3)},
                {"NumberOfPieces", new ExcelColumn("NumberOfPieces", 4)}
            }, new List<ExcelRow>(auction.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"Name", e.Title},
                    {"Description", e.Description},
                    {"DOAuction", e.DOAuction.ToString()},
                    {"AuctionType", e.AuctionType.ToString()},
                    {"NumberOfPieces", e.NumberOfPieces.ToString()}
                }
            })));
        }


        public async Task<int> RemoveAttachment(int id)
        {
            var auction = await _db.AuctionAttachments.SingleOrDefaultAsync(x => x.Id == id);
            if (auction == null)
            {
                throw new EntityNotFoundException();
            }
            _db.AuctionAttachments.Remove(auction);
            await _db.SaveChangesAsync();
            return auction.Id;
        }
    }
}



