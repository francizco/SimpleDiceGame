using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleDiceGame
{
    class Scorer
    {
        // Takes the category, sends the roll to
        // the appropriate method and returns the result
        public int Score(string category, int[] roll)
        {
            switch (category)
            {
                case "Ones":
                    return ScoreFace(roll, 1);
                case "Twos":
                    return ScoreFace(roll, 2);
                case "Threes":
                    return ScoreFace(roll, 3);
                case "Fours":
                    return ScoreFace(roll, 4);
                case "Fives":
                    return ScoreFace(roll, 5);
                case "Sixes":
                    return ScoreFace(roll, 6);
                case "Sevens":
                    return ScoreFace(roll, 7);
                case "Eights":
                    return ScoreFace(roll, 8);
                case "ThreeOfAKind":
                    return XOfAKind(roll, 3);
                case "FourOfAKind":
                    return XOfAKind(roll, 4);
                case "AllOfAKind":
                    return AllOfAKind(roll);
                case "NoneOfAKind":
                    return NoneOfAKind(roll);
                case "FullHouse":
                    return FullHouse(roll);
                case "SmallStraight":
                    return SmallStraight(roll);
                case "LargeStraight":
                    return LargeStraight(roll);
                default:
                    return ScoreChance(roll);
            }
        }

        // Returns a list of categories that score the highest
        // given a roll
        public string[] SuggestedCategories(string[] categories, int[] roll)
        {
            Dictionary<string,int> highScores = new Dictionary<string,int>();

            // Get all scores for the roll
            // Add them to a dictionary unless the score is zero
            for (int i = 0; i < categories.Length; i++)
            {
                int score = Score(categories[i], roll);
                if(score > 0) { highScores.Add(categories[i], score); }
            }

            // Sort dictionary by value and add the high score category
            // to an array
            string[] highScoresList = new string[highScores.Count];
            int j = 0;
            foreach(KeyValuePair<string,int> category in highScores.OrderByDescending(d => d.Value))
            {
                highScoresList[j] = category.Key;
                j += 1;
            }
            return highScoresList;
        }


        // Returns a sorted array of the roll
        private int[] SortDice(int[] roll)
        {
            List<int> dice = new List<int>();

            for (int i = 0; i < roll.Length; i++)
            {
                dice.Add(roll[i]);
            }

            dice.Sort();
            return dice.ToArray();
        }

        // Scores the sum of all ones/twos/threes/.../eights
        private int ScoreFace(int[] roll, int num)
        {
            int result = 0;

            for (int i = 0; i < roll.Length; i++)
            {
                if (roll[i] == num) { result = result + num; }
            }

            return result;
        }

        // Scores Three/Four of a kind
        private int XOfAKind(int[] roll, int num)
        {
            Dictionary<int, int> diceKinds = new Dictionary<int, int>();
            bool hasOfAKind = false;

            // Collect kinds
            for (int i = 0; i < roll.Length; i++)
            {
                if(diceKinds.ContainsKey(roll[i])) { diceKinds[roll[i]] = diceKinds[roll[i]] + 1; }
                else { diceKinds.Add(roll[i], 1); }
                if(diceKinds[roll[i]] >= num) { hasOfAKind = true; }
            }

            if (hasOfAKind && diceKinds.Count != 1) { return ScoreChance(roll); } // 3 or 4 of a kind
            else return 0;
        }

        // Converts a roll to a dictionary where the
        // face and quantity is the key and value
        private Dictionary<int,int> RollToDictionary(int[] roll)
        {
            Dictionary<int, int> diceKinds = new Dictionary<int, int>();

            for (int i = 0; i < roll.Length; i++)
            {
                if (diceKinds.ContainsKey(roll[i])) { diceKinds[roll[i]] = diceKinds[roll[i]] + 1; }
                else { diceKinds.Add(roll[i], 1); }
            }

            return diceKinds;
        }

        // Scores All of a kind
        private int AllOfAKind(int[] roll)
        {
            Dictionary<int, int> diceKinds = RollToDictionary(roll);

            if (diceKinds.Count == 1)
            {
                int key = GetFirstKey(diceKinds);
                if (diceKinds[key] == 5) { return 50; }
                else return 0;
            }

            else return 0;
        }

        // Scores None of a kind
        private int NoneOfAKind(int[] roll)
        {
            Dictionary<int, int> diceKinds = RollToDictionary(roll);

            if (diceKinds.Count == 5) { return 40; }
            else return 0;
        }

        // Scores a full house
        private int FullHouse(int[] roll)
        {
            Dictionary<int, int> diceKinds = RollToDictionary(roll);
            if (diceKinds.Count == 2)
            {
                return 25;
            }
            else { return 0; }
        }

        // Gets the first key in a dictionary
        // Mainly used for a dictionary of size 1
        private int GetFirstKey(Dictionary<int,int> dict)
        {
            foreach (int k in dict.Keys)
            {
                return k;
            }
            return -1;
        }

        // Scores a small straight
        private int SmallStraight(int[] roll)
        {
            roll = SortDice(roll);
            int face = roll[0];
            int fails = 0;

            for(int i = 1; i < 5; i++)
            {
                if (roll[i] != face + 1)
                {
                    fails = fails + 1;
                    if (fails > 1) { return 0; }
                }

                face = roll[i];
            }
            return 30;
        }

        // Scores a large straight
        private int LargeStraight(int[] roll)
        {
            roll = SortDice(roll);
            int face = roll[0];
            int fails = 0;

            for (int i = 1; i < 5; i++)
            {
                if (roll[i] != face + 1)
                {
                    fails = fails + 1;
                    if (fails > 0) { return 0; }
                }

                face = roll[i];
            }
            return 30;
        }

        // Scores the sum of all dice
        private int ScoreChance(int[] roll)
        {
            int result = 0;

            for (int i = 0; i < roll.Length; i++)
            {
                result = result + roll[i];
            }

            return result;
        }
    }
}
