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
            Article article = new Article(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string operation = command[0];
                string input = command[1];

                if (operation == "Edit")
                {
                    article.Edit(input);
                }
                else if (operation == "ChangeAuthor")
                {
                    article.ChangeAuthor(input);
                }
                else if (operation == "Rename")
                {
                    article.Rename(input);
                }
            }

            article.ToString();
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

        public void ToString()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }
}
