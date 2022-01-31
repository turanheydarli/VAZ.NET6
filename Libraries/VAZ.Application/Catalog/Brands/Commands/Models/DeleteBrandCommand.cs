using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Brands.Commands.Models
{
	public class DeleteBrandCommand:IRequest<IResult>
	{
		public int Id { get; set; }
	}
}
