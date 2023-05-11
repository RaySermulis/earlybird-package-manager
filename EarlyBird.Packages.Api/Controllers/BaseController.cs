using EarlyBird.Packages.Api.Errors;
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
        protected ActionResult InvalidInputParameters()
        {
            var response = new ErrorResponse();
            response.AddError(new Error("Input parameters are invalid", "INVALID_INPUT", 400, "INPUT"));
            return BadRequest(response);
        }

        //todo pass list of errors 
        protected IActionResult PackageDimensionsInvalid(List<string> messages)
        {
            var errorMessages = string.Join(", ", messages.ToArray());
            var response = new ErrorResponse();
            response.AddError(new Error($"Package dimensions are not valid: {errorMessages}", "Range_Not_Satisfiable", 416, "INPUT"));
            return BadRequest(response);
        }
    }
}