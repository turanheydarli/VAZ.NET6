using MediatR;
using VAZ.Application.Models;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Brands.Queries.Models
{
	public class GetBrandQuery : IRequest<IDataResult<BrandDto>>
	{
		public int Id { get; set; }
	}
}
