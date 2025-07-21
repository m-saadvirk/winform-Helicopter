using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SimpleHeli
{
    public partial class Form1 : Form
    {
        int score = 0;

        Player player;
        Obstacle topPipe;
        Obstacle bottomPipe;

        SoundPlayer flySound = new SoundPlayer("sounds1/fly.wav");
        SoundPlayer hitSound = new SoundPlayer("sounds1/hit.wav");

        public Form1()
        {
            InitializeComponent();

            player = new Player(helicopter);
            topPipe = new Obstacle(pipeTop, 950);
            bottomPipe = new Obstacle(pipeBottom, 800);
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            score++;
            player.ApplyGravity();
            topPipe.MoveLeft();
            bottomPipe.MoveLeft();

            topPipe.ResetIfOffScreen();
            bottomPipe.ResetIfOffScreen();

            scoreText.Text = "Score: " + score;

            if (player.Bounds.IntersectsWith(topPipe.Bounds) ||
                player.Bounds.IntersectsWith(bottomPipe.Bounds) ||
                player.IsOutOfBounds(10, 280))
            {
                player.SetVisible(false);

                crashHeli.Location = player.Location;
                crashHeli.Visible = true;

                gameTimer.Stop();
                hitSound.Play();
                MessageBox.Show("Game Over!\nYour Score: " + score);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                player.MoveUp(8);
                flySound.Play();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                player.Gravity = 7;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optional: Stop the timer if it's running
            if (gameTimer.Enabled)
            {
                gameTimer.Stop();
            }

            // Optional: Stop sounds
            flySound.Stop();
            hitSound.Stop();

            // Confirm exit
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
