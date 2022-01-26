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
	public class EngineDto : IMapFrom<Engine>
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
		public string Name { get; set; }


		public void Mapping(Profile profile)
		{
			profile.CreateMap<Engine,EngineDto>()
				.ForMember(e => e.Id, opt => opt.MapFrom(d => d.Id))
				.ForMember(e => e.CreatedTime, opt => opt.MapFrom(d => d.CreatedTime))
				.ForMember(e => e.UpdatedTime, opt => opt.MapFrom(d => d.UpdatedTime))
				.ForMember(e => e.Name, opt => opt.MapFrom(d => d.Name)).ReverseMap();
		}
	}
}
