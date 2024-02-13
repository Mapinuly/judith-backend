using GoGIS_Model.ViewModel;
using GoGIS_Services.RegisterEventsService;
using System;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class RegisterEventsController : ApiController
    {
        private readonly IRegisterEventsService _service = new RegisterEventsService();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/register_events")]
        public IHttpActionResult Create(RegisterEvents model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateRegisterEvents(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/register_events")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllRegisterEventsDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/register_events/{id}")]
        public IHttpActionResult DataById(int id)
        {
            try
            {
                var data = _service.GetEventsById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        [Route("api/register_events")]
        public IHttpActionResult UpdateData(RegisterEvents model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.UpdateRegisterEventsDetails(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/register_events/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteRegisterEventsDetails(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}