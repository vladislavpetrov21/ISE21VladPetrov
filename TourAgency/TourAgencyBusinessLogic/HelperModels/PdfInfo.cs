using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportVoucherTourViewModel> VoucherTours { get; set; }
    }
}
