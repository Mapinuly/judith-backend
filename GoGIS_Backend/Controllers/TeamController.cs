using GoGIS_Model.ViewModel;
using GoGIS_Services.TeamService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class TeamController : ApiController
    {
        private readonly ITeamService _service = new TeamService();

        [HttpPost]
        //[Authorize]
        [Route("api/team")]
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

                var teamModel = new Team
                {
                    name = httpRequest["name"],
                    designation = httpRequest["designation"],
                    bio = httpRequest["bio"],
                    img = imgPath
                };

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.CreateTeam(teamModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/team")]
        public IHttpActionResult AllData()
        {
            try
            {
                var data = _service.AllTeamDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/team/{id}")]
        public IHttpActionResult DataById(int id)
        {
            try
            {
                var data = _service.GetTeamById(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        [Route("api/team")]
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

                var model = new Team
                {
                    id = Convert.ToInt32(httpRequest["id"]),
                    name = httpRequest["name"],
                    designation = httpRequest["designation"],
                    bio = httpRequest["bio"],
                    img = imgPath
                };

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var data = _service.UpdateTeamDetails(model);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/team/{id}")]
        public IHttpActionResult DeleteData(int id)
        {
            try
            {
                var data = _service.DeleteTeamDetails(id);

                return Ok("Data Deleted");
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
