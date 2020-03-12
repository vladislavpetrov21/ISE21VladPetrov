using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyFileImplement.Models;

namespace TourAgencyFileImplement.Implements
{
    public class VoucherLogic : IVoucherLogic
    {
        private readonly FileDataListSingleton source;
        public VoucherLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(VoucherBindingModel model)
        {
            Voucher element = source.Vouchers.FirstOrDefault(rec => rec.VoucherName ==
           model.VoucherName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть путевка с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Vouchers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Vouchers.Count > 0 ? source.Tours.Max(rec =>
               rec.Id) : 0;
                element = new Voucher { Id = maxId + 1 };
                source.Vouchers.Add(element);
            }
            element.VoucherName = model.VoucherName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.VoucherTours.RemoveAll(rec => rec.VoucherId == model.Id &&
           !model.VoucherTours.ContainsKey(rec.TourId));
            // обновили количество у существующих записей
            var updateTours = source.VoucherTours.Where(rec => rec.VoucherId ==
           model.Id && model.VoucherTours.ContainsKey(rec.TourId));
            foreach (var updateTour in updateTours)
            {
                updateTour.Count =
               model.VoucherTours[updateTour.TourId].Item2;
                model.VoucherTours.Remove(updateTour.TourId);
            }
            // добавили новые
            int maxPCId = source.VoucherTours.Count > 0 ?
           source.VoucherTours.Max(rec => rec.Id) : 0;            
            foreach (var pc in model.VoucherTours)
            {
                source.VoucherTours.Add(new VoucherTour
                {
                    Id = ++maxPCId,
                    VoucherId = element.Id,
                    TourId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(VoucherBindingModel model)
        {
            // удаяем записи по турам при удалении путевки
            source.VoucherTours.RemoveAll(rec => rec.VoucherId == model.Id);
            Voucher element = source.Vouchers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Vouchers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<VoucherViewModel> Read(VoucherBindingModel model)
        {
            return source.Vouchers
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new VoucherViewModel
            {
                Id = rec.Id,
                VoucherName = rec.VoucherName,
                Price = rec.Price,
                VoucherTours = source.VoucherTours
            .Where(recPC => recPC.VoucherId == rec.Id)
            .ToDictionary(recPC => recPC.TourId, recPC =>
            (source.Tours.FirstOrDefault(recC => recC.Id ==
           recPC.TourId)?.TourName, recPC.Count))
            })
            .ToList();
        }
    }
}
