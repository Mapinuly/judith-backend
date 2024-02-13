using GoGIS_Model.ViewModel;
using GoGIS_Services.EventService;
using System;
using System.Web;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class EventController : ApiController
    {
        private readonly IEventService _service = new EventService();

        [HttpPost]
        //[Authorize]
        [Route("api/upcoming_events")]
        public IHttpActionResult Create()
        {
            try
            {
                string imgPath = "";
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];
                    imgPath = SaveImage(postedFile);
                }

                var eventsModel = new Events
                {
                    title = httpRequest["title"],
                    description = httpRequest["description"],
                    img = imgPath,
                    start_date = Convert.ToDateTime(httpRequest["start_date"]),
                    end_date = Convert.ToDateTime(httpRequest["end_date"])
                };

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateUpcomingEvents(eventsModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/upcoming_events")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllUpcomingEventsDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/events/{id}")]
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
        [Route("api/upcoming_events")]
        public IHttpActionResult UpdateData()
        {
            try
            {
                string imgPath = "";
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];
                    imgPath = SaveImage(postedFile);
                }

                var model = new Events
                {
                    id = Convert.ToInt32(httpRequest["Id"]),
                    title = httpRequest["title"],
                    description = httpRequest["description"],
                    img = imgPath,
                    start_date = Convert.ToDateTime(httpRequest["start_date"]),
                    end_date = Convert.ToDateTime(httpRequest["end_date"])
                };

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.UpdateUpcomingEventsDetails(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/upcoming_events/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteUpcomingEventsDetails(id);

                return Ok("Data Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/events")]
        public IHttpActionResult AllEventData()
        {
            try
            {
                var data = _service.AllEventsDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string SaveImage(HttpPostedFile file)
        {
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = HttpContext.Current.Server.MapPath("~/ImgUpload/" + fileName);
            file.SaveAs(filePath);
            return filePath;
        }
    }
}
