using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Cities.Commands.Models
{
	public class CreateCityCommand:IRequest<IDataResult<CityDto>>
	{
		public string Name { get; set; }
	}
}
