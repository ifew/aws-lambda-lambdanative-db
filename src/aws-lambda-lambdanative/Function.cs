using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using LambdaNative;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, APIGatewayProxyResponse>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();
        private ServiceProvider _service;

        // public Function()
        //     : this (Bootstrap.CreateInstance()) {}

        // /// <summary>
        // /// Default constructor that Lambda will invoke.
        // /// </summary>
        // public Function(ServiceProvider service)
        // {
        //     _service = service;
        // }

        public APIGatewayProxyResponse Handle(string name, ILambdaContext context)
        {
            //Services service = _service.GetService<Services>();
            //List<DistrictModel> districts = service.List_district();

            APIGatewayProxyResponse respond = new APIGatewayProxyResponse {
                StatusCode = (int)HttpStatusCode.OK,
                Headers = new Dictionary<string, string>
                { 
                    { "Content-Type", "application/json" }, 
                    { "Access-Control-Allow-Origin", "*" } 
                },
                Body = "{}" //JsonConvert.SerializeObject(districts)
            };

            return respond;
        }
    }
}
