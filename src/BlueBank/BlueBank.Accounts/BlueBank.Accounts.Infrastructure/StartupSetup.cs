﻿using BlueBank.Accounts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlueBank.Accounts.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddInMemoryDbContext(this IServiceCollection services, string dbName) =>
            services.AddDbContext<AccountsDbContext>(options =>
                options.UseInMemoryDatabase(dbName)); // will be created in web project root


        //Not used in the test task
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AccountsDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root
    }
}
