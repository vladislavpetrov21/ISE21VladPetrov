using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyFileImplement.Models
{
    public class VoucherTour
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int TourId { get; set; }
        public int Count { get; set; }
    }
}
