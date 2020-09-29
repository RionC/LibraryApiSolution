using LibraryApi;
using LibraryApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApiIntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var systemTimeDescriptor = services.Single(d => d.ServiceType == typeof(ISystemTime));

                services.Remove(systemTimeDescriptor);
                services.AddTransient<ISystemTime, FakeSystemTime>();
            });
        }
    }

    public class FakeSystemTime : ISystemTime
    {
        public DateTime GetCurrent => new DateTime(1992, 7, 22, 23, 59, 00);
    }
}
