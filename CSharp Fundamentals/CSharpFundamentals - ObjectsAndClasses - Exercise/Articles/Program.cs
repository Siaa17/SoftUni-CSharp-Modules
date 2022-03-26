using System;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string title = articleData[0];
            string content = articleData[1];
            string author = articleData[2];

            Article artcle = new Article();

            artcle.Title = title;
            artcle.Content = content;
            artcle.Author = author;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandParts[0];
                string argument = commandParts[1];

                if (command == "Edit")
                {
                    artcle.Edit(argument);
                }
                else if (command == "ChangeAuthor")
                {
                    artcle.ChangeAuthor(argument);
                }
                else if (command == "Rename")
                {
                    artcle.Rename(argument);
                }
            }

            Console.WriteLine(artcle);
        }
    }

    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
