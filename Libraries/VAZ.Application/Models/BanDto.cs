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
	public class BanDto : IMapFrom<Ban>
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.Now;
		public DateTime? UpdatedTime { get; set; }
		public string Name { get; set; }
		public ICollection<ProductDetail> Products { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Ban, BanDto>()
				.ForMember(b => b.Id, opt => opt.MapFrom(d => d.Id))
				.ForMember(b => b.CreatedTime, opt => opt.MapFrom(d => d.CreatedTime))
				.ForMember(b => b.UpdatedTime, opt => opt.MapFrom(d => d.UpdatedTime))
				.ForMember(b => b.Name, opt => opt.MapFrom(d => d.Name))
				.ForMember(b => b.Products, opt => opt.MapFrom(d => d.Products));
		}
	}
}
