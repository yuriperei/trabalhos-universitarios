using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using MustDo.Domain.Interfaces.Services;
using MustDo.Presentation.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MustDo.Presentation.WebMVC.Controllers
{
	public class TarefasController : Controller
	{
		private readonly ITarefaService _tarefaService;
		private readonly ICategoriaService _categoriaService;
        private readonly ITagService _tagService;

		public TarefasController(ITarefaService tarefaService, ICategoriaService categoriaService, ITagService tagService)
		{
			_tarefaService = tarefaService;
			_categoriaService = categoriaService;
            _tagService = tagService;
		}

		// GET: Tarefas
		public ActionResult Index()
		{
			var tarefas = _tarefaService.ObterTodos();
			var tarefasView = AutoMapper.Mapper.Map<IEnumerable<Tarefa>, IEnumerable<TarefaViewModelDetails>>(tarefas);
			return View(tarefasView);
		}



		// GET: Tarefas/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tarefa = _tarefaService.ObterPorId(id);
			var tarefaView = AutoMapper.Mapper.Map<TarefaViewModelDetails>(tarefa);
			if (tarefaView == null)
			{
				return HttpNotFound();
			}
			return View(tarefaView);
		}

		// GET: Tarefas/Create
		public ActionResult Create()
		{
			ViewBag.CategoriaId = new SelectList(ObterTodasCategorias(), "CategoriaId", "Nome");
            ViewBag.Tags = new SelectList(ObterTodasTags(), "TagId", "Nome");
            return View();
		}

		// POST: Tarefas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "TarefaId,Nome,Descricao,Situacao,DataFinalizacao,HoraFinalizacao,CategoriaId,TagsIds")] TarefaViewModel tarefaView)
		{
			if (ModelState.IsValid)
			{
				var tarefaDomain = AutoMapper.Mapper.Map<Tarefa>(tarefaView);
				tarefaDomain.DataCriacao = DateTime.Now;
                tarefaDomain.Tags = _tagService.ObterTodos().Where(m => tarefaView.TagsIds.Contains(m.TagId)).ToList();

				VerificaFinalizacaoTarefa(tarefaDomain);
				_tarefaService.Adicionar(tarefaDomain);
				return RedirectToAction("Index");
            }

			ViewBag.CategoriaId = new SelectList(ObterTodasCategorias(), "CategoriaId", "Nome", tarefaView.CategoriaId);
            ViewBag.Tags = new SelectList(ObterTodasTags(), "TagId", "Nome", ObterIdsTags(tarefaView));
            return View(tarefaView);
		}

		// GET: Tarefas/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tarefa = _tarefaService.ObterPorId(id);
			var tarefaView = AutoMapper.Mapper.Map<TarefaViewModel>(tarefa);
			if (tarefaView == null)
			{
				return HttpNotFound();
			}

			ViewBag.CategoriaId = new SelectList(ObterTodasCategorias(), "CategoriaId", "Nome", tarefaView.CategoriaId);
            ViewBag.Tags = new MultiSelectList(ObterTodasTags(), "TagId", "Nome", ObterIdsTags(tarefaView));

            return View(tarefaView);
		}

		// POST: Tarefas/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "TarefaId,Nome,Descricao,Situacao,DataCriacao, DataFinalizacao,HoraFinalizacao,CategoriaId,TagsIds")] TarefaViewModel tarefaView)
		{
			if (ModelState.IsValid)
			{
				var tarefaDomain = AutoMapper.Mapper.Map<Tarefa>(tarefaView);
                tarefaDomain.Tags = _tagService.ObterTodos().Where(m => tarefaView.TagsIds.Contains(m.TagId)).ToList();

                var tarefaBase = _tarefaService.ObterPorId(tarefaDomain.TarefaId);
                tarefaBase.AtualizarTarefa(tarefaDomain);

                VerificaFinalizacaoTarefa(tarefaBase);
				_tarefaService.Alterar(tarefaBase);

				return RedirectToAction("Index");
			}

			ViewBag.CategoriaId = new SelectList(ObterTodasCategorias(), "CategoriaId", "Nome", tarefaView.CategoriaId);
            ViewBag.Tags = new MultiSelectList(ObterTodasTags(), "TagId", "Nome", ObterIdsTags(tarefaView));
            return View(tarefaView);
		}

		// GET: Tarefas/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tarefa = _tarefaService.ObterPorId(id);
			var tarefaView = AutoMapper.Mapper.Map<TarefaViewModelDetails>(tarefa);
			if (tarefaView == null)
			{
				return HttpNotFound();
			}
			return View(tarefaView);
		}

		// POST: Tarefas/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_tarefaService.Remover(id);
			return RedirectToAction("Index");
		}

		public ActionResult FinalizarTarefasAtrasadas()
		{
			_tarefaService.FinalizarTarefasAtrasadas();
			return RedirectToAction("Index");
		}


		public ActionResult FinalizarTarefa(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var tarefaDomain = _tarefaService.ObterPorId(id);

			if (tarefaDomain.Situacao != SituacaoTarefaEnum.Progresso && tarefaDomain.Situacao != SituacaoTarefaEnum.Atrasada)
			{
				//Somente tarefas em progresso e atrasadas podem ser finalizadas
				return new HttpStatusCodeResult(HttpStatusCode.NotModified);
			}

			if (tarefaDomain != null)
			{
				tarefaDomain.Situacao = SituacaoTarefaEnum.Finalizada;
				VerificaFinalizacaoTarefa(tarefaDomain);
				_tarefaService.Alterar(tarefaDomain);
				return RedirectToAction("Index");
			}

			var tarefaView = AutoMapper.Mapper.Map<TarefaViewModel>(tarefaDomain);
			if (tarefaView == null)
			{
				return HttpNotFound();
			}

			ViewBag.CategoriaId = new SelectList(ObterTodasCategorias(), "CategoriaId", "Nome", tarefaView.CategoriaId);
            ViewBag.Tags = new SelectList(ObterTodasTags(), "TagId", "Nome", ObterIdsTags(tarefaView));

            return View(tarefaView);
		}

		private IEnumerable<CategoriaViewModel> ObterTodasCategorias()
		{
			var categorias = _categoriaService.ObterTodos();
			var categoriasView = AutoMapper.Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(categorias);
			return categoriasView;
		}

        private IEnumerable<TagViewModel> ObterTodasTags()
        {
            var tags = _tagService.ObterTodos();
            var tagsView = AutoMapper.Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);
            return tagsView;
        }

        private int[] ObterIdsTags(TarefaViewModel tarefaView)
        {
            int[] retorno = null;

            if (tarefaView.Tags != null && tarefaView.Tags.Count() != 0)
            {
                retorno = new int[tarefaView.Tags.Count()];
                int cont = 0;

                foreach (var item in tarefaView.Tags)
                {
                    retorno[cont] = item.TagId;
                    cont++;
                }
            }


            return retorno;
        }


        private void VerificaFinalizacaoTarefa(Tarefa tarefa)
		{
			if (tarefa.Situacao == SituacaoTarefaEnum.Finalizada)
			{
				tarefa.DataFinalizacao = DateTime.Now;
			}
		}

	}
}
