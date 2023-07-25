using System;
using System.Collections.Generic;

namespace P07SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vipGuests = new HashSet<string>();
            var normalGuests = new HashSet<string>();

            ReadReservations(vipGuests, normalGuests);
            ComingGuests(vipGuests, normalGuests);

            PrintGuestWhoDidntCame(vipGuests, normalGuests);
        }

        private static void PrintGuestWhoDidntCame(HashSet<string> vipGuests, HashSet<string> normalGuests)
        {
            var count = vipGuests.Count + normalGuests.Count;

            Console.WriteLine(count);

            foreach (var vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }

            foreach (var guest in normalGuests)
            {
                Console.WriteLine(guest);
            }
        }

        private static void ComingGuests(HashSet<string> vipGuests, HashSet<string> normalGuests)
        {
            while (true)
            {
                var comingGuest = Console.ReadLine();

                if (comingGuest == "END")
                {
                    break;
                }

                if (char.IsDigit(comingGuest[0]))
                {
                    vipGuests.Remove(comingGuest);
                }
                else
                {
                    normalGuests.Remove(comingGuest);
                }
            }
        }

        private static void ReadReservations(HashSet<string> vipGuests, HashSet<string> normalGuests)
        {
            while (true)
            {
                var guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    normalGuests.Add(guest);
                }
            }
        }
    }
}
