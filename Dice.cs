using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDiceGame
{
    class Dice
    {
        private int faces;
        private int quantity;
        private Random rand;

        // Creates only one die
        public Dice(int size)
        {
            faces = size;
            quantity = 1;
            rand = new Random();
        }

        // Specify number of dice to create
        public Dice(int size, int total)
        {
            if (size > 0) { faces = size; }
            else { size = 6; }

            if (total > 0) { quantity = total; }
            else { total = 1; }
            rand = new Random();
        }

        // Single roll of a single die
        public int Roll
        {
            get { return rand.Next(1, faces + 1); }
        }

        // Roll all dice and return list of results
        public int[] RollAll()
        {
            int[] results = new int[quantity];

            for (int i = 0; i < quantity; i++)
            {
                results[i] = rand.Next(1, faces + 1);
            }

            return results;
        }
    }
}
