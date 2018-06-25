using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class ActivitiesController : ApiController
    {

        private ActivitiesRepository _activititiesRepository = null;

        public ActivitiesController(ActivitiesRepository activitiesRepository)
        {
            _activititiesRepository = activitiesRepository;
        }
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_activititiesRepository.GetList());
        }
    }
}