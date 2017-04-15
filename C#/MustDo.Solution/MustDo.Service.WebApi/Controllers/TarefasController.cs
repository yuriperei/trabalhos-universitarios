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
using MustDo.Service.WebApi.Models;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Service.WebApi.Controllers
{
    public class TarefasController : ApiController
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITagService _tagServie;

        public TarefasController(ITarefaService tarefaService, ITagService tagServie)
        {
            _tarefaService = tarefaService;
            _tagServie = tagServie;
        }

        // GET: api/Tarefas
        public IEnumerable<TarefaDTO> GetTarefas()
        {
            var tarefaDomain = _tarefaService.ObterTodos();
            var tarefaDTO = AutoMapper.Mapper.Map<IEnumerable<Tarefa>, IEnumerable<TarefaDTO>>(tarefaDomain);
            return tarefaDTO;
        }

        // GET: api/Tarefas/PorCategoria/{id}
        [HttpGet]
        public IEnumerable<TarefaDTO> PorCategoria(int id)
        {
            var tarefaDomain = _tarefaService.ObterTarefasPorCategoria(id);
            if (tarefaDomain != null)
            {
                return AutoMapper.Mapper.Map<IEnumerable<Tarefa>, IEnumerable<TarefaDTO>>(tarefaDomain);
            }         
            return null;
        }

        // GET: api/Tarefas/PorTag/{id}
        [HttpGet]
        public IEnumerable<TarefaDTO> PorTag(int id)
        {
            var tag = _tagServie.ObterPorId(id);
            if (tag != null)
            {
                IEnumerable<Tarefa> tarefas = tag.Tarefas;
                return AutoMapper.Mapper.Map<IEnumerable<Tarefa>, IEnumerable<TarefaDTO>>(tarefas);
            }
            return null;
        }

        // GET: api/Tarefas/5
        [ResponseType(typeof(TarefaDTO))]
        public IHttpActionResult GetTarefa(int id)
        {
            var tarefaDomain = _tarefaService.ObterPorId(id);
            if (tarefaDomain == null)
            {
                return NotFound();
            }

            var tarefaDTO = AutoMapper.Mapper.Map<Tarefa, TarefaDTO>(tarefaDomain);
            return Ok(tarefaDTO);
        }

        // PUT: api/Tarefas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarefa(int id, TarefaDTO tarefaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarefaDTO.TarefaId)
            {
                return BadRequest();
            }

            try
            {
                var tarefaDomain = AutoMapper.Mapper.Map<Tarefa>(tarefaDTO);
                //var tarefaBase = _tarefaService.ObterPorId(id);
                //tarefaBase.(tarefaDomain);
                _tarefaService.Alterar(tarefaDomain);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tarefas
        [ResponseType(typeof(TarefaDTO))]
        public IHttpActionResult PostTarefa(TarefaDTO tarefaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarefaDomain = AutoMapper.Mapper.Map<Tarefa>(tarefaDTO);
            _tarefaService.Adicionar(tarefaDomain);

            return CreatedAtRoute("DefaultApi", new { id = tarefaDomain.TarefaId }, tarefaDomain);
        }

        // DELETE: api/Tarefas/5
        [ResponseType(typeof(TarefaDTO))]
        public IHttpActionResult DeleteTarefa(int id)
        {
            var tarefaDomain = _tarefaService.ObterPorId(id);
            if (tarefaDomain == null)
            {
                return NotFound();
            }

            var tarefaDTO = AutoMapper.Mapper.Map<TarefaDTO>(tarefaDomain);
            _tarefaService.Remover(tarefaDomain);

            return Ok(tarefaDTO);
        }


        //private bool TarefaExists(int id)
        //{
        //    return db.Tarefas.Count(e => e.TarefaId == id) > 0;
        //}
    }
}