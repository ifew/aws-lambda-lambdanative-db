using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using aws_lambda_lambdanative;

namespace LambdaNative
{
    public static class EntryPoint
    {
        public static void Main()
        {
            LambdaNative.Run<Handler, JObject, List<Member>>();
        }
    }
}
