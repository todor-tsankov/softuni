using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGame
{
    class PlayerArea
    {
        public PlayerArea()
        {
            PlayerAndArea = "W";
        }
        public string PlayerAndArea { get; set; }

        public void MoveLeft()
        {
            if (PlayerAndArea[0] != 'W')
            {
                
                PlayerAndArea = PlayerAndArea.Substring(1, PlayerAndArea.Length - 1);
            }
        }

        public void MoveRight()
        {
            PlayerAndArea = " " + PlayerAndArea;
        }
    }
}
