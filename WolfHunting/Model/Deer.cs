
using System;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Annotations;
using Mars.Interfaces.Environments;
using Mars.Interfaces.Layers;
using WolfHunting.Model.Agents;
using WolfHunting.Model.Layers;

namespace WolfHunting.Model
{
    
    public class Deer : AbstractAnimal, IAgent<ForestLayer>, IPositionable
    {
        [PropertyDescription]
        public UnregisterAgent UnregisterHandle { get; set; }
        
        [PropertyDescription] 
        private bool ReproducibleSpawning { get; set; }
        [PropertyDescription]
        private int Seed { get; set; }
        
        private ForestLayer _forestLayer;

        public void Init(ForestLayer layer)
        {
            _forestLayer = layer;
            Position = _forestLayer.FindRandomPosition(ReproducibleSpawning);
            if (ReproducibleSpawning) SetupInitialValues(Seed);
            else SetupInitialValues();
            _forestLayer.DeerEnvironment.Insert(this);
        }
        



        public void Tick()
        {
            
        }
        

        public Guid ID { get; set; }
        public Position Position { get; set; }


        public override void Move()
        {
            
        }

        public override void Die()
        {
            _forestLayer.DeerEnvironment.Remove(this);
            UnregisterHandle.Invoke(_forestLayer, this);
        }

        public override void Reproduce(int amount)
        {
            AdjustReproductionUrge(amount);
        }

        public override void Eat(int amount)
        {
            AdjustHunger(amount);
        }

        public override void Drink(int amount)
        {
            AdjustThirst(amount);
        }

        protected override Position FindMotivationalTargetInSight(Motivation motivation, IRasterLayer layer, ISpatialGraphEnvironment environment)
        {
            throw new NotImplementedException();
        }
    }


    
    
}