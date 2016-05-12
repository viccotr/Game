using System;
using System.Drawing;

namespace ChessGame
{
    public class BishopFigure : ChessFigure
    {
        public BishopFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base (xLocation,yLocation,colorIsWhiteValue)
        {
            Type = "bishop";
        }
        //create copy of figure
        public BishopFigure(BishopFigure orig) : base(orig)
        {

        }

        //get image of figure
        public override Bitmap GetImage()
        {
            if(Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_bishop_w : Properties.Resources._1_bishop_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_bishop_w : Properties.Resources._2_bishop_b;
                return sourceImage;
            }
        }

        //drawing image
        public override void Draw(Graphics graphicsObject)
        {
            graphicsObject.DrawImage(GetImage(), new Rectangle(X,Y,WorkWithBoard.TILESIZE, WorkWithBoard.TILESIZE));
        }

        //figure can move to
        public override bool CanMoveTo(int x, int y)
        {
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {
                if (Math.Abs(X - x) == Math.Abs(Y - y))
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

            //right and down
            for (int x = X / WorkWithBoard.TILESIZE + 1, y = Y / WorkWithBoard.TILESIZE + 1; x <= 7 && y <= 7; x++, y++)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (int i = x, j = y; i <= 7 && j <= 7; i++, j++)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
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
            //right and up
            for (int x = X / WorkWithBoard.TILESIZE + 1, y = Y / WorkWithBoard.TILESIZE - 1; x < 8 && y >= 0; x++, y--)
            {
                if (tileBoard[x, y].Move == 0 || tileBoard[x, y].Move == 2)
                {
                    if (tileBoard[x, y].Move == 0)
                    {
                        for (int i = x, j = y; i < 8 && j >= 0; i++, j--)
                        {
                            tileBoard[i, j].Move = 0;
                            allvar[i, j] = 0;
                        }
                    }
                    else//2
                    {
                        for (int i = x + 1, j = y - 1; i < 8 && j >= 0; i++, j--)
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
            
            return tileBoard;
        }
    }
}
