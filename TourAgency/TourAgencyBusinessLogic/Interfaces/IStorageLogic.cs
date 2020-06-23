using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.ViewModels;

namespace TourAgencyBusinessLogic.Interfaces
{
    public interface IStorageLogic
    {
		List<StorageViewModel> GetList();
		StorageViewModel GetElement(int id);
		void AddElement(StorageBindingModel model);
		void UpdElement(StorageBindingModel model);
		void DelElement(int id);
		void FillStorage(StorageToursBindingModel model);
	}
}
