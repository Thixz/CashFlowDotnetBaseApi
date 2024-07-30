using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = new MySqlServerVersion(new Version(5, 7, 22));

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString,serverVersion));
    }
}
