using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
    public partial class Setings : Form
    {
        ArrayList tiles = new ArrayList();
        ArrayList figures = new ArrayList();
        
        byte til = 0;
        byte fig = 0;
        
        public Setings()
        {
            InitializeComponent();
        }

        private void Setings_Load(object sender, EventArgs e)
        {
            til = Players.IndTilePlayer;
            fig = Players.IndFigImPlayer;

            tiles.Add(Properties.Resources.pres1);
            tiles.Add(Properties.Resources.pres2);
            figures.Add(Properties.Resources.fpres1);
            figures.Add(Properties.Resources.fpres2);

            ch_UnderAttack.Checked = Players.CheckUnderAttack;
            ch_varOfMove.Checked = Players.VarOfMove;

            pb_figImages.Invalidate();
            pb_tileImages.Invalidate();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Players.IndTilePlayer = til;
            Players.IndFigImPlayer = fig;
            
            Players.CheckUnderAttack = ch_UnderAttack.Checked;
            Players.VarOfMove = ch_varOfMove.Checked;            
            //save
            Close();
        }

        private void btn_NextTile_Click(object sender, EventArgs e)
        {
            til = ChangeIndex(til, true);
            pb_tileImages.Invalidate();
        }

        private void btn_PreviousTile_Click(object sender, EventArgs e)
        {
            til = ChangeIndex(til, false);
            pb_tileImages.Invalidate();
        }

        private void btn_NextFig_Click(object sender, EventArgs e)
        {
            fig = ChangeIndex(fig, true);
            pb_figImages.Invalidate();
        }

        private void btn_PreviousFig_Click(object sender, EventArgs e)
        {
            fig = ChangeIndex(fig, false);
            pb_figImages.Invalidate();
        }
        
        private byte ChangeIndex(byte index, bool plus)
        {
            if(plus)
            {
                if (index == 0)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
            else
            {
                if (index == 1)
                {
                    index--;
                }
                else
                {
                    index = 1;
                }
            }

            return index;
        }

        private void pb_figImages_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage((Bitmap)figures[fig], new Rectangle(0, 0, 75, 75));
        }

        private void pb_tileImages_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage((Bitmap)tiles[til], new Rectangle(0, 0, 75, 75));            
        }
    }
}
