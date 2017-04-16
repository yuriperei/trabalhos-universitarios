using AutoMapper;
using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using MustDo.Service.WebApi.Models;
using System;

namespace MustDo.Service.WebApi.App_Start
{
	public static class MapperConfig
	{
		public static void CreateAutoMapperMappings()
		{
			//AutoMapper.Mapper.CreateMap<Fonte, Destino>()

			Mapper.Initialize(config =>
			{
				config.CreateMap<Categoria, CategoriaDTO>();
				config.CreateMap<CategoriaDTO, Categoria>();

				config.CreateMap<Tag, TagDTO>();
				config.CreateMap<TagDTO, Tag>();

				config.CreateMap<Tarefa, TarefaDTO>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao)
				).ForMember(dest => dest.HoraFinalizacao, opt => opt.MapFrom(src =>
				src.DataFinalizacao)
                ).ForMember(dest => dest.SituacaoDescricao, opt => opt.MapFrom(src => Enum.GetName(typeof(SituacaoTarefaEnum), src.Situacao)));

                config.CreateMap<TarefaDTO, Tarefa>()
				.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				new DateTime(src.DataFinalizacao.Year,
						src.DataFinalizacao.Month,
						src.DataFinalizacao.Day,
						src.HoraFinalizacao.Hour,
						src.HoraFinalizacao.Minute,
						src.HoraFinalizacao.Second)
				));

				//config.CreateMap<Tarefa, TarefaViewModelDetails>()
				//.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				//src.DataFinalizacao)
				//).ForMember(dest => dest.HoraFinalizacao, opt => opt.MapFrom(src =>
				//src.DataFinalizacao));

				//config.CreateMap<TarefaViewModelDetails, Tarefa>()
				//.ForMember(dest => dest.DataFinalizacao, opt => opt.MapFrom(src =>
				//new DateTime(src.DataFinalizacao.Year,
				//		src.DataFinalizacao.Month,
				//		src.DataFinalizacao.Day,
				//		src.HoraFinalizacao.Hour,
				//		src.HoraFinalizacao.Minute,
				//		src.HoraFinalizacao.Second)
				//));

			});
		}
	}
}