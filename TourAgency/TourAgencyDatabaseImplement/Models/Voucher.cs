using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TourAgencyDatabaseImplement.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        [Required]
        public string VoucherName { get; set; }
        [ForeignKey("VoucherId")]
        [Required]
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual VoucherTour VoucherTour { get; set; }
    }
}
