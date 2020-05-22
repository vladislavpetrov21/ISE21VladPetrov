using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TourAgencyBusinessLogic.Enums;
using System.Runtime.Serialization;

namespace TourAgencyBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        [DisplayName("ID")]
        public int VoucherId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Путевка")]
        public string VoucherName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        [DataMember]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
