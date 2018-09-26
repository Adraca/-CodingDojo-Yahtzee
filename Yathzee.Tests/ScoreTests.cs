using Xunit;

namespace Yathzee.Tests
{
    public class ScoreTests
    {
        [Fact]
        public void TestsOnesResultOne()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 2, 3, 4, 5);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.AcesToSix(1);

            //Assert
            Assert.Equal(1, obtainedScore);
        }

        [Fact]
        public void TestsOnesResultThree()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 1, 1, 4, 5);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.AcesToSix(1);

            //Assert
            Assert.Equal(3, obtainedScore);
        }

        [Fact]
        public void TestsSixesResultThree()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(6, 6, 6, 6, 6);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.AcesToSix(6);

            //Assert
            Assert.Equal(30, obtainedScore);
        }

        [Fact]
        public void TestHighestPairFoundIsFive()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 4, 4, 5, 5);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.CalculatePairScore(false);

            //Assert
            Assert.Equal(10, obtainedScore);
        }

        [Fact]
        public void TestHighestPairFoundIsThree()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(3, 4, 6, 3, 5);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.CalculatePairScore(false);

            //Assert
            Assert.Equal(6, obtainedScore);
        }

        [Fact]
        public void TestSumPairFoundIsThree()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(3, 4, 1, 3, 1);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.CalculatePairScore(true);

            //Assert
            Assert.Equal(8, obtainedScore);
        }

        [Fact]
        public void TestThree3ShouldBeThreeOfAKind()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(3, 3, 3, 1, 2);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.ThreeOfAKind();

            //Assert
            Assert.Equal(12, obtainedScore);
        }

        [Fact]
        public void TestFour4ShouldBeThreeOfAKind()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(4, 4, 4, 4, 2);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.ThreeOfAKind();

            //Assert
            Assert.Equal(18, obtainedScore);
        }

        [Fact]
        public void TestFour4ShouldBeFourOfAKind()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(4, 4, 4, 4, 2);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.FourOfAKind();

            //Assert
            Assert.Equal(18, obtainedScore);
        }

        [Fact]
        public void TestFive6ShouldBeFourOfAKind()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(6, 6, 6, 6, 6);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.FourOfAKind();

            //Assert
            Assert.Equal(30, obtainedScore);
        }

        [Fact]
        public void TestFive6ShouldBeYahtzee()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(6, 6, 6, 6, 6);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.Yahtzee();

            //Assert
            Assert.Equal(50, obtainedScore);
        }

        [Fact]
        public void TestFive1ShouldBeYahtzee()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 1, 1, 1, 1);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.Yahtzee();

            //Assert
            Assert.Equal(50, obtainedScore);
        }

        [Fact]
        public void TestFive1ShouldBeFull()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 1, 1, 1, 1);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.Full();

            //Assert
            Assert.Equal(25, obtainedScore);
        }

        [Fact]
        public void TestThree1AndTwo2ShouldBeFull()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(1, 1, 1, 2, 2);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.Full();

            //Assert
            Assert.Equal(25, obtainedScore);
        }

        [Fact]
        public void Test2to6ShouldBeLargeStraight()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(2, 6, 4, 5, 3);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.LargeStraight();

            //Assert
            Assert.Equal(40, obtainedScore);
        }

        [Fact]
        public void Test1to5ShouldBeLargeStraight()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(2, 1, 4, 5, 3);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.LargeStraight();

            //Assert
            Assert.Equal(40, obtainedScore);
        }

        [Fact]
        public void TestRandomShouldNotBeLargeStraight()
        {
            //Arrange
            DiceThrow dices = new DiceThrow(2, 1, 1, 5, 3);
            Score score = new Score(dices);

            //Act
            var obtainedScore = score.LargeStraight();

            //Assert
            Assert.Equal(0, obtainedScore);
        }
    }
}

