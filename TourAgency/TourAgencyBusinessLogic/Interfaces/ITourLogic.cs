using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.Interfaces
{
    public interface ITourLogic
    {
        List<TourViewModel> Read(TourBindingModel model);
        void CreateOrUpdate(TourBindingModel model);
        void Delete(TourBindingModel model);
    }
}
