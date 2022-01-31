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
	public class PictureDto:IMapFrom<Picture>
	{
		public int Id { get; set; }
		public string Caption { get; set; }
		public int FileSize { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Picture, PictureDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(d => d.Id))
				.ForMember(p => p.Caption, opt => opt.MapFrom(d => d.Caption))
				.ForMember(p => p.FileSize, opt => opt.MapFrom(d => d.FileSize))
				.ForMember(p => p.FileName, opt => opt.MapFrom(d => d.FileName))
				.ForMember(p => p.MimeType, opt => opt.MapFrom(d => d.MimeType))
				.ForMember(p => p.CreatedTime, opt => opt.MapFrom(d => d.CreatedTime))
				.ForMember(p => p.UpdatedTime, opt => opt.MapFrom(d => d.UpdatedTime)).ReverseMap();
		}
	}
}
