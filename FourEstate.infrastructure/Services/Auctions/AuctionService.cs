using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Helpers;
using FourEstate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Auctions
{
     public class AuctionService :IAuctionService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _FileService;
        public AuctionService(FourEstateDbContext db, IMapper mapper, IFileService FileService)
        {
            _db = db;
            _mapper = mapper;
            _FileService = FileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.AuctionsDb.Include(x=>x.Attachments).Include(x => x.RealEstate)
                .Where(x => !x.IsDelete && (x.Title.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch)))
                .AsQueryable();


            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var auction = _mapper.Map<List<AuctionDbViewModel>>(dataList);

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


        public async Task<List<AuctionDbViewModel>> GetAllAPI(string serachKey)
        {
            var buycontract = await _db.AuctionsDb.Include(x=>x.Attachments)
                .Include(x => x.RealEstate).ThenInclude(x => x.Location)
                .Include(x => x.RealEstate).ThenInclude(x => x.Category)
                .Where(x => x.Stauts.ToString().Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey))
                .ToListAsync();
            return _mapper.Map<List<AuctionDbViewModel>>(buycontract);
        }





        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id ).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }



        public async Task<List<AuctionDbViewModel>> GetAuctionName()
        {
            var auctionDb = await _db.Contracts.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<AuctionDbViewModel>>(auctionDb);
        }


        public async Task<int> Create(CreateAuctionDto dto)
        {
            var auctoinDb = _mapper.Map<CreateAuctionDto, AuctionDb>(dto);
            await _db.AuctionsDb.AddAsync(auctoinDb);
            await _db.SaveChangesAsync();


            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var auctionDbAttachment = new AuctionDbAttachment();
                    auctionDbAttachment.AttachmentUrl = await _FileService.SaveFile(a, "Images");
                    auctionDbAttachment.AuctionDbId = auctoinDb.Id;
                    await _db.AuctionDbAttachments.AddAsync(auctionDbAttachment);
                    await _db.SaveChangesAsync();
                }
            }
            return auctoinDb.Id;
        }

        
        
        public async Task<int> Update(UpdateAuctionDto dto)
        {
            var auctionDb = await _db.AuctionsDb.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (auctionDb == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedauctionDb = _mapper.Map<UpdateAuctionDto, AuctionDb>(dto, auctionDb);
            _db.AuctionsDb.Update(updatedauctionDb);
            await _db.SaveChangesAsync();

            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var auctionDbAttachment = new AuctionDbAttachment();
                    auctionDbAttachment.AttachmentUrl = await _FileService.SaveFile(a, "Images");
                    auctionDbAttachment.AuctionDbId = updatedauctionDb.Id;
                    await _db.AuctionDbAttachments.AddAsync(auctionDbAttachment);
                    await _db.SaveChangesAsync();
                }
            }
            return updatedauctionDb.Id;
        }


        public async Task<UpdateAuctionDto> Get(int Id)
        {
            var auctionDb = await _db.AuctionsDb.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (auctionDb == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateAuctionDto>(auctionDb);
        }



        public async Task<int> Delete(int Id)
        {
            var auctionDb = await _db.AuctionsDb.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (auctionDb == null)
            {
                throw new EntityNotFoundException();
            }
            auctionDb.IsDelete = true;
            _db.AuctionsDb.Update(auctionDb);
            await _db.SaveChangesAsync();
            return auctionDb.Id;
        }




        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var auctionDb = await _db.AuctionsDb.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (auctionDb == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = auctionDb.Id;
            changeLog.Type = ContentType.Auction;
            changeLog.Old = auctionDb.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();


            auctionDb.Stauts = status;
            _db.AuctionsDb.Update(auctionDb);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return auctionDb.Id;
        }



        public async Task<byte[]> ExportToExcel()
        {
            var auctionDb = await _db.AuctionsDb.Include(x => x.RealEstate).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"CourtType", new ExcelColumn("CourtType", 0)},
                {"AuctionType", new ExcelColumn("AuctionType", 1)},
                {"RealEstate", new ExcelColumn("RealEstate", 2)},
                {"DOAuction", new ExcelColumn("DOAuction", 3)}
            }, new List<ExcelRow>(auctionDb.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"CourtType", e.CourtType.ToString()},
                    {"AuctionType", e.AuctionType.ToString()},
                    {"RealEstate", e.RealEstate.Name},
                    {"DOAuction", e.DOAuction.ToString()}
                }
            })));
     
        }


        public async Task<int> RemoveAttachment(int id)
        {
            var auctionDb = await _db.AuctionDbAttachments.SingleOrDefaultAsync(x => x.Id == id);
            if (auctionDb == null)
            {
                throw new EntityNotFoundException();
            }
            _db.AuctionDbAttachments.Remove(auctionDb);
            await _db.SaveChangesAsync();
            return auctionDb.Id;
        }

    }
}
