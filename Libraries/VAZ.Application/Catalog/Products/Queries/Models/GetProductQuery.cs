using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Models;

namespace VAZ.Application.Catalog.Products.Queries.Models
{
	public class GetProductQuery : IRequest<IDataResult<ProductDto>>
	{
		public int Id { get; set; }
	}
}
