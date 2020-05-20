using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.Enums;

namespace TourAgencyBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string VoucherName { get; set; }
        public string TourName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
