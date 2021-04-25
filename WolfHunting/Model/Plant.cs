using System;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Environments;
using WolfHunting.Model.Layers;

namespace WolfHunting.Model.Agents
{
    public class Plant : IPositionable, IAgent<ForestLayer>
    {
        public Position Position { get; set; }
        public Guid ID { get; set; }
        
        
        public void Init(ForestLayer layer)
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}