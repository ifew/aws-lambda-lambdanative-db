using System.ComponentModel.DataAnnotations.Schema;

namespace aws_lambda_lambdanative
{
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
