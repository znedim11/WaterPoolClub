using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity; using VaterpoloKlub.Models;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaterpoloKlub.Data;

[assembly: HostingStartup(typeof(VaterpoloKlub.Areas.Identity.IdentityHostingStartup))]
namespace VaterpoloKlub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}