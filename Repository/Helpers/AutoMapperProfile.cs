using System;
using AutoMapper;
using Repository.Entity;
using Repository.Models;

namespace Repository.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Item, ItemDto>().ReverseMap();
		}
	}
}

