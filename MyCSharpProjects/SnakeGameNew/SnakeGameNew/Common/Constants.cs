namespace SnakeGame.Common
{
    public static  class Constants
    {
        public const int MillisecondsWaitTime = 500;
        public const int MillisecondsBonusWaitTime = 10000;

        public const int SnakeInitialRow = 5;
        public const int SnakeInitialCol = 10;

        public const int PlayableRowsCount = 10;
        public const int PlayableColsCount = 20;

        public const int MinRowIndex = 1;
        public const int MinColIndex = 1;

        public const int MaxRowIndex = PlayableRowsCount;
        public const int MaxColIndex = PlayableColsCount;


        public const char FieldInsideChar = ' ';
        public const char FieldSidesChar = '|';
        public const char FieldEdgesChar = '+';
        public const char FieldFloorsChar = '-';

        public const char SnakeChar = 'o';
        public const char PointChar = '*';
        public const char BonusChar = '$';

        public const string HighscoreFilePath = "highscore.txt";
        public const string DateFormat = "dd/MM/yyyy";
    }
}
