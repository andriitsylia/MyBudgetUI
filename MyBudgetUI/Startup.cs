using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBudgetUI.Interfaces;
using MyBudgetUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();

            services.AddHttpClient<IIncomeTypeService, IncomeTypeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IExpenseTypeService, ExpenseTypeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IIncomeService, IncomeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IExpenseService, ExpenseService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
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
