using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using LambdaNative;


namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, DistrictModel>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();
        //private ServiceProvider _service;

        // public Function()
        //     : this (Bootstrap.CreateInstance()) {}

        // /// <summary>
        // /// Default constructor that Lambda will invoke.
        // /// </summary>
        // public Function(ServiceProvider service)
        // {
        //     _service = service;
        // }

        public DistrictModel Handle(string name, ILambdaContext context)
        {
            //Services service = _service.GetService<Services>();
            //List<DistrictModel> districts = service.List_district();

            // APIGatewayProxyResponse respond = new APIGatewayProxyResponse {
            //     StatusCode = (int)HttpStatusCode.OK,
            //     Headers = new Dictionary<string, string>
            //     { 
            //         { "Content-Type", "application/json" }, 
            //         { "Access-Control-Allow-Origin", "*" } 
            //     },
            //     Body = "{}" //JsonConvert.SerializeObject(districts)
            // };
            
            return new DistrictModel { 
                    DistrictId = 1,
                    Code = 222,
                    TitleEng = "aaaa",
                    TitleTha = "กกกฟหกหฟก",
                    ProvinceId = 333
                };
        }
    }
}
