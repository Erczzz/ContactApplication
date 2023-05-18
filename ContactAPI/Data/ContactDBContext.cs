using ContactAPI.Model;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace ContactAPI.Data
{
    public class ContactDBContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger<ContactDBContext> _logger { get; }
        private readonly IWebHostEnvironment _env;

        public ContactDBContext(IConfiguration appConfig, IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var server = _appConfig.GetConnectionString("Server");
                var db = _appConfig.GetConnectionString("DB");
                string connectionString;

                if (_env.IsDevelopment())
                {
                    connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true;TrustServerCertificate=True;";
                }
                else
                {
                    var username = _appConfig.GetConnectionString("Username");
                    var password = _appConfig.GetConnectionString("Password");
                    connectionString = $"Server={server};Database={db};User Id={username};Password={password};MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=false";
                }

                optionsBuilder.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
