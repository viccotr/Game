using System.Drawing;

namespace ChessGame
{
    public class Tile
    {
        //point with coordinates of tile
        private Point tilePoint;
        //color of tile
        private bool ligth;
        //figure on tile
        public ChessFigure FigureOnTile { get; set; }
        //condition to move on this tile
        public int Move { get; set; }
        /*all varints on this tile:
0 - can't move 
1 - can move
2 - figth enemy
3 - short castle for white
4 - long castle for white
5 - short castle for black
6 - long castle for black
7 - белые могут взять на проходе черную фигуру
    */
        //this tile selected by user
        public bool Selected { get; set; }
        //this tile under attack
        public bool UnderAttack { get; set; }
        //on this tile can be "en passant"
        public bool Passant { get; set; }


        //get set X coordinate from point of tile
        public int X
        {
            get
            {
                return tilePoint.X;
            }
            set
            {
                if(value >= 0 && value <= 7 * WorkWithBoard.TILESIZE)
                {
                    tilePoint.X = value;
                }
            }
        }

        //get set Y coordinate from point of tile
        public int Y
        {
            get
            {
                return tilePoint.Y;
            }
            set
            {
                if(value >= 0 && value <= 7 * WorkWithBoard.TILESIZE)
                {
                    tilePoint.Y = value;
                }                
            }
        }

        //create new tile
        public Tile(int x, int y, ChessFigure fig)
        {
            X = x;
            Y = y;
            ligth = IsWhite;
            FigureOnTile = fig;
        }

        //create copy of tile
        public Tile(Tile original)
        {
            X = original.X;
            Y = original.Y;
            ligth = IsWhite;
            if(original.FigureOnTile != null)
            {
                //create copy of figure
                switch (original.FigureOnTile.Type)
                {
                    case "pawn":
                        {
                            FigureOnTile = new PawnFigure((PawnFigure)original.FigureOnTile);
                            break;
                        }
                    case "bishop":
                        {
                            FigureOnTile = new BishopFigure((BishopFigure)original.FigureOnTile);
                            break;
                        }
                    case "horse":
                        {
                            FigureOnTile = new HorseFigure((HorseFigure)original.FigureOnTile);
                            break;
                        }
                    case "king":
                        {
                            FigureOnTile = new KingFigure((KingFigure)original.FigureOnTile);
                            break;
                        }
                    case "queen":
                        {
                            FigureOnTile = new QueenFigure((QueenFigure)original.FigureOnTile);
                            break;
                        }
                    case "rock":
                        {
                            FigureOnTile = new RockFigure((RockFigure)original.FigureOnTile);
                            break;
                        }
                }
            }
        }

        //get image to drawing tile
        public Bitmap GetImage()
        {
            if(Players.VarOfMove)
            {
                if(Move == 7 && Passant == true)
                {
                    Bitmap sourceImage = Properties.Resources.can;
                    return sourceImage;
                }
                if (Move == 1 || Move == 3 || Move == 4 || Move == 5 || Move == 6)
                {
                    Bitmap sourceImage = Properties.Resources.can;
                    return sourceImage;
                }
                else if (Move == 2)
                {
                    Bitmap sourceImage = Properties.Resources.fight;
                    return sourceImage;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //drawing image of tile
        public void Draw(Graphics graphicsObject)
        {
            if (Players.IndTilePlayer == 0)
            {
                Bitmap sourceImage = IsWhite ? Properties.Resources.lightTile1 : Properties.Resources.darkTile1;
                graphicsObject.DrawImage(sourceImage, tilePoint);
                if (FigureOnTile != null)
                {
                    FigureOnTile.Draw(graphicsObject);
                }
                if (GetImage() != null)
                    graphicsObject.DrawImage(GetImage(), tilePoint);
            }
            else
            {
                Bitmap sourceImage = IsWhite ? Properties.Resources.ligth_tile_01 : Properties.Resources.dark_tile_01;
                graphicsObject.DrawImage(sourceImage, tilePoint);
                if (FigureOnTile != null)
                {
                    FigureOnTile.Draw(graphicsObject);
                }
                if (GetImage() != null)
                    graphicsObject.DrawImage(GetImage(), tilePoint);
            }
            if(Players.CheckUnderAttack)
            {
                if (UnderAttack)
                {
                    graphicsObject.DrawImage(Properties.Resources.fight, tilePoint);
                }
            }   
            if(Selected)
            {
                graphicsObject.DrawImage(Properties.Resources.selected, tilePoint);
            }         
        }

        //return color of tile
        public bool IsWhite
        {
            get
            {
                return tilePoint.X/WorkWithBoard.TILESIZE % 2 == 0 ^ tilePoint.Y/WorkWithBoard.TILESIZE % 2 == 0;
            }
        }

        //transform pawn to queen on last step
        public void Transform()
        {
            if (FigureOnTile != null)
            {
                if (FigureOnTile.Type == "pawn")
                {
                    if (Y == 0 || Y / WorkWithBoard.TILESIZE == 7)
                    {
                        Transform t = new Transform();
                        t.ShowDialog();

                        switch(Players.TransformTo)
                        {
                            case 0:
                                {
                                    FigureOnTile = new QueenFigure(X, Y, FigureOnTile.ColorIsWhite);
                                    break;
                                }
                            case 1:
                                {
                                    FigureOnTile = new RockFigure(X, Y, FigureOnTile.ColorIsWhite);
                                    break;
                                }
                            case 2:
                                {
                                    FigureOnTile = new BishopFigure(X, Y, FigureOnTile.ColorIsWhite);
                                    break;
                                }
                            case 3:
                                {
                                    FigureOnTile = new HorseFigure(X, Y, FigureOnTile.ColorIsWhite);
                                    break;
                                }
                            default:
                                {
                                    FigureOnTile = new QueenFigure(X, Y, FigureOnTile.ColorIsWhite);
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}
