using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    class Articles
    {
        static void Main(string[] args)
        {
            List<Article> listArticles = new List<Article>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                listArticles.Add(new Article(input));
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                listArticles = listArticles.OrderBy(i => i.Title).ToList();
            }
            else if (criteria == "content")
            {
                listArticles = listArticles.OrderBy(i => i.Content).ToList();
            }
            else if (criteria == "author")
            {
                listArticles = listArticles.OrderBy(i => i.Author).ToList();
            }

            foreach (var item in listArticles)
            {
                item.ToString();
            }
        }
    }

    class Article
    {
        public Article(string input)
        {
            string[] inputParts = input.Split(", ");  // has to be ", "
            Title = inputParts[0];
            Content = inputParts[1];
            Author = inputParts[2];
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void ToString()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }
}
