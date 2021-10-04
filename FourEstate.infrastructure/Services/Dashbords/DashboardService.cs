using FourEstate.Core.ViewModels;
using FourEstate.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Dashbords
{
    public class DashboardService :IDashboardService
    {

        private readonly FourEstateDbContext _db ;

        public DashboardService(FourEstateDbContext db)
        {
            _db = db;
        }


        public async Task<DashboardViewModel> GetData()
        {

            var dash= new DashboardViewModel();
            dash.NoumberOfCategory = await _db.Categories.CountAsync(x=>!x.IsDelete);
            dash.NoumberOfAdvertisment = await _db.Advertisements.CountAsync(x => !x.IsDelete);
            dash.NoumberOfLocation = await _db.Locations.CountAsync(x => !x.IsDelete);
            dash.NoumberOfContracts = await _db.Contracts.CountAsync(x => !x.IsDelete);
            dash.NoumberOfCustomer = await _db.Customers.CountAsync(x => !x.IsDelete);
            dash.NoumberOfRealEstate = await _db.RealEstates.CountAsync(x => !x.IsDelete);
            dash.NoumberOfUsers = await _db.Users.CountAsync(x => !x.IsDelete);
            return dash;
        }







        public async Task<List<PieChartViewModel>> GetUsersDataChart()
        {

            var chart = new List<PieChartViewModel>();
            chart.Add(new PieChartViewModel()
            {
             Key = "Administrator",
             Value = await _db.Users.CountAsync(x=> !x.IsDelete && x.UserType ==Core.Enums.UserType.Administrator),
             Color = "Red",
             });
            chart.Add(new PieChartViewModel()
            {
                Key = "Customer",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == Core.Enums.UserType.Customer),
                Color = "Yellow",
            });
            chart.Add(new PieChartViewModel()
            {
                Key = "Advertisement Owner",
                Value = await _db.Users.CountAsync(x => !x.IsDelete && x.UserType == Core.Enums.UserType.AdvertisementOwner),
                Color = "Orange",
            });
      
       

            return chart;
        }




    }
}
