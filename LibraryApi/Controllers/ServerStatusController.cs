using LibraryApi.Models.ServerStatus;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class ServerStatusController : ControllerBase
    {
        private ISystemTime _systemTime;

        public ServerStatusController(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        // GET /serverstatus
        [HttpGet("/serverstatus")]
        public ActionResult GetTheServerStatus()
        {
            var response = new GetServerStatusResponse
            {
                Message = "Looks good",
                CheckedBy = "Joe Smith",
                LastChecked = _systemTime.GetCurrent
            };
            return Ok(response);
        }
    }
}
