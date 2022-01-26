using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Models;

namespace VAZ.Application.Interfaces
{
	public interface IProductService
	{
		Task<ProductDto> GetById(int id);
		ICollection<ProductDto> GetAll();
		Task<ProductDto> Update(ProductDto product);
		Task Delete(ProductDto product);
	}
}
