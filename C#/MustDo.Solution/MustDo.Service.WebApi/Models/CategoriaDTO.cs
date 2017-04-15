using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MustDo.Service.WebApi.Models
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}