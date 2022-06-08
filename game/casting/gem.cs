using System.Collections.Generic;
namespace Unit04.Game.Casting
{
    public class Gem : Actor {

        private int points = 1;
        public Gem() {

        }

        //we might need to get the start possition of the gem here (might already be done in a different class)

        //if gems posiitoin is greater than {coordinates of the bottom of the screen}
        //then have the gem go down every gameloop (tick)

        // set the point value

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int score,int points)
        {
            score += points;
        }






    }


}