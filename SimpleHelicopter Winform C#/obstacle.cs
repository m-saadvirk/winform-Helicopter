using System.Drawing;
using System.Windows.Forms;

namespace SimpleHeli
{
    public class Obstacle
    {
        public PictureBox Pipe { get; set; }
        public int Speed { get; set; } = 8;
        public int ResetX { get; set; }

        public Obstacle(PictureBox pipe, int resetX)
        {
            Pipe = pipe;
            ResetX = resetX;
        }

        public void MoveLeft()
        {
            Pipe.Left -= Speed;
        }

        public void ResetIfOffScreen()
        {
            if (Pipe.Left < -Pipe.Width)
            {
                Pipe.Left = ResetX;
            }
        }

        public Rectangle Bounds => Pipe.Bounds;
    }
}
