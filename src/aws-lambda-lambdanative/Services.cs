using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace aws_lambda_lambdanative
{
    public class Services : IServices
    {
        private readonly IConfiguration _config;

        public Services(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(LambdaConfiguration.Instance["DB_CONNECTION"]));
            }
        }

        public async Task<List<DistrictModel>> ListDistrict()
        {
            using (IDbConnection _connection = Connection)
            {
                string sqlQuery = "SELECT * FROM district";

                _connection.Open();
                var result = await _connection.QueryAsync<DistrictModel>(sqlQuery);

                return result.ToList();
            }
        }
    }

}
