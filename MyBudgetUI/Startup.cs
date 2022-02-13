using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Services;
using System;
using System.Net.Http;

namespace MyBudgetUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var baseAddress = new Uri(Configuration["BaseAddress"]);

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();

            services.AddHttpClient<IIncomeTypeService, IncomeTypeService>(client =>
            {
                client.BaseAddress = baseAddress;
            });
            services.AddHttpClient<IExpenseTypeService, ExpenseTypeService>(client =>
            {
                client.BaseAddress = baseAddress;
            });
            services.AddHttpClient<IIncomeService, IncomeService>(client =>
            {
                client.BaseAddress = baseAddress;
            });
            services.AddHttpClient<IExpenseService, ExpenseService>(client =>
            {
                client.BaseAddress = baseAddress;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
