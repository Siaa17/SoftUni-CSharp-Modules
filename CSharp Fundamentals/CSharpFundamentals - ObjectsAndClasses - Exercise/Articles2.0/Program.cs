using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                Article article = new Article()
                {
                    Title = articleData[0],
                    Content = articleData[1],
                    Author = articleData[2]
                };

                articles.Add(article);             
            }

            string sortingCriteria = Console.ReadLine();

            List<Article> sortedArticles = new List<Article>();

            if (sortingCriteria == "title")
            {
                sortedArticles = articles
                    .OrderBy(n => n.Title)
                    .ToList();
            }
            else if (sortingCriteria == "content")
            {
                sortedArticles = articles
                    .OrderBy(n => n.Content)
                    .ToList();
            }
            else if (sortingCriteria == "author")
            {
                 sortedArticles = articles
                    .OrderBy(n => n.Author)
                    .ToList();
            }

            foreach (Article article in sortedArticles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
