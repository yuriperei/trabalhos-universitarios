using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Services;
using MustDo.Presentation.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MustDo.Presentation.WebMVC.Controllers
{
	public class TagsController : Controller
	{
		private readonly ITagService _tagService;

		public TagsController(ITagService tagService)
		{
			_tagService = tagService;
		}

		// GET: Tags
		public ActionResult Index()
		{
			var tags = _tagService.ObterTodos();
			var tagsView = AutoMapper.Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);

			return View(tagsView);
		}

		// GET: Tags/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tag = _tagService.ObterPorId(id);
			var tagView = AutoMapper.Mapper.Map<TagViewModel>(tag);
			if (tagView == null)
			{
				return HttpNotFound();
			}
			return View(tagView);
		}

		// GET: Tags/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Tags/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "TagId,Nome")] TagViewModel tagView)
		{
			if (ModelState.IsValid)
			{
				var tagDomain = AutoMapper.Mapper.Map<Tag>(tagView);
				_tagService.Adicionar(tagDomain);
				return RedirectToAction("Index");
			}

			return View(tagView);
		}

		// GET: Tags/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tag = _tagService.ObterPorId(id);
			var tagView = AutoMapper.Mapper.Map<TagViewModel>(tag);
			if (tagView == null)
			{
				return HttpNotFound();
			}
			return View(tagView);
		}

		// POST: Tags/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "TagId,Nome")] TagViewModel tagView)
		{
			if (ModelState.IsValid)
			{
				var tagDomain = AutoMapper.Mapper.Map<Tag>(tagView);
				_tagService.Alterar(tagDomain);
				return RedirectToAction("Index");
			}
			return View(tagView);
		}

		// GET: Tags/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var tag = _tagService.ObterPorId(id);
			var tagView = AutoMapper.Mapper.Map<TagViewModel>(tag);
			if (tagView == null)
			{
				return HttpNotFound();
			}
			return View(tagView);
		}

		// POST: Tags/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var tag = _tagService.ObterPorId(id);
			_tagService.Remover(tag);
			return RedirectToAction("Index");
		}
	}
}
