using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace geotracker_desktop.cloud
{
    internal class ProjectIdProvider
    {
        private readonly IConfiguration _configuration;

        public ProjectIdProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true);

            _configuration = builder.Build();
        }

        public string GetApiKey()
        {
            return _configuration["FIRESTORE_PROJECT_ID"];
        }
    }
}
