using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Engines.Commands.Models;
using VAZ.Application.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Engines.Commands.Handlers
{
	public class UpdateEngineCommandHandler : IRequestHandler<UpdateEngineCommand, IDataResult<EngineDto>>
	{
		private IRepository<Engine> _engineRepository;
		private IMapper _mapper;

		public UpdateEngineCommandHandler(IMapper mapper, IRepository<Engine> engineRepository)
		{
			_mapper = mapper;
			_engineRepository = engineRepository;
		}
		public async Task<IDataResult<EngineDto>> Handle(UpdateEngineCommand request, CancellationToken cancellationToken)
		{
			Engine engine = await _engineRepository.GetAsync(e => e.Id == request.Id);

			if (engine == null)
				return new ErrorDataResult<EngineDto>(Messages.NotFound);

			engine.Name = request.Name;
			engine.UpdatedTime = DateTime.Now;

			if (_engineRepository.Update(engine) == -1)
				return new ErrorDataResult<EngineDto>(_mapper.Map<EngineDto>(engine), Messages.NotAdded);

			return new SuccessDataResult<EngineDto>(_mapper.Map<EngineDto>(engine), Messages.Added);

		}
	}
}
