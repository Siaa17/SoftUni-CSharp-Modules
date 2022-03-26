using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> outputMessages = new List<string>();

            string input = string.Empty;
           
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> chatLogger = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = chatLogger[0];
                
                if (command == "Chat")
                {
                    string message = chatLogger[1];

                    outputMessages.Add(message);
                }
                else if (command == "Delete")
                {
                    string messageToDelete = outputMessages[1];

                    if (outputMessages.Contains(messageToDelete))
                    {
                        outputMessages.Remove(messageToDelete);
                    }
                }
                else if (command == "Edit")
                {
                    string messageToEdit = chatLogger[1];
                    string editedVersion = chatLogger[2];

                    //int index1 = chatLogger.IndexOf(messageToEdit);

                    //outputMessages.Insert(index1, editedVersion);
                    outputMessages.Remove(messageToEdit);
                    //outputMessages.Remove(editedVersion);
                    outputMessages.Add(editedVersion);
                }
                else if (command == "Pin")
                {
                    string messageToPin = chatLogger[1];

                    outputMessages.Remove(messageToPin);
                    outputMessages.Add(messageToPin);
                }
                else if (command == "Spam")
                {
                    for (int i = 1; i <= chatLogger.Count - 1; i++)
                    {
                        outputMessages.Add(chatLogger[i]);
                    }                   
                }
            }

            Console.Write(string.Join(Environment.NewLine, outputMessages));

            Console.WriteLine();
        }
    }
}
