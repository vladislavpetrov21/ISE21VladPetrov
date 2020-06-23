using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyListImplement.Models
{
    public class StorageTours
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int TourId { get; set; }
        public int Count { get; set; }
    }
}
