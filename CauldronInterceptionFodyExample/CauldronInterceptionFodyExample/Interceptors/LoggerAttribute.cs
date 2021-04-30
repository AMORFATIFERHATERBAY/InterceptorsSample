using Cauldron.Interception;
using System;
using System.IO;
using System.Reflection;

namespace CauldronInterceptionFodyExample.Interceptors
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class LoggerAttribute : Attribute, IMethodInterceptor
    {
        private string methodName;


        public void OnEnter(Type declaringType, object instance, MethodBase methodbase, object[] values)
        {
            this.methodName = methodbase.Name;
            this.AppendToFile($"Enter -> {declaringType.Name} {methodbase.Name} {string.Join(" ", values)}");
        }

        public void OnException(Exception e) => this.AppendToFile($"Exception -> {e.Message}");

        public void OnExit() => this.AppendToFile($"Exit -> {this.methodName}");

        private void AppendToFile(string line)
        {
            File.AppendAllLines("log.txt", new string[] { line });
            Console.WriteLine(">> " + line);
        }
    }
}