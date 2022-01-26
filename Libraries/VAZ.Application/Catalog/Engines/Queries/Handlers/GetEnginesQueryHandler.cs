using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Engines.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Engines.Queries.Handlers
{
	public class GetEnginesQueryHandler : IRequestHandler<GetEnginesQuery, IDataResult<IEnumerable<EngineDto>>>
	{
		private IRepository<Engine> _engineRepository;
		private IMapper _mapper;

		public GetEnginesQueryHandler(IMapper mapper, IRepository<Engine> engineRepository)
		{
			_mapper = mapper;
			_engineRepository = engineRepository;
		}

		public async Task<IDataResult<IEnumerable<EngineDto>>> Handle(GetEnginesQuery request, CancellationToken cancellationToken)
		{
			IEnumerable<EngineDto> result = _mapper.Map<IEnumerable<EngineDto>>(await _engineRepository.GetAll.ToListAsync());

			return new SuccessDataResult<IEnumerable<EngineDto>>(result);
		}
	}
}
