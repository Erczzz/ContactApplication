using ContactWEB.Model;
using ContactWEB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactWEB.Data
{
    public class ContactDBContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }
        private readonly IWebHostEnvironment _env;
        public ContactDBContext(IConfiguration appConfig, ILogger<ContactDBContext> logger,
            IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _logger = logger;
            _env = env;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
                .UseQueryTrackingBehavior(QueryTrackingBehavior
                .NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        /*public DbSet<Contact> Contacts => Set<Contact>();*/
        public DbSet<Contact> Contacts { get; set; }
    }
}
