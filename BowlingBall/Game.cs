
namespace BowlingBall
{
    public class Game
    {
        #region Private Fields

        private int[] _rolls;
        private int _currentRoll = 0;

        #endregion

        #region Public Constructor

        public Game()
        {
            // for 10th frame we can get more rolls we have strike or spare
            _rolls = new int[21];
        }

        #endregion

        #region Public Methods

        public int GetScore()
        {
            var score = 0;
            int roleIndex = 0;
            // consider frame which has two rolls
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roleIndex))
                {
                    score += StrikeBonus(roleIndex);
                    roleIndex++;
                }
                else if (IsSpare(roleIndex))
                {
                    score += 10 + SpareBonus(roleIndex);
                    roleIndex += 2;
                }
                else
                {
                    score += BallSum(roleIndex);
                    roleIndex += 2;
                }

            }
            return score;
        }

        #endregion

        #region Private Methods

        private int BallSum(int roleIndex)
        {
            return _rolls[roleIndex] + _rolls[roleIndex + 1];
        }

        private int SpareBonus(int roleIndex)
        {
            return _rolls[roleIndex + 2];
        }

        private int StrikeBonus(int roleIndex)
        {
            return 10 + _rolls[roleIndex + 1] + _rolls[roleIndex + 2];
        }

        private bool IsStrike(int roleIndex)
        {
            return _rolls[roleIndex] == 10;
        }

        private bool IsSpare(int roleIndex)
        {
            return _rolls[roleIndex] + _rolls[roleIndex + 1] == 10;
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        #endregion
    }
}
