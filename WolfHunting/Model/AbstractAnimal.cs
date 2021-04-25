using System;
using System.Collections.Generic;
using System.Linq;
using Mars.Interfaces.Environments;
using Mars.Interfaces.Layers;

namespace WolfHunting.Model.Agents
{
    public abstract class AbstractAnimal
    {
        private Dictionary<Motivation, int> _motivations = new();
        private int _age;
        private int _energy;
        private int _viewRadius;
        private Gender Gender { get; set;}
        
        
        /// TODO:: Find real world values; Use a distribution; Use constants
        protected void SetupInitialValues(int seed)
        {
            SetupValues(new Random(seed));
        }
        
        protected void SetupInitialValues()
        {
            SetupValues(new Random());
        }

        private void SetupValues(Random rng)
        {
            
            _motivations.Add(Motivation.Hunger, rng.Next(20, 101));
            _motivations.Add(Motivation.Thirst, rng.Next(20, 101));
            _motivations.Add(Motivation.ReproductionUrge, rng.Next(20, 101));
            _age = rng.Next(0, 100);
            _energy = rng.Next(10, 100);
            _viewRadius = rng.Next(1, 10);
            Gender = rng.NextDouble() < 0.5 ? Gender.Female : Gender.Male;
        }

        public void AdjustEnergy(int amount)
        {
            _energy += amount;
        }

        public bool IsAlive()
        {
            return _energy > 0;
        }

        protected void AdjustHunger(int amount)
        {
            _motivations[Motivation.Hunger] += amount;
            _motivations[Motivation.Hunger] = _motivations[Motivation.Hunger] switch
            {
                < 0 => 0,
                > 100 => 100,
                _ => _motivations[Motivation.Hunger]
            };
        }

        protected void AdjustThirst(int amount)
        {
            _motivations[Motivation.Thirst] += amount;
            _motivations[Motivation.Thirst] = _motivations[Motivation.Thirst] switch
            {
                < 0 => 0,
                > 100 => 100,
                _ => _motivations[Motivation.Thirst]
            };
        }

        protected void AdjustReproductionUrge(int amount)
        {
            _motivations[Motivation.ReproductionUrge] += amount;
            _motivations[Motivation.ReproductionUrge] = _motivations[Motivation.ReproductionUrge] switch
            {
                < 0 => 0,
                > 100 => 100,
                _ => _motivations[Motivation.ReproductionUrge]
            };
        }

        /// <summary>
        /// Adjust all motivational values together.
        /// </summary>
        /// <param name="hungerAmount"></param>
        /// <param name="thirstAmount"></param>
        /// <param name="reproductionUrgeAmount"></param>
        public void AdjustAllValues(int hungerAmount, int thirstAmount, int reproductionUrgeAmount)
        {
            AdjustHunger(hungerAmount);
            AdjustThirst(thirstAmount);
            AdjustReproductionUrge(reproductionUrgeAmount);
        }

        protected void IncrementAge()
        {
            _age++;
        }

        public void Mature()
        {
            IncrementAge();
        }



        public Motivation GetHighestMotivation()
        {
            return _motivations.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public int GetMotivationValue(Motivation motivation)
        {
            _motivations.TryGetValue(motivation, out int value);
            return value;
        }

        public abstract void Move();
        public abstract void Die();
        public abstract void Reproduce(int amount);
        public abstract void Eat(int amount);
        public abstract void Drink(int amount);
        
        protected abstract Position FindMotivationalTargetInSight(Motivation motivation, IRasterLayer layer,
            ISpatialGraphEnvironment environment);


    }
    
    public enum Motivation {
        Hunger,
        Thirst,
        ReproductionUrge
    }
    
    public enum Gender
    {
        Male, 
        Female
    }
    
}