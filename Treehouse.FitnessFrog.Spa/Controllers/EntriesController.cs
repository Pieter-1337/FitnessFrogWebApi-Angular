﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;
using Treehouse.FitnessFrog.Shared.Data;
using Treehouse.FitnessFrog.Spa.Dto;
namespace Treehouse.FitnessFrog.Spa.Controllers 
{


    public class EntriesController : ApiController
    {
        private EntriesRepository _entriesRepository = null;

        public EntriesController(EntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;   
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_entriesRepository.GetList());
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            var entry = _entriesRepository.Get(Convert.ToInt32(id));
            if(entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpPost]
        public IHttpActionResult Post(EntryDto entry)
        {
            if (ModelState.IsValid)
            {
                var entryModel = entry.ToModel();

                _entriesRepository.Add(entryModel);

                entry.Id = entryModel.Id;

                return Created(Url.Link("DefaultApi", new { controller = "entries", id = entry.Id }), entry);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int? id, EntryDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entryModel = entry.ToModel();
            _entriesRepository.Update(entryModel);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public void Delete(int? id)
        {
            _entriesRepository.Delete(Convert.ToInt32(id));
        }

    }
}