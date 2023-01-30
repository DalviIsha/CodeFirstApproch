using Dapper;
using Demo_Crud_For_Customer.Entity;
using Npgsql;

namespace Demo_Crud_For_Customer.Repository
{
    public class CustomerRepo : ICustomer
    {
        private readonly IConfiguration _configuration;

        public CustomerRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            var connection = new NpgsqlConnection(_configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
            var custmer = await connection.ExecuteAsync("INSERT INTO customer (fisrtname, lastname, isactive) VALUES (@FisrtName, @LastName, @IsActive)", new { fisrtname = customer.FirstName, LastName = customer.LastName, IsActive = customer.IsActive});
            if (custmer > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var connection = new NpgsqlConnection(_configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
            var custmer = await connection.ExecuteAsync("DELETE FROM customer WHERE ID = @Id", new  { Id = id});
            if (custmer > 0)
                return true;
            return false;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var connection = new NpgsqlConnection(_configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
            var customerDetails = await connection.QueryFirstOrDefaultAsync<Customer>("SELECT * FROM customer WHERE Id = @Id", new { Id = id });
            if (customerDetails == null)
                return new Customer();
            return customerDetails;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var connection = new NpgsqlConnection(_configuration.GetValue<string>("DataBaseSetting:ConnetionString"));
            var custmer = await connection.ExecuteAsync("UPDATE SET customer fisrtname = @FirstName, lastname = @LastName, isactive = @IsActive WHERE Id = @Id"
            , customer);
            if (custmer > 0)
                return true;
            return false;
        }
    }
}
