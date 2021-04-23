using System;
using System.Linq;
using Mars.Components.Environments;
using Mars.Components.Layers;
using Mars.Core.Data;
using Mars.Interfaces.Annotations;
using Mars.Interfaces.Environments;
using Mars.Interfaces.Layers;

namespace WolfHunting.Model.Layers
{
    public class ForestLayer : RasterLayer, ISteppedActiveLayer
    {
        [PropertyDescription]
        public int PlantRegrowthPerStep { get; set; }
        [PropertyDescription]
        private int seed { get; set; }
        public SpatialHashEnvironment<Rabbit> RabbitEnvironment { get; set; }
        
        public IAgentManager AgentManager { get; set; }

        


        public override bool InitLayer(LayerInitData layerInitData, RegisterAgent registerAgentHandle, UnregisterAgent unregisterAgentHandle)
        {
            var initiated = base.InitLayer(layerInitData, registerAgentHandle, unregisterAgentHandle);
            RabbitEnvironment = new SpatialHashEnvironment<Rabbit>(Width - 1, Height - 1) {CheckBoundaries = true};

            AgentManager = layerInitData.Container.Resolve<IAgentManager>();
            AgentManager.Spawn<Rabbit, ForestLayer>().ToList();


            return initiated;
        }
        
        public Position FindRandomPosition(bool reproducible)
        {
            var rng = reproducible ? new Random(seed) : new Random();
            return Position.CreatePosition(rng.Next(Width - 1), rng.Next(Height - 1));
        }


        public void Tick()
        {
            throw new System.NotImplementedException();
        }

        public void PreTick()
        {
            throw new System.NotImplementedException();
        }

        public void PostTick()
        {
            throw new System.NotImplementedException();
        }
    }
}