using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyListImplement.Models;

namespace TourAgencyListImplement.Implements
{
    public class VoucherLogic : IVoucherLogic
    {
        private readonly DataListSingleton source;
        public VoucherLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(VoucherBindingModel model)
        {
            Voucher tempVoucher = model.Id.HasValue ? null : new Voucher { Id = 1 };
            foreach (var voucher in source.Vouchers)
            {
                if (voucher.VoucherName == model.VoucherName && voucher.Id != model.Id)
                {
                    throw new Exception("Уже есть путевка с таким названием");
                }
                if (!model.Id.HasValue && voucher.Id >= tempVoucher.Id)
                {
                    tempVoucher.Id = voucher.Id + 1;
                }
                else if (model.Id.HasValue && voucher.Id == model.Id)
                {
                    tempVoucher = voucher;
                }
            }
            if (model.Id.HasValue)
            {               
                if (tempVoucher == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempVoucher);
            }
            else
            {
                source.Vouchers.Add(CreateModel(model, tempVoucher));
            }
        }
        public void Delete(VoucherBindingModel model)
        {           
            for (int i = 0; i < source.VoucherTours.Count; ++i)
            {
                if (source.VoucherTours[i].VoucherId == model.Id)
                {
                    source.VoucherTours.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Vouchers.Count; ++i)
            {
                if (source.Vouchers[i].Id == model.Id)
                {
                    source.Vouchers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Voucher CreateModel(VoucherBindingModel model, Voucher product)
        {
            product.VoucherName = model.VoucherName;
            product.Price = model.Price;            
            int maxPCId = 0;
            for (int i = 0; i < source.VoucherTours.Count; ++i)
            {
                if (source.VoucherTours[i].Id > maxPCId)
                {
                    maxPCId = source.VoucherTours[i].Id;
                }
                if (source.VoucherTours[i].VoucherId == product.Id)
                {                    
                    if
                    (model.VoucherTours.ContainsKey(source.VoucherTours[i].TourId))
                    {                        
                        source.VoucherTours[i].Count =
                        model.VoucherTours[source.VoucherTours[i].TourId].Item2;                                           
                        model.VoucherTours.Remove(source.VoucherTours[i].VoucherId);
                    }
                    else
                    {
                        source.VoucherTours.RemoveAt(i--);                        
                    }
                }
            }            
            foreach (var pc in model.VoucherTours)
            {
                source.VoucherTours.Add(new VoucherTour
                {
                    Id = ++maxPCId,
                    VoucherId = product.Id,
                    TourId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<VoucherViewModel> Read(VoucherBindingModel model)
        {
            List<VoucherViewModel> result = new List<VoucherViewModel>();
            foreach (var tour in source.Vouchers)
            {
                if (model != null)
                {
                    if (tour.Id == model.Id)
                    {
                        result.Add(CreateViewModel(tour));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(tour));
            }
            return result;
        }
        private VoucherViewModel CreateViewModel(Voucher voucher)
        {            
        Dictionary<int, (string, int)> voucherTours = new Dictionary<int,(string, int)>();
            foreach (var pc in source.VoucherTours)
            {
                if (pc.VoucherId == voucher.Id)
                {
                    string tourName = string.Empty;
                    foreach (var tour in source.Tours)
                    {
                        if (pc.TourId == tour.Id)
                        {
                            tourName = tour.TourName;
                            break;
                        }
                    }
                    voucherTours.Add(pc.TourId, (tourName, pc.Count));
                }
            }
            return new VoucherViewModel
            {
                Id = voucher.Id,              
                VoucherName = voucher.VoucherName,
                Price = voucher.Price,
                VoucherTours = voucherTours
            };
        }
    }
}
