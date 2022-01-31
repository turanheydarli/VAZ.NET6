using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Engines.Commands.Models
{
	public class DeleteEngineCommand : IRequest<IResult>
	{
		public int Id { get; set; }
	}
}
