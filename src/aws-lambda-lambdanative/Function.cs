using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using LambdaNative;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, List<Member>>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();

        public List<Member> Handle(string name, ILambdaContext context)
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
                            Firstname =reader["firstname"].ToString(),
                            Lastname = reader["lastname"].ToString(),
                        });
                    }
                }
            }

            return members;
        }
    }

    [Table("member")]
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
