using GoGIS_Model.ViewModel;
using GoGIS_Services.SynopsisService;
using System;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class SynopsisController : ApiController
    {
        private readonly ISynopsisService _service = new SynopsisService();

        [HttpPost]
        //[Authorize]
        [Route("api/Synopsis")]
        public IHttpActionResult Create(Synopsis model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateUpcomingSynopsis(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Synopsis")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllUpcomingSynopsisDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Synopsis/{id}")]
        public IHttpActionResult DataById(int id)
        {
            try
            {
                var data = _service.GetSynopsisById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //[Authorize]
        //[Route("api/Synopsis")]
        //public IHttpActionResult UpdateData(Synopsis model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Invalid model");
        //        }

        //        var data = _service.UpdateUpcomingSynopsisDetails(model);

        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete]
        //[Authorize]
        [Route("api/Synopsis/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteUpcomingSynopsisDetails(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
