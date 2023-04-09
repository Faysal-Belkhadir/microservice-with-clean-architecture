// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DepartmentController : ApiBaseController<DepartmentController>
{
    public DepartmentController(
        ILogger<DepartmentController> logger,
        IWebHostEnvironment webHostEnvironment
    ) : base(logger, webHostEnvironment)
    {
    }

    [HttpGet(nameof(GetDepartmentById))]
    public async Task<IActionResult> GetDepartmentById(Guid id)
    {
        return Ok(new Department());
    }

    [HttpGet(nameof(GetAllDepartments))]
    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
        return Ok(new List<Department>());
    }
}
