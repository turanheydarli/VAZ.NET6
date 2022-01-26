using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Products.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Products.Queries.Handlers
{
	public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IDataResult<ProductDto>>
	{
		private IRepository<Product> _productRepository;
		private IMapper _mapper;

		public GetProductQueryHandler(IRepository<Product> productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}
		public async Task<IDataResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
		{
			ProductDto product =
				_mapper.Map<ProductDto>(
					await _productRepository.GetAsync(p => p.Id == request.Id, p => p.Currency, p => p.ProductDetail, p => p.Pictures));

			return new SuccessDataResult<ProductDto>(product);
		}
	}
}
