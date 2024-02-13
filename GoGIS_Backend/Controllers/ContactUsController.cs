using GoGIS_Model.ViewModel;
using GoGIS_Services.ContactUsService;
using System;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class ContactUsController : ApiController
    {
        private readonly IContactUsService _service = new ContactUsService();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/contact_us")]
        public IHttpActionResult Create(ContactUs model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateContactUs(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/contact_us")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllContactUsDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/contact_us/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteContactUs(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
