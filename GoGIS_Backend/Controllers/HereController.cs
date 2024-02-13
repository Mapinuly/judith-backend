using GoGIS_Model.ViewModel;
using GoGIS_Services.HereService;
using System;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class HereController : ApiController
    {
        private readonly IHereService _service = new HereService();

        [HttpPost]
        //[Authorize]
        [Route("api/we_are_here")]
        public IHttpActionResult Create(Here model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateHere(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/we_are_here")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllHereDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/we_are_here/{id}")]
        public IHttpActionResult DataById(int id)
        {
            try
            {
                var data = _service.GetHereById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Authorize]
        //[Route("api/we_are_here")]
        //public IHttpActionResult UpdateData(Here model)
        //{
        //    try
        //    {
        //        var data = _service.UpdateHereDetails(model);

        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete]
        //[Authorize]
        [Route("api/we_are_here/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteHereDetails(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
