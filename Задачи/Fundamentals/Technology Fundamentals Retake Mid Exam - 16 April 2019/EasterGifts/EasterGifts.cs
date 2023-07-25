using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGifts
{
    class EasterGifts
    {
        static void Main(string[] args)
        {
            string[] giftList = Console.ReadLine().Split();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];
                string gift = commandParts[1];

                if (operation == "OutOfStock")
                {
                    OutOfStock(giftList, gift);
                }
                else if (operation == "Required")
                {
                    int index = int.Parse(commandParts[2]);
                    Required(giftList, gift, index);
                }
                else if (operation == "JustInCase")
                {
                    JustInCase(giftList, gift);
                }
            }

            foreach (var item in giftList)
            {
                if (item != "None")
                {
                    Console.Write(item + " ");
                }
            }

            Console.WriteLine();
        }

        static void OutOfStock(string[] giftList, string gift)
        {
            for (int i = 0; i < giftList.Length; i++)
            {
                if (giftList[i] == gift)
                {
                    giftList[i] = "None";
                }
            }
        }

        static void Required(string[] giftList, string gift, int index)
        {
            if (index >= 0 && index < giftList.Length)
            {
                giftList[index] = gift;
            }
        }

        static void JustInCase(string[] giftList, string gift)
        {
            giftList[giftList.Length - 1] = gift;
        }
    }
}
