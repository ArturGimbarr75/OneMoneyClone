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

		[HttpGet]
		public string Get()
		{
			return "Hello, World!";
		}
	}
}
