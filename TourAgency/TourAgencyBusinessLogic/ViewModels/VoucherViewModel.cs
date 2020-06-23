using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using TourAgencyBusinessLogic.Attributes;

namespace TourAgencyBusinessLogic.ViewModels
{
    [DataContract]
    public class VoucherViewModel : BaseViewModel
    {
        [Column(title: "Название путевки", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string VoucherName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> VoucherTours { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "VoucherName",
            "Price"
        };
    }
}
