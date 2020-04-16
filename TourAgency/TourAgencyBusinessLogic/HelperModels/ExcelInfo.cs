﻿using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
        public List<ReportVoucherTourViewModel> VoucherTours { get; set; }
    }
}
