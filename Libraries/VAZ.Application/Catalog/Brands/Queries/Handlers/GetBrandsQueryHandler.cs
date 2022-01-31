using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
	public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<ICollection<BrandDto>>>
	{
		IMapper _mapper;
		IRepository<Brand> _brandRepository;

		public GetBrandsQueryHandler(IRepository<Brand> brandRepository, IMapper mapper)
		{
			_mapper = mapper;
			_brandRepository = brandRepository;
		}

		public async Task<IDataResult<ICollection<BrandDto>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
		{
			ICollection<Brand> brands = await _brandRepository.GetAll.ToListAsync();

			return new SuccessDataResult<ICollection<BrandDto>>(_mapper.Map<ICollection<BrandDto>>(brands));
		}
	}
}
