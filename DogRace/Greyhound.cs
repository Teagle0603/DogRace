using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogRace
{
    public class Greyhound
    {
        public int StartingPostion;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;
        
        public bool Run()
        {
            Location += Randomizer.Next(1,11) ;
            MyPictureBox.Left = StartingPostion + Location;
            if (MyPictureBox.Left>=RacetrackLength-MyPictureBox.Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            StartingPostion = 0;
            
        }
    }
}
