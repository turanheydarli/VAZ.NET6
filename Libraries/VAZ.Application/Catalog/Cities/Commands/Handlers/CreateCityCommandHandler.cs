using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Cities.Commands.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Cities.Commands.Handlers
{
	public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IDataResult<CityDto>>
	{
		IMapper _mapper;
		IRepository<City> _cityRepository;

		public CreateCityCommandHandler(IRepository<City> cityRepository, IMapper mapper)
		{
			_cityRepository = cityRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
		{
			City city =await  _cityRepository.InsertAsync(new City
			{
				Name = request.Name
			});

			return new SuccessDataResult<CityDto>(_mapper.Map<CityDto>(city));
		}
	}
}
