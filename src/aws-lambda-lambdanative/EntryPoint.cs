using System;
using aws_lambda_lambdanative;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LambdaNative
{
    public static class EntryPoint
    {
        public static void Main(String[] args)
        {
            //System.Console.WriteLine(AppDomain.CurrentDomain.GetAssemblies());
            //GetAssemblies();
            LambdaNative.Run<Function, string, Task<List<DistrictModel>>>();
        }
    }
}
