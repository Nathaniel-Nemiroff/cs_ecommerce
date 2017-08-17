using Microsoft.EntityFrameworkCore;

namespace proj
{
	public class projContext : DbContext
	{
		public projContext(DbContextOptions<projContext> options):base(options){}
		public DbSet<User>Users{get;set;}
		public DbSet<Order>Orders{get;set;}
		public DbSet<Product>Products{get;set;}
	}
}
