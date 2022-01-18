using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.System.Mappings;
using VAZ.Domain.Entities;
using VAZ.Shared.Domain.Common;

namespace VAZ.Application.Engines.Queries.Models
{
	public class EngineAddDto : IDto, IMapFrom<Engine>
	{
		public string Name { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<Engine, EngineDto>()
				.ForMember(e => e.Name, opt => opt.MapFrom(d => d.Name)).ReverseMap();
		}
	}
}
