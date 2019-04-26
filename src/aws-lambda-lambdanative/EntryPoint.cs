using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using aws_lambda_lambdanative;

namespace LambdaNative
{
    public static class EntryPoint
    {
        public static void Main()
        {
            LambdaNative.Run<Function, string, Task<List<DistrictModel>>>();
        }
    }
}
