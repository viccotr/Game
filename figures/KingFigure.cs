using System;
using System.Drawing;


namespace ChessGame
{
    public class KingFigure : ChessFigure
    {
        public KingFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base(xLocation, yLocation, colorIsWhiteValue)
        {
            Type = "king";
        }
        public KingFigure(KingFigure orig) : base(orig)
        {

        }

        //get figure image
        public override Bitmap GetImage()
        {
            if (Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_king_w : Properties.Resources._1_king_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_king_w : Properties.Resources._2_king_b;
                return sourceImage;
            }
        }

        //draw image
        public override void Draw(Graphics graphicsObject)
        {
            graphicsObject.DrawImage(GetImage(), new Rectangle(X, Y, WorkWithBoard.TILESIZE, WorkWithBoard.TILESIZE));
        }

        //figure can move to
        public override bool CanMoveTo(int x, int y)
        {
            if ((x >= 0 && x <= 7 * WorkWithBoard.TILESIZE) && (y >= 0 && y <= 7 * WorkWithBoard.TILESIZE))
            {
                if (Math.Abs(X - x) == WorkWithBoard.TILESIZE && Math.Abs(Y - y) == WorkWithBoard.TILESIZE ||
                    Math.Abs(X - x) == 0 && Math.Abs(Y - y) == WorkWithBoard.TILESIZE ||
                    Math.Abs(X - x) == WorkWithBoard.TILESIZE && Math.Abs(Y - y) == 0)
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

            //castle
            if (ColorIsWhite)
            {
                if (FirstMove)
                {
                    //short castle for white
                    if (tileBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE].Move != 2)
                    {
                        if (tileBoard[0, 0].FigureOnTile != null)
                        {
                            if (tileBoard[0, 0].FigureOnTile.FirstMove == true)
                            {
                                if (tileBoard[1, 0].FigureOnTile == null && tileBoard[2, 0].FigureOnTile == null)
                                {
                                    tileBoard[X / WorkWithBoard.TILESIZE - 2, Y / WorkWithBoard.TILESIZE].Move = 3;
                                }
                            }

                        }
                    }
                    //long castle for white
                    if (tileBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE].Move != 2)
                    {
                        if (tileBoard[7, 0].FigureOnTile != null)
                        {
                            if (tileBoard[7, 0].FigureOnTile.FirstMove == true)
                            {
                                if (tileBoard[6, 0].FigureOnTile == null && tileBoard[5, 0].FigureOnTile == null && tileBoard[4, 0].FigureOnTile == null)
                                {
                                    tileBoard[X / WorkWithBoard.TILESIZE + 2, Y / WorkWithBoard.TILESIZE].Move = 4;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                if (FirstMove)
                {
                    //short castle for black
                    if (tileBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE].Move != 2)
                    {
                        if (tileBoard[0, 7].FigureOnTile != null)
                        {
                            if (tileBoard[0, 7].FigureOnTile.FirstMove == true)
                            {
                                if (tileBoard[1, 7].FigureOnTile == null && tileBoard[2, 7].FigureOnTile == null)
                                {
                                    tileBoard[X / WorkWithBoard.TILESIZE - 2, Y / WorkWithBoard.TILESIZE].Move = 5;
                                }
                            }

                        }
                    }
                    //long castle for black
                    if (tileBoard[X / WorkWithBoard.TILESIZE, Y / WorkWithBoard.TILESIZE].Move != 2)
                    {
                        if (tileBoard[7, 7].FigureOnTile != null)
                        {
                            if (tileBoard[7, 7].FigureOnTile.FirstMove == true)
                            {
                                if (tileBoard[6, 7].FigureOnTile == null && tileBoard[5, 7].FigureOnTile == null && tileBoard[4, 7].FigureOnTile == null)
                                {
                                    tileBoard[X / WorkWithBoard.TILESIZE + 2, Y / WorkWithBoard.TILESIZE].Move = 6;
                                }
                            }

                        }
                    }
                }
            }
            return tileBoard;
        }
    }
}