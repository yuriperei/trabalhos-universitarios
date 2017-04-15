using MustDo.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MustDo.Service.WebApi.Models
{
    public class TarefaDTO
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public SituacaoTarefaEnum Situacao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataFinalizacao { get; set; }

        public DateTime HoraFinalizacao { get; set; }

        public CategoriaDTO Categoria { get; set; }

        public int CategoriaId { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}