using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourAgencyBusinessLogic.ViewModels
{
    public class StorageToursViewModel
    {
		public int Id { get; set; }
		public int StorageId { get; set; }
		public int TourId { get; set; }
		[DisplayName("Название тура")]
		public string TourName { get; set; }
		[DisplayName("Количество")]
		public int Count { get; set; }
	}
}
