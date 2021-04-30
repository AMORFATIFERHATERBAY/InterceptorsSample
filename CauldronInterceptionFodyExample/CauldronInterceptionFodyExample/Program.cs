using CauldronInterceptionFodyExample.Interceptors;
using System;

namespace CauldronInterceptionFodyExample
{
    [OnPropertySet(nameof(ExecuteMe))]
    public class PropertySetterTestClass
    {
        public int BookId { get; set; }
        public string BookName { get; set; }

        private void ExecuteMe(string propertyName, object newValue) =>
            Console.WriteLine($"The property '{propertyName}' has a new value: '{newValue ?? ""}'");
    }

    [Logger]
    internal class Program
    {
        private static int Add(int a, int b) => a + b;

        private static void Main(string[] args)
        {
            Console.WriteLine(Add(5, 20));

            var sampleClass = new PropertySetterTestClass
            {
                BookName = "50 shades of C#",
                BookId = 23432
            };

            Console.ReadLine();
        }
    }
}