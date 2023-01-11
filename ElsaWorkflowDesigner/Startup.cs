using Elsa;
using Elsa.Activities.Workflows.Workflow;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.Sqlite;
using Elsa.Persistence.EntityFramework.SqlServer;
using ElsaWorkflowDesigner.Activities;
using ElsaWorkflowDesigner.Services;
using ElsaWorkflowDesigner.Workflows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaWorkflowDesigner
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
            workflowDB = configuration["Data:DefaultConnection:workflowDB"];
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940



        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }
        public static string workflowDB { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var elsaSection = Configuration.GetSection("Elsa");

            // Elsa services.
            services
                .AddElsa(elsa => elsa
                    .AddConsoleActivities()
                    .AddEmailActivities(elsaSection.GetSection("Smtp").Bind)
                    .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(workflowDB))
                    .AddConsoleActivities()
                    .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                    .AddQuartzTemporalActivities()
                    .AddWorkflowsFrom<Startup>()
                    .AddActivity<SampleOutput>()
                    .AddActivity<DepartmentBudgetApproval>()
                    .AddActivity<ApprovalFromDepartmentBudgetApproverActivity>()
                    .AddActivity<DepartmentBudgetApprovalFinance>()
                    .AddActivity<DepartmentBudgetApprovalHR>()
                    .AddActivity<DepartmentBudgetApprovalCFO>()
                    .AddActivity<SampleCustomActivity>()
                    .AddWorkflow<SampleCustomeWorkflow>()
                    .AddWorkflow<ApprovalDepartmentWorkflow>()
                    .AddWorkflow<ApprovalFromDepartmentBudgetApproverWF>()
                    .AddWorkflow<ApprovalFinanceWorkflow>()
                    .AddWorkflow<ApprovalHRWorkflow>()
                    .AddWorkflow<ApprovalCFOWorkflow>()

                );


            // Elsa API endpoints.
            services.AddElsaApiEndpoints();

            services.AddBookmarkProvider<DepartmentBudgetBookmarkProvider>();


            // For Dashboard.
            services.AddRazorPages();
            services.AddMvc()
                    .AddSessionStateTempDataProvider();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSession()
                .UseStaticFiles() // For Dashboard.
                .UseHttpActivities()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    //endpoints.MapControllers();

                    //// For Dashboard.
                    //endpoints.MapFallbackToPage("/_Host");

                    endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    // endpoints.MapRazorPages();

                });

            //// Elsa API Endpoints are implemented as regular ASP.NET Core API controllers.
            //endpoints.MapControllers();

            //        // For Dashboard.
            //        endpoints.MapFallbackToPage("/_Host");
            //    });
        }
    }
}
