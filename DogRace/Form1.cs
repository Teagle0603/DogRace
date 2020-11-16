using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRace
{
    public partial class Form1 : Form
    {
        Greyhound[] Dogs;
        Guy[] Guys;
        
        public Form1()
        {
            InitializeComponent();


            Dogs = new Greyhound[4];
            Dogs[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPostion = pictureBox2.Left,
                RacetrackLength = raceTrack.Width - pictureBox2.Width,
                Randomizer =new Random()
            };
            Dogs[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPostion = pictureBox3.Left,
                RacetrackLength = raceTrack.Width - pictureBox3.Width,
                Randomizer = new Random()
            };
            Dogs[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPostion = pictureBox4.Left,
                RacetrackLength = raceTrack.Width - pictureBox4.Width,
                Randomizer = new Random()
        };
            Dogs[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPostion = pictureBox5.Left,
                RacetrackLength = raceTrack.Width - pictureBox5.Width,
                Randomizer = new Random()
            };


            Guys = new Guy[3];
            Guys[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };
            Guys[1] = new Guy()
            {
                Name = "Bob",
                Cash = 50,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };
            Guys[2] = new Guy()
            {
                Name = "Al",
                Cash = 50,
                MyRadioButton =alRadioButton,
                MyLabel =alBetLabel
            };

            minimumBetLabel.Text = "Minimum bet: " + betsNumeri.Minimum + "bucks";

            for (int i = 0; i < 3; i++)
            {
                Guys[i].MyRadioButton.Text = Guys[i].Name + " has " + Guys[i].Cash + " bucks";
                Guys[i].MyLabel.Text= Guys[i].Name+" hasn't placed a bet";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Dogs[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Dog #" + (i+1) + " won the race!", "We have a winner!");
                    for (int j = 0; j < 3; j++)
                    {
                        Guys[j].Collect(i + 1);
                    }
                }
            }
        }


        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Al";
        }



        private void betsButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                Guys[0].PlaceBet((int)betsNumeri.Value, (int)dogsNumer.Value);
            }
            else if(bobRadioButton.Checked)
            {
                Guys[1].PlaceBet((int)betsNumeri.Value, (int)dogsNumer.Value);
            }
            else
            {
                Guys[2].PlaceBet((int)betsNumeri.Value, (int)dogsNumer.Value);
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            //groupBox1.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                Dogs[i].TakeStartingPosition();
            }
        }
    }
}
