using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
	public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IDataResult<ICollection<CityDto>>>
	{
		IMapper _mapper;
		IRepository<City> _cityRepository;

		public GetCitiesQueryHandler(IRepository<City> cityRepository, IMapper mapper)
		{
			_cityRepository = cityRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<ICollection<CityDto>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
		{
			return new SuccessDataResult<ICollection<CityDto>>(_mapper.Map<ICollection<CityDto>>(await _cityRepository.GetAll.ToListAsync()));
		}
	}
}
