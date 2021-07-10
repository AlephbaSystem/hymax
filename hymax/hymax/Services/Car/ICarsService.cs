using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using hymax.Models;
namespace hymax.Services.Cars
{

    interface ICarsService
    {
        Task<CarsModel> Status(CarsModel currentCar);
        ObservableCollection<CarsModel> CarLists();
    }
}
