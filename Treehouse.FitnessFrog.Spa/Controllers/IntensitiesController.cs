using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class IntensitiesController : ApiController
    {
        private EntriesRepository _entriesRepository = null;

        public IntensitiesController(EntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var Intensities = Enum.GetValues(typeof(Entry.IntensityLevel))
                 .Cast<Entry.IntensityLevel>()
                 .Select(il => new { id = (int)il, name = il.ToString() }).ToList();

            return Ok(Intensities);
        }

    }
}