using EarlyBird.Packages.Service;
using Microsoft.AspNetCore.Mvc;

namespace EarlyBird.Packages.Api.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("/package")]
        public async Task<IActionResult> GetAllPackages() => Ok(await _packageService.GetAllPackages());


        [Produces("application/json")]
        [HttpGet]
        [Route("/package/{kolliid}")]
        public async Task<IActionResult> GetPackageSize(int kolliid) => Ok();

        [Produces("application/json")]
        [HttpPost]
        [Route("/package")]
        public async Task<IActionResult> CreatePackage() => Ok();
    }
}
