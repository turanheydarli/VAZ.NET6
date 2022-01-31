using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Cities.Queries.Models
{
	public class GetCityQuery : IRequest<IDataResult<CityDto>>
	{
		public int Id { get; set; }
	}
}
