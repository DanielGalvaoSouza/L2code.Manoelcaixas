using L2code.Manoelcaixas.Application.DTOs;
using L2code.Manoelcaixas.Application.DTOs.OutputBoxes;
using L2code.Manoelcaixas.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L2Code.ManoelCaixas.Apirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PackagingController : ControllerBase
    {
        private readonly IPackagingService _packagingService;

        public PackagingController(IPackagingService packagingService)
        {
            _packagingService = packagingService;
        }

        // Post: api/PackagingProducts
        [HttpPost]
        public PackagingFeedbackDTO PackagingProducts(InputOrdersDTO caixasDTO)
        {
            return _packagingService.PackagingProducts(caixasDTO); ;
        }

        
    }
}
