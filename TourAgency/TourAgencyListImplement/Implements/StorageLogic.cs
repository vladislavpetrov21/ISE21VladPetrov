using System;
using System.Collections.Generic;
using System.Text;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using TourAgencyListImplement.Models;

namespace TourAgencyListImplement.Implements
{
	public class StorageLogic : IStorageLogic
	{
		private readonly DataListSingleton source;
		public StorageLogic()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<StorageViewModel> GetList()
		{
			List<StorageViewModel> result = new List<StorageViewModel>();
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				List<StorageToursViewModel> StorageTours = new
	List<StorageToursViewModel>();
				for (int j = 0; j < source.StorageTours.Count; ++j)
				{
					if (source.StorageTours[j].StorageId == source.Storages[i].Id)
					{
						string TourName = string.Empty;
						for (int k = 0; k < source.Tours.Count; ++k)
						{
							if (source.StorageTours[j].TourId ==
						   source.Tours[k].Id)
							{
								TourName = source.Tours[k].TourName;
								break;
							}
						}
						StorageTours.Add(new StorageToursViewModel
						{
							Id = source.StorageTours[j].Id,
							StorageId = source.StorageTours[j].StorageId,
							TourId = source.StorageTours[j].TourId,
							TourName = TourName,
							Count = source.StorageTours[j].Count
						});
					}
				}
				result.Add(new StorageViewModel
				{
					Id = source.Storages[i].Id,
					StorageName = source.Storages[i].StorageName,
					StorageTours = StorageTours
				});
			}
			return result;
		}
		public StorageViewModel GetElement(int id)
		{
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				List<StorageToursViewModel> StorageBilletss = new
	List<StorageToursViewModel>();
				for (int j = 0; j < source.StorageTours.Count; ++j)
				{
					if (source.StorageTours[j].StorageId == source.Storages[i].Id)
					{
						string BilletsName = string.Empty;
						for (int k = 0; k < source.Tours.Count; ++k)
						{
							if (source.StorageTours[j].TourId ==
						   source.Tours[k].Id)
							{
								BilletsName = source.Tours[k].TourName;
								break;
							}
						}
						StorageBilletss.Add(new StorageToursViewModel
						{
							Id = source.StorageTours[j].Id,
							StorageId = source.StorageTours[j].StorageId,
							TourId = source.StorageTours[j].TourId,
							TourName = BilletsName,
							Count = source.StorageTours[j].Count
						});
					}
				}
				if (source.Storages[i].Id == id)
				{
					return new StorageViewModel
					{
						Id = source.Storages[i].Id,
						StorageName = source.Storages[i].StorageName,
						StorageTours = StorageBilletss
					};
				}
			}
			throw new Exception("Элемент не найден");
		}
		public void AddElement(StorageBindingModel model)
		{
			int maxId = 0;
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id > maxId)
				{
					maxId = source.Storages[i].Id;
				}
				if (source.Storages[i].StorageName == model.StorageName)
				{
					throw new Exception("Уже есть склад с таким названием");
				}
			}
			source.Storages.Add(new Storage
			{
				Id = maxId + 1,
				StorageName = model.StorageName
			});
		}
		public void UpdElement(StorageBindingModel model)
		{
			int index = -1;
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id == model.Id)
				{
					index = i;
				}
				if (source.Storages[i].StorageName == model.StorageName &&
				source.Storages[i].Id != model.Id)
				{
					throw new Exception("Уже есть склад с таким названием");
				}
			}
			if (index == -1)
			{
				throw new Exception("Элемент не найден");
			}
			source.Storages[index].StorageName = model.StorageName;
		}
		public void DelElement(int id)
		{
			for (int i = 0; i < source.StorageTours.Count; ++i)
			{
				if (source.StorageTours[i].StorageId == id)
				{
					source.StorageTours.RemoveAt(i--);
				}
			}
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id == id)
				{
					source.Storages.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		public void FillStorage(StorageToursBindingModel model)
		{
			int foundItemIndex = -1;
			for (int i = 0; i < source.StorageTours.Count; ++i)
			{
				if (source.StorageTours[i].TourId == model.TourId
					&& source.StorageTours[i].StorageId == model.StorageId)
				{
					foundItemIndex = i;
					break;
				}
			}
			if (foundItemIndex != -1)
			{
				source.StorageTours[foundItemIndex].Count =
					source.StorageTours[foundItemIndex].Count + model.Count;
			}
			else
			{
				int maxId = 0;
				for (int i = 0; i < source.StorageTours.Count; ++i)
				{
					if (source.StorageTours[i].Id > maxId)
					{
						maxId = source.StorageTours[i].Id;
					}
				}
				source.StorageTours.Add(new StorageTours
				{
					Id = maxId + 1,
					StorageId = model.StorageId,
					TourId = model.TourId,
					Count = model.Count
				});
			}
		}
	}
}
