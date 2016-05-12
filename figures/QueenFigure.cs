using System;
using System.Drawing;

namespace ChessGame
{
    public class QueenFigure : ChessFigure
    {
        public QueenFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base(xLocation, yLocation, colorIsWhiteValue)
        {
            Type = "queen";
        }
        public QueenFigure(QueenFigure orig) : base(orig)
        {

        }
        
        //get image
        public override Bitmap GetImage()
        {
            if(Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_queen_w : Properties.Resources._1_queen_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_queen_w : Properties.Resources._2_queen_b;
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
                if ((X == x && Y != y) || (X != x && Y == y) || (Math.Abs(X - x) == Math.Abs(Y - y)))
                {
                    return true;
                }
            }
            return false;
        }
        
        //all variant of move
        public override Tile[,] AllVarToMove(Tile[,] tileBoard)
        {            
            tileBoard = CommonVar(tileBoard);
             //like bishop
             //rigth and down
            for (int x = X / WorkWithBoard.TILESIZE + 1, y = Y / WorkWithBoard.TILESIZE + 1; x < 8 && y < 8; x++, y++)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; x <= 7 && y <= 7; x++, y++)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int i = x + 1, j = y + 1; i <= 7 && j <= 7; i++, j++)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    break;
                }
            }
            //rigth and up
            for (int x = X / WorkWithBoard.TILESIZE + 1, y = Y / WorkWithBoard.TILESIZE - 1; x < 8 && y >= 0; x++, y--)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; x <= 7 && y >= 0; x++, y--)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int i = x + 1, j = y - 1; i <= 7 && j >= 0; i++, j--)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    break;
                }
            }
            //left and up
            for (int x = X / WorkWithBoard.TILESIZE - 1, y = Y / WorkWithBoard.TILESIZE - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (int i = x, j = y; i >= 0 && j >= 0; i--, j--)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    else//2
                    {
                        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    break;
                }
            }
            //left and down
            for (int x = X / WorkWithBoard.TILESIZE - 1, y = Y / WorkWithBoard.TILESIZE + 1; x >= 0 && y < 8; x--, y++)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (int i = x, j = y; i >= 0 && j < 8; i--, j++)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    else//2
                    {
                        for (int i = x - 1, j = y + 1; i >= 0 && j < 8; i--, j++)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    break;
                }
            }
            //like rock
            //rigth
            for (int x = X / WorkWithBoard.TILESIZE + 1; x < 8; x++)
            {
                int y = Y / WorkWithBoard.TILESIZE;
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; x <= 7; x++)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        if (x + 1 <= 7)
                        {
                            for (int j = x + 1; j < 8; j++)
                            {
                                tileBoard[j, y].Move = 0;
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
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; x >= 0; x--)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = x - 1; j >= 0; j--)
                        {
                            tileBoard[j, y].Move = 0;
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
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; y <= 7; y++)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = y + 1; j <= 7; j++)
                        {
                            tileBoard[x, j].Move = 0;
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
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (; y >= 0; y--)
                        {
                            tileBoard[x, y].Move = 0;
                            allvar[x, y] = 0;
                        }
                    }
                    else//2
                    {
                        for (int j = y - 1; j >= 0; j--)
                        {
                            tileBoard[x, j].Move = 0;
                            allvar[x, j] = 0;
                        }
                    }
                    break;
                }
            }
            
            return tileBoard;
        }
    }
}
