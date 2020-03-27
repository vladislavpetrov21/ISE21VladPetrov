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
        public virtual List<Order> Orders { get; set; }
        public virtual List<VoucherTour> VoucherTours { get; set; }
    }
}
