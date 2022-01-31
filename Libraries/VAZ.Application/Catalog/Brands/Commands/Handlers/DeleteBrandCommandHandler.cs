using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Brands.Commands.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Brands.Commands.Handlers
{
	public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, IResult>
	{
		IRepository<Brand> _brandRepository;

		public DeleteBrandCommandHandler(IRepository<Brand> brandRepository)
		{
			_brandRepository = brandRepository;
		}
		public async Task<IResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
		{
			Brand brand = await _brandRepository.GetByIdAsync(request.Id);

			await _brandRepository.DeleteAsync(brand);

			return new SuccessResult(Messages.Deleted);
		}
	}
}
