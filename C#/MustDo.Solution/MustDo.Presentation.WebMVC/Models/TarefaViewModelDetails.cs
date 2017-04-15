using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MustDo.Presentation.WebMVC.Models
{
	public class TarefaViewModelDetails
	{
		public int TarefaId { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public SituacaoTarefaEnum Situacao { get; set; }

		[Display(Name = "Criado em")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy à\\s HH:mm}")]
		public DateTime DataCriacao { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		[Display(Name = "Finaliza em")]
		[DataType(DataType.Date, ErrorMessage = "Data com formato inválido")]
		public DateTime DataFinalizacao { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		[Display(Name = "Hora de Finalização")]
		[DataType(DataType.Time, ErrorMessage = "Hora com formato inválido")]
		public DateTime HoraFinalizacao { get; set; }

		public Categoria Categoria { get; set; }

		[Required(ErrorMessage = "É preciso informar uma categoria")]
		[Display(Name = "Categoria")]
		public int CategoriaId { get; set; }
		public IEnumerable<Tag> Tags { get; set; }
	}
}