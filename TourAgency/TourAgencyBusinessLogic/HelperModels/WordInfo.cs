using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<VoucherViewModel> Vouchers { get; set; }
    }
}
