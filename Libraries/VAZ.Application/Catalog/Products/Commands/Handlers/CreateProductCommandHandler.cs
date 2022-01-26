using AutoMapper;
using MediatR;
using Turan.Shared.Utilities.Results;
using VAZ.Application.Catalog.Products.Commands.Models;
using VAZ.Application.Models;
using VAZ.Application.Storage.Interfaces;
using VAZ.Application.Utilities.Extensions;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;

namespace VAZ.Application.Catalog.Products.Commands.Handlers
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IDataResult<ProductDto>>
	{
		private IRepository<Product> _productRepository;
		private IPictureService _pictureService;
		private IMapper _mapper;

		public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper, IPictureService pictureService)
		{
			_productRepository = productRepository;
			_pictureService = pictureService;
			_mapper = mapper;
		}
		public async Task<IDataResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			Product product = new Product
			{
				Title = request.Title,
				Slug = SeoExtensions.GenerateSlug(request.Title, false, false, false),
				Contact = request.Contact,
				Currency = request.Currency,
				Description = request.Description,
				IsPro = request.IsPro,
				IsVip = request.IsVip,
				ProductDetail = request.ProductDetail,
				Price = request.Price,
			};
			
			Product addedProduct = _productRepository.Insert(product);

			addedProduct.Pictures = await _pictureService.SavePictureBulk(request.ImageFiles, addedProduct.Id);

			await _productRepository.UpdateAsync(addedProduct);

			return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(await _productRepository.InsertAsync(product)));
		}
	}
}
