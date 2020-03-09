using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyListImplement.Models;

namespace TourAgencyListImplement.Implements
{
    public class TourLogic : ITourLogic
    {
        private readonly DataListSingleton source;
        public TourLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(TourBindingModel model)
        {
            Tour tempTour = model.Id.HasValue ? null : new Tour
            {
                Id = 1
            };
            foreach (var tour in source.Tours)
            {
                if (tour.TourName == model.TourName && tour.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть тур с таким названием");
                }
                if (!model.Id.HasValue && tour.Id >= tempTour.Id)
                {
                    tempTour.Id = tour.Id + 1;
                }
                else if (model.Id.HasValue && tour.Id == model.Id)                 
                {
                    tempTour = tour;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempTour == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempTour);
            }
            else
            {
                source.Tours.Add(CreateModel(model, tempTour));
            }
        }
        public void Delete(TourBindingModel model)
        {
            for (int i = 0; i < source.Tours.Count; ++i)
            {
                if (source.Tours[i].Id == model.Id.Value)
                {
                    source.Tours.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<TourViewModel> Read(TourBindingModel model)
        {
            List<TourViewModel> result = new List<TourViewModel>();
            foreach (var tour in source.Tours)
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
        private Tour CreateModel(TourBindingModel model, Tour tour)
        {
            tour.TourName = model.TourName;
            return tour;
        }
        private TourViewModel CreateViewModel(Tour tour)
        {
            return new TourViewModel
        {
            Id = tour.Id,
            TourName = tour.TourName
            };
        }
    }
}
