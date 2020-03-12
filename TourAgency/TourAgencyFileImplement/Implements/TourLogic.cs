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
    public class TourLogic : ITourLogic
    {
        private readonly FileDataListSingleton source;
        public TourLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(TourBindingModel model)
        {
            Tour element = source.Tours.FirstOrDefault(rec => rec.TourName
           == model.TourName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть тур с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Tours.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Tours.Count > 0 ? source.Tours.Max(rec =>
               rec.Id) : 0;
                element = new Tour { Id = maxId + 1 };
                source.Tours.Add(element);
            }
            element.TourName = model.TourName;
        }
        public void Delete(TourBindingModel model)
        {
            Tour element = source.Tours.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Tours.Remove(element);
            }
            else
            {               
                throw new Exception("Элемент не найден");
            }
        }
        public List<TourViewModel> Read(TourBindingModel model)
        {
            return source.Tours
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
