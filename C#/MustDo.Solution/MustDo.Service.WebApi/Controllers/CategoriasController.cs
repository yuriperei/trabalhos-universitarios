using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MustDo.Domain.Entities;
using MustDo.Infra.Data.Contexts;
using MustDo.Domain.Interfaces.Services;
using MustDo.Service.WebApi.Models;

namespace MustDo.Service.WebApi.Controllers
{
    public class CategoriasController : ApiController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/Categorias
        public IEnumerable<CategoriaDTO> GetCategorias()
        {
            var categoriaDomain = _categoriaService.ObterTodos();
            var categoriaDTO = AutoMapper.Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(categoriaDomain);
            return categoriaDTO;
        }

        // GET: api/Categorias/5
        [ResponseType(typeof(CategoriaDTO))]
        public IHttpActionResult GetCategoria(int id)
        {
            var categoriaDomain = _categoriaService.ObterPorId(id);
            if (categoriaDomain == null)
            {
                return NotFound();
            }

            var categoriaDTO = AutoMapper.Mapper.Map<Categoria, CategoriaDTO>(categoriaDomain);
            return Ok(categoriaDTO);
        }

        // PUT: api/Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoria(int id, CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaDTO.CategoriaId)
            {
                return BadRequest();
            }

            try
            {
                var categoriaDomain = AutoMapper.Mapper.Map<Categoria>(categoriaDTO);
                //var tagBase = _categoriaService.ObterPorId(id);
                //tagBase.(categoriaDomain);
                _categoriaService.Alterar(categoriaDomain);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categorias
        [ResponseType(typeof(CategoriaDTO))]
        public IHttpActionResult PostCategoria(CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaDomain = AutoMapper.Mapper.Map<Categoria>(categoriaDTO);
            _categoriaService.Adicionar(categoriaDomain);

            return CreatedAtRoute("DefaultApi", new { id = categoriaDomain.CategoriaId }, categoriaDomain);
        }

        // DELETE: api/Categorias/5
        [ResponseType(typeof(CategoriaDTO))]
        public IHttpActionResult DeleteCategoria(int id)
        {
            var categoriaDomain = _categoriaService.ObterPorId(id);
            if (categoriaDomain == null)
            {
                return NotFound();
            }

            var categoriaDTO = AutoMapper.Mapper.Map<CategoriaDTO>(categoriaDomain);
            _categoriaService.Remover(categoriaDomain);

            return Ok(categoriaDTO);
        }


        //private bool CategoriaExists(int id)
        //{
        //    return db.Categorias.Count(e => e.CategoriaId == id) > 0;
        //}
    }
}