using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        #region Private Fields

        private Game _game;

        #endregion

        #region Public Methods

        [TestInitialize]
        public void SetUp()
        {
            _game = new Game();
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            Roll(_game, 0, 20);
            Assert.AreEqual(0, _game.GetScore());
        }

        [TestMethod]
        public void AllRoleWithOnePin_ShouldReturnScoreAs_20_test()
        {
            // Arrange - done in SetUp

            // Action
            Roll(_game, 1, 20);

            // Assertion
            Assert.AreEqual(20, _game.GetScore());
        }

        [TestMethod]
        public void OneSpare_ShouldReturnScoreAs_14_test()
        {
            RoleSpare();
            _game.Roll(2);

            // Total score should be 5 + 5 + 3 (Bonus of next frame) + 3 = 16
            // Role limit should be 17 becuase we have spare here and to calculate the bonus we need next frame score
            // So 17 as limit
            Roll(_game, 0, 17);

            Assert.AreEqual(14, _game.GetScore());
        }

        [TestMethod]
        public void OneStrike_ShouldReturnScoreAs_24_test()
        {
            RoleStrike();
            _game.Roll(3);
            _game.Roll(4);

            // Total score should be 10 + 3 + 4 (Bonus of next frame) + 3 + 4 = 24
            Roll(_game, 0, 16);

            Assert.AreEqual(24, _game.GetScore());
        }

        [TestMethod]
        public void PerfectGame_ShouldReturnScoreAs_300_test()
        {
            Roll(_game, 10, 12);
            Assert.AreEqual(300, _game.GetScore());
        }

        #endregion

        #region Private Methods

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private void RoleStrike()
        {
            _game.Roll(10);
        }

        private void RoleSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        #endregion
    }
}
