using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Bans.Commands.Models;
using VAZ.Application.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Bans.Commands.Hanlers
{
	public class UpdateBanCommandHandler : IRequestHandler<UpdateBanCommand, IDataResult<BanDto>>
	{
		private IMapper _mapper;
		private IRepository<Ban> _banRepository;

		public UpdateBanCommandHandler(IRepository<Ban> banRepository, IMapper mapper)
		{
			_banRepository = banRepository;
			_mapper = mapper;
		}
		public async Task<IDataResult<BanDto>> Handle(UpdateBanCommand request, CancellationToken cancellationToken)
		{
			Ban ban = await _banRepository.GetByIdAsync(request.Id);

			if (ban == null)
				return new ErrorDataResult<BanDto>(Messages.NotFound);

			ban.UpdatedTime = DateTime.Now;
			ban.Name = request.Name;

			return new SuccessDataResult<BanDto>(_mapper.Map<BanDto>(await _banRepository.UpdateAsync(ban)));
		}
	}
}
