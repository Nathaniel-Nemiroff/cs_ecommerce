using System;
using System.ComponentModel.DataAnnotations;

namespace proj
{
	public class Product : basemodel
	{
		[Key]
		public int ProductId{get;set;}
		public string Name{get;set;}

		public string URL{get;set;}

		public string Description{get;set;}

		public int Quantity{get;set;}

		public DateTime CreatedAt{get;set;}
		public DateTime UpdatedAt{get;set;}

		public Product()
		{
			CreatedAt = DateTime.Now;
			UpdatedAt = DateTime.Now;
		}
	}
}
