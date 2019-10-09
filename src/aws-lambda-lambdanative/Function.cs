using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using LambdaNative;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;


namespace aws_lambda_lambdanative
{
    public class Handler : IHandler<JObject, List<Member>>
    {
        public ILambdaSerializer Serializer => new JsonSerializer();

        public List<Member> Handle(JObject request, ILambdaContext context)
        {
            string unit_id = null;
            string lang = "THA";
            if (request != null) {
                Console.WriteLine("Log: request: " + request.ToString());
            }
            if (request["pathParameters"]["unit_id"] != null)
            {
                unit_id = request["pathParameters"]["unit_id"].ToString();
                Console.WriteLine("Log: Get request.pathParameters - unit_id: " + unit_id);
            }

            if(request["queryStringParameters"]["lang"] != null) {
                lang = request["queryStringParameters"]["lang"].ToString();
                Console.WriteLine("Log: Get request.queryStringParameters - lang: " + lang);
            }

            Console.WriteLine("Log: Start Connection");

            string configDB = Environment.GetEnvironmentVariable("DB_CONNECTION");

            using (var _connection = new MySqlConnection(configDB))
            {
                Console.WriteLine("Log: _connection.ConnectionString: " + _connection.ConnectionString);

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                Console.WriteLine("Log: State: " + _connection.State.ToString());
                Console.WriteLine("Log: DB ServerVersion: " + _connection.ServerVersion);

                using (var cmd = new MySqlCommand("SELECT * FROM test_member", _connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Log: reader.FieldCount: " + reader.FieldCount);
                        List<Member> members = new List<Member>();
                        while (reader.Read())
                        {
                            members.Add(new Member
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                            });
                        }

                        Console.WriteLine("Log: Count: " + members.Count);

                        return members;
                    }
                }

            }
        }
    }

    [Table("test_member")]
    public class Member
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

    }
}
