using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juuump
{
    public partial class Form1 : Form
    {
        bool goleft, goright, jumping, accumulatescore; // accumulatescore basically flags if 
        int playerspeed = 16;
        int gravityspeed = 19;
        int platformcount = 8;
        int jumpinguntil;
        int scoreheight;

        PictureBox[] platforms = new PictureBox[10];
        
        int[] platformsbouncecount = new int[10];

        PictureBox[] buildings = new PictureBox[17];
        PictureBox[] ceiling = new PictureBox[10];

        private void Heartbeat_Tick(object sender, EventArgs e)
        {


            // update debug label
            if (goleft || goright || jumping)
            {
                labelinfo.Text = "Top: " + (player.Top).ToString() + " Left: " + (player.Left).ToString() + " Right: " + player.Right.ToString() + " Bottom: " +
                player.Bottom.ToString() + "\r\n Height: " + player.Height.ToString() + " Width: " + player.Width.ToString() + "\r\n Speed: " +
                playerspeed.ToString() + " Gravity: " + gravityspeed.ToString() + "\r\nScore: " + scoreheight.ToString();
            }

            // move player location left/right, bounded by left/right form width
            if (goleft && player.Left > 0) { player.Left -= playerspeed; }
            if (goright && player.Right < Width - player.Width + playerspeed) { player.Left += playerspeed; }

            // reset mario image when goright
            if (goright) { player.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("mario"); }


            // platform collision check
            // this checks against the one hardcoded platform
            if (player.Bounds.IntersectsWith(platformRight.Bounds) && Math.Abs(platformRight.Top - player.Bottom) <= Math.Max(playerspeed, gravityspeed) && !jumping)
            {
                jumping = true;
                jumpinguntil = player.Top - Math.Abs(200 - platformRight.Width);
                //player.Top -= Math.Abs(200 - platform.Width);                
                accumulatescore = false;
            }

            // platform collision checks against the platforms created at runtime
            for (int loopcounter = 1; loopcounter <= platformcount; loopcounter++)
            { 
                if (player.Bounds.IntersectsWith(platforms[loopcounter].Bounds) && Math.Abs(player.Bottom - platforms[loopcounter].Top) <= Math.Max(playerspeed, gravityspeed) && !jumping)
                {
                    jumping = true;
                    jumpinguntil = player.Top - Math.Abs(200 - platformRight.Width);
                    player.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("marioJump");
                    player.Refresh();
                    if (platformsbouncecount[loopcounter] == 0)
                    {
                        accumulatescore = true;
                        platforms[loopcounter].Image = Properties.Resources.marioCloud2gray;
                    }
                    else
                    {
                        accumulatescore = false;
                        
                    }
                    platformsbouncecount[loopcounter]++;
                }
            }

            // gravity
            if (player.Bottom < Height - player.Height && !jumping)
            {
                player.Top += gravityspeed;
            }

            if (player.Bottom >= Height - player.Height && !jumping)
            {
                labelinfo.Text = "GAME OVER\r\n\r\nPress 'p' to play again...";
                GameOver();
            }

            // jumping 
            if (jumping)
            {
                // score
                if (accumulatescore) { scoreheight++; }
                

                //increase playerspeed/gravity when reach a specific score
                //switch (scoreheight)
                //{
                //    case 10:
                //    case 20:
                //    case 30:
                //    case 40:
                //    case 50:
                //    case 60:
                //    case 70:

                //        playerspeed++;
                //        gravityspeed++;

                //        break;

                //}


                labelscore.Text = scoreheight.ToString();
                
                // if jumping update player top position by playerspeed * jumpspeed
                player.Top -= Convert.ToInt32(playerspeed * 3.5);
                if (player.Top <= jumpinguntil ) { jumping = false; }



                // buildings fall
                for (int loopcounter = 1; loopcounter < 17; loopcounter++)
                {
                    if(accumulatescore)
                    { 
                        buildings[loopcounter].Top += Convert.ToInt32(playerspeed * 2);
                        if (buildings[loopcounter].Top >= Height - player.Height)
                        {
                            buildings[loopcounter].Top = 50;
                        }
                    }
                }




            }

            Random rand1 = new Random();
            // platforms fall,  randomly recycle platforms when fall off screen
            for (int loopcounter = 1; loopcounter <= platformcount; loopcounter++)
            {

                    platforms[loopcounter].Top += Convert.ToInt32(gravityspeed / 5);
                    if (platforms[loopcounter].Top >= Height - player.Height)
                    {
                        platforms[loopcounter].Top = rand1.Next(80, 140);
                        platforms[loopcounter].Left = rand1.Next(10, 560);
                        platforms[loopcounter].Width = rand1.Next(10, 50);
                        
                        platformsbouncecount[loopcounter] = 0;
                        platforms[loopcounter].Image = Properties.Resources.marioCloud2;
                }

            }




            


        }

        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Use double buffering to reduce flicker.
            //this.SetStyle(
            //    ControlStyles.AllPaintingInWmPaint |
            //    ControlStyles.UserPaint |
            //    ControlStyles.DoubleBuffer,
            //    true);
            //this.UpdateStyles();


        }

 


        private void player_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ResetGame()
        {
            playerspeed = 6;
            gravityspeed = 5;
            platformcount = 8;

            scoreheight = 0;
            player.Top = 100;
            player.Left = 100;
            labelscore.Top = Height - player.Height - 200;

            Random rand1 = new Random();
            // create jump platforms[] creation, random location mostly
            for (int loopcounter = 1; loopcounter <= platformcount; loopcounter++)
            {
                platforms[loopcounter] = new PictureBox
                {
                    Top = 50 * (loopcounter + 2) + 50,
                    Left = rand1.Next(10, 560), //50 * (loopcounter + 2),
                    Width = 30,
                    Height = 10,
                    BorderStyle = BorderStyle.None,
                    Enabled = true,
                    Visible = true,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    
                };
                
                platforms[loopcounter].Image = Properties.Resources.marioCloud2;
                

            }

            this.Controls.AddRange(platforms);


            // create building 1
            buildings[1] = new PictureBox
            {
                Top = 10,
                Left = 10,
                Width = 84,
                Height = 346,
                BorderStyle = BorderStyle.None,
                Enabled = true,
                Visible = true,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            buildings[1].Image = Properties.Resources.building;


            // create buildings
            int buildingtop, buildingleft;
            for (int loopcounter = 2; loopcounter < 17; loopcounter++)
            {
                if (loopcounter <= 8)
                {
                    buildingtop = buildings[1].Top + rand1.Next(10, 200);
                    buildingleft = buildings[loopcounter - 1].Right;
                }
                else // second row of buildings 
                {
                    buildingtop = buildings[loopcounter - 8].Bottom;
                    buildingleft = buildings[loopcounter - 8].Left;
                }


                buildings[loopcounter] = new PictureBox
                {
                    Top = buildingtop,
                    Left = buildingleft,
                    Width = 84,
                    Height = 346,
                    BorderStyle = BorderStyle.None,
                    Enabled = true,
                    Visible = true,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                buildings[loopcounter].Image = Properties.Resources.building;

                switch (rand1.Next(1, 3))
                {
                    case 1:
                        buildings[loopcounter].Image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                        break;
                    case 2:
                        buildings[loopcounter].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                }

                
        }
            this.Controls.AddRange(buildings);



            // create ceiling cloud 1
            ceiling[1] = new PictureBox
            {
                Top = 0,
                Left = 0,
                Width = 100,
                Height = 20,
                BorderStyle = BorderStyle.None,
                Enabled = true,
                Visible = true,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            ceiling[1].Image = Properties.Resources.marioCloud2;


            // create ceiling clouds 2+
            for (int loopcounter = 2; loopcounter < 9; loopcounter++)
            {
                ceiling[loopcounter] = new PictureBox
                {
                    Top = 0,
                    Left = ceiling[loopcounter - 1].Right,
                    Width = 100,
                    Height = 15,
                    BorderStyle = BorderStyle.None,
                    Enabled = true,
                    Visible = true,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                ceiling[loopcounter].Image = Properties.Resources.marioCloud2;

            }
            this.Controls.AddRange(ceiling);

            


            Heartbeat.Start();

        }

        
        private void GameOver()
        {
            for (int loopcounter = 1; loopcounter <= platformcount; loopcounter++)
            {
                this.Controls.Remove(platforms[loopcounter]);
            }
            for (int loopcounter = 1; loopcounter < 17; loopcounter++)
            {
                this.Controls.Remove(buildings[loopcounter]);
            }



            Heartbeat.Stop();
        }





        //controls
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goleft = true;
                

            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == Keys.Space)
            {
                
                jumping = true;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goleft = false;
                player.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("mario"); player.Refresh();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == Keys.Space)
            {
                
                jumping = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
            {
                GameOver();
                ResetGame();
            }

            // pause
            if (e.KeyChar == 'x' || e.KeyChar == 'X')
            {
                if (Heartbeat.Enabled)
                {
                    Heartbeat.Stop();
                }
                else
                {
                    Heartbeat.Start();
                }


            }

        }
    }

}
