using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{


    public enum PoolTypeEnum{
        RECREATION,
        COMPETITION,
        THERMAL,
        KIDS
    }

    class HashSet
    {
        private static Random random = new Random();
        Dictionary<PoolTypeEnum, HashSet<int>> tickets;
        private static bool GetRandomBoolean()
        {
            return random.Next(2) == 1;
        }
        public HashSet()
        {
            tickets = new Dictionary<PoolTypeEnum, HashSet<int>>()
            {
                {PoolTypeEnum.COMPETITION, new HashSet<int>() },
                {PoolTypeEnum.KIDS, new HashSet<int>() },
                {PoolTypeEnum.RECREATION, new HashSet<int>() },
                {PoolTypeEnum.THERMAL, new HashSet<int>() }

            };

            for(int i = 1; i <100; i++)
            {
                foreach(KeyValuePair<PoolTypeEnum,HashSet<int>> type in tickets)
                {
                    if (GetRandomBoolean())
                    {
                        type.Value.Add(i);
                    }
                }


            }

            Console.WriteLine("Number of vistors by pool type");
            foreach(KeyValuePair<PoolTypeEnum,HashSet<int>> type in tickets)
            {
                Console.WriteLine($" - {type.Key.ToString().ToLower()} : {type.Value.Count}");
            }

            PoolTypeEnum maxVisitors = tickets
                .OrderByDescending(t => t.Value.Count)
                .Select(t => t.Key)
                .FirstOrDefault();
            Console.WriteLine($"Pool '{maxVisitors.ToString().ToLower()}' was the most popular.");

            HashSet<int> any = new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);

            any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
            any.UnionWith(tickets[PoolTypeEnum.KIDS]);
            any.UnionWith(tickets[PoolTypeEnum.THERMAL]);
            Console.WriteLine($"{any.Count} people visited at least one pool.");



        }
    }
}
