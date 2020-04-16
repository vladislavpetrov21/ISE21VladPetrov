using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.HelperModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ITourLogic tourLogic;
        private readonly IVoucherLogic voucherLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IVoucherLogic voucherLogic, ITourLogic tourLogic,
       IOrderLogic orderLLogic)
        {
            this.voucherLogic = voucherLogic;
            this.tourLogic = tourLogic;
            this.orderLogic = orderLLogic;
        }
        public List<ReportVoucherTourViewModel> GetVoucherTour()
        {
            var tours = tourLogic.Read(null);
            var vouchers = voucherLogic.Read(null);
            var list = new List<ReportVoucherTourViewModel>();
            foreach (var tour in tours)
            {
                foreach (var voucher in vouchers)
                {
                    if (voucher.VoucherTours.ContainsKey(tour.Id))
                    {
                        var record = new ReportVoucherTourViewModel
                        {
                            VoucherName = voucher.VoucherName,
                            TourName = tour.TourName,
                            Count = voucher.VoucherTours[tour.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }       
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                VoucherName = x.VoucherName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }       
        public void SaveToursToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список туров",
                Tours = tourLogic.Read(null)
            });
        }      
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveVoucherToursToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Детализация пакетов ",
                VoucherTours = GetVoucherTour()
            });
        }
    }
}
