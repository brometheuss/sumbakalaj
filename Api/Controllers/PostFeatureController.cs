using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Commands;
using BusinessLogic.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostFeatureController : ControllerBase
    {
        private readonly IGetPostFeaturesCommand _getPostFeatures;

        public PostFeatureController(IGetPostFeaturesCommand getPostFeatures)
        {
            _getPostFeatures = getPostFeatures;
        }


        // GET: api/PostFeature
        [HttpGet]
        public IActionResult Get([FromBody]FeatureQuery query)
        {
            return Ok(_getPostFeatures.Execute(query));
        }

        // GET: api/PostFeature/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PostFeature
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PostFeature/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
