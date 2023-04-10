// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Shared.Dtos;

public record CompanyInfoDto(Guid Id, string Name, string? Designation, string Adress, string Country);
