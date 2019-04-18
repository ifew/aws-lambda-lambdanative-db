
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aws_lambda_lambdanative
{
    public class respondModel {
    public string http_code { get; set; }
    public string http_message { get; set; }
    public object body { get; set; }
}

    public class HelloModel {
        public string message { get; set; }
    }


    [Table("profiles")]
    public class ProfileModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("lang")]
        public string Language { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("about_us")]
        public string AboutUs { get; set; }

        [Column("add_datetime")]
        public DateTime AddDatetime { get; set; }

    }

}
