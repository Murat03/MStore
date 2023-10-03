using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.ProductId);
			builder.Property(p => p.ProductName).IsRequired();
			builder.Property(p => p.Price).IsRequired();

			builder.HasData(
				new Product()
				{
					ProductId = 1,
					ProductName = "Computer",
					Price = 15000,
					ImageUrl = "/images/1.jpg",
					CategoryId = 1,
					ShowCase = false
				},
				new Product()
				{
					ProductId = 2,
					ProductName = "Phone",
					Price = 10000,
					ImageUrl = "/images/2.jpg",
					CategoryId = 1,
					ShowCase = true
				},
				new Product()
				{
					ProductId = 3,
					ProductName = "Mouse",
					Price = 500,
					ImageUrl = "/images/3.jpg",
					CategoryId = 1,
					ShowCase = true
				},
				new Product()
				{
					ProductId = 4,
					ProductName = "Book",
					Price = 50,
					ImageUrl = "/images/4.jpg",
					CategoryId = 1,
					ShowCase = true
				});
		}
	}
}
