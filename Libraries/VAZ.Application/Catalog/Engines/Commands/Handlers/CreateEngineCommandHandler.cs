using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Engines.Commands.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Engines.Commands.Handlers
{
	public class CreateEngineCommandHandler : IRequestHandler<CreateEngineCommand, IDataResult<EngineDto>>
	{
		private IRepository<Engine> _engineRepository;
		private IMapper _mapper;

		public CreateEngineCommandHandler(IMapper mapper, IRepository<Engine> engineRepository)
		{
			_mapper = mapper;
			_engineRepository = engineRepository;
		}
		public async Task<IDataResult<EngineDto>> Handle(CreateEngineCommand request, CancellationToken cancellationToken)
		{
			Engine engine = await _engineRepository.InsertAsync(new Engine { Name = request.Name });

			return new SuccessDataResult<EngineDto>(_mapper.Map<EngineDto>(engine));
		}
	}
}
