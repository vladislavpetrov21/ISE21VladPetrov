using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TourAgencyBusinessLogic.Attributes;

namespace TourAgencyBusinessLogic.ViewModels
{
    public class TourViewModel : BaseViewModel
    {
        [Column(title: "Тур", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string TourName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "TourName"
        };
    }
}
