using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aws_lambda_lambdanative
{
    public interface IServices
    {
        Task<List<DistrictModel>> ListDistrict();
    }

}
