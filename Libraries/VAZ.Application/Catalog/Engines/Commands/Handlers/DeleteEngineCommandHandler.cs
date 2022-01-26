using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Engines.Commands.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Engines.Commands.Handlers
{
	public class DeleteEngineCommandHandler : IRequestHandler<DeleteEngineCommand, IResult>
	{
		private IRepository<Engine> _engineRepository;

		public DeleteEngineCommandHandler(IMapper mapper, IRepository<Engine> engineRepository)
		{
			_engineRepository = engineRepository;
		}
		public async Task<IResult> Handle(DeleteEngineCommand request, CancellationToken cancellationToken)
		{
			Engine engine = await _engineRepository.GetAsync(e => e.Id == request.Id);

			if (engine == null)
				return new ErrorResult(Messages.NotFound);

			if(_engineRepository.Delete(engine) == -1)
				return new ErrorResult(Messages.NotDeleted);

			return new SuccessResult(Messages.Deleted);
		}
	}
}
