
using System;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Annotations;
using Mars.Interfaces.Environments;
using Mars.Interfaces.Layers;
using WolfHunting.Model.Layers;

namespace WolfHunting.Model
{
    
    public class Rabbit : AbstractAnimal, IAgent<ForestLayer>, IPositionable
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
            SetupInitialValues();
            _forestLayer.RabbitEnvironment.Insert(this);
        }
        



        public void Tick()
        {
            
        }
        
        


        
        


        public Guid ID { get; set; }
        public Position Position { get; set; }


        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Mature()
        {
            IncrementAge();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Reproduce()
        {
            throw new NotImplementedException();
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }
    }


    
    
}