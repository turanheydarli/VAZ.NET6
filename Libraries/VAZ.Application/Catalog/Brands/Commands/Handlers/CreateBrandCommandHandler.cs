using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Brands.Commands.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Brands.Commands.Handlers
{
	public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IDataResult<BrandDto>>
	{
		IMapper _mapper;
		IRepository<Brand> _brandRepository;

		public CreateBrandCommandHandler(IRepository<Brand> brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}
		public async Task<IDataResult<BrandDto>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			Brand brandToAdded = await _brandRepository.InsertAsync(new Brand
			{
				Name = request.Name
			});

			return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(brandToAdded));
		}
	}
}
