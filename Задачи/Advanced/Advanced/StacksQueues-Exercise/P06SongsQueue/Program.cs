using System;
using System.Collections.Generic;
using System.Linq;

namespace P06SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputSongs = Console.ReadLine()
                                    .Split(", ");

            var songsQueue = new Queue<string>(inputSongs);

            while (songsQueue.Any())
            {
                var cmdArgs = Console.ReadLine()
                                     .Split();

                var cmdType = cmdArgs[0];

                if (cmdType == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (cmdType == "Add")
                {
                    var song = string.Join(" ", cmdArgs[1..cmdArgs.Length]);

                    if (!songsQueue.Contains(song))
                    {
                        songsQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    
                }
                else if (cmdType == "Show")
                {
                    var songsLeft = string.Join(", ", songsQueue);

                    Console.WriteLine(songsLeft);
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
