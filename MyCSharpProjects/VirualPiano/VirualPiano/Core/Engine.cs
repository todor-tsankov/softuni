using System;
using System.Text;
using System.Collections.Generic;

using VirualPiano.Enumerations;
using VirualPiano.Core.Contracts;

namespace VirualPiano.Core
{
    public class Engine : IEngine
    {
        private const int SoundDurationMilliseconds = 100;
        
        private readonly IDictionary<ConsoleKey, Note> keys;

        public Engine(IDictionary<ConsoleKey, Note> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException($"Input dictionary cannot be null!");
            }

            this.keys = keys;
        }
        public void Run()
        {
            PrintInfoScreen();

            while (true)
            {
                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Escape)
                {
                    break;
                }

                PlaySound(pressedKey);
            }
        }

        private void PrintInfoScreen()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   This is a simple virtual piano by toshko, version 1.0");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("              W E   T Y U");
            Console.WriteLine();
            Console.WriteLine("              S D F G H J K");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("    Press escape to exit...");

            Console.ForegroundColor = ConsoleColor.Black;
        }

        private void PlaySound(ConsoleKey pressedKey)
        {
            if (this.keys.ContainsKey(pressedKey))
            {
                var note = this.keys[pressedKey];

                Console.Beep((int)note, SoundDurationMilliseconds);
            }
        }
    }
}
