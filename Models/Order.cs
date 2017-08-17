using System;
using System.ComponentModel.DataAnnotations;

namespace proj
{
	public class Order : basemodel
	{
		[Key]
		public int OrderId{get;set;}

		public int UserId{get;set;}
		public User user{get;set;}

		public int ProductId{get;set;}
		public Product product{get;set;}

		public int Quantity{get;set;}

		public DateTime CreatedAt{get;set;}
		public DateTime UpdatedAt{get;set;}

		public Order()
		{
			CreatedAt = DateTime.Now;
			UpdatedAt = DateTime.Now;
		}
	}
}
