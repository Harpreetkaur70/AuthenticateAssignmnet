using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterLoginProject.Data;

[assembly: HostingStartup(typeof(RegisterLoginProject.Areas.Identity.IdentityHostingStartup))]
namespace RegisterLoginProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RegisterLoginProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RegisterLoginProjectContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<RegisterLoginProjectContext>();
            });
        }
    }
}