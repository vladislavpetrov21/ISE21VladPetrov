using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourAgencyBusinessLogic.ViewModels
{    
    public class VoucherViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название путевки")]
        public string VoucherName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> VoucherTours { get; set; }
    }
}
