﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgencyBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageToursBindingModel> StorageTours { get; set; }
    }
}
