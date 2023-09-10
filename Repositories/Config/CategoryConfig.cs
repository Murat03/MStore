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
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(x => x.CategoryId);
			builder.Property(x => x.CategoryName);

			builder.HasData(new Category()
			{
				CategoryId = 1,
				CategoryName = "Electronic"
			},new Category()
			{
				CategoryId = 2,
				CategoryName = "Book"
			});
		}
	}
}
