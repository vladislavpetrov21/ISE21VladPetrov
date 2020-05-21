using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyListImplement.Models;

namespace TourAgencyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Tour> Tours { get; set; }
        public List<Order> Orders { get; set; }
        public List<Voucher> Vouchers { get; set; }
        public List<VoucherTour> VoucherTours { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {           
            Tours = new List<Tour>();
            Orders = new List<Order>();
            Vouchers = new List<Voucher>();
            VoucherTours = new List<VoucherTour>();
            Clients = new List<Client>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
