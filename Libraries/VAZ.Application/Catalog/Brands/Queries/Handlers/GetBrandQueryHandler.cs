using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Brands.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Brands.Queries.Handlers
{
	public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, IDataResult<BrandDto>>
	{
		IMapper _mapper;
		IRepository<Brand> _brandRepository;

		public GetBrandQueryHandler(IRepository<Brand> brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<BrandDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
		{
			return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(await _brandRepository.GetAsync(b => b.Id == request.Id)));
		}
	}
}
