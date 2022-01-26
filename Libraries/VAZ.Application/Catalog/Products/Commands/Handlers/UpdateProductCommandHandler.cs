using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Products.Commands.Models;
using VAZ.Application.Models;
using VAZ.Application.Storage.Interfaces;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Products.Commands.Handlers
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IDataResult<ProductDto>>
	{

		private IRepository<Product> _productRepository;
		private IMapper _mapper;
		private IPictureService _pictureService;

		public UpdateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper, IPictureService pictureService)
		{
			_mapper = mapper;
			_pictureService = pictureService;
			_productRepository = productRepository;
		}
		public async Task<IDataResult<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetByIdAsync(request.Id);

			if (product == null)
				return new ErrorDataResult<ProductDto>(Messages.NotFound);

			product.ProductDetail = request.ProductDetail;
			product.IsPro = request.IsPro;
			request.IsVip = request.IsVip;
			request.Price = request.Price;
			product.Contact = request.Contact;
			product.Description = request.Description;
			product.UpdatedTime = DateTime.Now;
			product.Currency = request.Currency;

			if (request.ImageFiles.Count() > 0 && product.Pictures.Count < 5)
			{
				foreach (Picture picture in await _pictureService.SavePictureBulk(request.ImageFiles, product.Id))
				{
					product.Pictures.Add(picture);
				}
			}

			if (_productRepository.Update(product) == -1)
			{
				return new ErrorDataResult<ProductDto>(_mapper.Map<ProductDto>(product));
			}

			return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(product));
		}
	}
}
