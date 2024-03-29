using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebContacts
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            //��������� ��������� ����������� � ������������� (MVS)
            services.AddControllersWithViews()
            //���������� ������������� � asp.net core 3.0
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ������� ����������� middleware ����� ����� !!!
            
            // � �������� ���������� ��� ����� ������ ��������� ���������� �� �������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // ���������� ��������� ��������� ������ � ���������� (css, js � �.�)
            app.UseStaticFiles();

            //������������ ������ ��� �������� (���������)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/action=Index}/{id?}");
                
            });
        }
    }
}
