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

namespace Flappy_Bird
{
    public partial class Background : Form
    {
        int pipeSpeed = 4;
        int gravity = 7;
        int score = 0;

        public Background()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeDown.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeDown.Left < -150)
            {
                pipeDown.Left = 200;
                score++;
            }
            if(pipeTop.Left < -190)
            {
                pipeTop.Left = 250;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || 
                    flappyBird.Bounds.IntersectsWith(Ground.Bounds) || flappyBird.Top < -25)
            {
                SoundPlayer soundDie = new SoundPlayer(@"C:\Users\brdsl\Desktop\.NET Training\Flappy_Bird\Mobile - Flappy Bird - Everything/sfx_die.wav");
                soundDie.Play();
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 7;
            }
        }

        private void gamekeysisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gamekeysisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                SoundPlayer soundSwoosh = new SoundPlayer(@"C:\Users\brdsl\Desktop\.NET Training\Flappy_Bird\Mobile - Flappy Bird - Everything/sfx_swooshing.wav");
                soundSwoosh.Play();
                gravity = 7;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!";
            score = 0;
        }
    }
}
