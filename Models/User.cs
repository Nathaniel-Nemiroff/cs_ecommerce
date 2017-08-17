using System;
using System.ComponentModel.DataAnnotations;

namespace proj
{
	public class User : basemodel
	{
		[Key]
		public int UserId{get;set;}
		public string Name{get;set;}

		public DateTime CreatedAt{get;set;}
		public DateTime UpdatedAt{get;set;}

		public User()
		{
			CreatedAt = DateTime.Now;
			UpdatedAt = DateTime.Now;
		}
	}
}
