using AlIInOne.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlIInOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _service;

        public LecturerController(ILecturerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _service.GetById(id));

    }
}
