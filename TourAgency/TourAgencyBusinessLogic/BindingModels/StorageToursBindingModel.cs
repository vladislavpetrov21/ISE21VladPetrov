using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyBusinessLogic.BindingModels
{
    public class StorageToursBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int TourId { get; set; }
        public int Count { get; set; }
    }
}
