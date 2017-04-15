using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MustDo.Presentation.WebMVC.Models
{
	public class TarefaViewModel
	{
		public int TarefaId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        public string Descricao { get; set; }
		public SituacaoTarefaEnum Situacao { get; set; }

		[Display(Name = "Criado em")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd à\\s HH:mm}")]
		public DateTime DataCriacao { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		[Display(Name = "Finaliza em")]
		[DataType(DataType.Date, ErrorMessage = "Data com formato inválido")]
		public DateTime DataFinalizacao { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		[Display(Name = "Hora de Finalização")]
		[DataType(DataType.Time, ErrorMessage = "Hora com formato inválido")]
		public DateTime HoraFinalizacao { get; set; }

		public Categoria Categoria { get; set; }

		[Display(Name = "Categoria")]
		[Required(ErrorMessage = "É preciso informar uma categoria")]
		public int CategoriaId { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Campo Tags é obrigatório.")]
        public int[] TagsIds { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

    }
}