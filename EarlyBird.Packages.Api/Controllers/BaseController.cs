﻿using EarlyBird.Packages.Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.Packages.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
            => result is null ? NotFound() : Ok(result);

        protected IActionResult ExceptionToActionResult(Exception ex)
        {
            if (ex.InnerException != null)
                while (ex.InnerException != null)
                    ex = ex.InnerException;

            Console.Error.WriteLine("*Error Error*. " + ex.Message + ' ' + ex.InnerException + ' ' + ex.StackTrace);
            return BadRequest(ex);
        }
        protected IActionResult InvalidInputParameters()
        {
            var response = new ErrorResponse();
            response.AddError(new Error("Input parameters are invalid", "INVALID_INPUT", 400, "INPUT"));
            return BadRequest(response);
        }
    }
}