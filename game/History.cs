using System;
using System.Drawing;

namespace ChessGame
{
    [Serializable]
    public class History
    {
        public Point from = new Point();
        public Point to = new Point();

        public History(Point f, Point t)
        {
            from = f;
            to = t;            
        }

        private string GetCell(Point pV)
        {
            return Convert.ToChar(pV.X+65) + "-" + (pV.Y + 1); 
        }

        public override string ToString()
        {
            return "From " + GetCell(from) + " to " + GetCell(to) + ".\n";
        }
    }
}
