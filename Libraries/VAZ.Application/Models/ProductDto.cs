
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.System.Mappings;
using VAZ.Domain.Entities;

namespace VAZ.Application.Models
{
	public class ProductDto : IMapFrom<Product>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public Currency Currency { get; set; }
		public ProductDetail ProductDetail { get; set; }
		public int ViewCount { get; set; }
		public string Contact { get; set; }
		public ICollection<Picture> Pictures { get; set; }
		public bool IsPro { get; set; }
		public bool IsVip { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Product, ProductDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(d => d.Id))
				.ForMember(p => p.Title, opt => opt.MapFrom(d => d.Title))
				.ForMember(p => p.Slug, opt => opt.MapFrom(d => d.Slug))
				.ForMember(p => p.Description, opt => opt.MapFrom(d => d.Description))
				.ForMember(p => p.Price, opt => opt.MapFrom(d => d.Price))
				.ForMember(p => p.Currency, opt => opt.MapFrom(d => d.Currency))
				.ForMember(p => p.ProductDetail, opt => opt.MapFrom(d => d.ProductDetail))
				.ForMember(p => p.ViewCount, opt => opt.MapFrom(d => d.ViewCount))
				.ForMember(p => p.Contact, opt => opt.MapFrom(d => d.Contact))
				.ForMember(p => p.Pictures, opt => opt.MapFrom(d => d.Pictures))
				.ForMember(p => p.IsPro, opt => opt.MapFrom(d => d.IsPro))
				.ForMember(p => p.IsVip, opt => opt.MapFrom(d => d.IsVip))
				.ForMember(p => p.CreatedTime, opt => opt.MapFrom(d => d.CreatedTime))
				.ForMember(p => p.UpdatedTime, opt => opt.MapFrom(d => d.UpdatedTime)).ReverseMap();
		}
	}
}
