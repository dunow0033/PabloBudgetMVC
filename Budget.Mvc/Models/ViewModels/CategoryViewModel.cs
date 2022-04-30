using System.ComponentModel.DataAnnotations;

namespace Budget.Mvc.Models.ViewModels
{
	public class CategoryViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}

