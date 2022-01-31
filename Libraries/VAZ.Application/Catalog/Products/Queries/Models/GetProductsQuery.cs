using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Shared.Utilities.Results;
using VAZ.Application.Models;

namespace VAZ.Application.Catalog.Products.Queries.Models
{
	public class GetProductsQuery : IRequest<IDataResult<IEnumerable<ProductDto>>>
	{

	}
}
