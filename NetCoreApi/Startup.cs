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
            #region swagger服务注册

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo

                {
                    Version = "V1",//版本号
                    Title = $"{apiName} 接口文档——dotnetcore 3.1",//编辑标题
                    Description = $"{apiName} HTTP API V1",//编辑描述
                    Contact = new OpenApiContact { Name = apiName, Email = "sogood12138@163.com" },//编辑联系方式
                    License = new OpenApiLicense { Name = apiName }//编辑许可证
                });
                c.OrderActionsBy(o => o.RelativePath);
                var xmlPath = Path.Combine(Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath, "NetCoreApi.xml");// 配置接口文档文件路径
                c.IncludeXmlComments(xmlPath, true); // 把接口文档的路径配置进去。第二个参数表示的是是否开启包含对Controller的注释容纳
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

            #region 添加swagger中间件

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
