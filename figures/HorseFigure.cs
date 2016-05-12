using System.Drawing;
using System;

namespace ChessGame
{
    public class HorseFigure : ChessFigure
    {
        public HorseFigure(int xLocation, int yLocation, bool colorIsWhiteValue) : base(xLocation, yLocation, colorIsWhiteValue)
        {
            Type = "horse";
        }
        public HorseFigure(HorseFigure orig) : base(orig)
        {

        }

        //get figure image
        public override Bitmap GetImage()
        {
            if(Players.IndFigImPlayer == 0)
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._1_horse_w1 : Properties.Resources._1_horse_b;
                return sourceImage;
            }
            else
            {
                Bitmap sourceImage = ColorIsWhite ? Properties.Resources._2_horse_w : Properties.Resources._2_horse_b;
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
                if ((Math.Abs(X - x) / WorkWithBoard.TILESIZE == 2 && Math.Abs(Y - y) / WorkWithBoard.TILESIZE == 1) ||
                        (Math.Abs(Y - y) / WorkWithBoard.TILESIZE == 2 && Math.Abs(X - x) / WorkWithBoard.TILESIZE == 1))
                {
                    return true;
                }
            }
            return false;
        }

        //all variant of move
        public override Tile[,] AllVarToMove(Tile[,] cellBoard)
        {
            cellBoard = CommonVar(cellBoard);

            return cellBoard;
        }
    }
}