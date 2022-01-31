using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Bans.Queries.Models;
using VAZ.Application.Models;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Bans.Queries.Hanlers
{
	public class GetBanQueryHandler : IRequestHandler<GetBanQuery, IDataResult<BanDto>>
	{
		private IMapper _mapper;
		private IRepository<Ban> _banRepository;

		public GetBanQueryHandler(IRepository<Ban> banRepository, IMapper mapper)
		{
			_banRepository = banRepository;
			_mapper = mapper;
		}

		public async Task<IDataResult<BanDto>> Handle(GetBanQuery request, CancellationToken cancellationToken)
		{
			Ban ban = await _banRepository.GetAsync(b => b.Id == request.Id, b => b.Products);

			return new SuccessDataResult<BanDto>(_mapper.Map<BanDto>(ban));

		}
	}
}
