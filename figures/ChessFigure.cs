using System.Drawing;

namespace ChessGame
{
    public abstract class ChessFigure
    {
        //coordinate
        private Point figureCoordinats = new Point();
        
        //figure color
        public bool ColorIsWhite { get; set; }

        //first move of figure
        public bool FirstMove { get; set; }

        //type of figure
        public string Type { get; set; }
                
        public int X
        {
            get
            {
                return figureCoordinats.X;
            }
            set
            {
                if(value >= 0 && value <= WorkWithBoard.TILESIZE * 7)
                {
                    figureCoordinats.X = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return figureCoordinats.Y;
            }
            set
            {
                if(value >= 0 && value <=  7 * WorkWithBoard.TILESIZE)
                {
                    figureCoordinats.Y = value;
                }
            }
        }

        //all variant of move 
        public byte[,] allvar = new byte[8, 8];
        
        public ChessFigure(int xLocation, int yLocation, bool colorIsWhiteValue)
        {
            X = xLocation;
            Y = yLocation;
            ColorIsWhite = colorIsWhiteValue;
            FirstMove = true;
        }

        //make copy of figure
        public ChessFigure(ChessFigure orig)
        {
            X = orig.X;
            Y = orig.Y;
            ColorIsWhite = orig.ColorIsWhite;
            Type = orig.Type;
            FirstMove = true;
        }
        
        //get image of figure
        abstract public Bitmap GetImage();

        //figure can move to ...
        abstract public bool CanMoveTo(int x, int y);

        //all variants of move
        abstract public Tile[,] AllVarToMove(Tile[,] cellBoard);

        //draw image of figure
        abstract public void Draw(Graphics graphicsObject);

        //move to coordinats
        public virtual void MoveTo(int x, int y)
        {
            if(FirstMove)
                FirstMove = false;
            
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {   
                X = x;
                Y = y;                
            }
        }

        //common variant of move
        public Tile[,] CommonVar(Tile[,] cellBoard)
        {
            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    if (CanMoveTo(x * WorkWithBoard.TILESIZE, y * WorkWithBoard.TILESIZE))
                    {
                        if (cellBoard[x, y].FigureOnTile != null)
                        {
                            if (cellBoard[x, y].FigureOnTile.ColorIsWhite == ColorIsWhite)
                            {
                                cellBoard[x, y].Move = 0;
                                allvar[x, y] = 0;
                            }
                            else
                            {
                                cellBoard[x, y].Move = 2;
                                allvar[x, y] = 2;
                            }
                        }
                        else
                        {
                            cellBoard[x, y].Move = 1;
                            allvar[x, y] = 1;
                        }
                    }
                    else
                    {
                        cellBoard[x, y].Move = 0;
                        allvar[x, y] = 0;
                    }
                }
            }
            return cellBoard;
        }
    }
}
