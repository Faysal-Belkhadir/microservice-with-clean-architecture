// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController : ApiBaseController<CompanyController>
{
    public CompanyController(
        ILogger<CompanyController> logger,
        IWebHostEnvironment webHostEnvironment,
        IBusMediator busMediator
    ) : base(logger, webHostEnvironment, busMediator)
    {
    }

    [HttpGet(nameof(AboutUs))]
    public async Task<IActionResult> AboutUs(Guid companyId)
    {
        var companyInfo = await BusMediator.SendQuery(new QueryGetCompanyInfo(companyId));

        return Ok(companyInfo ?? $"No company found with the Id = {companyId}");
    }
}
