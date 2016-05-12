namespace ChessGame
{
    public static class Players
    {
        private static byte indTilePlayer = 1;//type of tile image
        private static byte indFigImPlayer = 1;//type of figure image

        private static bool checkUnderAttack = false;
        private static bool varOfMove = true;
        
        public static byte IndTilePlayer
        {
            get
            {
                return indTilePlayer;
            }
            set
            {
                if(value == 1 || value == 0)
                {
                    indTilePlayer = value;
                }
                else
                {
                    indTilePlayer = 1;
                }
            }
        }
        public static byte IndFigImPlayer
        {
            get
            {
                return indFigImPlayer;
            }
            set
            {
                if (value == 1 || value == 0)
                {
                    indFigImPlayer = value;
                }
                else
                {
                    indFigImPlayer = 1;
                }
            }
        }
        public static bool CheckUnderAttack
        {
            get
            {
                return checkUnderAttack;
            }
            set
            {
                checkUnderAttack = value;
            }
        }
        public static bool VarOfMove
        {
            get
            {
                return varOfMove;
            }
            set
            {
                varOfMove = value;
            }
        }
        public static string Message { get; set; }
        public static byte TransformTo { get; set; }        
    }
}
