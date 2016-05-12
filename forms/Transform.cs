using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Transform : Form
    {
        //choose for transform pawn
        public Transform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Players.TransformTo = 0;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Players.TransformTo = 1;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Players.TransformTo = 2;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Players.TransformTo = 3;
            Close();
        }
    }
}
