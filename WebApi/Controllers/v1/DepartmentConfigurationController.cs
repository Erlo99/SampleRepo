using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class DepartmentConfigurationController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult GetDepartmentList()
        //{
        //    return Ok();
        //}

        ////[HttpGet]
        ////public IActionResult GetDepartmentById()
        ////{
        ////    return Ok();
        ////}

        //[HttpPost]
        //public IActionResult CreateDepartment()
        //{
        //    return Ok();
        //}

        ////[HttpPut]
        ////public IActionResult UpdateDepartment()
        ////{
        ////    return Ok();
        ////}

        //[HttpDelete]
        //public IActionResult DeleteDepartment()
        //{
        //    return Ok();
        //}

        //[HttpPut] // na jaki deparment dac
        //public IActionResult ModifyCustomRoleAccess()
        //{
        //    return Ok();
        //}
    }
}
