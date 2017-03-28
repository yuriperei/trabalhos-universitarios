using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace MustDo.Presentation.WebMVC.Controllers
{
	public class CategoriasController : Controller
	{
		private readonly ICategoriaService _categoriaService;

		public CategoriasController(ICategoriaService categoriaService)
		{
			_categoriaService = categoriaService;
		}


		// GET: Categorias
		public ActionResult Index()
		{
			return View(_categoriaService.ObterTodos());
		}

		// GET: Categorias/Details/5
		public ActionResult Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Categoria categoria = _categoriaService.ObterPorId(id);
			if (categoria == null)
			{
				return HttpNotFound();
			}
			return View(categoria);
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
		public ActionResult Create([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
		{
			if (ModelState.IsValid)
			{
				categoria.CategoriaId = Guid.NewGuid();
				_categoriaService.Adicionar(categoria);
				return RedirectToAction("Index");
			}

			return View(categoria);
		}

		// GET: Categorias/Edit/5
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Categoria categoria = _categoriaService.ObterPorId(id);
			if (categoria == null)
			{
				return HttpNotFound();
			}
			return View(categoria);
		}

		// POST: Categorias/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CategoriaId,Nome")] Categoria categoria)
		{
			if (ModelState.IsValid)
			{
				_categoriaService.Alterar(categoria);
				return RedirectToAction("Index");
			}
			return View(categoria);
		}

		// GET: Categorias/Delete/5
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Categoria categoria = _categoriaService.ObterPorId(id);
			if (categoria == null)
			{
				return HttpNotFound();
			}
			return View(categoria);
		}

		// POST: Categorias/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			_categoriaService.Remover(id);
			return RedirectToAction("Index");
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		_categoriaService.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
	}
}
