using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Models;

namespace VAZ.Application.Catalog.Engines.Commands.Models
{
	public class CreateEngineCommand : IRequest<IDataResult<EngineDto>>
	{
		public string Name { get; set; }
	}
}
