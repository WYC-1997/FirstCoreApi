using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCoreApi.Models;
using NetCoreApi.services.UserServices;

namespace NetCoreApi
{
    public class Startup
    {
        private readonly string apiName = ".NetCore API";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContextPool<DataBaseContent>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"]);
            });
            #region swagger����ע��

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo

                {
                    Version = "V1",//�汾��
                    Title = $"{apiName} �ӿ��ĵ�����dotnetcore 3.1",//�༭����
                    Description = $"{apiName} HTTP API V1",//�༭����
                    Contact = new OpenApiContact { Name = apiName, Email = "sogood12138@163.com" },//�༭��ϵ��ʽ
                    License = new OpenApiLicense { Name = apiName }//�༭���֤
                });
                c.OrderActionsBy(o => o.RelativePath);
                var xmlPath = Path.Combine(Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath, "NetCoreApi.xml");// ���ýӿ��ĵ��ļ�·��
                c.IncludeXmlComments(xmlPath, true); // �ѽӿ��ĵ���·�����ý�ȥ���ڶ���������ʾ�����Ƿ���������Controller��ע������
            });
            #endregion
            //services.AddHttpClient();
            services.AddTransient<IUserService, UserService>();
            //services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            #region ���swagger�м��

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{apiName} V1");
                c.RoutePrefix = "";
            });
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
