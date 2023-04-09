// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController : ApiBaseController<CompanyController>
{
    public CompanyController(
        ILogger<CompanyController> logger,
        IWebHostEnvironment webHostEnvironment
    ) : base(logger, webHostEnvironment)
    {
    }

    [HttpGet(nameof(AboutUs))]
    public async Task<IActionResult> AboutUs()
    {
        return Ok(new Company());
    }
}
