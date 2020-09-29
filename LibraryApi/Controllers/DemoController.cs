using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class DemoController : ControllerBase
    {
        // Route Params
        // GET /employees/19
        [HttpGet("/employees/{employeeId:int}")]
        public ActionResult LookupEmployee([FromRoute] int employeeId)
        {
            return Ok($"Finding employee { employeeId }");
        }

        // GET /blogs/2020/09/18
        [HttpGet("/blogs/{year:int}/{month:int:range(1,12)}/{day:int:range(1,31)}")]
        public ActionResult GetBlogPosts([FromRoute] int year, [FromRoute] int month, [FromRoute] int day)
        {
            return Ok($"Getting blogs for {year}/{month}/{day}");
        }
        // Query Strings
    }
}
