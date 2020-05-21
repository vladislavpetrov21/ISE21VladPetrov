using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.BusinessLogics;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IVoucherLogic _voucher;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IVoucherLogic voucher, MainLogic main)
        {
            _order = order;
            _voucher = voucher;
            _main = main;
        }
        [HttpGet]
        public List<VoucherModel> GetVoucherList() => _voucher.Read(null)?.Select(rec =>
      Convert(rec)).ToList();
        [HttpGet]
        public VoucherModel GetVoucher(int VoucherId) => Convert(_voucher.Read(new
       VoucherBindingModel
        { Id = VoucherId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private VoucherModel Convert(VoucherViewModel model)
        {
            if (model == null) return null;
            return new VoucherModel
            {
                Id = model.Id,
                VoucherName = model.VoucherName,
                Price = model.Price
            };
        }
    }
}
