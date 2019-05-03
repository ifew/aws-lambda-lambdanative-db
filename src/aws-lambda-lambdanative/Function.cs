using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using LambdaNative;
using MySql.Data.MySqlClient;

namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, List<Member>>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();

        public List<DistrictModel> Handle(string name, ILambdaContext context)
        {
            List<Member> members = new List<Member>();

            string configDB = Environment.GetEnvironmentVariable("DB_CONNECTION");
            using (var _connection = new MySqlConnection(configDB)) {
                _connection.Open();

                using (var cmd = new MySqlCommand("SELECT * FROM member", _connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Firstname = Convert.ToInt32(reader["firstname"]),
                            Lastname = reader["lastname"].ToString(),
                        });
                    }
                }
            }

            return members;
        }
    }
}
