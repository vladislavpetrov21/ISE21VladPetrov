using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourAgencyRestApi
{
    public class VoucherModel
    {
        public int Id { get; set; }
        public string VoucherName { get; set; }
        public decimal Price { get; set; }
    }
}
