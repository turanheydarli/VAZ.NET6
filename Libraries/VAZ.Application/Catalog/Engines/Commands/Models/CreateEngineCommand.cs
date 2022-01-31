using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Engines.Commands.Models
{
	public class CreateEngineCommand : IRequest<IDataResult<EngineDto>>
	{
		public string Name { get; set; }
	}
}
