﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TourAgencyBusinessLogic.Enums;
using TourAgencyFileImplement.Models;

namespace TourAgencyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string TourFileName = "C:\\Users\\par55\\Documents\\TourAgency\\Tour.xml";
        private readonly string OrderFileName = "C:\\Users\\par55\\Documents\\TourAgency\\Order.xml";
        private readonly string VoucherFileName = "C:\\Users\\par55\\Documents\\TourAgency\\Voucher.xml";
        private readonly string VoucherTourFileName = "C:\\Users\\par55\\Documents\\TourAgency\\VoucherTour.xml";
        public List<Tour> Tours { get; set; }
        public List<Order> Orders { get; set; }
        public List<Voucher> Vouchers { get; set; }
        public List<VoucherTour> VoucherTours { get; set; }
        private FileDataListSingleton()
        {
            Tours = LoadTours();
            Orders = LoadOrders();
            Vouchers = LoadVouchers();
            VoucherTours = LoadVoucherTours();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveTours();
            SaveOrders();
            SaveVouchers();
            SaveVoucherTours();            
        }
        private List<Tour> LoadTours()
        {
            var list = new List<Tour>();
            if (File.Exists(TourFileName))
            {
                XDocument xDocument = XDocument.Load(TourFileName);
                var xElements = xDocument.Root.Elements("Tour").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Tour
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TourName = elem.Element("TourName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        VoucherId = Convert.ToInt32(elem.Element("VoucherId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate =
                         Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Voucher> LoadVouchers()
        {
            var list = new List<Voucher>();
            if (File.Exists(VoucherFileName))
            {
                XDocument xDocument = XDocument.Load(VoucherFileName);                
                var xElements = xDocument.Root.Elements("Voucher").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Voucher
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        VoucherName = elem.Element("VoucherName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<VoucherTour> LoadVoucherTours()
        {
            var list = new List<VoucherTour>();
            if (File.Exists(VoucherTourFileName))
            {
                XDocument xDocument = XDocument.Load(VoucherTourFileName);
                var xElements = xDocument.Root.Elements("VoucherTour").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new VoucherTour
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        VoucherId = Convert.ToInt32(elem.Element("VoucherId").Value),
                        TourId = Convert.ToInt32(elem.Element("TourId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveTours()
        {
            if (Tours != null)
            {
                var xElement = new XElement("Tours");
                foreach (var tour in Tours)
                {
                    xElement.Add(new XElement("Tour",
                    new XAttribute("Id", tour.Id),
                    new XElement("TourName", tour.TourName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(TourFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {                
            var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("VoucherId", order.VoucherId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveVouchers()
        {
            if (Vouchers != null)
            {
                var xElement = new XElement("Vouchers");
                foreach (var voucher in Vouchers)
                {
                    xElement.Add(new XElement("Voucher",
                    new XAttribute("Id", voucher.Id),
                    new XElement("VoucherName", voucher.VoucherName),
                    new XElement("Price", voucher.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(VoucherFileName);
            }
        }
        private void SaveVoucherTours()
        {
            if (VoucherTours != null)
            {
                var xElement = new XElement("VoucherTours");
                foreach (var voucherTour in VoucherTours)
                {
                    xElement.Add(new XElement("VoucherTour",
                    new XAttribute("Id", voucherTour.Id),
                    new XElement("VoucherId", voucherTour.VoucherId),
                    new XElement("TourId", voucherTour.TourId),
                    new XElement("Count", voucherTour.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(VoucherTourFileName);
            }
        }
    }
}
