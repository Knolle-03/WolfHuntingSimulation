using System;
using System.Collections.Generic;
using System.Linq;
using WolfHunting.Model.Layers;

namespace WolfHunting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Motivation, int> _motivattions = new Dictionary<Motivation, int>()
            {
                {Motivation.Thirst, 32}, {Motivation.Hunger, 32}, {Motivation.ReproductionUrge, 32}, {Motivation.Sleep, 33}
            };
            var max = _motivattions.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine(max);
            
            
            if (_motivattions.TryGetValue(Motivation.Hunger, out var value))
            {
                Console.WriteLine(value);
            }

            

        }
    }
}
