using Demo_Crud_For_Customer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo_Crud_For_Customer.Context
{
    public class CustomerContext : DbContext
    {
        protected readonly IConfiguration _Configuration;

        public CustomerContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            // var connection = new NpgsqlConnection(_Configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
            options.UseNpgsql(
                    _Configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
        }
        public DbSet<Customer> customers { get; set; }
    }
}
