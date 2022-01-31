using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Bans.Queries.Models
{
	public class GetBanQuery : IRequest<IDataResult<BanDto>>
	{
		public int Id { get; set; }
	}
}
