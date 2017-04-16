using MustDo.Domain.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MustDo.Domain.Entities
{
	public class Tarefa
	{
		public int TarefaId { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public SituacaoTarefaEnum Situacao { get; set; }
		public DateTime DataCriacao { get; set; }
		public DateTime DataFinalizacao { get; set; }
        public string UsuarioId { get; set; }

        #region Foreign Key
        public int CategoriaId { get; set; }
        #endregion

        #region Virtual

        public virtual Categoria Categoria { get; set; }
		public virtual ICollection<Tag> Tags { get; set; }

        #endregion

        public void AtualizarTarefa(Tarefa tarefa)
        {
            Nome = tarefa.Nome;
            Descricao = tarefa.Descricao;
            Situacao = tarefa.Situacao;
            DataFinalizacao = tarefa.DataFinalizacao;
            AtualizarTags(tarefa.Tags);
        }

        private void AtualizarTags(ICollection<Tag> tagsAutalizadas)
        {
            RemoverTags();
            foreach (var tag in tagsAutalizadas.ToList())
            {
                Tags.Add(tag);
            }
        }

        private void RemoverTags()
        {
            Tags.Clear();
        }
    }
}
