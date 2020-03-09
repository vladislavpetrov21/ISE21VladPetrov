using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyBusinessLogic.BindingModels
{   
    public class CreateOrderBindingModel
    {
        public int VoucherId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
