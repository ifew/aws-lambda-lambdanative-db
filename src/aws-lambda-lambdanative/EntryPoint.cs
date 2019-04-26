using System;
using System.Security.Policy;
using System.Reflection;
using aws_lambda_lambdanative;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LambdaNative
{
    public static class EntryPoint
    {
        public static void Main(String[] args)
        {
            LambdaNative.Run<Function, string, Task<List<DistrictModel>>>();
        }
    }
}
