using System;
using System.Collections.Generic;

using VirualPiano.Core;
using VirualPiano.Enumerations;

namespace VirualPiano
{
    public class StartUp
    {
        public static void Main()
        {
            var keyNoteDictionary = CreateDictionary();
            var engine = new Engine(keyNoteDictionary);

            engine.Run();
        }

        public static IDictionary<ConsoleKey, Note> CreateDictionary()
        {
            var keyNoteDictionary = new Dictionary<ConsoleKey, Note> 
            {
                {ConsoleKey.S , Note.C },
                {ConsoleKey.W , Note.CS},
                {ConsoleKey.D , Note.D},
                {ConsoleKey.E , Note.DS},
                {ConsoleKey.F , Note.E},
                {ConsoleKey.G , Note.F},
                {ConsoleKey.T , Note.FS},
                {ConsoleKey.H , Note.G},
                {ConsoleKey.Y , Note.GS},
                {ConsoleKey.J , Note.A},
                {ConsoleKey.U , Note.AS},
                {ConsoleKey.K , Note.B},
            };

            return keyNoteDictionary;
        }
    }
}
