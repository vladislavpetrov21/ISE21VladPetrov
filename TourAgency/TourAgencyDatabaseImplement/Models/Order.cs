using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TourAgencyBusinessLogic.Enums;

namespace TourAgencyDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
