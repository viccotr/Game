using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public static class WorkWithBoard
    {
        //size of tile
        public const int TILESIZE = 75;

        //find all variant move of enemy and make tiles under attack
        private static void AllVarOfEnemyT(Tile[,] tiles, bool whoMove)
        {
            //reset all tiles from attack
            foreach (Tile c in tiles)
            {
                c.UnderAttack = false;
            }

            foreach (Tile c in tiles)
            {
                if (c.FigureOnTile != null)
                {
                    if (c.FigureOnTile.ColorIsWhite != whoMove)
                    {
                        //find all variant move enemies figure
                        c.FigureOnTile.AllVarToMove(tiles);

                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                if (c.FigureOnTile.allvar[x, y] >= 2)
                                {
                                    tiles[x, y].UnderAttack = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        //create dip copy of board
        private static Tile[,] CreateCopyOfBoard(Tile[,] board)
        {
            Tile[,] copyOfBoard = new Tile[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    copyOfBoard[i, j] = new Tile(board[i, j]);
                }
            }

            return copyOfBoard;
        }

        //move figure
        private static void Move(Tile[,] tilesVal, Point fromVal, Point toVal)
        {
            tilesVal[fromVal.X, fromVal.Y].FigureOnTile.MoveTo(toVal.X * TILESIZE, toVal.Y * TILESIZE);
            tilesVal[toVal.X, toVal.Y].FigureOnTile = tilesVal[fromVal.X, fromVal.Y].FigureOnTile;
            tilesVal[fromVal.X, fromVal.Y].FigureOnTile = null;
        }
        
        //create new game board
        public static Tile[,] CreateBoard()
        {
            Tile[,] tiles = new Tile[8, 8];
            bool colorOfFigure = true;

            for (int rowY = 0; rowY <= 7 * TILESIZE; rowY += TILESIZE)
            {
                if (rowY > 5 * TILESIZE)
                    colorOfFigure = false;
                
                for (int columnX = 0; columnX <= 7 * TILESIZE; columnX += TILESIZE)
                {
                    if (rowY == 0 || rowY == 7 * TILESIZE)
                    {
                        switch (columnX)
                        {
                            case 0:
                            case 7 * TILESIZE:
                                RockFigure rf = new RockFigure(columnX, rowY, colorOfFigure);
                                tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, rf);
                                break;

                            case 1 * TILESIZE:
                            case 6 * TILESIZE:
                                HorseFigure hf = new HorseFigure(columnX, rowY, colorOfFigure);
                                tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, hf);
                                break;

                            case 2 * TILESIZE:
                            case 5 * TILESIZE:
                                BishopFigure bf = new BishopFigure(columnX, rowY, colorOfFigure);
                                tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, bf);
                                break;

                            case 3 * TILESIZE:
                                KingFigure kf = new KingFigure(columnX, rowY, colorOfFigure);
                                tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, kf);
                                break;

                            case 4 * TILESIZE:
                                QueenFigure qf = new QueenFigure(columnX, rowY, colorOfFigure);
                                tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, qf);
                                break;
                        }
                    }
                    else if (rowY == 1 * TILESIZE || rowY == 6 * TILESIZE)
                    {
                        PawnFigure pf = new PawnFigure(columnX, rowY, colorOfFigure);
                        tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, pf);
                    }
                    else if (rowY == 2 * TILESIZE || rowY == 3 * TILESIZE || rowY == 4 * TILESIZE || rowY == 5 * TILESIZE)
                    {
                        tiles[columnX / TILESIZE, rowY / TILESIZE] = new Tile(columnX, rowY, null);
                    }
                }
            }
            return tiles;
        }
        
        //move and figth
        public static bool MoveOrFight(Tile[,] tilesVal, Point fromVal, Point toVal)
        {
            if (tilesVal[toVal.X, toVal.Y].Move == 1 || tilesVal[toVal.X, toVal.Y].Move == 2)
            {
                if (tilesVal[toVal.X, toVal.Y].FigureOnTile != null)
                {
                    if (tilesVal[toVal.X, toVal.Y].FigureOnTile.Type == "king")
                    {
                        //can't kill king
                        return false;
                    }
                    else
                    {
                        Move(tilesVal, fromVal, toVal);
                    }
                }
                else
                {
                    Move(tilesVal, fromVal, toVal);
                }
                //check en passant
                if (tilesVal[toVal.X, toVal.Y].FigureOnTile.Type == "pawn")
                {
                    if ((fromVal.Y - toVal.Y) == 2)
                    {
                        if (tilesVal[fromVal.X, fromVal.Y - 1].Move == 7)
                        {
                            tilesVal[fromVal.X, fromVal.Y - 1].Passant = true;
                        }
                    }
                    if ((toVal.Y - fromVal.Y) == 2)
                    {
                        if (tilesVal[fromVal.X, fromVal.Y + 1].Move == 7)
                        {
                            tilesVal[fromVal.X, fromVal.Y - 1].Passant = true;
                        }
                    }
                }
            }

            //short castling to white
            if (tilesVal[toVal.X, toVal.Y].Move == 3)
            {
                Move(tilesVal, new Point(0, 0), new Point(2, 0));
                Move(tilesVal, new Point(3, 0), new Point(1, 0));
            }
            //long castling to white
            if (tilesVal[toVal.X, toVal.Y].Move == 4)
            {
                Move(tilesVal, new Point(7, 0), new Point(4, 0));
                Move(tilesVal, new Point(3, 0), new Point(5, 0));
            }
            //short castling to black
            if (tilesVal[toVal.X, toVal.Y].Move == 5)
            {
                Move(tilesVal, new Point(0, 7), new Point(2, 7));
                Move(tilesVal, new Point(3, 7), new Point(1, 7));
            }
            //long castling to black
            if (tilesVal[toVal.X, toVal.Y].Move == 6)
            {
                Move(tilesVal, new Point(7, 7), new Point(4, 7));
                Move(tilesVal, new Point(3, 7), new Point(5, 7));
            }

            //En passant
            if (tilesVal[toVal.X, toVal.Y].Move == 7 && tilesVal[toVal.X, toVal.Y].Passant == true)
            {
                if (tilesVal[fromVal.X, fromVal.Y].FigureOnTile.ColorIsWhite)
                {
                    if (tilesVal[toVal.X, toVal.Y - 1].FigureOnTile != null)
                    {
                        if (tilesVal[toVal.X, toVal.Y - 1].FigureOnTile.Type == "pawn")
                        {
                            if (tilesVal[toVal.X, toVal.Y - 1].FigureOnTile.ColorIsWhite != tilesVal[fromVal.X, fromVal.Y].FigureOnTile.ColorIsWhite)
                            {
                                Move(tilesVal, fromVal, toVal);
                                
                                tilesVal[toVal.X, toVal.Y - 1].FigureOnTile = null;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else
                {
                    if (tilesVal[toVal.X, toVal.Y + 1].FigureOnTile != null)
                    {
                        if (tilesVal[toVal.X, toVal.Y + 1].FigureOnTile.Type == "pawn")
                        {
                            if (tilesVal[toVal.X, toVal.Y + 1].FigureOnTile.ColorIsWhite != tilesVal[fromVal.X, fromVal.Y].FigureOnTile.ColorIsWhite)
                            {
                                Move(tilesVal, fromVal, toVal);

                                tilesVal[toVal.X, toVal.Y + 1].FigureOnTile = null;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            foreach (Tile c in tilesVal)
            {
                if (tilesVal[toVal.X, toVal.Y].FigureOnTile != null)
                {
                    if (tilesVal[toVal.X, toVal.Y].FigureOnTile.ColorIsWhite)
                    {
                        if (c.Y/TILESIZE == 2)
                            c.Passant = false;
                    }
                    else
                    {
                        if (c.Y/TILESIZE == 5)
                            c.Passant = false;
                    }
                }
            }

            //checking tile to passant
            if (tilesVal[toVal.X, toVal.Y].FigureOnTile != null)
            {
                if(tilesVal[toVal.X, toVal.Y].FigureOnTile.Type == "pawn")
                {
                    if(tilesVal[toVal.X, toVal.Y].FigureOnTile.ColorIsWhite)
                    {
                        if(toVal.Y - fromVal.Y == 2)
                        {
                            tilesVal[toVal.X, toVal.Y - 1].Passant = true;
                        }
                    }
                    else
                    {
                        if (fromVal.Y - toVal.Y == 2)
                        {
                            tilesVal[toVal.X, toVal.Y + 1].Passant = true;                            
                        }
                    }
                }
            }
            //if figure don't move
            if (tilesVal[fromVal.X, fromVal.Y].FigureOnTile != null)
                return false;
                              
            return true;                              
        }

        //checking king under attack
        public static bool KingUnderAttak(Tile[,] tilesVal, bool firstPlayerMove)
        {
            AllVarOfEnemyT(tilesVal, firstPlayerMove);

            foreach (Tile c in tilesVal)
            {
                if(c.FigureOnTile != null)
                {
                    if (c.FigureOnTile.Type == "king")
                    {
                        if (c.FigureOnTile.ColorIsWhite == firstPlayerMove)
                        {
                            if (c.UnderAttack)
                            {
                                return true;
                            }
                        }
                    }
                }
            }            
            return false;
        }
        
        //if king under attack find variant of move
        public static void UpdateVarOfMove(Tile[,] tilesVal, Tile nowOnTile)
        {
            nowOnTile.FigureOnTile.AllVarToMove(tilesVal);

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (nowOnTile.FigureOnTile.allvar[x, y] >= 1)
                    {
                        /*  checking variant of move after
                        creting copy of board and movig figure
                        at end delete copy  */
                        Tile[,] copy = CreateCopyOfBoard(tilesVal);

                        Point from = new Point(nowOnTile.X / 75, nowOnTile.Y / 75);
                        Point to = new Point(x, y);

                        copy[from.X, from.Y].FigureOnTile.AllVarToMove(copy);

                        if(MoveOrFight(copy, from, to))
                        {
                            if(KingUnderAttak(copy, copy[to.X, to.Y].FigureOnTile.ColorIsWhite))
                            {
                                tilesVal[x, y].Move = 0;
                                nowOnTile.FigureOnTile.allvar[x, y] = 0;
                            }
                        }
                        copy = null;
                    }
                }
            }
        }

        //check end of game
        public static void EndOfGame(Tile[,] tilesVal, bool firstPlayerMove)
        {            
            if(KingUnderAttak(tilesVal, firstPlayerMove))
            {
                int i = 0;
                foreach (Tile c in tilesVal)
                {
                    if (c.FigureOnTile != null)
                    {
                        if (c.FigureOnTile.ColorIsWhite == firstPlayerMove)
                        {
                            c.FigureOnTile.AllVarToMove(tilesVal);

                            UpdateVarOfMove(tilesVal, c);

                            foreach (Tile cel in tilesVal)
                            {
                                if (cel.Move >= 1)
                                    i++;
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    if (firstPlayerMove)
                    {
                        MessageBox.Show("WINER: Black");
                    }
                    else
                    {
                        MessageBox.Show("WINER: White");
                    }
                }                
            }
        }
    }
}