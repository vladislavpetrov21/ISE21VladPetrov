﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyBusinessLogic.BindingModels
{   
    public class ChangeStatusBindingModel
    {
        public int OrderId { get; set; }
        public int? ImplementerId { get; set; }
    }
}
