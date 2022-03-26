using System;
using System.Linq;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pathParts = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string fileWithExtension = pathParts[pathParts.Length - 1];

            int extensionIndex = fileWithExtension.LastIndexOf(".");
             
            string fileName = fileWithExtension.Substring(0, extensionIndex);
            string extension = fileWithExtension.Substring(extensionIndex + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");          
        }
    }
}
