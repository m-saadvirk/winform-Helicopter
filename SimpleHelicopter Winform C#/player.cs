using System.Drawing;
using System.Windows.Forms;

namespace SimpleHeli
{
    public class Player
    {
        public PictureBox Helicopter { get; set; }
        public int Gravity { get; set; } = 8;

        public Player(PictureBox helicopter)
        {
            Helicopter = helicopter;
        }

        public void MoveUp(int strength)
        {
            Helicopter.Top -= strength;
        }

        public void ApplyGravity()
        {
            Helicopter.Top += Gravity;
        }

        public bool IsOutOfBounds(int minY, int maxY)
        {
            return Helicopter.Top < minY || Helicopter.Top > maxY;
        }

        public Rectangle Bounds => Helicopter.Bounds;

        public Point Location => Helicopter.Location;

        public void SetVisible(bool visible)
        {
            Helicopter.Visible = visible;
        }

        public void SetLocation(Point location)
        {
            Helicopter.Location = location;
        }
    }
}
