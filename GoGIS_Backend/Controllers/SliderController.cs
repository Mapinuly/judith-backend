using GoGIS_Model.ViewModel;
using GoGIS_Services.SliderService;
using System;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class SliderController : ApiController
    {
        private readonly ISliderService _service = new SliderService();

        [HttpPost]
        //[Authorize]
        [Route("api/slider")]
        public IHttpActionResult Create(Slider model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateSlider(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/slider")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllSliderDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/slider/{id}")]
        public IHttpActionResult DataById(int id)
        {
            try
            {
                var data = _service.GetSliderById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        [Route("api/slider")]
        public IHttpActionResult UpdateData(Slider model)
        {
            try
            {
                var data = _service.UpdateSliderDetails(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/slider/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteSliderDetails(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
