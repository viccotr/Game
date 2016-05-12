using System.Drawing;

namespace ChessGame
{
    public class PawnFigure : ChessFigure
    {
        public PawnFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base(xLocation, yLocation, colorIsWhiteValue)
        {
            Type = "pawn";
        }
        public PawnFigure(PawnFigure orig) : base(orig)
        {

        }

        //get image of figure
        public override Bitmap GetImage()
        {
            if(Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_pawn_w : Properties.Resources._1_pawn_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_pawn_w : Properties.Resources._2_pawn_b;
                return sourceImage;
            }
        }

        //draw image
        public override void Draw(Graphics graphicsObject)
        {
            graphicsObject.DrawImage(GetImage(), new Rectangle(X, Y, WorkWithBoard.TILESIZE, WorkWithBoard.TILESIZE));
        }

        //can move to
        public override bool CanMoveTo(int x, int y)
        {
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {
                if (ColorIsWhite)
                {
                    if (FirstMove)
                    {
                        if (((y / WorkWithBoard.TILESIZE - Y / WorkWithBoard.TILESIZE == 1) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE)) |
                            ((y / WorkWithBoard.TILESIZE - Y / WorkWithBoard.TILESIZE == 2) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE)))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if ((y / WorkWithBoard.TILESIZE - Y / WorkWithBoard.TILESIZE == 1) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (FirstMove)
                    {
                        if (((Y / WorkWithBoard.TILESIZE - y / WorkWithBoard.TILESIZE == 1) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE)) |
                            ((Y / WorkWithBoard.TILESIZE - y / WorkWithBoard.TILESIZE == 2) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE)))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if ((Y / WorkWithBoard.TILESIZE - y / WorkWithBoard.TILESIZE == 1) && (x / WorkWithBoard.TILESIZE == X / WorkWithBoard.TILESIZE))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //all variant of move
        public override Tile[,] AllVarToMove(Tile[,] cellBoard)
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
            }//общая часть

            if (ColorIsWhite)
            {                
                //En passant
                if (Y == 4 * WorkWithBoard.TILESIZE)
                {
                    if (X / WorkWithBoard.TILESIZE + 1 <= 7)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1].Move = 7;
                        allvar[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1] = 7;
                    }
                    if (X / WorkWithBoard.TILESIZE - 1 >= 0)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1].Move = 7;
                        allvar[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1] = 7;
                    }
                }

                if (X / WorkWithBoard.TILESIZE + 1 < 8 && Y / WorkWithBoard.TILESIZE + 1 < 8)//white firth right side
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1].FigureOnTile != null)
                    {
                        if (cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1].FigureOnTile.ColorIsWhite != ColorIsWhite)
                        {
                            cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1].Move = 2;
                            allvar[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE + 1] = 2;
                        }
                    }
                }
                if (X / WorkWithBoard.TILESIZE - 1 >= 0 && Y / WorkWithBoard.TILESIZE + 1 < 8)//white firth left side
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1].FigureOnTile != null)
                    {
                        if (cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1].FigureOnTile.ColorIsWhite != ColorIsWhite)
                        {
                            cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1].Move = 2;
                            allvar[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE + 1] = 2;
                        }
                    }
                }
                if (Y / WorkWithBoard.TILESIZE + 1 < 8)
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 1].FigureOnTile != null)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 1].Move = 0;
                        allvar[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 1] = 0;
                    }
                }
                
                if (Y / WorkWithBoard.TILESIZE + 2 < 8)
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 2].FigureOnTile != null)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 2].Move = 0;
                        allvar[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE + 2] = 0;
                    }
                }
            }
            else//black
            {
                //En passant 
                if (Y == 3 * WorkWithBoard.TILESIZE)
                {
                    if (X / WorkWithBoard.TILESIZE + 1 <= 7)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1].Move = 7;
                        allvar[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1] = 7;
                    }
                    if (X / WorkWithBoard.TILESIZE - 1 >= 0)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1].Move = 7;
                        allvar[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1] = 7;
                    }
                }

                if (X / WorkWithBoard.TILESIZE + 1 < 8 && Y / WorkWithBoard.TILESIZE - 1 >= 0)//black firth right side
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1].FigureOnTile != null)
                    {
                        if (cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1].FigureOnTile.ColorIsWhite != ColorIsWhite)
                        {
                            cellBoard[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1].Move = 2;
                            allvar[X / WorkWithBoard.TILESIZE + 1, Y / WorkWithBoard.TILESIZE - 1] = 2;
                        }
                    }
                }
                if (X / WorkWithBoard.TILESIZE - 1 >= 0 && Y / WorkWithBoard.TILESIZE - 1 >= 0)//black firth left side
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1].FigureOnTile != null)
                    {
                        if (cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1].FigureOnTile.ColorIsWhite != ColorIsWhite)
                        {
                            cellBoard[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1].Move = 2;
                            allvar[X / WorkWithBoard.TILESIZE - 1, Y / WorkWithBoard.TILESIZE - 1] = 2;
                        }
                    }
                }
                if (Y / WorkWithBoard.TILESIZE - 1 >= 0)
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 1].FigureOnTile != null)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 1].Move = 0;
                        allvar[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 1] = 0;
                    }
                }
                
                if (Y / WorkWithBoard.TILESIZE - 2 >= 0)
                {
                    if (cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 2].FigureOnTile != null)
                    {
                        cellBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 2].Move = 0;
                        allvar[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE - 2] = 0;
                    }
                }
            }
            return cellBoard;
        }

        public override void MoveTo(int x, int y)
        {
            if (FirstMove)
            {
                FirstMove = false;
            }
            
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {
                X = x;
                Y = y;
            }
        }
    }
}
