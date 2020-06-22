using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TourAgencyDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("ClientId")]
        public List<Order> Orders { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
    }
}
