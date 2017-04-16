using Microsoft.AspNet.Identity;
using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Services;
using MustDo.Presentation.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MustDo.Presentation.WebMVC.Controllers
{
	public class CategoriasController : Controller
	{
		private readonly ICategoriaService _categoriaService;
		//AutoMapper.Mapper.Map<Destino>(source)

		public CategoriasController(ICategoriaService categoriaService)
		{
			_categoriaService = categoriaService;
            
        }

		// GET: Categorias
		public ActionResult Index()
		{
            ObterIdUsuario();
            var categorias = _categoriaService.ObterTodos();
			var categoriasView = AutoMapper.Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(categorias);
			return View(categoriasView);
		}

		// GET: Categorias/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var categoria = _categoriaService.ObterPorId(id);
			var categoriaView = AutoMapper.Mapper.Map<CategoriaViewModel>(categoria);
			if (categoriaView == null)
			{
				return HttpNotFound();
			}
			return View(categoriaView);
		}

		// GET: Categorias/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Categorias/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CategoriaId,Nome,Descricao")] CategoriaViewModel categoriaView)
		{
			if (ModelState.IsValid)
			{
				var categoriaDomain = AutoMapper.Mapper.Map<Categoria>(categoriaView);
                categoriaDomain.UsuarioId = User.Identity.GetUserId();
                _categoriaService.Adicionar(categoriaDomain);
				return RedirectToAction("Index");
			}

			return View(categoriaView);
		}

		// GET: Categorias/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var categoria = _categoriaService.ObterPorId(id);
			var categoriaView = AutoMapper.Mapper.Map<CategoriaViewModel>(categoria);
			if (categoriaView == null)
			{
				return HttpNotFound();
			}
			return View(categoriaView);
		}

		// POST: Categorias/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CategoriaId,Nome,Descricao,UsuarioId")] CategoriaViewModel categoriaView)
		{
			if (ModelState.IsValid)
			{
                ObterIdUsuario();
                var categoriaDomain = AutoMapper.Mapper.Map<Categoria>(categoriaView);
				_categoriaService.Alterar(categoriaDomain);
				return RedirectToAction("Index");
			}
            
            return View(categoriaView);
		}

		// GET: Categorias/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var categoria = _categoriaService.ObterPorId(id);
			var categoriaView = AutoMapper.Mapper.Map<CategoriaViewModel>(categoria);
			if (categoriaView == null)
			{
				return HttpNotFound();
			}
			return View(categoriaView);
		}

		// POST: Categorias/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var categoria = _categoriaService.ObterPorId(id);
			_categoriaService.Remover(categoria);
            return RedirectToAction("Index");
		}

        public void ObterIdUsuario()
        {
            _categoriaService.ObterIdUsuario(User.Identity.GetUserId());
        }
    }
}
