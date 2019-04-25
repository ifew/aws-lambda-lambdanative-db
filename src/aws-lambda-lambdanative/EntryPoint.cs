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
            //System.Console.WriteLine(AppDomain.CurrentDomain.GetAssemblies());
            //GetAssemblies();
            LambdaNative.Run<Function, string, Task<List<DistrictModel>>>();
        }
        
        // public static void GetAssemblies()
        // {
        //     StringBuilder result = new StringBuilder();
        //     result.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?><Directives xmlns=\"http://schemas.microsoft.com/netfx/2013/01/metadata\"><Application>");
            
        //     Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
        //     foreach (Assembly asm in assemblies)
        //     {
        //         AssemblyName asmName = asm.GetName();
        //         string name = asmName.Name;
        //         result.Append("<Assembly Name=\"" + name + "\"></Assembly>\n");
        //     }

        //     result.Append("</Application></Directives>\n");

        //     using (StreamWriter outputFile = new StreamWriter(Path.Combine("./", "rd.xml"), false))
        //     {
        //         outputFile.WriteLine(result);
        //     }
        // }
    }
}
