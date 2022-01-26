using AutoMapper;
using MediatR;
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
	public class GetEngineQueryHandler : IRequestHandler<GetEngineQuery, IDataResult<EngineDto>>
	{
		private IRepository<Engine> _engineRepository;
		private IMapper _mapper;

		public GetEngineQueryHandler(IMapper mapper, IRepository<Engine> engineRepository)
		{
			_mapper = mapper;
			_engineRepository = engineRepository;
		}
		public async Task<IDataResult<EngineDto>> Handle(GetEngineQuery request, CancellationToken cancellationToken)
		{
			EngineDto result = _mapper.Map<EngineDto>(await _engineRepository.GetAsync(e => e.Id == request.Id));

			return new SuccessDataResult<EngineDto>(result);
		}
	}
}
