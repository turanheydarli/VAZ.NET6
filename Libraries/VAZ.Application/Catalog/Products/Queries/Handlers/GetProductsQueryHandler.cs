using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VAZ.Shared.Utilities.Results;
using VAZ.Application.Catalog.Products.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Products.Queries.Handlers
{
	public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IDataResult<IEnumerable<ProductDto>>>
	{
		private IRepository<Product> _productRepository;
		private IMapper _mapper;

		public GetProductsQueryHandler(IRepository<Product> productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<IEnumerable<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
		{
			IEnumerable<ProductDto> products = _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll
				.Include( p => p.Currency).Include(p => p.ProductDetail).Include(p => p.Pictures).ToListAsync());

			return new SuccessDataResult<IEnumerable<ProductDto>>(products);
		}
	}
}
