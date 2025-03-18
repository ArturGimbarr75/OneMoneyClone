using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneMoneyCloneServer.Api.Controllers
{
    [Authorize]
    [ApiController]
	[Route("api/[controller]")]
	public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
		{
            _logger = logger;
        }

		[HttpGet("get")]
		public string Get()
		{
			return "Hello, World!";
		}

		[HttpGet("test-auth")]
		public IActionResult TestAuth()
		{
			return Ok(new
			{
				Name = User.Identity?.Name,
				Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList()
			});
		}
	}
}
