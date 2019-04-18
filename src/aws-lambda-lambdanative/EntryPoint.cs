using aws_lambda_lambdanative;
using Amazon.Lambda.APIGatewayEvents;

namespace LambdaNative
{
    public static class EntryPoint
    {
        public static void Main()
        {
            LambdaNative.Run<Function, string, APIGatewayProxyResponse>();
        }
    }
}
