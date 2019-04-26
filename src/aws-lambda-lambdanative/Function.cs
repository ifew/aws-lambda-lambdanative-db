using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using LambdaNative;
using Microsoft.Extensions.DependencyInjection;

namespace aws_lambda_lambdanative
{
    public class Function : IHandler<string, Task<List<DistrictModel>>>
    {
        public ILambdaSerializer Serializer => new Amazon.Lambda.Serialization.Json.JsonSerializer();
        private ServiceProvider _service;

        public Function()
            : this (Bootstrap.CreateInstance()) {}

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Function(ServiceProvider service)
        {
            _service = service;
        }

        public async Task<List<DistrictModel>> Handle(string name, ILambdaContext context)
        {
            Services service = _service.GetService<Services>();
            List<DistrictModel> districts = await service.ListDistrict();

            return districts;
        }
    }
}
