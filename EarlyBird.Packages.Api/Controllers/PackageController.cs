using EarlyBird.Packages.Service;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.Packages.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : BaseController
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PackageModel>>> GetAllPackages()
        {
            var result = _packageService.GetAllPackages();
            return OkOrNotFound(result);
        }


        [Produces("application/json")]
        [HttpGet("/package/{kolliid}")]
        public async Task<ActionResult<PackageModel>> GetPackageDetails(string kolliid)
        {
            if (Validations.IsSearchKolliidValid(kolliid))
            {
                var result = _packageService.GetPackageDetails(int.Parse(kolliid));
                return OkOrNotFound(result);
            }
            return InvalidInputParameters();
        }

        [Produces("application/json")]
        [HttpPost("/package")]
        public async Task<IActionResult> CreatePackage([FromBody] PackageModel packageModel)
        {
            try
            {
                var dimensionErrors = Validations.ValidateDimensions(packageModel);
                if (dimensionErrors.Count != 0)
                {
                    return PackageDimensionsInvalid(dimensionErrors);
                }

                if (Validations.IsSearchKolliidValid(packageModel.Kolliid))
                {
                    return InvalidInputParameters();
                }

                _packageService.CreatePackage(packageModel);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionToActionResult(e);
            }
        }
    }
}
