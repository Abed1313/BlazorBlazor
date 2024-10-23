using BlazorApp3.Shared;
using LazurdIT.FluentOrm.MsSql;
using System.Data.SqlClient;

namespace BlazorApp3.Server
{
    public class MovieContext : MsSqlFluentRepository<Movie>
    {
        public MovieContext(string connectionString) : base(new SqlConnection(connectionString)) { }
    }
    
}
