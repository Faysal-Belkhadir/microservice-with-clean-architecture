// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Persistence.Seeding;

public class Seeder
{
    private const string SEEDING_PATH = "../Persistence/Seeding";

    public static async Task SeedDatabase(DatabaseContext databaseContext, ILogger logger)
    {
        await SeedCompany(databaseContext);
        await databaseContext.SaveChangesAsync();
        logger.LogInformation($"{nameof(Seeder)} is successfully executed.");
    }

    private static async Task SeedCompany(DatabaseContext databaseContext)
    {
        if (databaseContext.Companies.Any())
        {
            return;
        }

        var companyData = await File.ReadAllTextAsync($"{SEEDING_PATH}/company-data.json");
        var company = JsonSerializer.Deserialize<Company>(companyData);
        if (company != null)
        {
            await databaseContext.AddAsync(company);
        }
    }
}
