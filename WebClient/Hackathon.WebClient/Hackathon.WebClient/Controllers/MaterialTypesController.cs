using Hackathon.DAL.Interface;
using Hackathon.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypesController : ControllerBase
    {
        private readonly IGenericRepository<MaterialType> _materialTypeRepository;

        public MaterialTypesController(IGenericRepository<MaterialType> materialTypeRepository)
        {
            _materialTypeRepository = materialTypeRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data= _materialTypeRepository.GetAll("Materials");
            return Ok(data);
        }
    }
}
