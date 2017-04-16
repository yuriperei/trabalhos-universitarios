using System;

namespace MustDo.Presentation.WebMVC.Models
{
	public class CategoriaViewModel
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
        public string UsuarioId { get; set; }
    }
}