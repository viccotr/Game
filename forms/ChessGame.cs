using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class ChessGame : Form
    {
        #region variable
        //now move white
        bool firstPlayerMove = true;
        //check
        bool check = false;
        
        //selected tile point
        Point Selected = new Point(-1,-1);

        //array of board tile's
        Tile[,] tiles;

        //history
        ArrayList history = new ArrayList();
        #endregion variable
        
        public ChessGame()
        {
            InitializeComponent();
        }

        private void ChessGame_Load(object sender, EventArgs e)
        {
            SetImagesOnForm();
            CreateNewGame();
        }
        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Point now = new Point(e.X / WorkWithBoard.TILESIZE, e.Y / WorkWithBoard.TILESIZE);

                if (now.X >= 0 && now.X <= 7 && now.Y >= 0 && now.Y <= 7)
                {
                    if (now != Selected)
                    {
                        if (tiles[now.X, now.Y].Move != 0)
                        {
                            if (WorkWithBoard.MoveOrFight(tiles, Selected, now))
                            {                                
                                history.Add(new History(Selected, now));

                                //transorm pawn to queen
                                tiles[now.X, now.Y].Transform();

                                tbGameLog.Text += "\r\n" + history[history.Count - 1].ToString();

                                ChangePlayer();
                            }
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
                if (Selected != new Point(-1,-1))
                {
                    tiles[Selected.X, Selected.Y].Selected = false;
                    Selected = new Point(-1, -1);
                }

                foreach (Tile t in tiles)
                    t.Move = 0;
                  
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Selected = new Point(e.X/ WorkWithBoard.TILESIZE, e.Y/ WorkWithBoard.TILESIZE);

            if (tiles[Selected.X, Selected.Y].FigureOnTile != null)
            {
                if (tiles[Selected.X, Selected.Y].FigureOnTile.ColorIsWhite == firstPlayerMove)
                {
                    tiles[Selected.X, Selected.Y].Selected = true;
                    tiles[Selected.X, Selected.Y].FigureOnTile.AllVarToMove(tiles);                    
                    WorkWithBoard.UpdateVarOfMove(tiles, tiles[Selected.X, Selected.Y]);
                    
                    pictureBox1.Invalidate();
                }                
            }            
        }

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setings set = new Setings();
            set.ShowDialog();

            SetImagesOnForm();

            pictureBox1.Invalidate();
        }

        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewGame();            
        }

        private void pbNum_Paint(object sender, PaintEventArgs e)
        {
            using (Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                int Y = 0;
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                for (int i = 0; i < 8; i++)
                {
                    Rectangle rect = new Rectangle(0, Y, 30, 75);
                    TextRenderer.DrawText(e.Graphics, (i + 1).ToString(), font2, rect, Color.Black, flags);
                    Y += 75;
                }
            }
        }

        private void pbAbc_Paint(object sender, PaintEventArgs e)
        {
            using (Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                int X = 0;
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                for (int i = 0; i < 8; i++)
                {
                    Rectangle rect = new Rectangle(X, 0, 75, 30);
                    TextRenderer.DrawText(e.Graphics, Convert.ToChar(65 + i).ToString(), font2, rect, Color.Black, flags);
                    X += 75;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObject = e.Graphics;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tiles[i, j].Draw(e.Graphics);
                }
            }
            if(check)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(0, 0, pictureBox1.Width-3, pictureBox1.Height-3));
            }
        }

        private void pbWhoMove_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pbWhoMove.Width, pbWhoMove.Height);

            if (firstPlayerMove)
            {                          
                e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), rect);
            }
        }
                        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveLoadHistory.Save(history);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            CreateNewGame();

            history = SaveLoadHistory.Load();

            foreach(History h in history)
            {
                if(h != null)
                {                    
                    tiles[h.from.X, h.from.Y].FigureOnTile.AllVarToMove(tiles);
                    if(WorkWithBoard.MoveOrFight(tiles, h.from, h.to))
                    {
                        firstPlayerMove = !firstPlayerMove;
                        tiles[h.to.X, h.to.Y].Transform(0);
                    }
                }
            }

            ChangePlayer();

            pictureBox1.Invalidate();
            pbWhoMove.Invalidate();
            Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chess game, created by Viccotr.\r\n2016", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetImagesOnForm()
        {
            if (Players.IndTilePlayer == 0)
            {
                pbNum.Image = Properties.Resources._123_0;
                pbAbc.Image = Properties.Resources.abc_0;
            }
            else
            {
                pbNum.Image = Properties.Resources._123_1;
                pbAbc.Image = Properties.Resources.abc_1;
            }
        }

        private void ChangePlayer()
        {
            firstPlayerMove = !firstPlayerMove;
            
            if (WorkWithBoard.KingUnderAttak(tiles, firstPlayerMove))
            {
                check = true;
                if (firstPlayerMove)
                {
                    labWhoMove.Text = "Now move: White (Check)";
                }
                else
                {
                    labWhoMove.Text = "Now move: Black (Check)";
                }
            }
            else
            {
                check = false;
                if (firstPlayerMove)
                {
                    labWhoMove.Text = "Now move: White";
                }
                else
                {
                    labWhoMove.Text = "Now move: Black";
                }
            }

            WorkWithBoard.EndOfGame(tiles, firstPlayerMove);

            pbWhoMove.Invalidate();
        }

        private void CreateNewGame()
        {
            tiles = WorkWithBoard.CreateBoard();
            tbGameLog.Text = "Welcome to chess.";
            history = new ArrayList();
            firstPlayerMove = true;
            labWhoMove.Text = "Now move: White";

            pictureBox1.Invalidate();
            pbWhoMove.Invalidate();
        }
    }
}