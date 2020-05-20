using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyDatabaseImplement.Models;

namespace TourAgencyDatabaseImplement.Implements
{
    public class VoucherLogic : IVoucherLogic
    {
        public void CreateOrUpdate(VoucherBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Voucher element = context.Vouchers.FirstOrDefault(rec =>
                       rec.VoucherName == model.VoucherName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть путевка с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Vouchers.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else                          
                        {
                            element = new Voucher();
                            context.Vouchers.Add(element);
                        }
                        element.VoucherName = model.VoucherName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.VoucherTours.Where(rec
                           => rec.VoucherId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.VoucherTours.RemoveRange(productComponents.Where(rec =>
                            !model.VoucherTours.ContainsKey(rec.TourId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.VoucherTours[updateComponent.TourId].Item2;

                                model.VoucherTours.Remove(updateComponent.TourId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.VoucherTours)
                        {
                            context.VoucherTours.Add(new VoucherTour
                            {
                                VoucherId = element.Id,
                                TourId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(VoucherBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {                        
                        context.VoucherTours.RemoveRange(context.VoucherTours.Where(rec =>
                        rec.VoucherId == model.Id));
                        Voucher element = context.Vouchers.FirstOrDefault(rec => rec.Id                      
                       == model.Id);
                        if (element != null)
                        {
                            context.Vouchers.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<VoucherViewModel> Read(VoucherBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                return context.Vouchers
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new VoucherViewModel
               {
                   Id = rec.Id,
                   VoucherName = rec.VoucherName,
                   Price = rec.Price,
                   VoucherTours = context.VoucherTours
                .Include(recPC => recPC.Tour)
               .Where(recPC => recPC.VoucherId == rec.Id)
               .ToDictionary(recPC => recPC.VoucherId, recPC =>
                (recPC.Tour?.TourName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
