using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TourAgencyBusinessLogic.Enums;
using System.Runtime.Serialization;
using TourAgencyBusinessLogic.Attributes;

namespace TourAgencyBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {       
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }       
        public int VoucherId { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Исполнитель", width: 100)]
        [DataMember]
        public string ImplementerFIO { get; set; }
        [Column(title: "Путевка", width: 100)]
        [DataMember]
        public string VoucherName { get; set; }
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ClientFIO",
            "VoucherName",
            "ImplementerFIO",
            "Count",
            "Sum",
            "Status",
            "DateCreate",
            "DateImplement"
        };
    }
}
