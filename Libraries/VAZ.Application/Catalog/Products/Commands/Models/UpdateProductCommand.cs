using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Products.Commands.Models
{
	public class UpdateProductCommand : IRequest<IDataResult<ProductDto>>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public Currency Currency { get; set; }
		public ProductDetail ProductDetail { get; set; }
		public string Contact { get; set; }
		public ICollection<Picture> Images { get; set; }
		public bool IsPro { get; set; }
		public bool IsVip { get; set; }
		public ICollection<IFormFile> ImageFiles { get; set; }

	}
}
