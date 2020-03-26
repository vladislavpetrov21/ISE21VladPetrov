using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TourAgencyDatabaseImplement.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [Required]
        public string TourName { get; set; }
        [ForeignKey("TourId")]
        public virtual List<VoucherTour> VoucherTours { get; set; }
    }
}
