using VAZ.Application.Interfaces;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using VAZ.Application.Models;

namespace VAZ.Application.Services
{
	public class ProductService : IProductService
	{
		IRepository<Product> _productRepository;
		IMapper _mapper;
		public ProductService(IRepository<Product> productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task Delete(ProductDto product)
		{
			await Task.Run(() => { _productRepository.Delete(_mapper.Map<Product>(product)); });
		}

		public ICollection<ProductDto> GetAll()
		{
			return _productRepository.GetAll.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList();
		}

		public Task<ProductDto> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ProductDto> Update(ProductDto product)
		{
			throw new NotImplementedException();
		}
	}
}
