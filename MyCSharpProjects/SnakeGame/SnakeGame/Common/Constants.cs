namespace SnakeGame.Common
{
    public static class Constants
    {
        public const int MILLISECONDS_WAIT = 500;

        public const int SNAKE_INITIAL_ROW = 5;
        public const int SNAKE_INITIAL_COL = 10;
        
        public const int PLAYABLE_ROWS_COUNT = 10;
        public const int PLAYABLE_COLS_COUNT = 20;

        public const int MIN_ROW_INDEX = 1;
        public const int MIN_COL_INDEX = 1;

        public const int MAX_ROW_INDEX = PLAYABLE_ROWS_COUNT;
        public const int MAX_COL_INDEX = PLAYABLE_COLS_COUNT;


        public const char DEFAULT_INSIDE_CHAR = ' ';
        public const char DEFAULT_SIDES_CHAR = '|';
        public const char DEFAULT_EDGE_CHAR = '+';
        public const char DEFAULT_FLOORS_CHAR = '-';

        public const char SNAKE_CHAR = 'o';
        public const char POINT_CHAR = '*';

        public const string HIGHSCORE_FILE_PATH = "highscore.txt";
    }
}
