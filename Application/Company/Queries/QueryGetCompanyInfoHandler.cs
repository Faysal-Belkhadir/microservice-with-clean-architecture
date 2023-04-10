// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Application.Company.Queries;

public class QueryGetCompanyInfoHandler : IRequestHandler<QueryGetCompanyInfo, CompanyInfoDto>
{
    private IGenericRepository<Domain.Company> CompanyRepository { get; }

    public QueryGetCompanyInfoHandler(IGenericRepository<Domain.Company> companyRepository)
    {
        CompanyRepository = companyRepository;
    }

    /// <inheritdoc />
    public async Task<CompanyInfoDto> Handle(QueryGetCompanyInfo request, CancellationToken cancellationToken)
    {
        var company = await CompanyRepository.SingleOrDefaultAsync(_ => _.Id == request.CompanyId);

        return (company == null
            ? null
            : new CompanyInfoDto(
                Id: company.Id,
                Name: company.Name,
                Designation: company.Designation,
                Country: company.Country,
                Adress: company.Address
            ))!;
    }
}
