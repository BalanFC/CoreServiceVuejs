using FDTE.Entities;
using FDTE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FDTE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarujoController : ControllerBase
    {
        private readonly IMarujoService _marujoService;

        public MarujoController(IMarujoService marujoService)
        {
            _marujoService = marujoService;
        }

		// GET: api/Marujo
		[HttpGet]
		[Route("GetMarujos")]
		public IActionResult GetMarujos()
		{
			return Ok(
				_marujoService.GetAll()
				);
		}

		// GET: api/Marujo/5
		[HttpGet("{id}")]
		[Route("GetMarujo/{id}")]
		public IActionResult GetMarujo(int id)
		{
			return Ok(
				_marujoService.Get(id)
				);
		}

		// POST: api/Marujo
		[HttpPost]
		[Route("AddMarujo")]
		public IActionResult Create([FromBody] Marujo model)
		{
			return Ok(
				_marujoService.Create(model)
				);
		}

		[HttpPost]
		[Route("UpdateMarujo")]
		public IActionResult Update([FromBody] Marujo model)
		{
			return Ok(
				_marujoService.Update(model)
				);
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		[Route("DeleteMarujo/{id}")]
		public IActionResult Delete(int id)
		{
			return Ok(
				_marujoService.Delete(id)
				);
		}
	}
}