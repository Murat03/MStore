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
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name).IsRequired();
			builder.Property(p => p.Price).IsRequired();

			builder.HasData(
				new Product()
				{
					Id = 1,
					Name = "Computer",
					Price = 15000
				},
				new Product()
				{
					Id = 2,
					Name = "Phone",
					Price = 10000
				},
				new Product()
				{
					Id = 3,
					Name = "HeadPhones",
					Price = 1000
				});
		}
	}
}
