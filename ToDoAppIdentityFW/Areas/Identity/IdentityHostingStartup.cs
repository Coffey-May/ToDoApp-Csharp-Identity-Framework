using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoAppIdentityFW.Data;
using ToDoAppIdentityFW.Models;

[assembly: HostingStartup(typeof(ToDoAppIdentityFW.Areas.Identity.IdentityHostingStartup))]
namespace ToDoAppIdentityFW.Areas.Identity
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