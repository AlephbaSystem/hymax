using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using hymax.Models;

namespace hymax.Services.Cars
{
    class CarsServiceStub : ICarsService
    {
        public async Task<CarsModel> Status(CarsModel currentCar)
        {
            var rs = hymax.Localization.Localizations.GetResource();
            currentCar.UpdateTime = await Task.FromResult<DateTime>(DateTime.Now);
            currentCar.UpdateTimeLabel = string.Concat(rs.GetString("CarDateLabel"), currentCar.UpdateTime.ToString());
            currentCar.Status = rs.GetString("CarStatusOpen");
            currentCar.Description = "";
            currentCar.Title = "پژو ۲۰۶";
            return currentCar;
        }

        public ObservableCollection<CarsModel> CarLists()
        {
            ObservableCollection<CarsModel> Cars = new ObservableCollection<CarsModel>();
            var rs = hymax.Localization.Localizations.GetResource();

            var cr = new CarsModel { ImagePath = "caroff.png" };
            cr.ImagePath.ClassId = "car1";

            cr.UpdateTime = DateTime.Now;
            cr.UpdateTimeLabel = string.Concat(rs.GetString("CarDateLabel"), cr.UpdateTime.ToString());
            cr.Status = rs.GetString("CarStatusOpen");
            cr.Description = "";
            cr.Title = "پژو ۲۰۶";
            cr.ID = "car1";
            Cars.Add(cr);
            return Cars;
        }

    }
}
