using System.Drawing;

namespace ChessGame
{
    public class RockFigure : ChessFigure
    {
        public RockFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base(xLocation, yLocation, colorIsWhiteValue)
        {
            Type = "rock";
        }
        public RockFigure(RockFigure orig) : base(orig)
        {

        }

        //get image
        public override Bitmap GetImage()
        {
            if(Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_rook_w : Properties.Resources._1_rook_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_rock_w : Properties.Resources._2_rock_b;
                return sourceImage;
            }
        }

        //draw image
        public override void Draw(Graphics graphicsObject)
        {
            graphicsObject.DrawImage(GetImage(), new Rectangle(X, Y, WorkWithBoard.TILESIZE, WorkWithBoard.TILESIZE));
        }

        //can move
        public override bool CanMoveTo(int x, int y)
        {
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {
                if ((X == x && Y != y) || (X != x && Y == y))
                {
                    return true;
                }
            }
            return false;
        }

        public override Tile[,] AllVarToMove(Tile[,] cellBoard)
        {
            cellBoard = CommonVar(cellBoard);

            //rigth
            for (int x = X / WorkWithBoard.TILESIZE + 1; x < 8; x++)
            {
                int y = Y / WorkWithBoard.TILESIZE;
                if (cellBoard[x, y].Move == 0 || cellBoard[x, y].Move == 2)
                {
                    if (cellBoard[x, y].Move == 0)
                    {
                        for (;x <= 7; x++)
                        {
                            cellBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        if (x + 1 <= 7)
                        {
                            for (int j = x + 1; j < 8; j++)
                            {
                                cellBoard[j, y].Move = 0;
                                allvar[j, y] = 0;
                            }
                        }
                    }
                    break;
                }
            }
            //left
            for (int x = X / WorkWithBoard.TILESIZE - 1; x >= 0; x--)
            {
                int y = Y / WorkWithBoard.TILESIZE;
                if (cellBoard[x, y].Move == 0 || cellBoard[x, y].Move == 2)
                {
                    if (cellBoard[x, y].Move == 0)
                    {
                        for (; x >= 0; x--)
                        {
                            cellBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = x - 1; j >= 0; j--)
                        {
                            cellBoard[j, y].Move = 0;
                            allvar[j, y] = 0;
                        }
                    }
                    break;
                }
            }
            //down
            for (int y = Y / WorkWithBoard.TILESIZE + 1; y <= 7; y++)
            {
                int x = X / WorkWithBoard.TILESIZE;
                if (cellBoard[x, y].Move == 0 || cellBoard[x, y].Move == 2)
                {
                    if (cellBoard[x, y].Move == 0)
                    {
                        for (; y <= 7; y++)
                        {
                            cellBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = y + 1; j <= 7; j++)
                        {
                            cellBoard[x, j].Move = 0;
                            allvar[x, j] = 0;
                        }
                    }
                    break;
                }
            }
            //up
            for (int y = Y / WorkWithBoard.TILESIZE - 1; y >= 0; y--)
            {
                int x = X / WorkWithBoard.TILESIZE;
                if (cellBoard[x, y].Move == 0 || cellBoard[x, y].Move == 2)
                {
                    if (cellBoard[x, y].Move == 0)
                    {
                        for (; y >= 0; y--)
                        {
                            cellBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = y - 1; j >= 0; j--)
                        {
                            cellBoard[x, j].Move = 0;
                            allvar[x, j] = 0;
                        }
                    }
                    break;
                }
            }

            return cellBoard;
        }
    }
}
