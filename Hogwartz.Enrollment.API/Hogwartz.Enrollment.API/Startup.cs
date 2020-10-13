namespace Hogwartz.Enrollment.API
{
    using Hogwartz.Common.Domain.Common.Validators;
    using Hogwartz.Common.Domain.DI;
    using Hogwartz.Enrollment.Application.Enrollment.Services;
    using Hogwartz.Enrollment.Application.Enrollment.Services.Impl;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Hogwartz.Enrollment.Domain.Enrollment.Validators;
    using Hogwartz.Infrastructure.DbMemory;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers.ToDomain;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers.ToInfrastructure;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Version = groupName,
                    Title = "Hogwartz Enrollment API",
                    Description = "Platform of enrollment to Hogwartz Magician Academy",
                    Contact = new OpenApiContact
                    {
                        Name = "DataIFX",
                        Email = string.Empty,
                        Url = new Uri("https://dataifx.com/"),
                    }
                });
            });

            services.AddDbContext<EnrollmentContext>(opt => opt.UseInMemoryDatabase("EnrollmentAPI"));
            services.AddTransient<IAddEnrollmentAppService, AddEnrollmentAppService>();
            services.AddTransient<IGetEnrollmentAppService, GetEnrollmentAppService>();
            services.AddTransient<IDeleteEnrollmentAppService, DeleteEnrollmentAppService>();
            services.AddTransient<IUpdateEnrollmentAppService, UpdateEnrollmentAppService>();
            services.AddTransient<IAddEnrollmentDomainService, EnrollmentAdder>();
            services.AddTransient<IGetEnrollmentDomainService, EnrollmentGetter>();
            services.AddTransient<IDeleteEnrollmentDomainService, EnrollmentDeleter>();
            services.AddTransient<IUpdateEnrollmentDomainService, EnrollmentUpdater>();
            services.AddTransient<IGetEnrollmentDomainService, EnrollmentGetter>();
            services.AddTransient<IValidator<EnrollmentRequest>, EnrollmentRequestValidator>();
            services.AddTransient<IMapper<EnrollmentRequest, EnrollmentRequestDb>, ToInfrastructureEnrollmentMapper>();
            services.AddTransient<IMapper<EnrollmentRequestDb, EnrollmentRequest>, ToDomainEnrollmentMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceActivator.Configure(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hogwartz Enrollment V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
