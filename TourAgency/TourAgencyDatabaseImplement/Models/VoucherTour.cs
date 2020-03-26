using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourAgencyDatabaseImplement.Models
{
    public class VoucherTour
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int TourId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
