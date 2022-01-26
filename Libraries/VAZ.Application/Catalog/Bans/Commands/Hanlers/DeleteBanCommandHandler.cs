using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Bans.Commands.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Bans.Commands.Hanlers
{
	public class DeleteBanCommandHandler : IRequestHandler<DeleteBanCommand, IResult>
	{
		private IRepository<Ban> _banRepository;

		public DeleteBanCommandHandler(IRepository<Ban> banRepository, IMapper mapper)
		{
			_banRepository = banRepository;
		}
		public async Task<IResult> Handle(DeleteBanCommand request, CancellationToken cancellationToken)
		{
			Ban ban = await _banRepository.GetByIdAsync(request.Id);

			if (ban == null)
				return new ErrorResult(Messages.NotFound);

			if (await _banRepository.UpdateAsync(ban) == -1)
				return new ErrorResult(Messages.NotDeleted);

			return new SuccessResult(Messages.Deleted);
		}
	}
}
