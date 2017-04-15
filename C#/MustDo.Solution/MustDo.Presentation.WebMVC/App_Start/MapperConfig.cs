using AutoMapper;
using MustDo.Domain.Entities;
using MustDo.Presentation.WebMVC.Models;
using System;

namespace MustDo.Presentation.WebMVC.App_Start
{
	public static class MapperConfig
	{
		public static void CreateAutoMapperMappings()
		{
			//AutoMapper.Mapper.CreateMap<Fonte, Destino>()

			Mapper.Initialize(config =>
			{
				config.CreateMap<Categoria, CategoriaViewModel>();
				config.CreateMap<CategoriaViewModel, Categoria>();

				config.CreateMap<Tag, TagViewModel>();
				config.CreateMap<TagViewModel, Tag>();

				config.CreateMap<Tarefa, TarefaViewModel>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao)
				).ForMember(dest => dest.HoraFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao));

				config.CreateMap<TarefaViewModel, Tarefa>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				new DateTime(src.DataFinalizacao.Year,
						src.DataFinalizacao.Month,
						src.DataFinalizacao.Day,
						src.HoraFinalizacao.Hour,
						src.HoraFinalizacao.Minute,
						src.HoraFinalizacao.Second)
				));

				config.CreateMap<Tarefa, TarefaViewModelDetails>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao)
				).ForMember(dest => dest.HoraFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao));

				config.CreateMap<TarefaViewModelDetails, Tarefa>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				new DateTime(src.DataFinalizacao.Year,
						src.DataFinalizacao.Month,
						src.DataFinalizacao.Day,
						src.HoraFinalizacao.Hour,
						src.HoraFinalizacao.Minute,
						src.HoraFinalizacao.Second)
				));

			});
		}
	}
}