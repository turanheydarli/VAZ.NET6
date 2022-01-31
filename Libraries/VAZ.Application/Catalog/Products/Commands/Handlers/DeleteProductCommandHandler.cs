using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Catalog.Products.Commands.Models;
using VAZ.Application.Storage.Interfaces;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Extensions;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Products.Commands.Handlers
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResult>
	{
		private IRepository<Product> _productRepository;
		private IPictureService _pictureService;

		public DeleteProductCommandHandler(IRepository<Product> productRepository, IPictureService pictureService)
		{
			_pictureService = pictureService;
			_productRepository = productRepository;
		}
		public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetAsync(p => p.Id == request.Id, p => p.Pictures);

			if (product == null)
				return new ErrorResult(Messages.NotFound);

			if(product.Pictures.Count > 0)
				await _pictureService.DeletePictureBulk(product.Pictures);

			_productRepository.Delete(product);

			return new SuccessResult(Messages.Deleted);

		}
	}
}
