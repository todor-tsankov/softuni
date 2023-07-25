using System;
using System.Collections.Generic;

namespace P05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            CheckNumberOfAppearancesOfSymbolsInText(text, symbols);
            Print(symbols);
        }

        private static void Print(SortedDictionary<char, int> symbols)
        {
            foreach (var (symbol, times) in symbols)
            {
                Console.WriteLine($"{symbol}: {times} time/s");
            }
        }

        private static void CheckNumberOfAppearancesOfSymbolsInText(string text, SortedDictionary<char, int> symbols)
        {
            foreach (var symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = 0;
                }

                symbols[symbol]++;
            }
        }
    }
}
