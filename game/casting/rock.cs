namespace Unit04.Game.Casting
{
    
    public class Rock : Actor
    {
        // set the point value
        private int points = 1;

        public Rock()
        {
        }
            

        ///public int GetScore()
        ///{
           /// return score;
        ///}

        public void SetScore(int score,int points)
        {
            score -= points;
        }
    }
}