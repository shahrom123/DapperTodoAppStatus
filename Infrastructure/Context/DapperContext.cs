using Npgsql;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Context
{

    public class DapperContext
    {
        private IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
