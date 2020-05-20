using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyBusinessLogic.HelperModels;

namespace TourAgencyBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ITourLogic TourLogic;
        private readonly IVoucherLogic VoucherLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IVoucherLogic VoucherLogic, ITourLogic TourLogic,
       IOrderLogic orderLogic)
        {
            this.VoucherLogic = VoucherLogic;
            this.TourLogic = TourLogic;
            this.orderLogic = orderLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportVoucherTourViewModel> GetVoucherTour()
        {
            var Vouchers = VoucherLogic.Read(null);
            var list = new List<ReportVoucherTourViewModel>();
            foreach (var voucher in Vouchers)
            {
                foreach (var vt in voucher.VoucherTours)
                {
                    var record = new ReportVoucherTourViewModel
                    {
                        VoucherName = voucher.VoucherName,
                        TourName = vt.Value.Item1,
                        Count = vt.Value.Item2
                    };
                    list.Add(record);
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
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveVouchersToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                Vouchers = VoucherLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение закусок с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
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

        /// <summary>
        /// Сохранение закусок с продуктами в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveVouchersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список туров по путевкам",
                VoucherTours = GetVoucherTour(),
            });
        }
    }
}
