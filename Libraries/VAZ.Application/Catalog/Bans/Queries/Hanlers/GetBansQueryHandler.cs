using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
	public class GetBansQueryHandler : IRequestHandler<GetBansQuery, IDataResult<ICollection<BanDto>>>
	{
		private IMapper _mapper;
		private IRepository<Ban> _banRepository;

		public GetBansQueryHandler(IRepository<Ban> banRepository, IMapper mapper)
		{
			_banRepository = banRepository;
			_mapper = mapper;
		}


		public async Task<IDataResult<ICollection<BanDto>>> Handle(GetBansQuery request, CancellationToken cancellationToken)
		{
			return new SuccessDataResult<ICollection<BanDto>>(_mapper.Map<ICollection<BanDto>>(await _banRepository.GetAll.ToListAsync()));
		}
	}
}
