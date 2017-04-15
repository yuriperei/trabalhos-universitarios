using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MustDo.Consumo.WebApi.WebMvc.Controllers
{
    public class TarefasController : Controller
    {
        // GET: Tarefas
        public ActionResult Categoria()
        {
            return View();
        }

        public ActionResult Tag()
        {
            return View();
        }
    }
}
