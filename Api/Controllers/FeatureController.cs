using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using BusinessLogic.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IGetFeaturesCommand getFeaturesCommand;
        private readonly IGetFeatureCommand getFeatureCommand;
        private readonly IAddFeatureCommand addFeatureCommand;
        private readonly IEditFeatureCommand editFeatureCommand;
        private readonly IDeleteFeatureCommand deleteFeatureCommand;

        public FeatureController(IGetFeaturesCommand getFeatures, IGetFeatureCommand getFeature, IAddFeatureCommand addFeature, IEditFeatureCommand editFeature, IDeleteFeatureCommand deleteFeature)
        {
            getFeaturesCommand = getFeatures;
            getFeatureCommand = getFeature;
            addFeatureCommand = addFeature;
            editFeatureCommand = editFeature;
            deleteFeatureCommand = deleteFeature;
        }


        // GET: api/Feature
        [HttpGet]
        public IActionResult Get([FromQuery] FeatureQuery query)
        {
            try
            {
                return Ok(getFeaturesCommand.Execute(query));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/Feature/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getFeatureCommand.Execute(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Feature
        [HttpPost]
        public IActionResult Post([FromBody] AddFeatureDto dto)
        {
            try
            {
                addFeatureCommand.Execute(dto);
                return StatusCode(201, "Feature successfully added");
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(422, "An error has occurred.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT: api/Feature/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddFeatureDto dto)
        {
            try
            {
                dto.Id = id;
                editFeatureCommand.Execute(dto);
                return StatusCode(204, "Successfully updated");
            }
            catch
            {
                return StatusCode(422, "Error while trying to update feature.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteFeatureCommand.Execute(id);
                return StatusCode(204, "Successfully deleted feature.");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
