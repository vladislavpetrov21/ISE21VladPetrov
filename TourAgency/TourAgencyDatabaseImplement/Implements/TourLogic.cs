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
    public class TourLogic : ITourLogic
    {
        public void CreateOrUpdate(TourBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                Tour element = context.Tours.FirstOrDefault(rec =>
               rec.TourName == model.TourName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Tours.FirstOrDefault(rec => rec.Id ==
                   model.Id);                  
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Tour();
                    context.Tours.Add(element);
                }
                element.TourName = model.TourName;
                context.SaveChanges();
            }
        }
        public void Delete(TourBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                Tour element = context.Tours.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Tours.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<TourViewModel> Read(TourBindingModel model)
        {
            using (var context = new TourAgencyDatabase())
            {
                return context.Tours
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new TourViewModel
                {
                    Id = rec.Id,
                    TourName = rec.TourName
                })
                .ToList();
            }
        }
    }
}
