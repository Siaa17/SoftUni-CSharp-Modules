using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> composerByPiece = new Dictionary<string, string>();
            Dictionary<string, string> keyByPiece = new Dictionary<string, string>();

            int numOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPieces; i++)
            {
                string[] data = Console.ReadLine()
                   .Split("|", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                string piece = data[0];
                string composer = data[1];
                string key = data[2];

                composerByPiece.Add(piece, composer);
                keyByPiece.Add(piece, key);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];
                string piece = commandArgs[1];

                if (command == "Add")
                {
                    string composer = commandArgs[2];
                    string key = commandArgs[3];
                    
                    if (composerByPiece.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        composerByPiece.Add(piece, composer);
                        keyByPiece.Add(piece, key);

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (composerByPiece.ContainsKey(piece))
                    {
                        composerByPiece.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = commandArgs[2];

                    if (keyByPiece.ContainsKey(piece))
                    {
                        keyByPiece[piece] = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            Dictionary<string, string> sorted = composerByPiece
                .OrderBy(p => p.Key)
                .ThenBy(c => c.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                string piece = kvp.Key;
                string composer = kvp.Value;
                string key = keyByPiece[piece];

                Console.WriteLine($"{piece} -> Composer: {composer}, Key: {key}");
            }
        }
    }
}
