using System.Collections.Generic;

namespace Yathzee
{
    public class DiceThrow
    {
        public IList<int> DiceList { get; set; }

        public DiceThrow(int firstDice, int secondDice, int thirdDice, int fourthDice, int fifthDice)
        {
            DiceList = new List<int>(5)
            {
                firstDice,
                secondDice,
                thirdDice,
                fourthDice,
                fifthDice
            };
        }
    }
}
