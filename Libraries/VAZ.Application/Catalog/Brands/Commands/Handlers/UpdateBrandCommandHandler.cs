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
	public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, IDataResult<BrandDto>>
	{
		IMapper _mapper;
		IRepository<Brand> _brandRepository;

		public UpdateBrandCommandHandler(IRepository<Brand> brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<BrandDto>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetByIdAsync(request.Id);

			brand.UpdatedTime = DateTime.Now;
			brand.Name = request.Name;

			return new SuccessDataResult<BrandDto>(_mapper.Map<BrandDto>(await _brandRepository.UpdateAsync(brand)));
		}
	}
}
