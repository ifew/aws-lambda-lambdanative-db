using System.ComponentModel.DataAnnotations.Schema;

namespace aws_lambda_lambdanative
{
    [Table("district")]
    public class DistrictModel
    {
        [Column("district_id")]
        public int District_Id { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("title_tha")]
        public string Title_Tha { get; set; }

        [Column("title_eng")]
        public string Title_Eng { get; set; }

        [Column("province_id")]
        public int Province_Id { get; set; }

    }

}
