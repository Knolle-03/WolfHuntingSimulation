using System;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Environments;
using Mars.Interfaces.Layers;
using WolfHunting.Model.Agents;
using WolfHunting.Model.Layers;

namespace WolfHunting.Model
{
    public class Wolf : AbstractAnimal, IAgent<ForestLayer>, IPositionable
    {
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Reproduce(int amount)
        {
            throw new NotImplementedException();
        }

        public override void Eat(int amount)
        {
            throw new NotImplementedException();
        }

        public override void Drink(int amount)
        {
            throw new NotImplementedException();
        }

        protected override Position FindMotivationalTargetInSight(Motivation motivation, IRasterLayer layer, ISpatialGraphEnvironment environment)
        {
            throw new NotImplementedException();
        }

        public void Init(ForestLayer layer)
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public Guid ID { get; set; }
        public Position Position { get; set; }
    }
}