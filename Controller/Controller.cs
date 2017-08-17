using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proj
{
	public class projController:Controller
	{
		private projContext _context;

		public projController(projContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			ViewBag.Products = _context.Products.ToList();
			ViewBag.Orders = _context.Orders.ToList();
			ViewBag.Users = _context.Users.ToList();
			return View();
		}

		[HttpGet]
		[Route("products")]
		public IActionResult Products()
		{
			ViewBag.Products = _context.Products.ToList();
			return View();
		}
		[HttpPost]
		[Route("newproduct")]
		public IActionResult NewProduct(string name, string url, string desc, int quan)
		{
			Product prod = new Product
			{
				Name = name,
				URL = url,
				Description = desc,
				Quantity = quan
			};
			_context.Add(prod);
			_context.SaveChanges();
			return RedirectToAction("products");
		}

		[HttpGet]
		[Route("orders")]
		public IActionResult Orders()
		{	
			ViewBag.Products = _context.Products.ToList();
			ViewBag.Orders = _context.Orders.ToList();
			ViewBag.Users = _context.Users.ToList();
			return View();
		}
		[HttpPost]
		[Route("neworder")]
		public IActionResult NewOrder(string customer, int quantity, string product)
		{
			int userid = _context.Users.SingleOrDefault(u => u.Name == customer).UserId;
			Product prod = _context.Products.SingleOrDefault(p => p.Name == product);
			Order ord = new Order
			{
				UserId = userid,
				Quantity=quantity,
				ProductId = prod.ProductId
			};
			prod.Quantity -= quantity;
			_context.Add(ord);
			_context.SaveChanges();
			return RedirectToAction("orders");
		}

		[HttpGet]
		[Route("customers")]
		public IActionResult Customers()
		{
			ViewBag.Users = _context.Users.ToList();
			return View();
		}
		[HttpPost]
		[Route("newcustomer")]
		public IActionResult NewCustomer(string name)
		{
			User user = new User
			{
				Name = name
			};
			_context.Add(user);
			_context.SaveChanges();
			return RedirectToAction("customers");
		}

		[HttpGet]
		[Route("settings")]
		public IActionResult Settings()
		{
			return View();
		}

		[HttpPost]
		[Route("removeuser/{id}")]
		public IActionResult RemoveUser(int id)
		{
			User user = _context.Users.SingleOrDefault(u=>u.UserId == id);
			_context.Users.Remove(user);
			_context.SaveChanges();
			return RedirectToAction("customers");
		}
	}
}
