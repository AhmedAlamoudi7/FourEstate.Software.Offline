using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.REAlEstate
{
    public class RealEstateService : IRealEstateService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public RealEstateService(FourEstateDbContext db, IMapper mapper,IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.RealEstates.Include(x=>x.Category).Include(x=>x.Location).Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var realEstates = _mapper.Map<List<RealEstateViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = realEstates,
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




        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id && x.Type == ContentType.RealEstate).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }




        public async Task<List<RealEstateViewModel>> GetRealEstateName()
        {
            var realEstates = await _db.RealEstates.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<RealEstateViewModel>>(realEstates);
        }


        public async Task<int> Delete(int id)
        {
            var realEstates = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (realEstates == null)
            {
                throw new EntityNotFoundException();
            }
            realEstates.IsDelete = true;
            _db.RealEstates.Update(realEstates);
            await _db.SaveChangesAsync();
            return realEstates.Id;
        }



        public async Task<UpdateRealEstateDto> Get(int id)
        {
            var realEstates = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (realEstates == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateRealEstateDto>(realEstates);
        }




        public async Task<int> Create(CreateRealEstateDto dto)
        {
            var realEstates = _mapper.Map<RealEstate>(dto);
            await _db.RealEstates.AddAsync(realEstates);
            await _db.SaveChangesAsync();


            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var realEstatesAttachment = new RealEstatetAttachment();
                    realEstatesAttachment.AttachmentUrl = await _fileService.SaveFile(a, "Images");
                    realEstatesAttachment.RealEstateId = realEstates.Id;
                    await _db.RealEstatetAttachments.AddAsync(realEstatesAttachment);
                    await _db.SaveChangesAsync();
                }
            }
            return realEstates.Id;
        }


        public async Task<int> Update(UpdateRealEstateDto dto)
        {

            var realEstates = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if (realEstates == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedrealEstates = _mapper.Map(dto, realEstates);

            if (dto.Attachments != null)
            {
                foreach (var a in dto.Attachments)
                {
                    var realEstatesAttachment = new RealEstatetAttachment();
                    realEstatesAttachment.AttachmentUrl = await _fileService.SaveFile(a, "Images");
                    realEstatesAttachment.RealEstateId = realEstates.Id;
                    await _db.RealEstatetAttachments.AddAsync(realEstatesAttachment);
                    await _db.SaveChangesAsync();
                }
            }

            _db.RealEstates.Update(updatedrealEstates);
            await _db.SaveChangesAsync();

            return realEstates.Id;
        }

        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var realEstate = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (realEstate == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = realEstate.Id;
            changeLog.Type = ContentType.RealEstate;
            changeLog.Old = realEstate.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();

            realEstate.Stauts = status;
            _db.RealEstates.Update(realEstate);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return realEstate.Id;
        }
    }
}



