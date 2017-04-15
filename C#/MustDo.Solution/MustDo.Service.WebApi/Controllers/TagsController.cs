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
    public class TagsController : ApiController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: api/Tags
        public IEnumerable<TagDTO> GetTags()
        {
            var tagDomain = _tagService.ObterTodos();
            var tagDTO = AutoMapper.Mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(tagDomain);
            return tagDTO;
        }

        // GET: api/Tags/5
        [ResponseType(typeof(TagDTO))]
        public IHttpActionResult GetTag(int id)
        {
            var tagDomain = _tagService.ObterPorId(id);
            if (tagDomain == null)
            {
                return NotFound();
            }

            var tagDTO = AutoMapper.Mapper.Map<Tag, TagDTO>(tagDomain);
            return Ok(tagDTO);
        }

        // PUT: api/Tags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTag(int id, TagDTO tagDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tagDTO.TagId)
            {
                return BadRequest();
            }
            
            try
            {
                var tagDomain = AutoMapper.Mapper.Map<Tag>(tagDTO);
                //var tagBase = _tagService.ObterPorId(id);
                //tagBase.(tagDomain);
                _tagService.Alterar(tagDomain);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tags
        [ResponseType(typeof(TagDTO))]
        public IHttpActionResult PostTag(TagDTO tagDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tagDomain = AutoMapper.Mapper.Map<Tag>(tagDTO);
            _tagService.Adicionar(tagDomain);

            return CreatedAtRoute("DefaultApi", new { id = tagDomain.TagId }, tagDomain);
        }

        // DELETE: api/Tags/5
        [ResponseType(typeof(TagDTO))]
        public IHttpActionResult DeleteTag(int id)
        {
            var tagDomain = _tagService.ObterPorId(id);
            if (tagDomain == null)
            {
                return NotFound();
            }

            var tagDTO = AutoMapper.Mapper.Map<TagDTO>(tagDomain);
            _tagService.Remover(tagDomain);

            return Ok(tagDTO);
        }


        //private bool TagExists(int id)
        //{
        //    return db.Tags.Count(e => e.TagId == id) > 0;
        //}
    }
}