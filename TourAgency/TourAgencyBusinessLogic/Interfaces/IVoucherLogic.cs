using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.Interfaces
{
    public interface IVoucherLogic
    {
        List<VoucherViewModel> Read(VoucherBindingModel model);
        void CreateOrUpdate(VoucherBindingModel model);
        void Delete(VoucherBindingModel model);
    }
}
