using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Bans.Commands.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Bans.Commands.Hanlers
{
	public class CreateBanCommandHandler : IRequestHandler<CreateBanCommand, IDataResult<BanDto>>
	{
		private IMapper _mapper;
		private IRepository<Ban> _banRepository;

		public CreateBanCommandHandler(IRepository<Ban> banRepository, IMapper mapper)
		{
			_banRepository = banRepository;
			_mapper = mapper;
		}
		public async Task<IDataResult<BanDto>> Handle(CreateBanCommand request, CancellationToken cancellationToken)
		{
			Ban ban = new Ban { Name = request.Name };

			return new SuccessDataResult<BanDto>(_mapper.Map<BanDto>(await _banRepository.InsertAsync(ban)));
		}
	}
}
