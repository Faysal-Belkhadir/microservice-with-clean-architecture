// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Application.Company.Queries;

public class QueryGetCompanyInfoValidator : AbstractValidator<QueryGetCompanyInfo>
{
    public QueryGetCompanyInfoValidator()
    {
        RuleFor(_ => _.CompanyId).NotNull();
    }
}
