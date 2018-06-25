using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;
using Treehouse.FitnessFrog.Shared.Data;

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
        public IHttpActionResult Post(Entry entry)
        {
            _entriesRepository.Add(entry);
            return Created(Url.Link("DefaultApi", new { controller = "entries", id = entry.Id }), entry);
        }

        [HttpPut]
        public void Put(int? id, Entry entry)
        {
            _entriesRepository.Update(entry);
        }

        [HttpDelete]
        public void Delete(int? id)
        {
            _entriesRepository.Delete(Convert.ToInt32(id));
        }

    }
}