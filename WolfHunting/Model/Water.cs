using System;
using Mars.Interfaces.Agents;
using Mars.Interfaces.Environments;

namespace WolfHunting.Model.Agents
{
    public class Water : IPositionable, IEntity
    {
        public Position Position { get; set; }
        public Guid ID { get; set; }
    }
}