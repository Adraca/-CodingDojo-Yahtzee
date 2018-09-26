using System.Linq;

namespace Yathzee
{
    public class Score
    {
        private readonly DiceThrow _dices;

        public Score(DiceThrow dices)
        {
            _dices = dices;
        }

        public int AcesToSix(int selectedValue)
        {
            return _dices.DiceList
                .Where(d => d == selectedValue)
                .Sum();
        }

        // OBSOLETE
        public int CalculatePairScore(bool isSum)
        {
            var result = _dices.DiceList
                .GroupBy(x => x)
                .Where(p => p.Count() >= 2)
                .Select(p => p.Key)
                .OrderByDescending(x => x);

            return isSum ? result.Sum() * 2 : result.FirstOrDefault() * 2;
        }

        public int ThreeOfAKind()
        {
            if (DoesContainNIdenticalDices(3))
            {
                return _dices.DiceList
                .Sum();
            }

            return 0;
        }

        public int FourOfAKind()
        {
            if (DoesContainNIdenticalDices(4))
            {
                return _dices.DiceList
                .Sum();
            }

            return 0;
        }

        private bool DoesContainNIdenticalDices(int n)
        {
            return _dices.DiceList
                .GroupBy(dice => dice)
                .Any(diceValue => diceValue.Count() >= n);
        }

        private bool DoesContainFull()
        {
            var dicesGrouped = _dices.DiceList
                .GroupBy(dice => dice);

            return dicesGrouped.Count() == 2
                && dicesGrouped.Any(diceValue => diceValue.Count() == 3);
        }

        public int Yahtzee()
        {
            if (DoesContainNIdenticalDices(5))
            {
                return 50;
            }

            return 0;
        }

        public int Full()
        {
            if (DoesContainNIdenticalDices(5) || DoesContainFull())
            {
                return 25;
            }

            return 0;
        }

        public int LargeStraight()
        {
            if (DoesContainLargeStraight())
            {
                return 40;
            }
            return 0;
        }

        private bool DoesContainLargeStraight()
        {
            var dicesGrouped = _dices.DiceList
                .GroupBy(dice => dice);

            return dicesGrouped.Count() == 5
                && (dicesGrouped.Max(diceValue => diceValue.Key == 5)
                   || dicesGrouped.Min(diceValue => diceValue.Key == 2))
                ;
        }
    }
}
