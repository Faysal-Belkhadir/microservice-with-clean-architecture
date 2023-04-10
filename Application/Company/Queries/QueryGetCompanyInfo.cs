// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Application.Company.Queries;

public class QueryGetCompanyInfo : RequestBase, IRequest<CompanyInfoDto>
{
    public Guid CompanyId { get; }

    public QueryGetCompanyInfo(Guid companyId)
    {
        CompanyId = companyId;
    }
}
