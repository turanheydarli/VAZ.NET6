using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Products.Commands.Models
{
	public class DeleteProductCommand : IRequest<IResult>
	{
		public int Id { get; set; }
	}
}
