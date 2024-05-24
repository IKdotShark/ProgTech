using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Archiver
{
    class Program
    {
        private static bool stopRequested = false;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Pack");
            Console.WriteLine("2. UnPack");
            Console.WriteLine("3. Stop");
            
            var choice = Console.ReadLine();

            Console.Write("Enter input file path: ");
            string inputFilePath = Console.ReadLine();
            Console.Write("Enter output file path: ");
            string outputFilePath = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await Pack(inputFilePath, outputFilePath);
                    break;
                case "2":
                    await UnPack(inputFilePath, outputFilePath);
                    break;
                case "3":
                    stopRequested = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private static async Task Pack(string inputFile, string outputFile)
        {
            try
            {
                var input = await File.ReadAllTextAsync(inputFile);
                var output = new StringBuilder();

                for (int i = 0; i < input.Length;)
                {
                    if (stopRequested)
                        break;

                    int count = 1;
                    char currentChar = input[i];

                    while (i + count < input.Length && input[i + count] == currentChar)
                    {
                        count++;
                    }

                    if (count > 1)
                    {
                        output.Append(count).Append(currentChar);
                        i += count;
                    }
                    else
                    {
                        int start = i;
                        while (i < input.Length && (i == start || input[i] != input[i - 1]))
                        {
                            i++;
                        }

                        output.Append('0').Append(i - start);
                        output.Append(input.Substring(start, i - start));
                    }

                    int progress = (int)((double)i / input.Length * 100);
                    Console.WriteLine($"Progress: {progress}%");
                }

                await File.WriteAllTextAsync(outputFile, output.ToString());
                Console.WriteLine("Compression completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task UnPack(string inputFile, string outputFile)
        {
            try
            {
                var input = await File.ReadAllTextAsync(inputFile);
                var output = new StringBuilder();

                for (int i = 0; i < input.Length;)
                {
                    if (stopRequested)
                        break;

                    if (char.IsDigit(input[i]) && input[i] != '0')
                    {
                        int count = int.Parse(input[i].ToString());
                        char currentChar = input[i + 1];
                        output.Append(new string(currentChar, count));
                        i += 2;
                    }
                    else if (input[i] == '0')
                    {
                        int count = int.Parse(input[i + 1].ToString());
                        output.Append(input.Substring(i + 2, count));
                        i += 2 + count;
                    }

                    int progress = (int)((double)i / input.Length * 100);
                    Console.WriteLine($"Progress: {progress}%");
                }

                await File.WriteAllTextAsync(outputFile, output.ToString());
                Console.WriteLine("Decompression completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
