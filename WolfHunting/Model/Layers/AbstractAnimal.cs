using System;
using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Utilities;

namespace WolfHunting.Model.Layers
{
    public abstract class AbstractAnimal
    {
        private Dictionary<Motivation, int> _motivations = new();
        private int age;
        private int energy;
        private int viewRadius;
        private Gender Gender { get; set;}
        
        /// TODO:: Find real world values; Use a distribution
        protected void SetupInitialValues()
        {
            var rng = new Random();
            _motivations.Add(Motivation.Hunger, rng.Next(20, 101));
            _motivations.Add(Motivation.Thirst, rng.Next(20, 101));
            _motivations.Add(Motivation.ReproductionUrge, rng.Next(20, 101));
            age = rng.Next(0, 100);
            energy = rng.Next(10, 100);
            viewRadius = rng.Next(1, 10);
            Gender = rng.NextDouble() < 0.5 ? Gender.Female : Gender.Male;
        }

        public void IncreaseEnergy(int amount)
        {
            energy += amount;
        }
        
        public void DecreaseEnergy(int amount)
        {
            energy -= amount;
        }
        
        public void IncreaseHunger(int amount)
        {
            _motivations[Motivation.Hunger] += amount;
        }
        
        public void DecreaseHunger(int amount)
        {
            _motivations[Motivation.Hunger] -= amount;
        }
        
        public void IncreaseThirst(int amount)
        {
            _motivations[Motivation.Thirst] += amount;
        }
        
        public void DecreaseThirst(int amount)
        {
            _motivations[Motivation.Thirst] -= amount;
        }
        
        public void IncreaseReproductionUrge(int amount)
        {
            _motivations[Motivation.ReproductionUrge] += amount;
        }
        
        public void DecreaseReproductionUrge(int amount)
        {
            _motivations[Motivation.ReproductionUrge] -= amount;
        }

        public void IncrementAge()
        {
            age++;
        }

        public abstract void Move();
        public abstract void Mature();
        public abstract void Die();
        public abstract void Reproduce();
        public abstract void Eat();
        public abstract void Drink();

    }
    
    internal enum Motivation {
        Hunger,
        Thirst,
        ReproductionUrge
    }
    
    internal enum Gender
    {
        Male, 
        Female
    }
    
}