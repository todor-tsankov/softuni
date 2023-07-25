using System;
using System.Collections.Generic;
using System.Linq;

namespace P03
{
    class P03
    {
        static void Main(string[] args)
        {
            List<Follower> followers = new List<Follower>();

            string input = Console.ReadLine();

            while (input != "Log out")
            {
                string[] cmdArgs = input.Split(": ");

                string cmdType = cmdArgs[0];
                string username = cmdArgs[1];
                int index = followers.FindIndex(i => i.Username == username);

                if (cmdType == "New follower")
                {
                    if (index < 0)
                    {
                        followers.Add(new Follower(username, 0, 0));
                    }
                }
                else if (cmdType == "Like")
                {
                    int count = int.Parse(cmdArgs[2]);

                    if (index < 0)
                    {
                        followers.Add(new Follower(username, 0, 0));
                        index = followers.FindIndex(i => i.Username == username);
                    }

                    followers[index].LikesCount += count;
                }
                else if (cmdType == "Comment")
                {
                    if (index < 0)
                    {
                        followers.Add(new Follower(username, 0, 1));
                        index = followers.FindIndex(i => i.Username == username);
                    }
                    else
                    {
                        followers[index].CommentsCount++;
                    }
                }
                else if (cmdType == "Blocked")
                {
                    if (index < 0)
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        followers.RemoveAt(index);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");

            var filteredFollowers = followers.OrderByDescending(i => i.LikesCount).ThenBy(i => i.Username);

            foreach (var item in filteredFollowers)
            {
                int likesAndcommentsCount = item.LikesCount + item.CommentsCount;
                Console.WriteLine($"{item.Username}: {likesAndcommentsCount}");
            }
        }
    }

    class Follower
    {
        public Follower(string username, int likes, int comments)
        {
            Username = username;
            LikesCount = likes;
            CommentsCount = comments;
        }
        public string Username { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        
    }
}
