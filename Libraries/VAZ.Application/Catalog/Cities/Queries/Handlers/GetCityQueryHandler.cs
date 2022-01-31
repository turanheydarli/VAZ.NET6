using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Cities.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Cities.Queries.Handlers
{
	public class GetCityQueryHandler : IRequestHandler<GetCityQuery, IDataResult<CityDto>>
	{
		IMapper _mapper;
		IRepository<City> _cityRepository;

		public async Task<IDataResult<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
		{
			City city = await _cityRepository.GetAsync(c => c.Id == request.Id);

			return new SuccessDataResult<CityDto>(_mapper.Map<CityDto>(city));
		}
	}
}
