using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public static class TowersofHanoi
    {

        public static void MoveTower(int discCount, string fromPole, string toPole, string withPole)
        {
            if (discCount >= 1)
            {
                MoveTower(discCount - 1, fromPole, withPole, toPole);
                Move(fromPole, toPole);
                MoveTower(discCount - 1, withPole, toPole, fromPole);
            }
        }

        public static void Move(string fromPole, string toPole)
        {
            Console.WriteLine($"Moving disk from {fromPole} to {toPole}");

        }
    }
}
