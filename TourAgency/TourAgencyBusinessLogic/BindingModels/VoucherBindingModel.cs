using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyBusinessLogic.BindingModels
{    
    public class VoucherBindingModel
    {
        public int? Id { get; set; }
        public string VoucherName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> VoucherTours { get; set; }
    }
}
