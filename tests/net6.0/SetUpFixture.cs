using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Avalara.AvaTax.RestClient;
using NUnit.Framework;

namespace Avalara.AvaTax.RestClient.Test.net60
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"Hosting Framework Runtime Version: {GetRuntimeFrameworkVersion(GetType().Assembly)}")
                .AppendLine($"Hosting Framework Version: {GetFrameworkVersion(GetType().Assembly)}")
                .AppendLine($"Target Framework Runtime Version: {GetRuntimeFrameworkVersion(typeof(AvaTaxClient).Assembly)}")
                .AppendLine($"Target Framework Version: {GetFrameworkVersion(typeof(AvaTaxClient).Assembly)}");

            TestContext.Progress.WriteLine(stringBuilder);
        }
        
        private static string GetRuntimeFrameworkVersion(Assembly assembly)
        {
            var imageRuntimeVersion = assembly
                .ImageRuntimeVersion;

            return imageRuntimeVersion;
        }

		private static string GetFrameworkVersion(Assembly assembly)  
        {
           var targetFrameAttribute = assembly.GetCustomAttributes(true)
              .OfType<TargetFrameworkAttribute>().FirstOrDefault();
           if (targetFrameAttribute == null)
           {
              return ".NET 2, 3 or 3.5";
           }

           return targetFrameAttribute.FrameworkName;
       }
    }
}
