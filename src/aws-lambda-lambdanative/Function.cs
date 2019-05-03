using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using LambdaNative;
using MySql.Data.MySqlClient;

namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, List<DistrictModel>>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();

        public List<DistrictModel> Handle(string name, ILambdaContext context)
        {
            List<DistrictModel> districts = new List<DistrictModel>();

            string configDB = Environment.GetEnvironmentVariable("DB_CONNECTION");
            using (var _connection = new MySqlConnection(configDB)) {
                _connection.Open();

                using (var cmd = new MySqlCommand("SELECT * FROM district", _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        districts.Add(new DistrictModel()
                        {
                            District_Id = Convert.ToInt32(reader["district_id"]),
                            Code = Convert.ToInt32(reader["code"]),
                            Title_Tha = reader["title_tha"].ToString(),
                            Title_Eng = reader["title_eng"].ToString(),
                            Province_Id = Convert.ToInt32(reader["province_id"]),
                        });
                    }
                }
            }

            return districts;
        }
    }
}
