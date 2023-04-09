// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.API.Controllers;

[Route("[controller]")]
[ApiController]
public class EmployeeController : ApiBaseController<EmployeeController>
{
    public EmployeeController(
        ILogger<EmployeeController> logger,
        IWebHostEnvironment webHostEnvironment
    ) : base(logger, webHostEnvironment)
    {
    }

    [HttpGet(nameof(GetEmployeeById))]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        return Ok(new Employee());
    }

    [HttpGet(nameof(GetAllEmployees))]
    public async Task<IActionResult> GetAllEmployees()
    {
        return Ok(new List<Employee>());
    }
}
