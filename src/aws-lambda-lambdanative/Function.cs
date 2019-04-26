using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using LambdaNative;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, Task<List<DistrictModel>>>
    {

        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();

        public async Task<List<DistrictModel>> Handle(string empty, ILambdaContext context)
        {
            using (MySqlConnection _connection = new MySqlConnection(LambdaConfiguration.Instance["DB_CONNECTION"].ToString()))  
            {  
                if (_connection.State == ConnectionState.Closed)  
                    _connection.Open();  
  
                string sqlQuery = "SELECT * FROM district";
                var result = await _connection.QueryAsync<DistrictModel>(sqlQuery);

                return result.ToList();  
            } 
        }
    }
}
